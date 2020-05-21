using Service.Interceptor.Common;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Service.Interceptor.Server
{
    internal class ServiceInterceptor : IParameterInspector, IDispatchMessageInspector
    {
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
        }

        //Intercept incoming calls, inspect for headers and apply custom logic for 
        //authentication/authorization
        //Add user data to the WCFOperation context
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            int userInfoHdrIndex = request.Headers.FindHeader(Constants.UserInformationHeader, Constants.HeaderNamespace);
            int correlationHdrIndex = request.Headers.FindHeader(Constants.CorrelationIdHeader, Constants.HeaderNamespace);

            //throw a fault exception based on some missing headers

            //add info to operation context
            string userInfo = request.Headers.GetHeader<string>(userInfoHdrIndex);
            string correlation = request.Headers.GetHeader<string>(correlationHdrIndex);

            WcfOperationContext.Current.ContextItems["User"] = userInfo;
            WcfOperationContext.Current.ContextItems["Correlation"] = correlation;

            return request;

        }

        //Authorization logic can be implemented here using attribute class
        //The service operations can be decorated with custom authorizationAttributes
        //and the logic can be implemented here
        public object BeforeCall(string operationName, object[] inputs)
        {
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
}