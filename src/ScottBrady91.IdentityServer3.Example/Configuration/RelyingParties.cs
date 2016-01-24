namespace ScottBrady91.IdentityServer3.Example.Configuration
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using IdentityModel.Constants;

    using global::IdentityServer3.WsFederation.Models;

    public static class RelyingParties
    {
        public static IEnumerable<RelyingParty> Get()
        {
            return new List<RelyingParty>
                       {
                           new RelyingParty
                               {
                                   Realm = "urn:testClient", 
                                   Name = "testclient", 
                                   Enabled = true, 
                                   ReplyUrl = "https://localhost:4004/TestClient/", 
                                   TokenType = TokenTypes.Saml2TokenProfile11, 
                                   ClaimMappings =
                                       new Dictionary<string, string>
                                           {
                                               { "sub", ClaimTypes.NameIdentifier }, 
                                               { "name", ClaimTypes.Name }, 
                                               { "given_name", ClaimTypes.GivenName }, 
                                               { "family_name", ClaimTypes.Surname }, 
                                               { "email", ClaimTypes.Email }, 
                                               { "upn", ClaimTypes.Upn }
                                           }
                               }
                       };
        }
    }
}