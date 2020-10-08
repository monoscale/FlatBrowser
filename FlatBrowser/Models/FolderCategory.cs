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
        public string Name { get; set; }
        public IList<FileExtension> Extensions { get; set; }

        public FolderCategory() {
            Extensions = new List<FileExtension>();
        }

        public FolderCategory(params string[] extensions) {
            Extensions = extensions.Select(ext => new FileExtension(ext)).ToList();
        }
    }
}
