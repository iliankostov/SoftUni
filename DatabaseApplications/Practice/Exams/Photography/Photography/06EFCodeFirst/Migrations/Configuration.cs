namespace Photography.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Photography.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PhonebookEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhonebookEntities context)
        {
            if (!context.Users.Any() && !context.Channels.Any())
            {
                var vGeorgiev = new User()
                                    {
                                        Username = "VGeorgiev",
                                        FullName = "Vladimir Georgiev",
                                        PhoneNumber = "0894545454"
                                    };
                var nakov = new User()
                                {
                                    Username = "Nakov",
                                    FullName = "Svetlin Nakov",
                                    PhoneNumber = "0897878787"
                                };

                var ache = new User()
                               {
                                   Username = "Ache",
                                   FullName = "Angel Georgiev",
                                   PhoneNumber = "0897121212"
                               };

                var alex = new User()
                               {
                                   Username = "Aleks",
                                   FullName = "Alexandra Svilarova",
                                   PhoneNumber = "0894151417"
                               };

                var petya = new User()
                                {
                                    Username = "Petya",
                                    FullName = "Petya Grozdarska",
                                    PhoneNumber = "0895464646"
                                };

                context.Users.AddRange(new List<User>() { vGeorgiev, nakov, ache, alex, petya });
                context.SaveChanges();

                var malinki = new Channel() { Name = "Malinki" };
                var softUni = new Channel() { Name = "SoftUni" };
                var admins = new Channel() { Name = "Admins" };
                var programmers = new Channel() { Name = "Programmers" };
                var geeks = new Channel() { Name = "Geeks" };

                context.Channels.AddRange(new List<Channel>() { malinki, softUni, admins, programmers, geeks });
                context.SaveChanges();

                var malinkiId = context.Channels.FirstOrDefault(ch => ch.Name == "Malinki");
                var petyaId = context.Users.FirstOrDefault(u => u.Username == "Petya");
                var nakovId = context.Users.FirstOrDefault(u => u.Username == "Nakov");
                var vGeorgievId = context.Users.FirstOrDefault(u => u.Username == "VGeorgiev");

                var chanelMessageOne = new ChannelMessage()
                                            {
                                                Chanel = malinkiId,
                                                Content = "Hey dudes, are you ready for tonight?",
                                                MessageDateTime = DateTime.Now,
                                                User = petyaId
                                            };

                var chanelMessageTwo = new ChannelMessage()
                                            {
                                                Chanel = malinkiId,
                                                Content = "Hey Petya, this is the SoftUni chat.",
                                                MessageDateTime = DateTime.Now,
                                                User = vGeorgievId
                                            };
                var chanelMessageThree = new ChannelMessage()
                                            {
                                                Chanel = malinkiId,
                                                Content = "Hahaha, we are ready!",
                                                MessageDateTime = DateTime.Now,
                                                User = nakovId
                                            };
                var chanelMessageFour = new ChannelMessage()
                                            {
                                                Chanel = malinkiId,
                                                Content = "Oh my god. I mean for drinking beers!",
                                                MessageDateTime = DateTime.Now,
                                                User = petyaId
                                            };
                var chanelMessageFive = new ChannelMessage()
                                            {
                                                Chanel = malinkiId,
                                                Content = "We are sure!",
                                                MessageDateTime = DateTime.Now,
                                                User = vGeorgievId
                                            };

                context.ChannelMessages.AddRange(
                    new List<ChannelMessage>()
                        {
                            chanelMessageOne,
                            chanelMessageTwo,
                            chanelMessageThree,
                            chanelMessageFour,
                            chanelMessageFive
                        });

                context.SaveChanges();
            }
        }
    }
}
