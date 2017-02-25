namespace Chepelare
{
    using System;
    using System.Globalization;
    using System.Threading;

    internal class App
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // var engine = Activator.CreateInstance(typeof(Engine)) as Engine;

            var engine = new Engine();
            engine.StartOperation();
        }
    }
}