namespace StudentClass
{
    using System;

    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangedEventArgs(string property, string oldValue, string newValue)
        {
            this.Property = property;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        public string Property { get; private set; }

        public string OldValue { get; private set; }

        public string NewValue { get; private set; }      
    }
}