namespace ConsoleForum.Entities.Posts
{
    using System.Collections.Generic;

    using ConsoleForum.Contracts;

    public class Post : IPost
    {
        public Post(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
        }

        public int Id { get; set; }

        public string Body { get; set; }

        public IUser Author { get; set; }
    }
}
