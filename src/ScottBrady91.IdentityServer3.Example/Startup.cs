using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using ScottBrady91.IdentityServer3.Example;
using ScottBrady91.IdentityServer3.Example.Configuration;

[assembly: OwinStartup("InMemory", typeof(Startup))]

namespace ScottBrady91.IdentityServer3.Example
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map(
                "/core",
                coreApp =>
                {
                    coreApp.UseIdentityServer(new IdentityServerOptions
                    {
                        SiteName = "Standalone Identity Server",
                        SigningCertificate = Cert.Load(),
                        Factory = 
                        new IdentityServerServiceFactory()
                            .UseInMemoryClients(Clients.Get())
                            .UseInMemoryScopes(Scopes.Get())
                            .UseInMemoryUsers(Users.Get()),
                        RequireSsl = true,
                        AuthenticationOptions = new AuthenticationOptions { EnablePostSignOutAutoRedirect = true }
                    });
                });
        }
    }
}