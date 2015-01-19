using System;

class Laptop
{
    // Create fields
    private string model;
    private string manufacturer;
    private string processor;
    private byte ram;
    private string graphicsCard;
    private ushort hdd;
    private string screen;
    private decimal price;

    // Create first constructor
    public Laptop(string model, string manufacturer, string processor, byte ram, string graphicsCard,
        ushort hdd, string screen, string battery, float batteryLife, decimal price)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Processor = processor;
        this.Ram = ram;
        this.GraphicsCard = graphicsCard;
        this.Hdd = hdd;
        this.Screen = screen;
        this.Price = price;
    }

    // Create and validate property Model
    public string Model
    {
        get { return this.model; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The model's field can't be empty");
            }
            this.model = value;
        }
    }

    // Create and validate property Manufacturer
    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The manufacturer's field can't be empty");
            }
            this.manufacturer = value;
        }
    }

    // Create and validate property Processor
    public string Processor
    {
        get { return this.processor; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The processor's field can't be empty");
            }
            this.processor = value;
        }
    }

    // Create and validate property Ram
    public byte Ram
    {
        get { return this.ram; }
        set
        {
            if (value < 0)
            {
                throw new Exception("The ram value can't be negative");
            }
            this.ram = value;
        }
    }

    // Create and validate property GraphicsCard
    public string GraphicsCard
    {
        get { return this.graphicsCard; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The graphics card field can't be empty");
            }
            this.graphicsCard = value;
        }
    }

    // Create and validate property Hdd
    public ushort Hdd
    {
        get { return this.hdd; }
        set
        {
            if (value < 0)
            {
                throw new Exception("The hdd value can't be negative");
            }
            this.hdd = value;
        }
    }

    // Create and validate property Screen
    public string Screen
    {
        get { return this.screen; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The screen's field can't be empty");
            }
            this.screen = value;
        }
    }

    // Create and validate property Price
    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new Exception("The price value can't be empty");
            }
            this.price = value;
        }
    }

}

class Battery : Laptop
{
    // Create fields
    private string battery;
    private float batteryLife;

    // Create and validate property Battery
    public string BatteryProp
    {
        get { return this.battery; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The battery's field can't be empty");
            }
            this.battery = value;
        }
    }

    // Create and validate property BatteryLife
    public float BatteryLife
    {
        get { return this.batteryLife; }
        set
        {
            if (value < 0)
            {
                throw new Exception("The batteryLife value can't be empty");
            }
            this.batteryLife = value;
        }      
    }
}

class MainProgram
{
    static void Main()
    {

    }
}