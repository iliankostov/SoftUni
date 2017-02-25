namespace Catalog
{
    using System;
    using System.Linq;
    class CatalogMain
    {
        static void Main()
        {
            // Creating components
            Component processorIntel = new Component("Intel Core i7-5550U", 250.99M, "4M Cache, up to 3.00 GHz");
            Component processorAMD = new Component("AMD FX Processors", 100.99M);

            Component gpuNvidia = new Component("Nvidia GeForce GTX990", 199.99M);
            Component gpuAMD = new Component("AMD Radeon R9", 149.99M);

            Component mbAsRock = new Component("Motherboard AsRock H81M-DG4", 96.99M,
                "Supports Intel Core i7/i5/i3/Xeon/Pentium/Celeron");
            Component mbAsus = new Component("Motherboard Asus MAXIMUS VII IMPACT", 125.99M,
                "Supports Intel Core i3, i5, i7, Pentium and Celeron");
            Component mbMSI = new Component("MSI AM1I Socket AM1", 77.99M);

            Component ram4GB = new Component("4GB DDR3", 56.99M);
            Component ram8GB = new Component("8GB DDR3", 96.99M);

            // Assembling components
            Component[] powerPC = new Component[] { processorIntel, gpuNvidia, mbAsus, ram8GB };
            Component[] optimizedPC = new Component[] { processorIntel, gpuAMD, mbAsRock, ram8GB };
            Component[] cheapPC = new Component[] { processorAMD, gpuAMD, mbMSI, ram4GB };

            // Create computers
            Computer asus = new Computer("Desktop PC Asus", powerPC);
            Computer asrock = new Computer("Desktop PC AsRock", optimizedPC);
            Computer msi = new Computer("Desktop PC MSI", cheapPC);

            // Put computers in the catalog
            Computer[] allPC = new Computer[] { asus, msi, asrock };

            // Sort computers by total price
            // OrderBy sort ascending acording to a key. If you need descending use OrderByDescending !
            Computer[] sortedPC = allPC.OrderBy(d => d.TotalPrice).ToArray();

            foreach (Computer computer in sortedPC)
            {
                Console.WriteLine(computer);
            }
        }
    }
}