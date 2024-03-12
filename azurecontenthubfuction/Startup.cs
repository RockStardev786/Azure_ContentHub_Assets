using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
[assembly:FunctionsStartup(typeof(Azure.Content.Hub.Fuction.Startup))]
namespace Azure.Content.Hub.Fuction
{
  public  class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IAssetEntity, AssetEntity>();
        }
    }
}
