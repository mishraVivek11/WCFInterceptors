using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interceptor.Client
{
    internal class ClientBehaviorExtElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(EndpointBehaviorExtension); }
        }

        protected override object CreateBehavior()
        {
            return new EndpointBehaviorExtension();
        }
    }
}
