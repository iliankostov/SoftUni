namespace InfiniteRecursion
{
    internal class InfiniteRecursion
    {
        private static long Calulate(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            return Calulate(n - 1) + Calulate(n + 1);
        }

        private static void Main()
        {
            Calulate(5);
        }
    }
}