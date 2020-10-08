using FlatBrowser.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowser {
    public class MainWindowViewModel {

        public class FolderTreeView {
            public Folder Folder { get; set; }
            public IList<File> Files { get; set; }

            public FolderTreeView(Folder folder) {
                Folder = folder;
                Files = folder.GetFiles();
            }
        }

        public List<FolderTreeView> FolderTreeViews { get; set; }

        public MainWindowViewModel() {
            FolderTreeViews = new List<FolderTreeView>() {
                new FolderTreeView(new Folder("Q:/Source/FlatBrowser/FlatBrowserTests/TestFolder/Folder1")),
                new FolderTreeView(new Folder("Q:/Source/FlatBrowser/FlatBrowserTests/Models", new FolderCategory(".cs")))
            };
        }

    }

}
