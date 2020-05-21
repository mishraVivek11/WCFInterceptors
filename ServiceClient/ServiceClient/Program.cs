using ServiceClient.DataServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DataServiceClient dataServiceClient = new DataServiceClient();
            //client interceptor configuration is added in the app config
            //any endpoint that needs to implement 
            //interception behaviour can simply add behaviorConfiguration in endpoint configuration
            string resp =dataServiceClient.GetData(5);
        }
    }
}
