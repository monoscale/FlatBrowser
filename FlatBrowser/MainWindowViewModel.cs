using FlatBrowser.Database;
using FlatBrowser.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowser {
    public class MainWindowViewModel {

        private IFolderCategoryRepository folderCategoryRepository;

        public class FolderTreeView {
            public Folder Folder { get; set; }
            public IList<File> Files { get; set; }

            public FolderTreeView(Folder folder) {
                Folder = folder;
                Files = folder.GetFiles();
            }
        }

        public List<FolderTreeView> FolderTreeViews { get; set; }

        public MainWindowViewModel(IFolderCategoryRepository repository) {
            folderCategoryRepository = repository;


            IList<FolderCategory> categories = (from folderCategory in repository.GetAll()
                                                select folderCategory).ToList();





            FolderTreeViews = categories[0].Folders.Select(folder => new FolderTreeView(folder)).ToList();

        }

    }

}
