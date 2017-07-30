using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabs.DataModels;

namespace Tabs
{
    class AzureManager
    {
        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<Phase1Module2table> CubeTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://phase22.azurewebsites.net");
            this.CubeTable = this.client.GetTable<Phase1Module2table>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task<List<Phase1Module2table>> GetCubeInformation()
        {
            return await this.CubeTable.ToListAsync();
        }

        public async Task PostCubeInformation(Phase1Module2table CubeModel)
        {
            await this.CubeTable.InsertAsync(CubeModel);
        }
    }
}
