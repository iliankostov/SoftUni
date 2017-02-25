namespace AATreeTests
{
    using System;

    internal class MainTest
    {
        public static void Main(string[] args)
        {
            TestClass.Test(new[] { 1 });
            TestClass.Test(new[] { 1, 2 });
            TestClass.Test(new[] { 2, 1 });
            TestClass.Test(new[] { 1, 2, 3 });
            TestClass.Test(new[] { 2, 1, 3 });
            TestClass.Test(new[] { 1, 3, 2 });
            TestClass.Test(new[] { 2, 3, 1 });
            TestClass.Test(new[] { 3, 1, 2 });
            TestClass.Test(new[] { 3, 2, 1 });
            TestClass.Test(new[] { 1, 2, 3, 4 });
            TestClass.Test(new[] { 2, 1, 3, 4 });
            TestClass.Test(new[] { 1, 3, 2, 4 });
            TestClass.Test(new[] { 2, 3, 1, 4 });
            TestClass.Test(new[] { 3, 1, 2, 4 });
            TestClass.Test(new[] { 3, 2, 1, 4 });
            TestClass.Test(new[] { 1, 2, 4, 3 });
            TestClass.Test(new[] { 2, 1, 4, 3 });
            TestClass.Test(new[] { 1, 3, 4, 2 });
            TestClass.Test(new[] { 2, 3, 4, 1 });
            TestClass.Test(new[] { 3, 1, 4, 2 });
            TestClass.Test(new[] { 3, 2, 4, 1 });
            TestClass.Test(new[] { 1, 4, 2, 3 });
            TestClass.Test(new[] { 2, 4, 1, 3 });
            TestClass.Test(new[] { 1, 4, 3, 2 });
            TestClass.Test(new[] { 2, 4, 3, 1 });
            TestClass.Test(new[] { 3, 4, 1, 2 });
            TestClass.Test(new[] { 3, 4, 2, 1 });
            TestClass.Test(new[] { 4, 1, 2, 3 });
            TestClass.Test(new[] { 4, 2, 1, 3 });
            TestClass.Test(new[] { 4, 1, 3, 2 });
            TestClass.Test(new[] { 4, 2, 3, 1 });
            TestClass.Test(new[] { 4, 3, 1, 2 });
            TestClass.Test(new[] { 4, 3, 2, 1 });

            for (int count = 0; count < 1000; count++)
            {
                int[] a = new int[100];
                Random random = new Random();
                for (int i = 0; i < a.Length; i++)
                {
                    int r;
                    bool dup;
                    do
                    {
                        dup = false;
                        r = random.Next();
                        for (int j = 0; j < i; j++)
                        {
                            if (a[j] == r)
                            {
                                dup = true;
                                break;
                            }
                        }
                    }
                    while (dup);
                    a[i] = r;
                }

                TestClass.Test(a);
            }
        }
    }
}