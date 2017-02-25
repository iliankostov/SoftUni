namespace CohesionAndCoupling.StringUtils
{
    public class FileNameUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".", System.StringComparison.Ordinal);
            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }
            else
            {
                return fileName.Substring(indexOfLastDot + 1);
            }
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".", System.StringComparison.Ordinal);

            if (indexOfLastDot == -1)
            {
                return fileName;
            }
            else
            {
                return fileName.Substring(0, indexOfLastDot);
            }
        }
    }
}