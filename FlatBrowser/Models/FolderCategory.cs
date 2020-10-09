using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowser.Models {

    /// <summary>
    /// Represents a category which can belong to a folder.
    /// </summary>
    public class FolderCategory {

        public int FolderCategoryId { get; set; }
        public string Name { get; set; }
        public IList<FileExtension> Extensions { get; set; }
        public IList<Folder> Folders { get; set; }


        public FolderCategory() : this(new List<Folder>(), new List<FileExtension>()) { }
        public FolderCategory(params string[] extensions) : this(new List<Folder>(), extensions.Select(ext => new FileExtension(ext)).ToList()) { }
        public FolderCategory(Folder folder, IList<FileExtension> extensions) : this(new List<Folder>() { folder }, extensions) { }
        public FolderCategory(IList<Folder> folders, FileExtension extension) : this(folders, new List<FileExtension>() { extension }) { }
        public FolderCategory(IList<Folder> folders, IList<FileExtension> extensions) {
            this.Folders = folders;
            this.Extensions = extensions;
        }
    }
}
