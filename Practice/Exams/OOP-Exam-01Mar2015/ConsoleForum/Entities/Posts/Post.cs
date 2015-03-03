namespace ConsoleForum.Entities.Posts
{
    using System;
    using Contracts;

    internal class Post : IPost
    {
        private int id;

        public Post(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;

        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value < 1)
                {
                    throw new IndexOutOfRangeException("The id cannot be small than 1");
                }
                this.id = value;
            }
        }

        public string Body
        {
            get;
            set;
        }

        public IUser Author
        {
            get;
            set;
        }
    }
}
