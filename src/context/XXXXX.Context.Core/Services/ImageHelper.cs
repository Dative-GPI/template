using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Blurhash.ImageSharp;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

using XXXXX.Context.Core.Abstractions;
using XXXXX.Context.Core.Configurations;
using SixLabors.ImageSharp.PixelFormats;

namespace XXXXX.Context.Core.Services
{
    public class ImageHelper : IImageHelper
    {
        private Encoder _encoder;
        private MD5 _md5;
        private ImageConfiguration _config;
        private ILogger<ImageHelper> _logger;

        public ImageHelper(IOptions<ImageConfiguration> options, ILogger<ImageHelper> logger)
        {
            _encoder = new Encoder();
            _md5 = MD5.Create();

            _config = options.Value;
            _logger = logger;
        }

        public async Task<Models.Image> Compute(byte[] data, int maxSize)
        {
            using var image = SixLabors.ImageSharp.Image.Load(data);

            using var dataStream = new MemoryStream();
            using var thumbnailStream = new MemoryStream();
            using var jpgStream = new MemoryStream();


            var thumbnail = image.Clone(
                x => x.Resize(new ResizeOptions()
                {
                    Size = new Size(90),
                    Mode = ResizeMode.Min
                })
            );

            var raw = image.Clone(
                x => x.Resize(new ResizeOptions()
                {
                    Size = new Size(maxSize),
                    Mode = ResizeMode.Min
                })
            );

            await raw.Clone().SaveAsJpegAsync(jpgStream);
            jpgStream.Position = 0;

            var jpg = SixLabors.ImageSharp.Image.Load<Rgb24>(jpgStream);

            var blurHash = _encoder.Encode(jpg, 4, 3);

            await raw.SaveAsPngAsync(dataStream);
            await thumbnail.SaveAsPngAsync(thumbnailStream);

            var png = dataStream.ToArray();
            var thumb = thumbnailStream.ToArray();

            var path = await ComputePath(png);

            var result = new Models.Image()
            {
                BlurHash = blurHash,
                Data = png,
                Thumbnail = thumb,
                Path = Path.Combine(_config.RawFolder, path),
                ThumbnailPath = Path.Combine(_config.ThumbnailFolder, path),
                Width = image.Bounds().Width,
                Height = image.Bounds().Height
            };

            return result;
        }

        public async Task<string> ComputePath(byte[] data)
        {
            using var memoryStream = new MemoryStream(data);

            var hash = await _md5.ComputeHashAsync(memoryStream);

            var path = string.Join("/", hash
                // on prend le hash qu'on affiche en valeur hexa (2 char)
                .Select((x, i) => new { Value = x.ToString("X2"), Index = i })
                // on group les morceaux de string par 4 (8 char)
                .GroupBy(i => i.Index / 4)
                // on les merge et on les join avec un "/"
                .Select(g => String.Concat(
                    g.Select(i => i.Value))
                ));

            return path;
        }
    }
}