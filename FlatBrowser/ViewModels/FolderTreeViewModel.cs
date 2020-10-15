using FlatBrowser.Models;
using FlatBrowser.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FlatBrowser.ViewModels {
    public class FolderTreeViewModel : ViewModelBase {
        public Folder Folder { get; set; }

        public IList<FileViewModel> Files { get; set; }

        public FolderTreeViewModel(Folder folder) {
            Folder = folder;
            Files = folder.GetFiles().Select(f => new FileViewModel(f)).ToList();
        }
    }


    public class FileViewModel : ViewModelBase {

        public string FullName { get; set; }
        public string Name { get; set; }

        private Visibility visibility;
        public Visibility Visibility {
            get { return visibility; }
            set { SetProperty(ref visibility, value); }
        }
        public FileViewModel(File file) {
            Name = file.NameWithExtension;
            FullName = file.FullName;
            Visibility = Visibility.Visible;
        }
    }
}
