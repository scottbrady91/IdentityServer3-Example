using System.Collections.Generic;
using Thinktecture.IdentityServer.Core.Models;

namespace ScottBrady91.IdentityServer3.Example.Configuration
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    ClientId = @"implicitclient", 
                    ClientName = @"Implicit Client",
                    Enabled = true,
                    Flow = Flows.Implicit,

                }
            };
        }
    }
}