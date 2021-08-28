using System;
using System.Data.SqlTypes;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using Microsoft.VisualBasic;

namespace AzBlobApiPOC {
    public class Test {

        readonly BlobService blobService = null;
        public Test(string connection) {
            blobService = new BlobService(connection);
        }

        public void EncodingTest() {
            var text = "hello dude";
            var buffer = Encoding.UTF8.GetBytes(text.ToCharArray());
            var text2 = Encoding.UTF8.GetString(buffer);

            if (text == text2) {
                Console.WriteLine("Equal");
            }
        }

        public void MemoryStreamTest() {
            // Encoding is the process of transforming a set of Unicode characters into a sequence of bytes
            var buffer = Encoding.UTF8.GetBytes("Hello dudes".ToCharArray());
            var memStream = new MemoryStream(buffer.Length);
            memStream.Write(buffer);


            var outBuf = new Byte[buffer.Length];
            memStream.Position = 0;
            memStream.Read(outBuf);
            var text = Encoding.UTF8.GetString(outBuf);

            Console.WriteLine(text);
        }

        public async Task AddBlobTest() {
            string containerName = "test-container";
            var blobName = "file1.txt";
            var text = "The shortnesss of life";
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(text.ToCharArray()));
            stream.Position = 0;
            await blobService.AddBlob(containerName, blobName, stream);
            // 
        }
    }
}