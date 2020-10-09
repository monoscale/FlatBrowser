using FlatBrowser.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowser.Windows {
    public class SettingsWindowViewModel {

        private IFolderCategoryRepository folderCategoryRepository;
        public SettingsWindowViewModel(IFolderCategoryRepository folderCategoryRepository) {
            this.folderCategoryRepository = folderCategoryRepository;
        }
    }
}
