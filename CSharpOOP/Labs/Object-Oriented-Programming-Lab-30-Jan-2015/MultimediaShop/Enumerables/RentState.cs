namespace Enumerables
{
    public enum RentState
    {
        Pending, // current date < deadline and return date is not set
        Overdue, // current date > deadline
        Returned // return date is set
    }
}