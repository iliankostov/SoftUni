namespace CoreLogic
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    using CustomExceptions;
    using Enumerables;
    using Interfaces;
    using Models;
    using Models.Items;

    internal class ShopEngine
    {
        private IDictionary<IItem, int> shopSupply = new Dictionary<IItem, int>();
        private SaleManager saleManager = new SaleManager();
        private RentManager rentManager = new RentManager();

        internal void Open()
        {
            while (true)
            {
                try
                {
                    this.ReadUserInput();

                }
                catch (Exception)
                {
                    Console.WriteLine("invalid input");
                }
            }
        }

        private void ReadUserInput()
        {
            string input = Console.ReadLine();
            string command = input.Substring(0, input.IndexOf(' '));

            switch (command)
            {
                case "rent":
                    this.ProcessRentCommand(input);
                    break;
                case "report":
                    this.ProcessReportCommand(input);
                    break;
                case "sell":
                    this.ProcessSellCommand(input);
                    break;
                case "supply":
                    this.ProcessSupplyCommand(input);
                    break;
                default:
                    Console.WriteLine("wrong command");
                    break;
            }
        }

        private void ProcessRentCommand(string input)
        {
            string[] rentParameters = input.Split(' ');
            string itemId = rentParameters[1];
            DateTime rentDate = DateTime.ParseExact(rentParameters[2], "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime deadline = DateTime.ParseExact(rentParameters[3], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            if (this.ItemIsInStock(itemId))
            {
                IItem rentItem = this.GetItemById(itemId);
                this.RemoveItemFromSupply(rentItem);
                this.rentManager.AddRent(new Rent(rentItem, rentDate, deadline));
            }
            else
            {
                throw new InsufficientSuppliesException();
            }
        }

        private void ProcessReportCommand(string input)
        {
            string[] reportParameters = input.Split(' ');
            string reportType = reportParameters[1];

            switch (reportType)
            {
                case "rents":
                    var report = this.rentManager.GetOverdueRents();
                    this.PrintRents(report);
                    break;
                case "sales":
                    DateTime startDate = DateTime.ParseExact(reportParameters[2], "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    IList<ISale> salesReport = this.saleManager.GetSales(startDate);
                    this.PrintSales(salesReport);
                    break;
                default:
                    break;
            }
        }

        private void ProcessSellCommand(string input)
        {
            string[] saleParameters = input.Split(' ');
            string itemId = saleParameters[1];
            DateTime saleDate = DateTime.ParseExact(saleParameters[2], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            if (this.ItemIsInStock(itemId))
            {
                IItem saleItem = this.GetItemById(itemId);
                this.RemoveItemFromSupply(saleItem);
                this.saleManager.AddSale(new Sale(saleItem, saleDate));
            }
            else
            {
                throw new InsufficientSuppliesException();
            }
        }

        private void ProcessSupplyCommand(string input)
        {
            string supllyCommandPattern = @"[a-z]+\s([a-z]+)\s(\d+)\s(.*)";
            Match match = Regex.Match(input, supllyCommandPattern);

            IDictionary<string, string> supplyParameters = new Dictionary<string, string>();

            supplyParameters.Add("type", match.Groups[1].Value);
            supplyParameters.Add("quantity", match.Groups[2].Value);

            string[] parameterPairs = match.Groups[3].Value.Split('&');

            foreach (var pair in parameterPairs)
            {
                string[] parameterValuePair = pair.Split('=');
                supplyParameters[parameterValuePair[0]] = parameterValuePair[1];
            }

            this.AddItemToSupply(supplyParameters);
        }

        private void AddItemToSupply(IDictionary<string, string> supplyParameters)
        {
            string itemType = supplyParameters["type"];
            int quantity = int.Parse(supplyParameters["quantity"]);
            string id = supplyParameters["id"];
            string title = supplyParameters["title"];
            decimal price = decimal.Parse(supplyParameters["price"]);
            string genre = supplyParameters["genre"];

            switch (itemType)
            {
                case "book":
                    string author = supplyParameters["author"];
                    this.shopSupply.Add(new Book(id, title, price, author, genre), quantity);
                    break;
                case "game":
                    AgeRestriction ageRestriction = (AgeRestriction)Enum.Parse(
                        typeof(AgeRestriction), supplyParameters["ageRestriction"]);
                    this.shopSupply.Add(new Game(id, title, price, genre, ageRestriction), quantity);
                    break;
                case "video":
                    int lengthInMinutes = int.Parse(supplyParameters["length"]);
                    this.shopSupply.Add(new Video(id, title, price, lengthInMinutes, genre), quantity);
                    break;
                default:
                    break;
            }
        }

        private void RemoveItemFromSupply(IItem item)
        {
            this.shopSupply[item]--;

            if (this.shopSupply[item] <= 0)
            {
                this.shopSupply.Remove(item);
            }
        }

        private bool ItemIsInStock(string id)
        {
            return this.shopSupply.Keys.Any(item => item.Id == id && this.shopSupply[item] > 0);
        }

        private IItem GetItemById(string id)
        {
            return this.shopSupply.Keys.FirstOrDefault(item => item.Id == id);
        }

        private void PrintRents(IList<IRent> report)
        {
            foreach (var rent in report)
            {
                Console.WriteLine("\r\n" + rent);
            }

            Console.WriteLine();
        }

        private void PrintSales(IList<ISale> report)
        {
            foreach (var sale in report)
            {
                Console.WriteLine("\r\n" + sale);
            }

            Console.WriteLine();
        }
    }
}