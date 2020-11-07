using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlatBrowser.Models {

    /// <summary>
    /// A logical view of a file extension. A file extension can be anything prefixed with a dot (.)
    /// </summary>
    public class FileExtension {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileExtensionId { get; set; }

        private string name;
        /// <summary>
        /// Gets or sets the name of the file extension. If the dot is missing, it will be inserted automatically.
        /// <br></br>
        /// .Name = ".jpg" and .Name = "jpg" are both valid ways to set this property.
        /// </summary>
        public string Name {
            get {
                return name;
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("[Setter] FileExtension.Name can not be null or empty.");
                }

                if (value[0] != '.') {
                    value = value.Insert(0, ".");
                }
                name = value;
            }
        }

        private FileExtension() { }

        /// <summary>
        /// Constructor which sets the name of the file extension.
        /// </summary>
        /// <param name="name">The name of the file extension. If the dot is missing, it will be inserted automatically.</param>
        public FileExtension(string name) {
            Name = name;
        }


    }
}