using System;
using System.Text;

class Computer
{

}

class Component
{
    // Create fields
    private string name;
    private string details;
    private decimal price;

    // Create first constructor
    public Component(string name, decimal price)
    {
        this.price = price;
        this.name = name;
    }

    // Create second constructor
    public Component(string name, decimal price, string details = null) : this(name, price)
    {
        this.details = details;
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
            this.price = value;
        }
    }

    // Create and validate property Name
    public string Name
    {
        get { return this.name; }
        set
        {
            if (value == "")
            {
                throw new ArgumentNullException("The name can't be empty.");
            }
            this.name = value;
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

    // Create override ToString() method
    public override string ToString()
    {
        StringBuilder componentsStringBuild = new StringBuilder();
        if (this.Name != null)
        {
            componentsStringBuild.Append("Name: " + this.Name + ";");
        }
        componentsStringBuild.AppendLine(" Price: " + this.Price + " BGN");
        return componentsStringBuild.ToString();
    }

}

class Catalog
{
    static void Main()
    {
        Component mbAsRock = new Component( "Motherboard AsRock H81M-DG4", 96.99M,
            "Supports New 4th and 4th Generation Intel® Core™ i7/i5/i3/Xeon®/Pentium®/Celeron® Processors (Socket 1150)");
        Component mbAsus = new Component( "Motherboard Asus MAXIMUS VII IMPACT", 125.99M,
            "LGA 1150 socket for the 4th-, new 4th- and 5th-generation Intel® Core™ i3, i5, i7, Pentium® and Celeron® processors");
        Component mbMSI = new Component( "MSI AM1I Socket AM1", 77.99M);

        Component processorIntel = new Component( "Intel® Core™ i7-5550U", 250.99M, "4M Cache, up to 3.00 GHz");
        Component processorAMD = new Component( "AMD FX Processors", 100.99M);

        Component ram = new Component( "4GB DDR3", 56.99M);

        

        

    }
}