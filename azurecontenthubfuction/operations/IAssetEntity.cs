using Stylelabs.M.Framework.Essentials.LoadOptions;
using Stylelabs.M.Sdk.Contracts.Base;
using Stylelabs.M.Sdk.Models.Jobs;
using System;
using System.Threading.Tasks;

namespace Azure.Content.Hub.Fuction
{
    public interface IAssetEntity
    {
        // Create Asset entity...
        public  Task<long> CreateAssetEntity(string title, string url);
    }
}
