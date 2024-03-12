using System;
using System.IO;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Azure.Content.Hub.Fuction
{
    [StorageAccount("AzureWebJobsStorage")]
    public class UploadAssetsInContentHub
    {
        private readonly IAssetEntity AssetEntity;

        public UploadAssetsInContentHub(IAssetEntity assetEntity)
        {
            AssetEntity = assetEntity;
        }

        [FunctionName("UploadAssetsInContentHub")]
        public void Run([BlobTrigger("sitecoretestdata/{name}")]Stream myBlob, string name, ILogger log)
        {
            try
            {
                log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n time:{System.DateTime.UtcNow}");
                string url = AppSettings.AzureUrl + name;

                var id = AssetEntity.CreateAssetEntity(name.Split("/").Last(), url);

                log.LogInformation($"\n Asset created in Content hub with Id:{id.Result} \n time:{System.DateTime.UtcNow}");
            }
            catch(Exception ex)
            {
                log.LogError(ex.Message);
            }
        }
    }
}
