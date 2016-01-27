# Identity Server 3 Standalone Example Implementation

## About
Standalone Identity Server 3 implementation referenced on [www.scottbrady91.com](https://www.scottbrady91.com)

##Configuration
Use the appSetting owin:AppStartup to switch between OWIN Startup configurations:

* InMemory: Generic, In-Memory Users as seen in [Identity Server Implementation Guide](https://www.scottbrady91.com/Identity-Server/Identity-Server-3-Standalone-Implementation-Part-1)
* AspNetIdentity: Implementation using ASP.NET Identity User Store as seen in [Identity Server Using ASP.NET Identity](https://www.scottbrady91.com/Identity-Server/Identity-Server-3-using-ASPNET-Identity)
* WsFederation: Implementation using the Identity Server WS-Federation plugin as seen in [Identity Server Using WS-Federation](https://www.scottbrady91.com/Identity-Server/Identity-Server-3-using-WS-Federation)
