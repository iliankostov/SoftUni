using System;
using System.Text;
using Wintellect.PowerCollections;

internal class Event : IComparable
{
    private DateTime date;
    private string title;
    private string location;

    public Event(DateTime date, string title, string location)
    {
        this.date = date;
        this.title = title;
        this.location = location;
    }

    public int
    CompareTo(object obj)
    {
        Event other = obj as Event;
        int diffByDate = this.date.CompareTo(other.date);
        int diffByTitle = this.title.CompareTo(other.title);
        int diffByLocation;
        diffByLocation = this.location.CompareTo(other.location);
        if (diffByDate == 0)
        {
            if (diffByTitle == 0)
            {
                return diffByLocation;
            }              
            else
            { 
                return diffByTitle; 
            }
        }
        else
        {
            return diffByDate;
        }          
    }

    public override string ToString()
    {
        StringBuilder toString = new StringBuilder();
        toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
        toString.Append(" | " + this.title);
        if (this.location != null && this.location != string.Empty)
        {
            toString.Append(" | " + this.location);
        }

        return toString.ToString();
    }
}