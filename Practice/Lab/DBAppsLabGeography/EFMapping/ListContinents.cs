namespace EFMapping
{
    using System;

    public class ListContinents
    {
        public static void Main()
        {
            var context = new GeographyEntities();
            foreach (var continent in context.Continents)
            {
                Console.WriteLine(continent.ContinentName);
            }
        }
    }
}
