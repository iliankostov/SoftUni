﻿namespace MultimediaShop
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using CoreLogic;
    using Models;

    internal class MainShop
    {
        internal static void Main()
        {
            //// Step 3 – Test Your Classes
            // Item sallingerBook = new Book("4adwlj4", "Catcher in the Rye", 20.00m, "J. D. Salinger", "fiction");
            // Item threeManBook = new Book("84djesd", "Three Men in a Boat", 39.99m, "Jerome K. Jerome", new List<string> { "comedy" });
            // Item acGame = new Game("9gkjdsa", "AC Revelations", 78.00m, "historical", AgeRestriction.Teen);
            // Item bubbleSplashGame = new Game("r8743jf", "Bubble Splash", 7.80m, new List<string> { "child", "fun" });
            // Item godfatherMovie = new Video("483252j", "The Godfather", 99.00m, 178, "crime");
            // Item dieHardMovie = new Video("9853kfds", "Die Hard 4", 9.90m, 144, new List<string> { "action", "crime", "thriller" });

            //// Step 4 - Test Your Classes
            // DateTime today = DateTime.Now;
            // DateTime fiveYearsAgo = today.AddYears(-5);
            // Sale dieHardSale = new Sale(dieHardMovie, fiveYearsAgo);
            // Console.WriteLine(dieHardSale.SaleDate); // 1/30/2010 2:31:55 PM
            // Sale acSale = new Sale(acGame);
            // Console.WriteLine(acSale.SaleDate); // Today
            // DateTime afterOneWeek = today.AddDays(30);
            // Rent bookRent = new Rent(sallingerBook, today, afterOneWeek);
            // Console.WriteLine(bookRent.RentState); // Pending
            // DateTime lastMonth = today.AddDays(-34);
            // DateTime lastWeek = today.AddDays(-8);
            // Rent movieRent = new Rent(godfatherMovie, lastMonth, lastWeek);
            // Console.WriteLine(movieRent.RentState); // Overdue
            // movieRent.ReturnItem();
            // Console.WriteLine(movieRent.RentState); // Returned
            // Console.WriteLine(movieRent.ReturnDate); // Today
            // Console.WriteLine(movieRent.RentFine); // 7.9200
        }
    }
}