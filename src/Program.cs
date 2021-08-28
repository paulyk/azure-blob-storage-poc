using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace AzBlobApiPOC {


    class Program {
        static void Main(string[] args) {
            var config = GetConfig();
            
            BlobService blobService = new(config["AZURE_STORGAE_CONNECTION"]);

        }

        static IConfiguration GetConfig() {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
