using Azure.Storage.Blobs;

namespace AzBlobApiPOC {
    public class BlobHeler {

        readonly BlobServiceClient blobServiceClient;
        public BlobHeler(string connection) {
            blobServiceClient = new BlobServiceClient(connection);
        } 

        

    }
}