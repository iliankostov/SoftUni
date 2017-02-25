namespace Photography
{
    using System;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    public class ExportJSON
    {
        public static void Main()
        {
            var context = new PhotographyEntities();

            var manufactorers = context.Manufacturers
                .Select(m => new
                             {
                                 manufacturer = m.Name,
                                 cameras = m.Cameras
                                                .Select(c => new
                                                              {
                                                                  model = c.Model,
                                                                  price = c.Price
                                                              })
                                                .OrderBy(c => c.model)
                             })
                .OrderBy(m => m.manufacturer);

            var output = JsonConvert.SerializeObject(manufactorers);
            File.AppendAllText(@"..\..\manufactureres-and-cameras.json", output);
            Console.WriteLine("Export manufactureres-and-cameras.json complited!");
        }
    }
}
