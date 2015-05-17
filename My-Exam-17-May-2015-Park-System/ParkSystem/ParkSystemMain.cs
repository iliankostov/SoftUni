namespace ParkSystem
{
    using System.Globalization;
    using System.Threading;

    public class ParkSystem
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; 
            var engine = new Engine(); 
            engine.Run();
        }
    }
}