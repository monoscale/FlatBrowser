using System;
using System.IO;

namespace FlatBrowser.Models {

    /// <summary>
    /// Represents a physical file on the file system.
    /// </summary>
    public class File {

        /// <summary>
        /// Gets the extension of the file.
        /// </summary>
        public FileExtension FileExtension { get; private set; }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        public string Name { get; private set; }



        private string fullName;
        /// <summary>
        /// Gets the full path of the file.
        /// </summary>
        public string FullName {
            get {
                return fullName;
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("[Setter] File.FullName can not be empty");
                }
                fullName = value;
            }

        }

        /// <summary>
        /// Gets the name of the file with the extension.
        /// </summary>
        public string NameWithExtension {
            get {
                return Name + FileExtension.Name;
            }
        }


        /// <summary>
        /// Default file constructor using the full path of the file.
        /// </summary>
        /// <param name="fullName">The absolute path to the file.</param>
        public File(string fullName) {
            FullName = fullName;

            Name = Path.GetFileNameWithoutExtension(fullName);
            FileExtension = new FileExtension(Path.GetExtension(fullName));


        }
    }
}