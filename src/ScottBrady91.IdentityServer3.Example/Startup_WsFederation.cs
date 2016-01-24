using Microsoft.Owin;

using ScottBrady91.IdentityServer3.Example;

[assembly: OwinStartup("WsFederation", typeof(Startup_WsFederation))]

namespace ScottBrady91.IdentityServer3.Example
{
    using System.Collections.Generic;

    using global::IdentityServer3.Core.Configuration;
    using global::IdentityServer3.WsFederation.Configuration;
    using global::IdentityServer3.WsFederation.Models;
    using global::IdentityServer3.WsFederation.Services;

    using Owin;

    using ScottBrady91.IdentityServer3.Example.Configuration;

    public sealed class Startup_WsFederation
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map(
                "/core",
                coreApp =>
                    {
                        coreApp.UseIdentityServer(
                            new IdentityServerOptions
                                {
                                    SiteName = "Standalone Identity Server",
                                    SigningCertificate = Cert.Load(),
                                    Factory =
                                        new IdentityServerServiceFactory().UseInMemoryClients(Clients.Get())
                                        .UseInMemoryScopes(Scopes.Get())
                                        .UseInMemoryUsers(Users.Get()),
                                    RequireSsl = true,
                                    PluginConfiguration = ConfigureWsFederation
                                });
                    });
        }

        private void ConfigureWsFederation(IAppBuilder pluginApp, IdentityServerOptions options)
        {
            var factory = new WsFederationServiceFactory(options.Factory);
            factory.Register(new Registration<IEnumerable<RelyingParty>>(RelyingParties.Get()));
            factory.RelyingPartyService = new Registration<IRelyingPartyService>(typeof(InMemoryRelyingPartyService));
            pluginApp.UseWsFederationPlugin(new WsFederationPluginOptions { IdentityServerOptions = options, Factory = factory });
        }
    }
}