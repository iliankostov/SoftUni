namespace ProcessingJSON.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductShopEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ProductShopEntities context)
        {
            if (!context.Users.Any())
            {
                var userXmlPath = @"..\..\..\users.xml";

                var xDocument = XDocument.Load(userXmlPath);

                foreach (XElement user in xDocument.Root.Descendants("user"))
                {
                    string firstName = null;
                    int? age = null;

                    if (user.Attribute("first-name") != null)
                    {
                        firstName = user.Attribute("first-name").Value;
                    }

                    if (user.Attribute("age") != null)
                    {
                        age = int.Parse(user.Attribute("age").Value);
                    }

                    var newUser = new User
                                      {
                                          FirstName = firstName,
                                          LastName = user.Attribute("last-name").Value,
                                          Age = age
                                      };

                    context.Users.Add(newUser);
                }

                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var userIds = context.Users.Select(u => u.Id);

                var productsJsonPath = @"..\..\..\products.json";

                var productsJson = File.ReadAllText(productsJsonPath);

                var products = JsonConvert.DeserializeObject<List<Product>>(productsJson);

                for (int i = 0; i < products.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        products[i].BuyerId = userIds.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                    }

                    products[i].SellerId = userIds.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

                    context.Products.Add(products[i]);
                }

                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                var categoriesJsonPath = @"..\..\..\categories.json";

                var categoriesJson = File.ReadAllText(categoriesJsonPath);

                var categoriesArray = JArray.Parse(categoriesJson);

                var categoriesList = new List<Category>();

                foreach (var categoryElement in categoriesArray)
                {
                    var categoryName = categoryElement["name"].ToString();
                    var category = new Category { Name = categoryName };
                    categoriesList.Add(category);
                    context.Categories.Add(category);
                }

                foreach (var product in context.Products)
                {
                    product.Categories.Add(categoriesList.OrderBy(x => Guid.NewGuid()).FirstOrDefault());
                }

                context.SaveChanges();
            }
        }
    }
}
