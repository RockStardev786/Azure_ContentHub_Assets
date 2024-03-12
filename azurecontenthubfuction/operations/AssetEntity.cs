using Stylelabs.M.Framework.Essentials.LoadOptions;
using Stylelabs.M.Sdk.Contracts.Base;
using Stylelabs.M.Sdk.Models.Jobs;
using System;
using System.Threading.Tasks;

namespace Azure.Content.Hub.Fuction
{
    public class AssetEntity : IAssetEntity
    {
        // Create Asset entity...
        public async Task<long> CreateAssetEntity(string title, string url)
        {
            IEntity assetEntity = await MConnector.Client.EntityFactory.CreateAsync("M.Asset", CultureLoadOption.Default).ConfigureAwait(false);

            assetEntity.SetPropertyValue("Title", title);

            long assetId = await MConnector.Client.Entities.SaveAsync(assetEntity).ConfigureAwait(false);

            // Create fetch job to link asset to entity...
            var webFetchJob = new WebFetchJobRequest(title, assetId)
            {
                Urls = new[] { new Uri(url) }
            };
            long jobId = await MConnector.Client.Jobs.CreateFetchJobAsync(webFetchJob);
            return assetId;
        }
    }
}
