using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatBrowser.Models {
    public class File {

        /// <summary>
        /// Gets the extension of the file.
        /// </summary>
        public FileExtension FileExtension { get; private set; }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the full path of the file.
        /// </summary>
        public string FullName { get; private set; }


        public File(string fullName) {
            FullName = fullName;
        }
    }
}