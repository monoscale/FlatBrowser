using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlatBrowser.Models {
    /// <summary>
    /// Represents a physical folder within the file system. It has a collection of files.
    /// </summary>
    public class Folder {

        public int FolderId { get; set; }

        private string path;
        public string Path {
            get {
                return path;
            }
            private set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("Path may not be null or empty");
                }

                if (!Directory.Exists(value)) {
                    throw new DirectoryNotFoundException($"Could not find the path '{value}'");
                }

                path = value;
            }
        }

        public FolderCategory FolderCategory { get; set; }

        public Folder() { }

        public Folder(string path) : this(path, new FolderCategory()) { }

        public Folder(string path, FolderCategory folderCategory) {
            Path = path;
            FolderCategory = folderCategory;
        }

        public IList<File> GetFiles() {
            DirectoryInfo directory = new DirectoryInfo(Path);
            List<File> files = new List<File>();
            foreach (FileExtension extension in FolderCategory.Extensions) {
                files.AddRange(directory.GetFiles("*" + extension.Name, SearchOption.AllDirectories).Select(fi => new File(fi.FullName)));
            }
            files.Sort(new FileComparer());
            return files;
        }
    }
}