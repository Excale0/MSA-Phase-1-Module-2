using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabs.DataModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AzureTables : ContentPage
    {
        MobileServiceClient client = AzureManager.AzureManagerInstance.AzureClient;
        public AzureTables()
        {
            InitializeComponent();
        }

        async void Handle_ClickedAsync(object messenger, System.EventArgs e)
        {
            List<Phase1Module2table> Cubeinfo = await AzureManager.AzureManagerInstance.GetCubeInformation();

            CubeList.ItemsSource = Cubeinfo;
        }
    }
}