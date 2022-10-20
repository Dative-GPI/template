namespace XXXXX.Context.Core.Models
{
    public class Image
    {
        public byte[] Data { get; set; }
        public string BlurHash { get; set; }
        public string Path { get; set; }
        public string ThumbnailPath { get; set; }
        public byte[] Thumbnail { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}