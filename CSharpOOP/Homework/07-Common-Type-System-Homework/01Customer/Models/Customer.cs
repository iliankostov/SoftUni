namespace Models
{
    using System;
    using System.Collections.Generic;

    using Enumerations;

    internal class Customer : ICloneable, IComparable<Customer>
    {
        public Customer(string firstName, string middleName, string lastName, string id, string address, string mobilePhone, string email, List<Payment> payments, CustomerType customerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.CustomerType = customerType;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Id { get; set; }

        public string Address { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public List<Payment> Payments { get; set; }

        public CustomerType CustomerType { get; set; }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return object.Equals(c1, c2);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !object.Equals(c1, c2);
        }

        public object Clone()
        {
            var copy = this.MemberwiseClone();
            (copy as Customer).Payments = new List<Payment>();
            foreach (var payment in this.Payments)
            {
                var copyPaiment = new Payment(payment.ProductName, payment.Price);
                (copy as Customer).Payments.Add(copyPaiment);
            }

            return copy;
        }

        public int CompareTo(Customer other)
        {
            string fullName = this.FirstName + this.MiddleName + this.LastName;
            string otherFullName = other.FirstName + other.MiddleName + other.LastName;
            if (fullName.CompareTo(otherFullName) == 0)
            {
                return this.Id.CompareTo(other.Id);
            }
            else
            {
                return fullName.CompareTo(otherFullName);
            }
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            if (customer == null)
            {
                return false;
            }

            List<object> props = new List<object>()
        {
            this.FirstName, this.MiddleName, this.LastName, this.Id, this.Address, 
                                                    this.MobilePhone, this.Email, this.Payments, this.CustomerType
        };
            List<object> copyProps = new List<object>()
        {
            customer.FirstName, customer.MiddleName, customer.LastName, customer.Id, customer.Address, customer.MobilePhone, customer.Email, customer.Payments, customer.CustomerType
        };
            for (int i = 0; i < props.Count; i++)
            {
                if (!object.Equals(props[i], copyProps[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^
                       this.Id.GetHashCode() ^ this.Address.GetHashCode() ^ this.MobilePhone.GetHashCode() ^
                       this.Email.GetHashCode() ^ this.Payments.GetHashCode() ^ this.CustomerType.GetHashCode();
        }

        public override string ToString()
        {
            string output = string.Format("Customer:\n   Name: {0} {1} {2}\n   ID: {3}\n   Permanent address: {4}\n   Mobile phone: {5}\n   Email: {6}\n   Payments:", this.FirstName, this.MiddleName, this.LastName, this.Id, this.Address, this.MobilePhone, this.Email);
            foreach (var payment in this.Payments)
            {
                output += "\n      " + payment;
            }

            output += "\n   Type: " + this.CustomerType;
            output += "\n";
            return output;
        }
    }
}