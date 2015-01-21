using System;
using System.Linq;
using System.Text;

class Computer
{
    // Create fields
    private string name;
    private Component[] components;

    // Create constructor
    public Computer(string name, Component[] components)
    {
        this.Name = name;
        this.Components = components;
    }

    // Create and validate property Name
    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The name can't be empty.");
            }
            this.name = value;
        }
    }

    // Create array property Components
    public Component[] Components
    {
        get { return this.components; }
        set { this.components = value; }
    }

    // Create and calculate property TotalPrice
    public decimal TotalPrice
    {
        get {
            decimal sum = 0M;
            foreach (Component component in Components)
            {
                sum += component.Price;
            }
            return sum;
        }
    }

    // Override ToString() method
    public override string ToString()
    {
        StringBuilder computerStringBuild = new StringBuilder();
        computerStringBuild.AppendLine("Name: " + this.Name);
        computerStringBuild.AppendLine("Components:");
        foreach (Component component in Components)
        {
            computerStringBuild.AppendLine(component.ToString());
        }
        computerStringBuild.AppendLine("Total Price: " + this.TotalPrice + " BGN");
        return computerStringBuild.ToString();
    }
}

class Component
{
    // Create fields
    private string name;
    private string details; // I haven't got condition to display details.
    private decimal price;

    // Create first constructor
    public Component(string name, decimal price)
    {
        this.Price = price;
        this.Name = name;
    }

    // Create second constructor
    public Component(string name, decimal price, string details = null) : this(name, price)
    {
        this.Details = details;
    }

    // Create and validate property Name
    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The name can't be empty.");
            }
            this.name = value;
        }
    }

    // Create and validate property Price
    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0M)
            {
                throw new IndexOutOfRangeException("The price can not be negative.");
            }
            this.price = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }

    // Create and validate property Details
    public string Details
    {
        get { return this.details; }
        set
        {
            if (value == "")
            {
                throw new ArgumentNullException("The details can't be empty.");
            }
        }
    }

    // Override ToString() method
    public override string ToString()
    {
        StringBuilder componentsStringBuild = new StringBuilder();
        if (this.Name != null)
        {
            componentsStringBuild.Append("Name: " + this.Name + "; ");
        }
        componentsStringBuild.Append("Price: " + this.Price + " BGN");
        return componentsStringBuild.ToString();
    }

}

class Catalog
{
    static void Main()
    {
        // Creating components
        Component processorIntel = new Component("Intel® Core™ i7-5550U", 250.99M, "4M Cache, up to 3.00 GHz");
        Component processorAMD = new Component("AMD FX Processors", 100.99M);

        Component gpuNvidia = new Component("Nvidia GeForce GTX990", 199.99M);
        Component gpuAMD = new Component("AMD Radeon R9", 149.99M);

        Component mbAsRock = new Component( "Motherboard AsRock H81M-DG4", 96.99M,
            "Supports New 4th and 4th Generation Intel® Core™ i7/i5/i3/Xeon®/Pentium®/Celeron® Processors (Socket 1150)");
        Component mbAsus = new Component( "Motherboard Asus MAXIMUS VII IMPACT", 125.99M,
            "LGA 1150 socket for the 4th-, new 4th- and 5th-generation Intel® Core™ i3, i5, i7, Pentium® and Celeron® processors");
        Component mbMSI = new Component( "MSI AM1I Socket AM1", 77.99M);

        Component ram4GB = new Component( "4GB DDR3", 56.99M);
        Component ram8GB = new Component("8GB DDR3", 96.99M);

        // Assembling components
        Component[] powerPC = new Component[] { processorIntel, gpuNvidia, mbAsus, ram8GB };
        Component[] optimizedPC = new Component[] { processorIntel, gpuAMD, mbAsRock, ram8GB };
        Component[] cheapPC = new Component[] { processorAMD, gpuAMD, mbMSI, ram4GB };

        // Create computers
        Computer asus = new Computer("Desktop PC Asus", powerPC);
        Computer asrock = new Computer("Desktop PC AsRock", optimizedPC);
        Computer msi = new Computer("Desktop PC MSI", cheapPC);

        // Put coputers in the catalog
        Computer[] allPC = new Computer[] { asus, msi, asrock };

        // Sort by total price
        // OrderBy sort ascending acording to a key. If you need descending use OrderByDescending !
        Computer[] sorted = allPC.OrderBy(c => c.TotalPrice).ToArray();

        foreach (Computer computer in sorted)
        {
            Console.WriteLine(computer);
        }
    }
}