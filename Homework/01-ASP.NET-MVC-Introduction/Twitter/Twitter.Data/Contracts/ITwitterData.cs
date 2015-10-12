﻿namespace Twitter.Data.Contracts
{
    using Twitter.Models;

    public interface ITwitterData
    {
        IRepository<Tweet> Tweets { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Message> Messages { get; }

        IRepository<Report> Reports { get; }

        void SaveChanges();
    }
}