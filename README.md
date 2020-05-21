# WCFInterceptors
Implementing custom WCF interceptors for a WCF soap Service &amp; Console client application

A simple proof of concept application for extending WCF and implementing Interceptors to add custom headers in the Message object.
This barebones framework can be extended to add custom authentication and authorization on the WCF service.

There are 3 application:
1) C# Console Application : WCF client
2) WCF Service (SOAP)
3) Class Library : Implementing the interceptor logic

The WCF behavior is extended by adding the behavior extension in the client and server app config.
Outgoing calls from the client are intercepted (based on the behavior extension in the appconfig) and username and correlation ID info is added to the Message header.
On the Service side the interceptor framework inspects the incoming message , extracts the header info and pushes it into an extended WCFOperation context.
And this information is now available in the service operation.


