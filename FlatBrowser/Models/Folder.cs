using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;

namespace FlatBrowser.Models {
    /// <summary>
    /// Represents a physical folder within the file system. It has a collection of files.
    /// </summary>
    public class Folder {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FolderId { get; set; }

        private string path;
        /// <summary>
        /// Gets the absolute path to the folder.
        /// </summary>
        public string Path {
            get {
                return path;
            }
            private set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("[Setter] Folder.Path can not be null or empty.");
                }

                if (!Directory.Exists(value)) {
                    throw new DirectoryNotFoundException($"[Setter] Folder.Path: could not find the path '{value}'.");
                }

                path = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="FolderCategory"/> object this Folder belongs to.
        /// </summary>
        public FolderCategory FolderCategory { get; set; }

        /// <summary>
        /// Empty constructor for Entity Framework.
        /// </summary>
        private Folder() { }

        /// <summary>
        /// Constructs a <see cref="Folder"/> object with the absolute path of the folder.
        /// </summary>
        /// <param name="path">The absolute path to the folder. It must exist on the file system.</param>
        /// <exception cref="ArgumentException">When path is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">When path leads to a nonexistent folder.</exception>
        public Folder(string path) : this(path, new FolderCategory()) { }

        /// <summary>
        /// Constructs a <see cref="Folder"/> object with the absolute path of the folder.
        /// </summary>
        /// <param name="path">The absolute path to the folder. It must exist on the file system.</param>
        /// <param name="folderCategory">The <see cref="FolderCategory"/> object this folder should belong to.</param>
        /// <exception cref="ArgumentException">When path is null or empty.</exception>
        /// <exception cref="DirectoryNotFoundException">When path leads to a nonexistent folder.</exception>
        public Folder(string path, FolderCategory folderCategory) {
            Path = path;
            FolderCategory = folderCategory;
        }



        /// <summary>
        /// Iterates all subfolders of this folder and looks for files which have relevant file extensions.
        /// </summary>
        /// <returns>A list of <see cref="File"/> objects which contain all the relevant files.</returns>
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