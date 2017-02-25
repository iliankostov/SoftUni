namespace Photography
{
    using System;
    using System.Linq;

    public class EFDatabaseFirstTest
    {
        public static void Main()
        {
            var context = new PhotographyEntities();

            var cameras = context.Cameras
                .Select(c => new
                             {
                                 c.Model,
                                 Manufactorer = c.Manufacturer.Name
                             })
                .OrderBy(c => c.Manufactorer)
                .ThenBy(c => c.Model);

            foreach (var camera in cameras)
            {
                Console.WriteLine(camera.Manufactorer + ' ' + camera.Model);
            }
        }
    }
}
