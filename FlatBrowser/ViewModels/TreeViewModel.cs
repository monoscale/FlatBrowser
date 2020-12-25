using FlatBrowser.Models;
using FlatBrowser.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FlatBrowser.ViewModels {

    /// <summary>
    /// A viewmodel which represents one folder in the treeview.
    /// </summary>
    public class FolderViewModel : ViewModelBase {
        /// <summary>
        /// The internal folder.
        /// </summary>
        public Folder Folder { get; private set; }
        /// <summary>
        /// The files, represented as a list of file viewmodels.
        /// </summary>
        public IList<FileViewModel> Files { get; private set; }

        /// <summary>
        /// Gets or sets the visibility of the view model.
        /// </summary>
        public Visibility Visibility {
            get { return Visibility.Visible; } // root is always visible
            set { } // empty because visibility is a property on fileviewmodel, to avoid errors during hierarchicaldatatemplate
        }

        private bool isExpanded;
        public bool IsExpanded {
            get { return isExpanded; }
            set { SetProperty(ref isExpanded, value); }
        }

        public FolderViewModel(Folder folder) {
            Folder = folder;
            Files = folder.GetFiles().Select(f => new FileViewModel(f)).ToList();
        }

        public bool AnyChildrenVisible() {
            return Files.Any(File => File.Visibility == Visibility.Visible);
        }
    }


    /// <summary>
    /// A viewmodel which represents one file in the treeview.
    /// </summary>
    public class FileViewModel : ViewModelBase {

        /// <summary>
        /// The full path of the file.
        /// </summary>
        public string FullName { get; private set; }
        public string FileExtensionName { get; private set; }
        /// <summary>
        /// The name of the file.
        /// </summary>
        public string Name { get; private set; }

        public bool IsExpanded {
            get { return true; } // child is always expanded
            set { } // empty because isexpanded is a property on folderviewmodel, to avoid errors during hierarchicaldatatemplate
        }

        private Visibility visibility;
        public Visibility Visibility {
            get { return visibility; }
            set { SetProperty(ref visibility, value); }
        }
        
        
        public FileViewModel(File file) {
            Name = file.NameWithExtension;
            FileExtensionName = file.FileExtension.Name;
            FullName = file.FullName;
            Visibility = Visibility.Visible;
        }
    }
}
