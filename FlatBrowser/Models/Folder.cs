using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FlatBrowser.Models {
    /// <summary>
    /// Represents a physical folder within the file system. It has a collection of files.
    /// </summary>
    public class Folder {

        private string path;
        [Key]
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

        public Folder(string path) : this(path, new FolderCategory()) { }

        public Folder(string path, FolderCategory folderCategory) {
            Path = path;
            FolderCategory = folderCategory;
        }

        public IList<File> GetFiles() {
            DirectoryInfo directory = new DirectoryInfo(Path);
            List<FileInfo> tmpFiles = new List<FileInfo>();

            foreach (FileExtension fileExtension in FolderCategory.Extensions) {
                string extName = fileExtension.Name;
                tmpFiles.AddRange(directory.GetFiles("*" + extName, SearchOption.AllDirectories));
            }

            List<File> files = tmpFiles.Select(f => new File(f.FullName)).ToList();
            files.Sort(new FileComparer());
            return files;
        }
    }
}