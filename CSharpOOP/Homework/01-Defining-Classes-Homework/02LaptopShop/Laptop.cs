namespace LaptopShop
{
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
            : this(model, price)
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

        // Override the ToString() method
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
}