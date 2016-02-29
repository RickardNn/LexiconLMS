namespace Lexicon_LMS.Migrations
{
    using Lexicon_LMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
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
                new Group { GroupId = 1, Name = ".NET utvecklare 2015", Teacher = "Oscar Jakobsson", Description = "Bla, bla 1.", StartDate = DateTime.Today, EndDate = DateTime.Today },
                new Group { Name = "Java Del 1", Teacher = "Adrian", Description = "Enkel kurs.", StartDate = DateTime.Today, EndDate = DateTime.Today },
                new Group { GroupId = 2, Name = ".NET utvecklare 2016", Teacher = "Oscar Jakobsson", Description = "Bla, bla 2.", StartDate = DateTime.Today, EndDate = DateTime.Today },
                new Group { Name = "C++", Teacher = "Pontus", Description = "Bla, bla ...", StartDate = DateTime.Today, EndDate = DateTime.Today },
                new Group { Name = "Java Del 2", Teacher = "Adrian", Description = "Svår kurs.", StartDate = DateTime.Today, EndDate = DateTime.Today },
                new Group { Name = "Grundläggande C", Teacher = "Anders Andersson", Description = "Hello world.", StartDate = DateTime.Today, EndDate = DateTime.Today },
                new Group { Name = "Avancerad C Del 1", Teacher = "Anders Andersson", Description = "Moment 1.", StartDate = DateTime.Today, EndDate = DateTime.Today },
                new Group { Name = "Assembler", Teacher = "Karin Larsson", Description = "Grundkurs.", StartDate = DateTime.Today, EndDate = DateTime.Today },
                new Group { Name = "HTML Grunderna", Teacher = "Olov Hansson", Description = "Del 1", StartDate = DateTime.Today, EndDate = DateTime.Today },
                new Group { Name = "Avancerad C Del 2", Teacher = "Anders Andersson", Description = "Moment 2.", StartDate = DateTime.Today, EndDate = DateTime.Today }
            );

            context.Courses.AddOrUpdate(
                c => c.Name,
               new Course
               {
                   Name = "C# 2015",
                   GroupId = 1,
                   CourseId = 1,
                   Teacher = "Oscar Jakobsson",
                   Description = "Bla, bla 888.",
                   StartDate = DateTime.ParseExact("2015-12-03", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-01-23", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2015 del2",
                   GroupId = 1,
                   CourseId = 2,
                   Teacher = "Oscar Jakobsson",
                   Description = "Bla, bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-01-24", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-02-12", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "Test 2015",
                   GroupId = 1,
                   CourseId = 3,
                   Teacher = "Mattias Östholm",
                   Description = "Test är bra, bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-02-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-02-17", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "SCRUM 2015",
                   GroupId = 1,
                   CourseId = 4,
                   Teacher = "Adrian",
                   Description = "SCRUM är bättre, bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-02-18", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-02-21", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "AngularJS 2015",
                   GroupId = 1,
                   CourseId = 5, 
                   Teacher = "Oscar Jakobsson",
                   Description = "AngularJS är bäst, bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-02-22", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-02-24", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "MVC5 2015",
                   GroupId = 1,
                   CourseId = 6,
                   Teacher = "Adrian",
                   Description = "MVC5 är ? , bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-02-25", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-03-01", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "LMS Projekt",
                   GroupId = 1,
                   CourseId = 7,
                   Teacher = "Oscar JAkobsson",
                   Description = "MVC5 är ? , bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-03-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-03-18", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2016",
                   GroupId = 2,
                   CourseId = 8,
                   Teacher = "Oscar Jakobsson",
                   Description = "Bla, mer bla 888.",
                   StartDate = DateTime.ParseExact("2016-04-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-04-29", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2016 del2",
                   GroupId = 2,
                   CourseId = 9,
                   Teacher = "Adrian",
                   Description = "Bla, bla, bla, pust, ...",
                   StartDate = DateTime.ParseExact("2016-04-30", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-05-12", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2016 del3",
                   GroupId = 2,
                   CourseId = 10,
                   Teacher = "Pontus",
                   Description = "Bla, bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-05-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-05-26", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "Test 2016",
                   GroupId = 2,
                   CourseId = 11,
                   Teacher = "Mattias Östholm",
                   Description = "Test är bra, bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-06-27", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-06-29", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "SCRUM 2016",
                   GroupId = 2,
                   CourseId = 12,
                   Teacher = "Adrian",
                   Description = "SCRUM är bättre, bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-06-30", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-07-04", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "AngularJS 2016",
                   GroupId = 2,
                   CourseId = 13,
                   Teacher = "Oscar Jakobsson",
                   Description = "AngularJS är bäst, bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-07-05", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-07-12", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "MVC5 2016",
                   GroupId = 2,
                   CourseId = 14,
                   Teacher = "Adrian",
                   Description = "MVC5 är ? , bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-07-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-07-14", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

            new Course
               {
                   Name = "LMS Projekt 2016",
                   GroupId = 2,
                   CourseId = 15,
                   Teacher = "Oscar JAkobsson",
                   Description = "MVC5 är ? , bla, bla, ...",
                   StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               }
             );

            //"plåster" för att få databaskoppling innan vi la till CourseId i Courese seeden.
            // context.SaveChanges();

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

            context.Activities.AddOrUpdate(
                a => a.Name,
                new Activity 
                { 
                    CourseId = 1, 
                    Type = "Lärarledd kurs", 
                    Name = "Databaser del 1", 
                    Teacher = "Adrian Lozano", 
                    Description = "Databas är bra att ha bla bla bla",  
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture), 
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity 
                {
                    CourseId = 8, 
                    Type = "Självstudier", 
                    Name = "E-learning", 
                    Teacher = "Oscar Jacobsson", 
                    Description = "Plural sight kurs",  
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture), 
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity 
                { 
                    CourseId = 2, 
                    Type = "Lärarledd kurs", 
                    Name = "C# fortsättningskurs", 
                    Teacher = "Oscar Jacobsson", 
                    Description = "I denna kurs kommer vi att lära oss mer om  C#", 
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture), 
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity 
                { 
                    CourseId = 6, 
                    Type = "Lärarledd kurs", 
                    Name = "Mvc grunder", 
                    Teacher = "Adrian Lozano", 
                    Description = "Kursen kommer att gå igenom grunderna i mvc",  
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture), 
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                { 
                    CourseId = 1, 
                    Type = "Självstudier", 
                    Name = "E-learning C#", 
                    Teacher = "Oskar Jakobsson", 
                    Description = "E-learning C# är bra för att bla bla bla",  
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture), 
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity 
                {
                    CourseId = 8, 
                    Type = "Lärarledd kurs", 
                    Name = "C#", 
                    Teacher = "Oscar Jacobsson", 
                    Description = "I denna kur skommer vi gå igenom bla bla bla bla.",  
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture), 
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                 new Activity 
                { 
                    CourseId = 2, 
                    Type = "Lärarledd kurs", 
                    Name = "C# fortsättningskurs 2015", 
                    Teacher = "Oscar Jacobsson", 
                    Description = "I denna kurs kommer vi att lära oss mer om  C# och bla bla bla bla", 
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture), 
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity 
                { 
                    CourseId = 6, 
                    Type = "Självstudier", 
                    Name = "E-learning", 
                    Teacher = "Adrian Lozano", 
                    Description = "Kursen kommer att bestå av e-learning på pluralsight",  
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture), 
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                }
            );

            

        }
    }
}
