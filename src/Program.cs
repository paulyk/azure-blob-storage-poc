using System;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AzBlobApiPOC {


    class Program {
        static async Task Main(string[] args) {
            var config = GetConfig();            
            Test test = new(config["AZURE_STORGAE_CONNECTION"]);
            test.EncodingTest();
            test.MemoryStreamTest();
            await test.AddBlobTest();
        }



        static IConfiguration GetConfig() {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
