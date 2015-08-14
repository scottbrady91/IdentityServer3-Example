using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace ScottBrady91.IdentityServer3.Example.Configuration
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.Roles,
                StandardScopes.Profile,
                StandardScopes.Email,
                StandardScopes.OfflineAccess
            };
        }
    }
}