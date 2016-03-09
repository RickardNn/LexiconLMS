namespace Lexicon_LMS.Migrations
{
    using Lexicon_LMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
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

            var users = new List<ApplicationUser> {
                new ApplicationUser {FirstName = "Oscar", LastName = "Jakobsson", Email = "oscar.jakobsson@lexicon.se", UserName = "oscar.jakobsson@lexicon.se"},
                new ApplicationUser {FirstName = "Adrian", LastName = "Lozano", Email = "adrian.lozano@lexicon.se", UserName = "adrian.lozano@lexicon.se"},
                
            };

            var NewUserList = new List<ApplicationUser>();

            foreach (var u in users)
            {
                userManager.Create(u, "foobar");
                var user = userManager.FindByEmail(u.Email);
                NewUserList.Add(user);
                userManager.AddToRole(user.Id, "Teacher");
            }



            var groups = new List<Group> {
                new Group 
                {
                    GroupId = 1,
                    Name = ".NET utvecklare 2015",
                    TeacherId = NewUserList[0].Id,
                    //Teacher = "Oscar Jakobsson",
                    Description = "Grunderna i C#.",
                    StartDate = DateTime.ParseExact("2015-12-03", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-02-03", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },
                new Group
                { 
                    GroupId = 2,
                    Name = ".NET utvecklare 2016",
                    TeacherId = NewUserList[0].Id,
                    //Teacher = "Oscar Jakobsson",
                    Description = "Grundkurs i C#.",
                    StartDate = DateTime.ParseExact("2016-01-03", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-04-13", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 3,
                    Name = "Java Del 1",
                    //Teacher = "Adrian Lozano",
                    TeacherId = NewUserList[1].Id,
                    Description = "Grundkurs.",
                    StartDate = DateTime.ParseExact("2015-11-04", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-04-17", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 4,
                    Name = "C++",
                    //Teacher = "Adrian Lozano",
                    TeacherId = NewUserList[1].Id,
                    Description = "Objektorienterad programmering.",
                    StartDate = DateTime.ParseExact("2015-10-14", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-12-28", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 5,
                    Name = "Java Del 2",
                    //Teacher = "Adrian Lozano",
                    TeacherId = NewUserList[1].Id,
                    Description = "Fortsättningskurs.",
                    StartDate = DateTime.ParseExact("2016-02-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-05-09", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 6,
                    Name = "Grundläggande C",
                    //Teacher = "Oscar Jakobsson",
                    TeacherId = NewUserList[0].Id,
                    Description = "Hello world.",
                    StartDate = DateTime.ParseExact("2015-12-03", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-03-23", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 7,
                    Name = "Avancerad C Del 1",
                    //Teacher = "Oscar Jakobsson",
                    TeacherId = NewUserList[0].Id,
                    Description = "Moment 1.",
                    StartDate = DateTime.ParseExact("2015-11-18", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-04-07", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 8,
                    Name = "Assembler",
                    //Teacher = "Adrian Lozano",
                    TeacherId = NewUserList[1].Id,
                    Description = "Grundkurs.",
                    StartDate = DateTime.ParseExact("2015-12-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-03-08", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 9,
                    Name = "HTML Grunderna",
                    //Teacher = "Adrian Lozano",
                    TeacherId = NewUserList[1].Id,
                    Description = "Skapa en hemsida.",
                    StartDate = DateTime.ParseExact("2016-03-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-05-28", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Group
                { 
                    GroupId = 10,
                    Name = "Avancerad C Del 2",
                    //Teacher = "Oscar Jakobsson",
                    TeacherId = NewUserList[0].Id,
                    Description = "Moment 2.",
                    StartDate = DateTime.ParseExact("2016-04-08", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-07-07", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                }

            };

            foreach (var gr in groups)
            {
                context.Groups.AddOrUpdate(g => g.Name, gr);
            }

            //context.SaveChanges();

            context.Courses.AddOrUpdate(
                c => c.Name,
               new Course
               {
                   Name = "C# 2015",
                   GroupId = 1,
                   CourseId = 1,
                   Teacher = "Oscar Jakobsson",
                   Description = "Klasser och objekt.",
                   StartDate = DateTime.ParseExact("2015-12-03", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-01-23", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2015 del2",
                   GroupId = 1,
                   CourseId = 2,
                   Teacher = "Oscar Jakobsson",
                   Description = "Interface.",
                   StartDate = DateTime.ParseExact("2016-01-24", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-02-12", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "Test 2015",
                   GroupId = 1,
                   CourseId = 3,
                   Teacher = "Mattias Östholm",
                   Description = "Vattenfallsmetoden.",
                   StartDate = DateTime.ParseExact("2016-02-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-02-17", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "SCRUM 2015",
                   GroupId = 1,
                   CourseId = 4,
                   Teacher = "Mattias Östholm",
                   Description = "SCRUM del 1",
                   StartDate = DateTime.ParseExact("2016-02-18", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-02-21", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "AngularJS 2015",
                   GroupId = 1,
                   CourseId = 5,
                   Teacher = "Oscar Jakobsson",
                   Description = "AngularJS del 1.",
                   StartDate = DateTime.ParseExact("2016-02-22", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-02-24", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "MVC5 2015",
                   GroupId = 1,
                   CourseId = 6,
                   Teacher = "Adrian Lozano",
                   Description = "Modeller.",
                   StartDate = DateTime.ParseExact("2016-02-25", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-03-01", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "LMS Projekt 2015",
                   GroupId = 1,
                   CourseId = 7,
                   Teacher = "Oscar Jakobsson",
                   Description = "Fastställa kravpec.",
                   StartDate = DateTime.ParseExact("2016-03-01", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-03-18", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2016",
                   GroupId = 2,
                   CourseId = 8,
                   Teacher = "Pontus Wittberg",
                   Description = "Klasser och objekt.",
                   StartDate = DateTime.ParseExact("2016-04-07", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-04-29", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2016 del2",
                   GroupId = 2,
                   CourseId = 9,
                   Teacher = "Adrian Lozano",
                   Description = "Arv.",
                   StartDate = DateTime.ParseExact("2016-04-30", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-05-12", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "C# 2016 del3",
                   GroupId = 2,
                   CourseId = 10,
                   Teacher = "Pontus Wittberg",
                   Description = "Skapa en app.",
                   StartDate = DateTime.ParseExact("2016-05-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-05-26", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "Test kurs 2016",
                   GroupId = 2,
                   CourseId = 11,
                   Teacher = "Mattias Östholm",
                   Description = "Dokumentation.",
                   StartDate = DateTime.ParseExact("2016-06-27", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-06-29", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "SCRUM 2016",
                   GroupId = 2,
                   CourseId = 12,
                   Teacher = "Adrian Lozano",
                   Description = "SCRUM Grunder.",
                   StartDate = DateTime.ParseExact("2016-06-30", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-07-04", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "AngularJS 2016",
                   GroupId = 2,
                   CourseId = 13,
                   Teacher = "Oscar Jakobsson",
                   Description = "AngularJS Grunder.",
                   StartDate = DateTime.ParseExact("2016-07-05", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-07-12", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

               new Course
               {
                   Name = "MVC5 2016",
                   GroupId = 2,
                   CourseId = 14,
                   Teacher = "Adrian Lozano",
                   Description = "MVC5 Controller.",
                   StartDate = DateTime.ParseExact("2016-07-13", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-07-14", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               },

            new Course
               {
                   Name = "LMS Projekt 2016",
                   GroupId = 2,
                   CourseId = 15,
                   Teacher = "Oscar JAkobsson",
                   Description = "Kravspec.",
                   StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                   EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
               }
             );

            //"plåster" för att få databaskoppling innan vi la till CourseId i Courese seeden.
            // context.SaveChanges();


            var users2 = new List<ApplicationUser> {
                new ApplicationUser { FirstName = "Nina", LastName = "Eriksson", Email = "nina@hemma.se", UserName = "nina@hemma.se", GroupId = 1 },              
                new ApplicationUser { FirstName = "Rickard", LastName = "Nilsson", Email = "rickard@hemma.se", UserName = "rickard@hemma.se", GroupId = 1 },
                new ApplicationUser { FirstName = "Disa", LastName = "Hiltunen", Email = "disa@hemma.se", UserName = "disa@hemma.se", GroupId = 1 },
                new ApplicationUser { FirstName = "Anna", LastName = "Andersson", Email = "anna@hemma.se", UserName = "anna@hemma.se", GroupId = 2 },
                new ApplicationUser { FirstName = "Kalle", LastName = "Karlsson", Email = "kalle@hemma.se", UserName = "kalle@hemma.se", GroupId = 2 },
                new ApplicationUser { FirstName = "Stina", LastName = "Persson", Email = "stina@hemma.se", UserName = "stina@hemma.se", GroupId = 2 }
            };

            foreach (var u in users2)
            {
                userManager.Create(u, "foobar");
                var user = userManager.FindByEmail(u.Email);
                userManager.AddToRole(user.Id, "Student");
            }


            //context.Users.AddOrUpdate(
            //var appUser = new ApplicationUser { FirstName = "Nina", LastName = "Eriksson", Email = "nina@hemma.se", UserName = "nina@hemma.se", GroupId = 1 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Rickard", LastName = "Nilsson", Email = "rickard@hemma.se", UserName = "rickard@hemma.se", GroupId = 1 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Disa", LastName = "Hiltunen", Email = "disa@hemma.se", UserName = "disa@hemma.se", GroupId = 1 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Anna", LastName = "Andersson", Email = "anna@hemma.se", UserName = "anna@hemma.se", GroupId = 2 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Kalle", LastName = "Karlsson", Email = "kalle@hemma.se", UserName = "kalle@hemma.se", GroupId = 2 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Stina", LastName = "Persson", Email = "stina@hemma.se", UserName = "stina@hemma.se", GroupId = 2 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Oscar", LastName = "Jakobsson", Email = "oscar.jakobsson@lexicon.se", UserName = "oscar.jakobsson@lexicon.se", GroupId = 1 };
            //userManager.Create(appUser, "foobar");

            //appUser = new ApplicationUser { FirstName = "Adrian", LastName = "Lozano", Email = "adrian.lozano@lexicon.se", UserName = "adrian.lozano@lexicon.se", GroupId = 2 };
            //userManager.Create(appUser, "foobar");




            //var user = userManager.FindByEmail("nina@hemma.se");
            //userManager.AddToRole(user.Id, "Student");
            //user = userManager.FindByEmail("disa@hemma.se");
            //userManager.AddToRole(user.Id, "Student");
            //user = userManager.FindByEmail("rickard@hemma.se");
            //userManager.AddToRole(user.Id, "Student");
            //user = userManager.FindByEmail("kalle@hemma.se");
            //userManager.AddToRole(user.Id, "Student");
            //user = userManager.FindByEmail("stina@hemma.se");
            //userManager.AddToRole(user.Id, "Student");

            //user = userManager.FindByEmail("oscar.jakobsson@lexicon.se");
            //userManager.AddToRole(user.Id, "Teacher");
            //user = userManager.FindByEmail("adrian.lozano@lexicon.se");
            //userManager.AddToRole(user.Id, "Teacher");



            context.Activities.AddOrUpdate(
                a => a.Name,
                new Activity
                {
                    CourseId = 1,
                    Type = "Lärarledd kurs",
                    Name = "Databaser del 1",
                    Teacher = "Adrian Lozano",
                    Description = "Databas är bra att ha bla bla bla",
                    StartDate = DateTime.ParseExact("2015-01-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-02-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 8,
                    Type = "Självstudier",
                    Name = "E-learning",
                    Teacher = "Oscar Jakobsson",
                    Description = "Plural sight kurs",
                    StartDate = DateTime.ParseExact("2016-04-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-04-16", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 2,
                    Type = "Lärarledd kurs",
                    Name = "C# fortsättningskurs",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att lära oss mer om  C#",
                    StartDate = DateTime.ParseExact("2015-08-02", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-08-14", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 6,
                    Type = "Lärarledd kurs",
                    Name = "Mvc grunder",
                    Teacher = "Adrian Lozano",
                    Description = "Kursen kommer att gå igenom grunderna i mvc",
                    StartDate = DateTime.ParseExact("2015-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-07-19", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 1,
                    Type = "Självstudier",
                    Name = "E-learning C#",
                    Teacher = "Oscar Jakobsson",
                    Description = "E-learning C# är bra för att bla bla bla",
                    StartDate = DateTime.ParseExact("2015-02-18", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2015-02-22", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 8,
                    Type = "Lärarledd kurs",
                    Name = "C#",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kur skommer vi gå igenom bla bla bla bla.",
                    StartDate = DateTime.ParseExact("2016-05-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-05-29", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                 new Activity
                {
                    CourseId = 2,
                    Type = "Lärarledd kurs",
                    Name = "C# fortsättningskurs 2015",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att lära oss mer om  C# och bla bla bla bla",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 6,
                    Type = "Självstudier",
                    Name = "E-learning2",
                    Teacher = "Adrian Lozano",
                    Description = "Kursen kommer att bestå av e-learning på pluralsight",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },




                 //mera data

                new Activity
                {
                    CourseId = 3,
                    Type = "Lärarledd kurs",
                    Name = "Test grunder 2015",
                    Teacher = "Adrian Lozano",
                    Description = "I denna kurs går vi igenom grunderna till test",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 3,
                    Type = "Självstudier",
                    Name = "Test E-learning",
                    Teacher = "Oscar Jakobsson",
                    Description = "Kursen består av ett antal e-learning kurser från Plural sight",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 4,
                    Type = "Lärarledd kurs",
                    Name = "Scrum del1",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att lära oss grunderna i scrum",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 5,
                    Type = "Lärarledd kurs",
                    Name = "Angular fördjupningskurs",
                    Teacher = "Adrian Lozano",
                    Description = "Kursen kommer att gå igenom allt möjligt om Angular",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 6,
                    Type = "Självstudier",
                    Name = "E-learning C# del2",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer ni att lyssna på det e-learning material som finns angånde C#",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 7,
                    Type = "Lärarledd kurs",
                    Name = "LMS grundkurs 1",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi gå igenom LMS",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                 new Activity
                {
                    CourseId = 9,
                    Type = "Lärarledd kurs",
                    Name = "C# fördjupningskurs 2016",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att fördjupa oss i C# ",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 10,
                    Type = "Självstudier",
                    Name = "E-learning3 2016",
                    Teacher = "Adrian Lozano",
                    Description = "Kursen kommer att bestå av e-learning på pluralsight",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                 new Activity
                {
                    CourseId = 9,
                    Type = "Lärarledd kurs",
                    Name = "C# 2016",
                    Teacher = "Adrian Lozano",
                    Description = "I denna kurs kommer vi att lära oss mer om C# ",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 10,
                    Type = "Lärarledd kurs",
                    Name = "C# kurs",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna kurs kommer vi att lära oss mer om C# ",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 11,
                    Type = "Lärarledd kurs",
                    Name = "Test kurs del1",
                    Teacher = "Mattias Östholm",
                    Description = "I denna kurs kommer vi att lära oss mer om test",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 12,
                    Type = "Lärarledd kurs",
                    Name = "Scrum grundkurs",
                    Teacher = "Oscar Jakobsson",
                    Description = "I denna del av kursen skommer vi gå igenom scrum",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                 new Activity
                {
                    CourseId = 13,
                    Type = "Lärarledd kurs",
                    Name = "Angular JS kurs",
                    Teacher = "Pontus Wittberg",
                    Description = "I denna kurs kommer vi att fördjupa oss i Angular JS ",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                new Activity
                {
                    CourseId = 14,
                    Type = "Självstudier",
                    Name = "E-learning MVC",
                    Teacher = "Adrian Lozano",
                    Description = "Kursen kommer att bestå av e-learning på pluralsight",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                },

                 new Activity
                {
                    CourseId = 15,
                    Type = "Lärarledd kurs",
                    Name = "LMS kurs",
                    Teacher = "Pontus Wittberg",
                    Description = "I denna kurs kommer vi att lära oss mer om LMS",
                    StartDate = DateTime.ParseExact("2016-07-15", "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EndDate = DateTime.ParseExact("2016-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                }


            );

            //var groups = new List<Group> {
            //    new Group { },
            //    new Group { },
            //    new Group { },
            //};

            //foreach (var g in groups) { 
            //    context.Groups.AddOrUpdate(g => g.Name, groups);
            //}

            //var users = new List<ApplicationUser> {
            //    new ApplicationUser { },
            //    new ApplicationUser { },
            //    new ApplicationUser { },
            //};

            //foreach (var u in users)
            //{
            //    int userIndex = users.IndexOf(u);
            //    userManager.Create(u, "foobar");
            //    userManager.AddToRole(u.Id, userIndex < 5 ? "Teacher" : "Student");
            //}

            //groups[0].UserId = users[2].Id;
            //users[1].GroupId = groups[1].GroupId;
            

        }
    }
}
