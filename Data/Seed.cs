using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Identity;
using Social_Media.Data;
using Social_Media.Data.Enum;
using Social_Media.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Social_Media.Data.Enum;
using Social_Media.Models;

namespace Social_Media.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Groups.Any())
                {
                    context.Groups.AddRange(new List<Group>()
                    {
                        
                        new Group()
                        {
                            


                            Title = "Ozzy Osbourne",
                            Image = "https://yt3.googleusercontent.com/NLB_F8uL9P8Wyr94tNM47aGHnQFOuE6E-rUl1hx9iw0PZxb_K3ok7i5k3ArN-x6oFs9bVy5lHg=s900-c-k-c0x00ffffff-no-rj",
                            Description = "This is the description of the first Band",
                            GroupCategory = GroupCategory.Indie,
                            Address = new Address()
                            {
                                Street = "Aldaru iela 6",
                                City = "Riga",
                                State = "",
                            }

                        },
                        new Group()
                        {

                            Title = "Metallica",
                            Image = "https://yt3.googleusercontent.com/NLB_F8uL9P8Wyr94tNM47aGHnQFOuE6E-rUl1hx9iw0PZxb_K3ok7i5k3ArN-x6oFs9bVy5lHg=s900-c-k-c0x00ffffff-no-rj",
                            Description = "This is the description of the first Band",
                            GroupCategory = GroupCategory.Pop,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        },
                        new Group()
                        {


                            Title = "Lincin park",
                            Image = "https://www.gannett-cdn.com/-mm-/4e09c2618c2c46c8dd6669ce088d1637a1ad52a5/c=0-17-648-382/local/-/media/Phoenix/Phoenix/2014/05/27//1401210370000-linkin-park.jpg",
                            Description = "This is the description of the third Band",

                            

                            GroupCategory = GroupCategory.Rock,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        },
                        new Group()
                        {


                            Title = "BAU",
                            Image = "https://a-a-ah-ru.s3.amazonaws.com/uploads/items/154268/320735/large_m1000x1000.jpg",
                            Description = "This is the description of the fourth Band",

                            

                            GroupCategory = GroupCategory.Granje,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Michigan",
                                State = "NC"
                            }
                        }

                    });
                    context.SaveChanges();
                }


                if (!context.Concerts.Any())
                {
                    context.Concerts.AddRange(new List<Concert>()
                    {
                        new Concert()
                        {


                            Title = "Indoor Concert",
                            Image = "",
                            Description = "This is the description of the first Concert",
                            ConcertCategory = ConcertCategory.Indoor,

                            
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        },
                        new Concert()
                        {


                            Title = "Burning man",
                            Image = "",
                            Description = "This is the description of the first Concert",
                            ConcertCategory = ConcertCategory.Outdoor,

                            AddressId = 5,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Charlotte",
                                State = "NC"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "teddysmithdev",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
