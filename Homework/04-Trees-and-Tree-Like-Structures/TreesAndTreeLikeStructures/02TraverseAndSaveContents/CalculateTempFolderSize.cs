namespace TreesAndTreeLikeStructures
{
    using System;
    using System.IO;

    public class CalculateTempFolderSize
    {
        private static long size;

        public static void Main()
        {
            Console.Write("Please enter your Windows username: ");
            string input = Console.ReadLine();
            try
            {
                string username = string.IsNullOrEmpty(input) ? "Default" : input;

                string folderPath = "C:\\Users\\" + username + "\\AppData\\Local\\Temp";
                var folder = new Folder(folderPath);
                CalculateSumOfFileSizes(folder);

                Console.WriteLine(
                    "{0}'s temp folder size is {1} bytes or {2} MB",
                    string.IsNullOrEmpty(input) ? "Default" : username,
                    size,
                    size / (1024 * 1024));
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine("Invalid username or " + dnfe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CalculateSumOfFileSizes(Folder folder)
        {
            var directoryInfo = new DirectoryInfo(folder.Name);

            foreach (var file in directoryInfo.GetFiles())
            {
                folder.Files.Add(new File(file.FullName, file.Length));
                size += file.Length;
            }

            foreach (var directory in directoryInfo.GetDirectories())
            {
                var newFolder = new Folder(directory.FullName);
                folder.ChildFolders.Add(newFolder);

                CalculateSumOfFileSizes(newFolder);
            }
        }
    }
}
