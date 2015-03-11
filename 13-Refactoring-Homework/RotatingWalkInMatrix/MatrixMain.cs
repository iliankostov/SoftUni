namespace RotatingWalkInMatrix
{
    public static class MatrixMain
    {
        private static void Main()
        {
            var n = Matrix.ReadMatrixSize();
            var matrix = Matrix.BuildMatrix(n);
            Matrix.PrintMatrix(matrix);
        }
    }
}