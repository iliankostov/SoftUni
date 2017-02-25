namespace Photography
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using Photography.Models;

    public class ImportFromJSON
    {
        public static void Main()
        {
            var context = new PhonebookEntities();

            var jsonString = File.ReadAllText(@"..\..\messages.json");

            var messagesArray = JsonConvert.DeserializeObject<List<JsonMessage>>(jsonString);

            foreach (var message in messagesArray)
            {
                try
                {
                    ImportNewMessage(message, context);
                    Console.WriteLine("Message \"{0}\" imported", message.Content);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("Error: " + ioe.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ImportNewMessage(JsonMessage message, PhonebookEntities context)
        {
            if (message.Content == null)
            {
                throw new InvalidOperationException("Content is required");
            }

            if (message.DateTime == null)
            {
                throw new InvalidOperationException("DateTime is required");
            }

            if (message.Recipient == null)
            {
                throw new InvalidOperationException("Recipient is required");
            }

            if (message.Sender == null)
            {
                throw new InvalidOperationException("Sender is required");
            }

            var recipientId = context.Users
                .Where(u => u.Username == message.Recipient)
                .Select(u => u.Id)
                .FirstOrDefault();

            var senderId = context.Users
                .Where(u => u.Username == message.Sender)
                .Select(u => u.Id)
                .FirstOrDefault();

            var newMessage = new UserMessages()
                                 {
                                     Content = message.Content,
                                     MessageDateTime = Convert.ToDateTime(message.DateTime),
                                     RecipientUserId = recipientId,
                                     SenderUserId = senderId
                                 };

            context.UserMessageses.Add(newMessage);
            context.SaveChanges();
        }
    }
}
