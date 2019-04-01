using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace MyAppService
{
    public sealed class Inventory : IBackgroundTask
    {
        private BackgroundTaskDeferral backroundTaskDeferral;
        private AppServiceConnection appServiceConnection;

        private String[] inventoryItems = new string[] { "Robot", "Chair" };
        private double[] inventoryPrices = new double[] { 129.99, 89.99 };
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            this.backroundTaskDeferral = taskInstance.GetDeferral();
            taskInstance.Canceled += onTaskCanceled;
            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;

            appServiceConnection = details.AppServiceConnection;
            appServiceConnection.RequestReceived += onRequestReceived;
        }
        private async void onRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            var messageDeferral = args.GetDeferral();
            ValueSet message = args.Request.Message;
            ValueSet returnData = new ValueSet();

            string command = message["Command"] as string;
            int? inventoryIndex = message["ID"] as int?;
            
            if(inventoryIndex.HasValue && inventoryIndex.Value >= 0 && inventoryIndex.Value < inventoryItems.GetLength(0))
            {
                switch(command)
                {
                    case "Price":
                        returnData.Add("Result", inventoryPrices[inventoryIndex.Value]);
                        returnData.Add("Status", "OK");
                        break;
                    case "Item":
                        returnData.Add("Result", inventoryPrices[inventoryIndex.Value]);
                        returnData.Add("Status", "OK");
                        break;
                    default:
                        returnData.Add("Status", "Fail: Unknown Command");
                        break;
                }
            }
            else
            {
                returnData.Add("Status", "Fail : Index Out Of Range");
            }
            await args.Request.SendResponseAsync(returnData);
            messageDeferral.Complete();
        }
        private void onTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            if(this.backroundTaskDeferral != null)
            {
                // Complete the service deferral. 
                this.backroundTaskDeferral.Complete();
            }
        }
}
