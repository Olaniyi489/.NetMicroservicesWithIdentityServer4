using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Server
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                //new Client
                //{
                //    ClientId = "employerClient",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets =
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = {"employerAPI"}
                //},
                new Client
                {
                    ClientId = "employee_mvc_client",
                    ClientName = "Employees MVC Web App",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    RequirePkce = false,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:5002/signin-oidc" 
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:5002/signout-callback-oidc"
                    },
                    ClientSecrets =new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        "employerAPI",
                        "roles"
                    }

                    //Authorization code configuration.
                //new Client
                //{
                //    ClientId = "employee_mvc_client",
                //    ClientName = "Employees MVC Web App",
                //    AllowedGrantTypes = GrantTypes.code,
                //    AllowRememberConsent = false,
                //    RedirectUris = new List<string>()
                //    {
                //        "https://localhost:5002/signin-oidc"
                //    },
                //    PostLogoutRedirectUris = new List<string>()
                //    {
                //        "https://localhost:5002/signout-callback-oidc"
                //    },
                //    ClientSecrets =new List<Secret>
                //    {
                //        new Secret("secret".Sha256())
                //    },
                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //        "employerAPI"
                //    }
                }
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("employerAPI", "Employer API")
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {

            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })

            };
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "waris",
                    Password = "maths2002*",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "waris"),
                        new Claim(JwtClaimTypes.FamilyName, "salami")

                    }
                }
            };

    }
}
