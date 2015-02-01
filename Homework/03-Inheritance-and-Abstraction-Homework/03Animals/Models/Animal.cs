namespace Animals
{
    using System;

    public abstract class Animal
    {
        private string name;
        private int age;
        private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }

            set
            {
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
                this.age = value;
            }
        }

        public Gender Gender 
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }
    }
}