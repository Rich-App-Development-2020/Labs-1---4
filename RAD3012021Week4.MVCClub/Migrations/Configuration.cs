namespace RAD3012021Week4.MVCClub.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RAD3012021Week4.MVCClub.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RAD3012021Week4.MVCClub.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RAD3012021Week4.MVCClub.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            
                //store the usermanager and the context together in a usable variable
            var manager =
             new UserManager<ApplicationUser>(
                 new UserStore<ApplicationUser>(context));

                //store the usermanager and the context together in a usable variable
            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));


            #region AddRoleDefinitions
                //define the different roles by name
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "ClubAdmin" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "member" }
                );
            #endregion AddRoleDefinitions

            PasswordHasher ps = new PasswordHasher();

            #region AddRoleDefinitions

                //add new users
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "powell.paul@itsligo.ie",
                    Email = "powell.paul@itsligo.ie",
                    EmailConfirmed = true,
                    //DateTime constructor = yyyy/mm/dd//hour//min
                    date_joined = new DateTime(2018, 10, 09, 23, 45, 42),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Paul",
                    Surname = "Powell",
                    PasswordHash = ps.HashPassword("``")
                });

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "radp2016@outlook.com",
                    Email = "radp2016@outlook.com",
                    EmailConfirmed = true,
                    date_joined = new DateTime(2018, 10, 09, 23, 45, 42),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    FirstName = "Rad",
                    Surname = "Paulner",
                    PasswordHash = ps.HashPassword("radP2016$1")
                });
            context.SaveChanges();

            #endregion AddRoleDefinitions

            #region AddFullAdmin
            ApplicationUser admin = manager.FindByEmail("powell.paul@itsligo.ie");
            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] { "Admin", "member", "ClubAdmin" });
            }
            #endregion AddFullAdmin

            #region AddNormalUser
            //create a variable to describe the rights of the user, this is just a normal user so I just called it user, 
            //can call it anything, it's just storing the user that you found by email
            //you then assign the roles you want to to that variable you created, then update database and a new role and
            //the ID for the member associated with that role will show in the database
            ApplicationUser user = manager.FindByEmail("radp2016@outlook.com");
            if (user != null)
            {
                manager.AddToRoles(user.Id, new string[] { "member"});
            }
            #endregion AddNormalUser
        }
    }
}