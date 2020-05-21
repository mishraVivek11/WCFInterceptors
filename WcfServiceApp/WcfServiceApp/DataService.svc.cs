using Service.Interceptor.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceApp
{
    public class DataService : IDataService
    {
        public string GetData(int value)
        {
            //fetching custom information from the operation context
            //which is available throughout the service/operation layer
            string user = WcfOperationContext.Current.ContextItems["User"].ToString();

            return string.Format($"User: {user} sent, value: {value}");
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
