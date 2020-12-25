using FlatBrowser.Models;
using FlatBrowser.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlatBrowser.ViewModels {
    public class FileExtensionViewModel : ViewModelBase {

        public string Name { get; private set; }
        public bool IncludeInSearch { get; set; }

        public FileExtensionViewModel(FileExtension fileExtension) {
            Name = fileExtension.Name;
            IncludeInSearch = true;
        }
    }
}
