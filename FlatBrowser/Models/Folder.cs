using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlatBrowser.Models {
    public class Folder {

        public string Path { get; set; }
        public ICollection<File> Files { get; set; }

        public ICollection<FileInfo> GetFiles() {
            throw new System.NotImplementedException();
        }
    }
}