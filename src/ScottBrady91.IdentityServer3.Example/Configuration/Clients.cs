using System.Collections.Generic;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Models;

namespace ScottBrady91.IdentityServer3.Example.Configuration
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = @"implicitclient",
                    ClientName = @"Example Implicit Client",
                    Enabled = true,
                    Flow = Flows.Implicit,
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    RedirectUris = new List<string> {"https://localhost:44304/account/signInCallback"},
                    PostLogoutRedirectUris = new List<string> {"https://localhost:44304/"},
                    ScopeRestrictions =
                        new List<string>
                        {
                            Constants.StandardScopes.OpenId,
                            Constants.StandardScopes.Profile,
                            Constants.StandardScopes.Email
                        },
                    AccessTokenType = AccessTokenType.Jwt
                },
                new Client
                {
                    ClientId = @"hybridclient",
                    ClientName = @"Example Hybrid Client",
                    ClientSecrets = new List<ClientSecret>
                    {
                        new ClientSecret("idsrv3test".Sha256())
                    },
                    Enabled = true,
                    Flow = Flows.Hybrid,
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44305/"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44305/"
                    },
                    ScopeRestrictions = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.Profile,
                        Constants.StandardScopes.Email,
                        Constants.StandardScopes.Roles,
                        Constants.StandardScopes.OfflineAccess
                    },
                    AccessTokenType = AccessTokenType.Jwt
                }
            };
        }
    }
}