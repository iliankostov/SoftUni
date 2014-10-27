using System;

class ZeroSubset
{
    static void Main()
    {
        string input = Console.ReadLine();
        long[] number = SplitStringsToInts(input);
        long a = number[0];
        long b = number[1];
        long c = number[2];
        long d = number[3];
        long e = number[4];

        if (a + b == 0)
            Console.WriteLine("{0} + {1} = 0", a, b);           
        if (a + c == 0)
            Console.WriteLine("{0} + {1} = 0", a, c);
        if (a + d == 0)
            Console.WriteLine("{0} + {1} = 0", a, d);
        if (a + e == 0)
            Console.WriteLine("{0} + {1} = 0", a, e);
        if (b + c == 0)
            Console.WriteLine("{0} + {1} = 0", b, c);
        if (b + d == 0)
            Console.WriteLine("{0} + {1} = 0", b, d);
        if (b + e == 0)
            Console.WriteLine("{0} + {1} = 0", b, e);
        if (c + d == 0)
            Console.WriteLine("{0} + {1} = 0", c, d);
        if (c + e == 0)
            Console.WriteLine("{0} + {1} = 0", c, e);
        if (d + e == 0)
            Console.WriteLine("{0} + {1} = 0", d, e);       
        if (a + b + c == 0)
            Console.WriteLine("{0} + {1} + {2} = 0", a, b, c);
        if (a + b + d == 0)
            Console.WriteLine("{0} + {1} + {2} = 0", a, b, d);
        if (a + b + e == 0)
            Console.WriteLine("{0} + {1} + {2} = 0", a, b, e);
        if (a + c + d == 0)
            Console.WriteLine("{0} + {1} + {2} = 0", a, c, d);
        if (a + c + e == 0)
            Console.WriteLine("{0} + {1} + {2} = 0", a, c, e);
        if (a + d + e == 0)
            Console.WriteLine("{0} + {1} + {2} = 0", a, d, e);     
        if (b + c + d == 0)
            Console.WriteLine("{0} + {1} + {2} = 0", b, c, d);
        if (b + c + e == 0)
            Console.WriteLine("{0} + {1} + {2} = 0", b, c, e);
        if (b + d + e == 0)
            Console.WriteLine("{0} + {1} + {2} = 0", b, d, e);     
        if (c + d + e == 0)
            Console.WriteLine("{0} + {1} + {2} = 0", c, d, e);       
        if (a + b + c + d == 0)
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, c, d);
        if (a + b + c + e == 0)
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, c, e);
        if (a + b + d + e == 0)
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, d, e);
        if (a + c + d + e == 0)
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, c, d, e);
        if (b + c + d + e == 0)
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", b, c, d, e);
        if (a + b + c + d + e == 0)
            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", a, b, c, d, e);
        else
            Console.WriteLine("no zero subset");
    }
    private static long[] SplitStringsToInts(string s)
    {
        string[] strArray = s.Split(' ');
        long[] intArray = new long[strArray.Length];

        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = long.Parse(strArray[i]);
        }
        return intArray;
    }
}