namespace GenericListVersion
{
    using System;

    [AttributeUsage(
        AttributeTargets.Struct |
        AttributeTargets.Class |
        AttributeTargets.Interface |
        AttributeTargets.Method |
        AttributeTargets.Enum)]

    public class GenericListVersion : System.Attribute
    {
        public GenericListVersion(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major { get; private set; }

        public int Minor { get; private set; }

        public override string ToString()
        {
            return this.Major + "." + this.Minor;
        }
    }
}
