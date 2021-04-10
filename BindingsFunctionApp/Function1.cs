using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.IO;

namespace BindingsFunctionApp
{
    public static class Function1
    {
        [FunctionName("Function1")]
        [return: Queue("az-func-logs")]
        public static string Run(
            [BlobTrigger("az-func-blob/{name}")]Stream intputBlob,
            string name, ILogger log)
        {
            var message = $"C# Blob trigger function Processed blob\n Name:{name} \n Size: {intputBlob.Length} Bytes";
            log.LogInformation(message);
            return message;
        }
    }
}
