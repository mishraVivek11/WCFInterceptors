using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Service.Interceptor.Server
{
    internal class ServiceBehaviorExtension : IEndpointBehavior, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher disp in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpointDispatcher in disp.Endpoints)
                {
                    endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new ServiceInterceptor());

                    foreach (DispatchOperation operation in endpointDispatcher.DispatchRuntime.Operations)
                    {
                        operation.ParameterInspectors.Add(new ServiceInterceptor());
                    }

                }
            }
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (DispatchOperation op in endpointDispatcher.DispatchRuntime.Operations)
            {
                op.ParameterInspectors.Add(new ServiceInterceptor());
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}
