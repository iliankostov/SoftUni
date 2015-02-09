namespace StudentClass
{
    using System;

    public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs eventArgs);

    public class Student
    {
        private string name;
        private int age;
        private PropertyChangedEventArgs changedArgs;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name should be at lest two characters");
                }

                if (value != this.Name)
                {
                    this.changedArgs = new PropertyChangedEventArgs("Name", this.Name, value);
                    this.OnPropertyChanged(this, this.changedArgs);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get 
            { 
                return this.age; 
            }

            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentOutOfRangeException("Age shoul be a number in the range [0....150]");
                }

                if (value != this.Age)
                {
                    this.changedArgs = new PropertyChangedEventArgs("Age", this.Age.ToString(), value.ToString());
                    this.OnPropertyChanged(this, this.changedArgs);
                }

                this.age = value;
            }
        }

        protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs changedArgs)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, changedArgs);
            }
        }
    }
}