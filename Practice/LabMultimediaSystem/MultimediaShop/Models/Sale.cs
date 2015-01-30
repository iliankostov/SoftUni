﻿namespace MultimediaShop.Models
{
    using System;
    using Interfaces;

    public class Sale : ISellable
    {
        private Item saleItem;

        public DateTime SaleDate
        {
            get;
            set;
        }

        public Sale(Item saleItem, DateTime saleDate)
        {
            this.SaleItem = saleItem;
            this.SaleDate = saleDate;
        }
        public Sale(Item saleItem) : this(saleItem, DateTime.Now)
        {
        }

        public Item SaleItem
        {
            get 
            { 
                return this.saleItem;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Sale Item cannot be null.");
                }
                this.saleItem = value;
            }
        }
    }
}
