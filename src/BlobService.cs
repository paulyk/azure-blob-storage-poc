using Azure.Storage.Blobs;

namespace AzBlobApiPOC {
    public class BlobService {

        readonly BlobServiceClient blobServiceClient;
        public BlobService(string connection) {
            blobServiceClient = new BlobServiceClient(connection);
        } 

        

    }
}