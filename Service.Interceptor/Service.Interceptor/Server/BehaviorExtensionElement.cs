using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interceptor.Server
{
    internal class CustomBehaviorExtensionElement : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get
            {
                return typeof(ServiceBehaviorExtension);
            }
        }

        protected override object CreateBehavior()
        {
            return new ServiceBehaviorExtension();
        }
    }
}
