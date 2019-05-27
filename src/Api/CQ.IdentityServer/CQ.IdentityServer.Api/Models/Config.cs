
using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace CQ.IdentityServer.Models
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                }
            };
        }


        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "NoteApi",
                    DisplayName = "",
                    ApiSecrets = 
                    {
                        new Secret("secret".Sha256())
                    },
                    UserClaims = 
                    {
                        JwtClaimTypes.Name,
                        JwtClaimTypes.Email,
                        JwtClaimTypes.PhoneNumber
                    },
                    Scopes = 
                    {
                        new Scope
                        {
                            Name = "NoteApi.Add",
                            DisplayName = "添加笔记接口"
                        },

                        new Scope
                        {
                            Name = "NoteApi.Get",
                            DisplayName = "获取笔记接口"
                        }
                    }
                }
            };
        }

    }
}