namespace Snippy.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Snippy.Models;

    public sealed class Configuration : DbMigrationsConfiguration<SnippyContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SnippyContext context)
        {
            SeedUsers(context);
            context.SaveChanges();
            SeedLanguages(context);
            context.SaveChanges();
            SeedLabels(context);
            context.SaveChanges();
            SeedSnippets(context);
            context.SaveChanges();
            SeedComments(context);
            context.SaveChanges();
        }

        private static void SeedUsers(SnippyContext context)
        {
            if (!context.Users.Any())
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);

                var admin = new User
                    {
                        Email = "admin@snippy.softuni.com",
                        UserName = "admin"
                    };
                userManager.Create(admin, "adminPass123");

                var adminRole = new IdentityRole { Name = "Admin" };
                context.Roles.Add(adminRole);

                var identityRole = new IdentityUserRole { RoleId = adminRole.Id, UserId = admin.Id };
                adminRole.Users.Add(identityRole);

                var someUser = new User
                    {
                        Email = "someUser@example.com",
                        UserName = "someUser"
                    };

                userManager.Create(someUser, "someUserPass123");

                var newUser = new User
                    {
                        Email = "new_user@gmail.com",
                        UserName = "newUser"
                    };

                userManager.Create(newUser, "userPass123");
            }
        }

        private static void SeedLanguages(SnippyContext context)
        {
            if (!context.Languages.Any())
            {
                var languages = new List<Language>()
                    {
                        new Language() { Name = "C#" },
                        new Language() { Name = "JavaScript" },
                        new Language() { Name = "Python" },
                        new Language() { Name = "CSS" },
                        new Language() { Name = "SQL" },
                        new Language() { Name = "PHP" }
                    };

                foreach (var language in languages)
                {
                    context.Languages.Add(language);
                }
            }
        }

        private static void SeedLabels(SnippyContext context)
        {
            if (!context.Labels.Any())
            {
                var labels = new List<Label>()
                    {
                        new Label() { Text = "bug" },
                        new Label() { Text = "funny" },
                        new Label() { Text = "jquery" },
                        new Label() { Text = "mysql" },
                        new Label() { Text = "useful" },
                        new Label() { Text = "web" },
                        new Label() { Text = "geometry" },
                        new Label() { Text = "back-end" },
                        new Label() { Text = "front-end" },
                        new Label() { Text = "games" }
                    };

                foreach (var label in labels)
                {
                    context.Labels.Add(label);
                }
            }
        }

        private static void SeedSnippets(SnippyContext context)
        {
            if (!context.Snippets.Any())
            {
                SeedSnippet1(context);
                SeedSnippet2(context);
                SeedSnippet3(context);
                SeedSnippet4(context);
                SeedSnippet5(context);
                SeedSnippet6(context);
                SeedSnippet7(context);
                SeedSnippet8(context);
            }
        }

        private static void SeedSnippet1(SnippyContext context)
        {
            var snippet1 = new Snippet()
                {
                    Title = "Ternary Operator Madness",
                    Description = "This is how you DO NOT user ternary operators in C#!",
                    Code = "bool X = Glob.UserIsAdmin ? true : false;",
                    CreatedOn = Convert.ToDateTime("26.10.2015 17:20:33")
                };

            var author = GetAuthor(context, "admin");
            var language = GetLanguage(context, "C#");
            var label1 = GetLabel(context, "funny");

            snippet1.Author = author;
            snippet1.Language = language;
            snippet1.Labels = new List<Label>() { label1 };
            context.Snippets.Add(snippet1);
        }

        private static void SeedSnippet2(SnippyContext context)
        {
            var snippet2 = new Snippet()
                {
                    Title = "Points Around A Circle For GameObject Placement",
                    Description =
                        "Determine points around a circle which can be used to place elements around a central point",
                    Code =
                        @"private Vector3 DrawCircle(float centerX, float centerY, float radius, float totalPoints, float currentPoint)
{
	float ptRatio = currentPoint / totalPoints;
	float pointX = centerX + (Mathf.Cos(ptRatio * 2 * Mathf.PI)) * radius;
	float pointY = centerY + (Mathf.Sin(ptRatio * 2 * Mathf.PI)) * radius;

	Vector3 panelCenter = new Vector3(pointX, pointY, 0.0f);

	return panelCenter;
}",
                    CreatedOn = Convert.ToDateTime("26.10.2015 20:15:30")
                };

            var author = GetAuthor(context, "admin");
            var language = GetLanguage(context, "C#");
            var label1 = GetLabel(context, "geometry");
            var label2 = GetLabel(context, "games");

            snippet2.Author = author;
            snippet2.Language = language;
            snippet2.Labels = new List<Label>() { label1, label2 };
            context.Snippets.Add(snippet2);
        }

        private static void SeedSnippet3(SnippyContext context)
        {
            var snippet3 = new Snippet()
                {
                    Title = "forEach. How to break?",
                    Description =
                        @"Array.prototype.forEach You can't break forEach. So use ""some"" or ""every"". Array.prototype.some some is pretty much the same as forEach but it break when the callback returns true. Array.prototype.every every is almost identical to some except it's expecting false to break the loop.",
                    Code = @"var ary = [""JavaScript"", ""Java"", ""CoffeeScript"", ""TypeScript""];

ary.some(function(value, index, _ary) {
                    console.log(index + "": "" + value);
            return value === ""CoffeeScript"";
        });
// output: 
// 0: JavaScript
// 1: Java
// 2: CoffeeScript
 
ary.every(function(value, index, _ary)
        {
            console.log(index + "": "" + value);
            return value.indexOf(""Script"") > -1;
        });
// output:
// 0: JavaScript
// 1: Java",
                    CreatedOn = Convert.ToDateTime("27.10.2015 10:53:20")
                };

            var author = GetAuthor(context, "newUser");
            var language = GetLanguage(context, "JavaScript");
            var label1 = GetLabel(context, "jquery");
            var label2 = GetLabel(context, "useful");
            var label3 = GetLabel(context, "web");
            var label4 = GetLabel(context, "front-end");

            snippet3.Author = author;
            snippet3.Language = language;
            snippet3.Labels = new List<Label>() { label1, label2, label3, label4 };
            context.Snippets.Add(snippet3);
        }

        private static void SeedSnippet4(SnippyContext context)
        {
            var snippet4 = new Snippet()
                {
                    Title = "Numbers only in an input field",
                    Description =
                        @"Method allowing only numbers (positive / negative / with commas or decimal points) in a field",
                    Code = @"$(""#input"").keypress(function(event){
	var charCode = (event.which) ? event.which : window.event.keyCode;
	if (charCode <= 13) { return true; } 
	else {
            var keyChar = String.fromCharCode(charCode);
            var regex = new RegExp(""[0-9,.-]"");
            return regex.test(keyChar);
    }
});",
                    CreatedOn = Convert.ToDateTime("28.10.2015 09:00:56")
                };

            var author = GetAuthor(context, "someUser");
            var language = GetLanguage(context, "JavaScript");
            var label1 = GetLabel(context, "web");
            var label2 = GetLabel(context, "front-end");

            snippet4.Author = author;
            snippet4.Language = language;
            snippet4.Labels = new List<Label>() { label1, label2 };
            context.Snippets.Add(snippet4);
        }

        private static void SeedSnippet5(SnippyContext context)
        {
            var snippet5 = new Snippet()
                {
                    Title = "Create a link directly in an SQL query",
                    Description = @"That's how you create links - directly in the SQL!",
                    Code = @"SELECT DISTINCT
              b.Id,
              concat('<button type=""""button"""" onclick=""""DeleteContact(', cast(b.Id as char), ')"""">Delete...</button>') as lnkDelete
FROM tblContact   b
WHERE ....",
                    CreatedOn = Convert.ToDateTime("30.10.2015 11:20:00")
                };

            var author = GetAuthor(context, "admin");
            var language = GetLanguage(context, "SQL");
            var label1 = GetLabel(context, "bug");
            var label2 = GetLabel(context, "funny");
            var label3 = GetLabel(context, "mysql");

            snippet5.Author = author;
            snippet5.Language = language;
            snippet5.Labels = new List<Label>() { label1, label2, label3 };
            context.Snippets.Add(snippet5);
        }

        private static void SeedSnippet6(SnippyContext context)
        {
            var snippet6 = new Snippet()
                {
                    Title = "Reverse a String",
                    Description = @"Almost not worth having a function for...",
                    Code = @"def reverseString(s):
	""""""Reverses a string given to it.""""""
    return s[::- 1]",
                    CreatedOn = Convert.ToDateTime("26.10.2015 09:35:13")
                };

            var author = GetAuthor(context, "admin");
            var language = GetLanguage(context, "Python");
            var label1 = GetLabel(context, "useful ");

            snippet6.Author = author;
            snippet6.Language = language;
            snippet6.Labels = new List<Label>() { label1 };
            context.Snippets.Add(snippet6);
        }

        private static void SeedSnippet7(SnippyContext context)
        {
            var snippet7 = new Snippet()
                {
                    Title = "Pure CSS Text Gradients",
                    Description = @"This code describes how to create text gradients using only pure CSS",
                    Code = @"/* CSS text gradients */
h2[data-text] {
	position: relative;
}
h2[data-text]::after {
	content: attr(data-text);
	z-index: 10;
	color: #e3e3e3;
	position: absolute;
	top: 0;
	left: 0;
	-webkit-mask-image: -webkit-gradient(linear, left top, left bottom, from(rgba(0,0,0,0)), color-stop(50%, rgba(0,0,0,1)), to(rgba(0,0,0,0)));",
                    CreatedOn = Convert.ToDateTime("22.10.2015 19:26:42")
                };

            var author = GetAuthor(context, "someUser");
            var language = GetLanguage(context, "CSS");
            var label1 = GetLabel(context, "web");
            var label2 = GetLabel(context, "front-end");

            snippet7.Author = author;
            snippet7.Language = language;
            snippet7.Labels = new List<Label>() { label1, label2 };
            context.Snippets.Add(snippet7);
        }

        private static void SeedSnippet8(SnippyContext context)
        {
            var snippet8 = new Snippet()
                {
                    Title = "Check for a Boolean value in JS",
                    Description = @"How to check a Boolean value - the wrong but funny way :D",
                    Code = @"var b = true;

if (b.toString().length < 5) {
  //...
}",
                    CreatedOn = Convert.ToDateTime("22.10.2015 05:30:04")
                };

            var author = GetAuthor(context, "admin");
            var language = GetLanguage(context, "JavaScript");
            var label1 = GetLabel(context, "funny ");

            snippet8.Author = author;
            snippet8.Language = language;
            snippet8.Labels = new List<Label>() { label1 };
            context.Snippets.Add(snippet8);
        }

        private static void SeedComments(SnippyContext context)
        {
            if (!context.Comments.Any())
            {
                var comment1 = new Comment()
                    {
                        Content = "Now that's really funny! I like it!",
                        CreatedOn = Convert.ToDateTime("30.10.2015 11:50:38")
                    };

                comment1.Author = GetAuthor(context, "admin");
                comment1.Snippet = GetSnippet(context, "Ternary Operator Madness");

                var comment2 = new Comment()
                    {
                        Content = "Here, have my comment!",
                        CreatedOn = Convert.ToDateTime("01.11.2015 15:52:42")
                    };

                comment2.Author = GetAuthor(context, "newUser");
                comment2.Snippet = GetSnippet(context, "Ternary Operator Madness");

                var comment3 = new Comment()
                    {
                        Content = "I didn't manage to comment first :(",
                        CreatedOn = Convert.ToDateTime("02.11.2015 05:30:20"),
                    };

                comment3.Author = GetAuthor(context, "someUser");
                comment3.Snippet = GetSnippet(context, "Ternary Operator Madness");

                var comment4 = new Comment()
                    {
                        Content = "That's why I love Python - everything is so simple!",
                        CreatedOn = Convert.ToDateTime("27.10.2015 15:28:14"),
                    };

                comment4.Author = GetAuthor(context, "newUser");
                comment4.Snippet = GetSnippet(context, "Reverse a String");

                var comment5 = new Comment()
                    {
                        Content =
                            "I have always had problems with Geometry in school. Thanks to you I can now do this without ever having to learn this damn subject",
                        CreatedOn = Convert.ToDateTime("29.10.2015 15:08:42")
                    };

                comment5.Author = GetAuthor(context, "someUser");
                comment5.Snippet = GetSnippet(context, "Points Around A Circle For GameObject Placement");

                var comment6 = new Comment()
                    {
                        Content =
                            "Thank you. However, I think there must be a simpler way to do this. I can't figure it out now, but I'll post it when I'm ready.",
                        CreatedOn = Convert.ToDateTime("03.11.2015 12:56:20"),
                    };

                comment6.Author = GetAuthor(context, "admin");
                comment6.Snippet = GetSnippet(context, "Numbers only in an input field");

                var comments = new List<Comment>()
                    {
                        comment1,
                        comment2,
                        comment3,
                        comment4,
                        comment5,
                        comment6
                    };

                foreach (var comment in comments)
                {
                    context.Comments.Add(comment);
                }
            }
        }

        private static User GetAuthor(SnippyContext context, string authorName)
        {
            return context.Users.FirstOrDefault(l => l.UserName == authorName);
        }

        private static Language GetLanguage(SnippyContext context, string languageName)
        {
            return context.Languages.FirstOrDefault(l => l.Name == languageName);
        }

        private static Label GetLabel(SnippyContext context, string labelName)
        {
            return context.Labels.FirstOrDefault(l => l.Text == labelName);
        }

        private static Snippet GetSnippet(SnippyContext context, string snippetName)
        {
            return context.Snippets.FirstOrDefault(l => l.Title == snippetName);
        }
    }
}