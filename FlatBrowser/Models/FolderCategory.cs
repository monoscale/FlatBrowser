using System;
using System.Collections.Generic;
using System.Linq;

namespace FlatBrowser.Models {

    /// <summary>
    /// Represents a category which can belong to a folder.
    /// </summary>
    public class FolderCategory {

        public int FolderCategoryId { get; set; }


        private string name;
        /// <summary>
        /// Gets or sets the name of the folder category.
        /// </summary>
        public string Name {
            get { return name; }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("[Setter] FolderCategory.Name can not be null or empty.");
                }
                name = value;
            } 
        }

        /// <summary>
        /// Gets or sets the list of file extensions this folder category will scan.
        /// </summary>
        public virtual ICollection<FileExtension> Extensions { get; set; }
        /// <summary>
        /// Gets or sets the list of folders that belong to this folder category.
        /// </summary>
        public virtual ICollection<Folder> Folders { get; set; }



        public FolderCategory() : this(new List<Folder>(), new List<FileExtension>()) { }
        public FolderCategory(string name) : this() {
            Name = name;
        }
        public FolderCategory(params string[] extensions) : this(new List<Folder>(), extensions.Select(ext => new FileExtension(ext)).ToList()) { }
        public FolderCategory(Folder folder, ICollection<FileExtension> extensions) : this(new List<Folder>() { folder }, extensions) { }
        public FolderCategory(ICollection<Folder> folders, FileExtension extension) : this(folders, new List<FileExtension>() { extension }) { }
        public FolderCategory(ICollection<Folder> folders, ICollection<FileExtension> extensions) {
            this.Folders = folders;
            this.Extensions = extensions;
        }
    }
}
