using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.Owin;
using Owin;
using ScottBrady91.IdentityServer3.Example;
using ScottBrady91.IdentityServer3.Example.Configuration;


[assembly: OwinStartup("AspNetIdentity", typeof(Startup_AspNetIdentity))]

namespace ScottBrady91.IdentityServer3.Example
{
    using global::IdentityServer3.AspNetIdentity;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Startup_AspNetIdentity
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map(
                "/core",
                coreApp =>
                    {
                        var factory =
                            new IdentityServerServiceFactory()
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get());

                        factory.Register(new Registration<IdentityDbContext>());
                        factory.Register(new Registration<UserStore<IdentityUser>>());
                        factory.Register(new Registration<UserManager<IdentityUser, string>>(x => new UserManager<IdentityUser>(x.Resolve<UserStore<IdentityUser>>())));
                        
                        factory.UserService = new Registration<IUserService, AspNetIdentityUserService<IdentityUser, string>>();

                        coreApp.UseIdentityServer(
                            new IdentityServerOptions
                                {
                                    SiteName = "Standalone Identity Server",
                                    SigningCertificate = Cert.Load(),
                                    Factory = factory,
                                    RequireSsl = true
                                });
                    });
        }
    }
}