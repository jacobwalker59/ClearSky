using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearSky.Entities;
using Microsoft.AspNetCore.Identity;

namespace ClearSky.Data
{
    public class Seed
    {
         public static async Task SeedData(DataContext context,
            UserManager<AccountHolder> userManager)
        {
            if (!userManager.Users.Any())
            {
                 var users = new List<AccountHolder>
                {
                    new AccountHolder
                    {
                        Id = "a",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AccountHolder
                    {
                        Id = "b",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AccountHolder
                    {
                        Id = "c",
                        UserName = "tom",
                        Email = "tom@test.com"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!context.Properties.Any())
            {
                var properties = new List<Property>
                {
                    new Property{
                        IsRentable = true,
                        PropertyName = "Big House",
                        PropertyPrice = 1000,
                        PropertyDescription ="Big"

                    },
                    new Property{
                        IsRentable = false,
                        PropertyName = "Little House",
                        PropertyPrice = 500,
                        PropertyDescription ="Little"

                    },
                    new Property{
                        IsRentable = true,
                        PropertyName = "Mansion",
                        PropertyPrice = 3000,
                        PropertyDescription ="Swimming Pool"

                    },
                    new Property{
                        IsRentable = true,
                        PropertyName = "UnderGround",
                        PropertyPrice = 1500,
                        PropertyDescription ="Burrow"

                    },
                    new Property{
                        IsRentable = false,
                        PropertyName = "Marine",
                        PropertyPrice = 2000,
                        PropertyDescription ="Aqua"

                    }

                };
                foreach (var property in properties)
                {
                    context.Properties.Add(property);
                }

                context.SaveChanges();
            }
        }

    }
}

