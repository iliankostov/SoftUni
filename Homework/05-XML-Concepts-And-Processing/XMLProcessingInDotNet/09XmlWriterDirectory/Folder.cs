﻿namespace XMLProcessingDotNet
{
    using System.Collections.Generic;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public IList<File> Files { get; set; }

        public IList<Folder> ChildFolders { get; set; }
    }
}
