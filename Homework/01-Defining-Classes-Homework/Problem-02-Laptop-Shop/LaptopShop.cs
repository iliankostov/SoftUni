using System;
using System.Text;

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
    private Battery battery;

    // Create first constructor
    public Laptop(string model, decimal price)
    {
        this.Model = model;
        this.Price = price;
    }

    // Create second constructor
    public Laptop(string model, decimal price, string manufacturer = null, string processor = null, 
        byte ram = 0, string graphicsCard = null, ushort hdd = 0, string screen = null, 
        string batteryType = null, float batteryLife = 0F) 
        : this (model, price)
    {
        
        this.Manufacturer = manufacturer;
        this.Processor = processor;
        this.Ram = ram;
        this.GraphicsCard = graphicsCard;
        this.Hdd = hdd;
        this.Screen = screen;
        this.Battery = new Battery(batteryType, batteryLife);
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

    // Create and validate property Battery
    public Battery Battery
    {
        get { return this.battery; }
        set { this.battery = value; }
    }

    // Create override the ToString() method
    public override string ToString()
    {
        StringBuilder laptopStringBuild = new StringBuilder();
        laptopStringBuild.AppendLine("model: " + this.Model);
        if (this.Manufacturer != null)
        {
            laptopStringBuild.AppendLine("manufacturer: " + this.Manufacturer);
        }
        if (this.Processor != null)
        {
            laptopStringBuild.AppendLine("processor: " + this.Processor);
        }
        if (this.Ram != 0)
        {
            laptopStringBuild.AppendLine("RAM: " + this.Ram + " GB");
        }
        if (this.GraphicsCard != null)
        {
            laptopStringBuild.AppendLine("graphics card: " + this.GraphicsCard);
        }
        if (this.Hdd != 0)
        {
            laptopStringBuild.AppendLine("HDD: " + this.Hdd + "GB SSD");
        }
        if (this.Screen != null)
        {
            laptopStringBuild.AppendLine("screen: " + this.Screen);
        }
        if (this.Battery != null)
        {
            laptopStringBuild.AppendLine(this.Battery.ToString());
        }
        laptopStringBuild.AppendLine("price: " + this.Price + " lv");
        return laptopStringBuild.ToString();
    }

}

class Battery
{
    // Create fields
    private string batteryType;
    private float batteryLife;

    // Create first constructor
    public Battery(string batteryType = null)
    {
        this.BatteryType = batteryType;
    }

    // Create second constructor
    public Battery(string batteryType = null, float batteryLife = 0F) 
        : this(batteryType)
    {
        this.BatteryLife = batteryLife;
    }

    // Create and validate property BatteryType
    public string BatteryType
    {
        get { return this.batteryType; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The battery's field can't be empty");
            }
            this.batteryType = value;
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

    // Create override the ToString() method
    public override string ToString()
    {
        StringBuilder batteryStringBuild = new StringBuilder();
        if (this.BatteryType != null)
        {
            batteryStringBuild.AppendLine("battery: " + this.BatteryType);
        }
        if (this.BatteryLife != 0F)
        {
            batteryStringBuild.Append("battery life: " + this.BatteryLife + " hours");
        }
        return batteryStringBuild.ToString();
    }
}

class LaptopShop
{
    static void Main()
    {
        Laptop lenovo = new Laptop("Lenovo Yoga 2 Pro", 2259.00M, "Lenovo", 
            "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", 
            8, "Intel HD Graphics 4400", 128, "13.3\"(33.78 cm) – 3200 x 1800(QHD +), IPS sensor display",
            "Li-Ion, 4-cells, 2550 mAh", 4.5F);

        Laptop hp = new Laptop("HP 250 G2", 699.00M);

        Console.WriteLine(lenovo);
        Console.WriteLine(hp);
    }
}