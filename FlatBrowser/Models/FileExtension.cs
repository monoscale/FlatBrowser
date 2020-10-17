using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlatBrowser.Models {
    public class FileExtension {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileExtensionId { get; set; }

        private string name;

        public string Name {
            get {
                return name;
            }
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException("[Setter] FileExtension.Name can not be empty");
                }

                if (value[0] != '.') {
                    value = value.Insert(0, ".");
                }
                name = value;
            }
        }

        public FileExtension() { }

        public FileExtension(string name) {
            Name = name;
        }


    }
}