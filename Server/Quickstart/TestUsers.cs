    // Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "Silifat Akinsanya",
                    locality = "Surulere-Lagos",
                    postal_code = 101015,
                    country = "Nigeria"
                };
                
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "amaka",
                        Password = "a1",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Amaka Ezekwesili"),
                            new Claim(JwtClaimTypes.GivenName, "Amaka"),
                            new Claim(JwtClaimTypes.FamilyName, "Ezekwesili"),
                            new Claim(JwtClaimTypes.Email, "amakae@rpp.ng"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "staff")

                        }
                    },
                    new TestUser
                    {
                        SubjectId = "88421113",
                        Username = "waris",
                        Password = "w1",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Salami Waris"),
                            new Claim(JwtClaimTypes.GivenName, "Waris"),
                            new Claim(JwtClaimTypes.FamilyName, "Salami"),
                            new Claim(JwtClaimTypes.Email, "Olawareez96@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://olaniyi489.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "admin")

                        }
                    }
                };
            }
        }
    }
}