using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace FlatBrowser.Models {
    public class FileExtension {
        private string name;

        [Key]
        public string Name {
            get {
                return name;
            }
            set {
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