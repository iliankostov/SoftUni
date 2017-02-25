﻿namespace Chepelare.Models
{
    using System;

    using Chepelare.Contracts;

    public class Booking : IDbEntity
    {
        private decimal totalPrice;

        // BUG: set client
        public Booking(User client, DateTime startBookDate, DateTime endBookDate, decimal totalPrice, string comments)
        {
            if (this.EndBookDate < this.StartBookDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }

            this.Client = client;
            this.StartBookDate = startBookDate;
            this.EndBookDate = endBookDate;
            this.TotalPrice = totalPrice;
            this.Comments = comments;
        }

        public int Id { get; set; }

        public User Client { get; private set; }

        public string Comments { get; private set; }

        public DateTime StartBookDate { get; private set; }

        public DateTime EndBookDate { get; private set; }

        public decimal TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The total price must not be less than 0.");
                }
                this.totalPrice = value;
            }
        }  
    }
}