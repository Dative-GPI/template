using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using Azure.Storage.Blobs;

using XXXXX.Context.Core.Abstractions;

namespace XXXXX.Context.Core.Services
{
    public class BinaryStorage : IBinaryStorage
    {
        const string FOLDER_NAME = "XXXXX-binary";
        private string _connectionString;

        public BinaryStorage(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AZURE_STORAGE");
        }

        public async Task<byte[]> Get(string path)
        {
            var client = await Init();

            var blob = client.GetBlobClient(path);

            var blobResult = await blob.DownloadContentAsync();

            return blobResult.Value.Content.ToArray();
        }

        public async Task Store(string path, byte[] data)
        {
            var client = await Init();

            BlobClient blob = client.GetBlobClient(path);

            var exist = await blob.ExistsAsync();

            if (!exist)
            {
                using var stream = new MemoryStream(data);
                await blob.UploadAsync(stream);
            }
        }

        private async Task<BlobContainerClient> Init()
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(FOLDER_NAME);

            await containerClient.CreateIfNotExistsAsync();

            return containerClient;
        }
    }
}