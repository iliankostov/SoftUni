namespace Photography
{
    using System;
    using System.Linq;

    public class EFCodeFirst
    {
        public static void Main()
        {
            var context = new PhonebookEntities();

            var channels = context.Channels
                .Select(
                    ch => new
                              {
                                  ch.Name,
                                  Messages = ch.ChannelMessages
                              });

            foreach (var channel in channels)
            {
                Console.WriteLine(channel.Name);
                Console.WriteLine("-- Messages: --");
                foreach (var channelMessage in channel.Messages)
                {
                    Console.WriteLine(
                        "Content: {0}, DateTime: {1}, User: {2}", 
                        channelMessage.Content, 
                        channelMessage.MessageDateTime,
                        channelMessage.User.Username);
                }

                Console.WriteLine();
            }
        }
    }
}
