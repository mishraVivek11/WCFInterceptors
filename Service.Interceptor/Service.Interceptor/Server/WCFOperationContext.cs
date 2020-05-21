using System.Collections.Generic;
using System.ServiceModel;

namespace Service.Interceptor.Server
{
    //This class holds the context information for the service
    //custom information can be added to the context so that it can be made available like the http context
    public class WcfOperationContext : IExtension<OperationContext>
    {
        private readonly IDictionary<string, object> contextItems;

        private WcfOperationContext()
        {
            contextItems = new Dictionary<string, object>();
        }

        public IDictionary<string, object> ContextItems
        {
            get { return contextItems; }
        }

        public static WcfOperationContext Current
        {
            get
            {
                WcfOperationContext context = OperationContext.Current.Extensions.Find<WcfOperationContext>();
                if (context == null)
                {
                    context = new WcfOperationContext();
                    OperationContext.Current.Extensions.Add(context);
                }
                return context;
            }
        }

        public void Attach(OperationContext owner)
        {
        }

        public void Detach(OperationContext owner)
        {
        }
    }
}
