namespace XMLProcessingInDotNet
{
    using System.IO;
    using System.Xml.Linq;

    public class XElementDirectory
    {
        private static XDocument xDocument = new XDocument();

        private static string folderPath = @"C:\Media\";

        private static bool isRoot = true;

        public static void Main()
        {
            var folder = new Folder(folderPath);
            xDocument.Add(RecursiveDirectoryTraversal(folder));
            xDocument.Save("../../XElementDirectory.xml");
        }

        private static XElement RecursiveDirectoryTraversal(Folder folder)
        {
            var directoryInfo = new DirectoryInfo(folder.Name);

            var dirElement = new XElement(isRoot ? "root-dir" : "dir", new XAttribute("name", folder.Name));
            isRoot = false;

            foreach (var file in directoryInfo.GetFiles())
            {
                folder.Files.Add(new File(file.FullName));
                var fileElement = new XElement("file", new XAttribute("name", file.Name));
                dirElement.Add(fileElement);
            }

            foreach (var directory in directoryInfo.GetDirectories())
            {
                var childFolder = new Folder(directory.FullName);
                folder.ChildFolders.Add(childFolder);

                dirElement.Add(RecursiveDirectoryTraversal(childFolder));
            }

            return dirElement;
        }
    }
}
