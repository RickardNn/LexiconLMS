namespace Lexicon_LMS.Migrations
{
    using Lexicon_LMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lexicon_LMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Lexicon_LMS.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Groups.AddOrUpdate(
                p => p.Name,
                new Group { Name = ".NET utvecklare", Teacher = "Oscar Jakobsson", Description = "Bla, bla ...", StartDate = DateTime.Today, EndDate = DateTime.Today });

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            foreach (string roleName in new[] { "Teacher", "Student" })
            {
                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    var role = new IdentityRole { Name = roleName };
                    roleManager.Create(role);
                }

            }


            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            //context.Users.AddOrUpdate(
            var appUser = new ApplicationUser { FirstName = "Nina", LastName = "Eriksson", Email = "nina@hemma.se", UserName = "nina@hemma.se", GroupId = 1 };
            userManager.Create(appUser, "foobar");

            appUser = new ApplicationUser { FirstName = "Rickard", LastName = "Nilsson", Email = "rickard@hemma.se", UserName = "rickard@hemma.se", GroupId = 1 };
            userManager.Create(appUser, "foobar");

            appUser = new ApplicationUser { FirstName = "Disa", LastName = "Hiltunen", Email = "disa@hemma.se", UserName = "disa@hemma.se", GroupId = 1 };
            userManager.Create(appUser, "foobar");

            appUser = new ApplicationUser { FirstName = "Oscar", LastName = "Jakobsson", Email = "oscar.jakobsson@lexicon.se", UserName = "oscar.jakobsson@lexicon.se", GroupId = 1 };
            userManager.Create(appUser, "foobar");

            //);
            //            var user = new ApplicationUser { UserName = email, Email = email };
            //userManager.Create(user, "foobar");
            //}

            var user = userManager.FindByEmail("nina@hemma.se");
            userManager.AddToRole(user.Id, "Student");
            user = userManager.FindByEmail("disa@hemma.se");
            userManager.AddToRole(user.Id, "Student");
            user = userManager.FindByEmail("rickard@hemma.se");
            userManager.AddToRole(user.Id, "Student");

            user = userManager.FindByEmail("oscar.jakobsson@lexicon.se");
            userManager.AddToRole(user.Id, "Teacher");

// Disas kod

            context.Courses.AddOrUpdate(
            a => a.Name,
            new Activity { CourseId = 1, Type = , Name = "E-learning", Teacher = "Oscar Jacobsson", Description = "Plural sight",  StartDate = DateTime.ParseExact("2016-02-07", "yyyy-MM-dd", EndDate = },
            new Activity { CourseId = 1, Type = , Name = "E-learning", Teacher = "Oscar Jacobsson", Description = "Plural sight",  StartDate = DateTime.ParseExact("2016-02-07", "yyyy-MM-dd", EndDate = },
            new Activity { CourseId = 1, Type = , Name = "E-learning", Teacher = "Oscar Jacobsson", Description = "Plural sight",  StartDate = DateTime.ParseExact("2016-02-07", "yyyy-MM-dd", EndDate = },
            new Activity { CourseId = 1, Type = , Name = "E-learning", Teacher = "Oscar Jacobsson", Description = "Plural sight",  StartDate = DateTime.ParseExact("2016-02-07", "yyyy-MM-dd", EndDate = },

            

        }
    }
}
