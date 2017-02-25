namespace Photography
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    public class ImportFromXML
    {
        public static void Main()
        {
            var context = new PhotographyEntities();

            var xDocument = XDocument.Load(@"..\..\manufacturers-and-lenses.xml");

            var manufacturersAndLenses = xDocument.XPathSelectElements("/manufacturers-and-lenses/manufacturer");

            int count = 1;
            foreach (var manufacturerNode in manufacturersAndLenses)
            {
                Console.WriteLine("Processing manufacturer #{0} ...", count);
                var manufactorer = ImportManufactorer(manufacturerNode, context);

                if (manufacturerNode.Element("lenses") != null)
                {
                    ImportLenses(manufacturerNode, context, manufactorer);
                }

                context.SaveChanges();

                count++;
            }
        }

        private static Manufacturer ImportManufactorer(XElement manufacturerNode, PhotographyEntities context)
        {
            var manufactorerName = manufacturerNode.Element("manufacturer-name").Value;

            var manufactorer = new Manufacturer();
            if (!context.Manufacturers.Any(m => m.Name == manufactorerName))
            {
                manufactorer.Name = manufactorerName;
                context.Manufacturers.Add(manufactorer);
                Console.WriteLine("Created manufacturer: " + manufactorer.Name);
            }
            else
            {
                manufactorer = context.Manufacturers.FirstOrDefault(m => m.Name == manufactorerName);
                if (manufactorer != null)
                {
                    Console.WriteLine("Existing manufacturer: " + manufactorer.Name);
                }
            }
            return manufactorer;
        }

        private static void ImportLenses(XElement manufacturerNode, PhotographyEntities context, Manufacturer manufactorer)
        {
            var lenses = manufacturerNode.XPathSelectElements("lenses/lens");

            foreach (var lenseNode in lenses)
            {
                var lensModel = lenseNode.Attribute("model").Value;

                var lens = new Lens();
                if (!context.Lenses.Any(l => l.Model == lensModel))
                {
                    lens.Model = lenseNode.Attribute("model").Value;
                    lens.Type = lenseNode.Attribute("type").Value;

                    if (lenseNode.Attribute("price") != null)
                    {
                        lens.Price = decimal.Parse(lenseNode.Attribute("price").Value);
                    }

                    context.Lenses.Add(lens);
                    if (manufactorer != null)
                    {
                        manufactorer.Lenses.Add(lens);
                    }

                    Console.WriteLine("Created lens: " + lens.Model);
                }
                else
                {
                    lens = context.Lenses.FirstOrDefault(l => l.Model == lensModel);
                    if (lens != null)
                    {
                        Console.WriteLine("Existing lens: " + lens.Model);
                    }
                }
            }
        }
    }
}
