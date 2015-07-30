namespace ProcessingJSON
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Newtonsoft.Json.Linq;

    public class ConsoleApp
    {
        public static void Main()
        {
            var context = new ProductShopEntities();
            Console.WriteLine("Numbers of users: " + context.Users.Count());
            Console.WriteLine("Numbers of products: " + context.Products.Count());
            Console.WriteLine("Numbers of categories: " + context.Categories.Count());

            Console.Write("Please select Query number from 1 to 4: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    var productsInPriceRange =
                        context.Products.Where(p => p.Price >= 500 && p.Price <= 1000 && p.BuyerId == null)
                            .OrderBy(p => p.Price)
                            .Select(p => new
                                    {
                                        ProductName = p.Name,
                                        ProductPrice = p.Price,
                                        SellerFullName = p.Seller.FirstName ?? string.Empty + p.Seller.LastName
                                    })
                            .ToList();

                    var productsArray = new JArray();
                    foreach (var product in productsInPriceRange)
                    {
                        var element = new JObject(
                            new JProperty("name", product.ProductName),
                            new JProperty("price", product.ProductPrice),
                            new JProperty("seller", product.SellerFullName));
                        productsArray.Add(element);
                    }

                    File.WriteAllText(@"..\..\..\products-in-range.json.json", productsArray.ToString());
                    Console.WriteLine("Export products-in-range.json complited!");
                    break;
                case "2":
                    var usersWithProducts =
                        context.Users.Where(u => u.SoldProduct.Any())
                            .OrderBy(u => u.LastName)
                            .ThenBy(u => u.FirstName)
                            .Select(u => new
                                    {
                                        FirstName = u.FirstName,
                                        LastName = u.LastName,
                                        SoldProducts = u.SoldProduct.Select(p => new
                                                                                     {
                                                                                         ProductName = p.Name,
                                                                                         ProductPrice = p.Price,
                                                                                         BuyerFirstName = p.Buyer.FirstName,
                                                                                         BuyerLastName = p.Buyer.LastName
                                                                                     })
                                    })
                            .ToList();

                    var userArray = new JArray();
                    foreach (var userWithProducts in usersWithProducts)
                    {
                        var userElement = new JObject();

                        if (userWithProducts.FirstName != null)
                        {
                            userElement.Add(new JProperty("firstName", userWithProducts.FirstName));
                        }

                        userElement.Add(new JProperty("LastName", userWithProducts.LastName));

                        var productArray = new JArray();
                        foreach (var product in userWithProducts.SoldProducts)
                        {
                            var productElement = new JObject(
                                new JProperty("name", product.ProductName),
                                new JProperty("price", product.ProductPrice));

                            if (product.BuyerFirstName != null)
                            {
                                productElement.Add(new JProperty("buyerFirstName", product.BuyerFirstName));
                            }

                            productElement.Add(new JProperty("buyerLastName", product.BuyerLastName));
                            productArray.Add(productElement);
                        }

                        userElement.Add(new JProperty("soldProducts", productArray));
                        userArray.Add(userElement);
                    }

                    File.WriteAllText(@"..\..\..\users-sold-products.json", userArray.ToString());
                    Console.WriteLine("Export users-sold-products.json complited!");
                    break;
                case "3":
                    var allCategories = context.Categories
                        .OrderBy(c => c.Products.Count)
                        .Select(c => new
                                     {
                                         CategoryName = c.Name,
                                         NumberOfProducts = c.Products.Count,
                                         AveragePrice = c.Products.Average(p => p.Price),
                                         TotalSum = c.Products.Sum(p => p.Price)
                                     })
                        .ToList();

                    var categoryArray = new JArray();
                    foreach (var category in allCategories)
                    {
                        var element = new JObject(
                            new JProperty("category", category.CategoryName),
                            new JProperty("productsCount", category.NumberOfProducts),
                            new JProperty("averagePrice", category.AveragePrice),
                            new JProperty("totalRevenue", category.TotalSum));
                        categoryArray.Add(element);
                    }

                    File.WriteAllText(@"..\..\..\categories-by-products.json", categoryArray.ToString());
                    Console.WriteLine("Export categories-by-products.json complited!");

                    break;
                case "4":
                    var users = context.Users
                        .Where(u => u.SoldProduct.Any())
                        .OrderByDescending(u => u.SoldProduct.Count)
                        .ThenBy(u => u.LastName)
                        .Select(u => new
                                     {
                                         FirstName = u.FirstName,
                                         LastName = u.LastName,
                                         Age = u.Age,
                                         Products = u.SoldProduct.Select(
                                             p => new
                                                      {
                                                          p.Name,
                                                          p.Price
                                                      })
                                     });

                    XElement usersNode = new XElement("users", new XAttribute("count", users.Count()));
                    foreach (var user in users)
                    {
                        XElement userNode = new XElement("user");
                        if (user.FirstName != null)
                        {
                            userNode.Add(new XAttribute("first-name", user.FirstName));
                        }

                        userNode.Add(new XAttribute("last-name", user.LastName));

                        if (user.Age != null)
                        {
                            userNode.Add(new XAttribute("age", user.Age));
                        }

                        var productsNode = new XElement("sold-products", new XAttribute("count", user.Products.Count()));

                        foreach (var product in user.Products)
                        {
                            XElement productNode = new XElement("product", 
                                new XAttribute("name", product.Name),
                                new XAttribute("price", product.Price));
                            productsNode.Add(productNode);
                        }

                        userNode.Add(productsNode);
                        usersNode.Add(userNode);
                    }

                    XDocument xDocument = new XDocument(usersNode);
                    xDocument.Save(@"..\..\..\user-and-products.xml");
                    Console.WriteLine("Export user-and-products.xml complited!");
                    break;
                default:
                    Console.WriteLine("Wrong input.");
                    break;
            }
        }
    }
}
