using Service.Interceptor.Common;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Service.Interceptor.Client
{
    internal class ClientMessageInterceptor : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        //Intercept the outgoing calls and add custom headers or any custom behaviour
        //In this example we add 2 headers with the Userinfo and correlationId
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            MessageHeader userInfoHdr = MessageHeader.CreateHeader(Constants.UserInformationHeader, Constants.HeaderNamespace, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            MessageHeader correlationHdr = MessageHeader.CreateHeader(Constants.CorrelationIdHeader, Constants.HeaderNamespace, Guid.NewGuid());

            request.Headers.Add(userInfoHdr);
            request.Headers.Add(correlationHdr);

            return null;

        }
    }
}