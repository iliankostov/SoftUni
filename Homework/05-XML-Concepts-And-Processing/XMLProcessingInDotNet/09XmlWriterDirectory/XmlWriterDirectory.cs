namespace XMLProcessingDotNet
{
    using System.IO;
    using System.Xml;

    public class XmlWriterDirectory
    {
        private static XmlWriter writer = XmlWriter.Create("../../XmlWriterDirectory.xml");

        private static string folderPath = @"C:\Media";

        public static void Main()
        {
            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root-dir");
                writer.WriteAttributeString("path", folderPath);

                var folder = new Folder(folderPath);
                RecursiveDirectoryTraversal(folder);

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        private static void RecursiveDirectoryTraversal(Folder folder)
        {
            var directoryInfo = new DirectoryInfo(folder.Name);

            foreach (var file in directoryInfo.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);

                folder.Files.Add(new File(file.FullName));

                writer.WriteEndElement();
            }

            foreach (var directory in directoryInfo.GetDirectories())
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", directory.Name);

                var childFolder = new Folder(directory.FullName);
                folder.ChildFolders.Add(childFolder);
                RecursiveDirectoryTraversal(childFolder);
                
                writer.WriteEndElement();
            }
        }
    }
}
