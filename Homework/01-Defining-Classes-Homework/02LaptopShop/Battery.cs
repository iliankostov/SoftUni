namespace LaptopShop
{
    using System;
    using System.Text;
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
}