using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AzBlobApiPOC {
    public class BlobService {

        readonly BlobServiceClient blobServiceClient;
        public BlobService(string connection) {
            blobServiceClient = new BlobServiceClient(connection);
        }

        public async Task AddBlob(string containerName, string blobName, Stream stream) {
            var blobContainerClient = await GetBlobContainerClient(containerName);            
            BlobClient blobClient = blobContainerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(stream, overwrite: true);            
        }

        private async Task<BlobContainerClient> GetBlobContainerClient(string containerName, bool? createIfNotExist = false) {
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            if (!await blobContainerClient.ExistsAsync()) {
                await blobContainerClient.CreateAsync();
            }
            return blobContainerClient;
        }  
    }
}