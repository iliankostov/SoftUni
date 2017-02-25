using System;

class Tables
{
    static void Main()
    {
        long oneBundlePackets = long.Parse(Console.ReadLine());
        long twoBundlePackets = long.Parse(Console.ReadLine());
        long threeBundlePackets = long.Parse(Console.ReadLine());
        long fourBundlePackets = long.Parse(Console.ReadLine());
        long tableTops = long.Parse(Console.ReadLine());
        long orderedTables = long.Parse(Console.ReadLine());

        long legs = oneBundlePackets * 1L + twoBundlePackets * 2L + threeBundlePackets * 3L + fourBundlePackets * 4L;
        long legsNeeded = orderedTables * 4L;
        long tableTopsNeeded = orderedTables;
        long diffTops = 0L;
        long diffLegs = 0L;

        if (tableTops > tableTopsNeeded)
        {
            diffTops = tableTops - tableTopsNeeded;
            diffLegs = legs - legsNeeded;
            Console.WriteLine("more: {0}", diffTops);
            Console.WriteLine("tops left: {0}, legs left: {1}", diffTops, diffLegs);
        }
        else if (tableTops < tableTopsNeeded)
        {
            diffTops = tableTops - tableTopsNeeded;
            if (legs < legsNeeded)
            {
                diffLegs = legs - legsNeeded;
            }
            Console.WriteLine("less: {0}", diffTops);
            Console.WriteLine("tops needed: {0}, legs needed: {1}", Math.Abs(diffTops), Math.Abs(diffLegs));
        }
        else
        {
            Console.WriteLine("Just enough tables made: {0}", tableTops);
        }
    }
}