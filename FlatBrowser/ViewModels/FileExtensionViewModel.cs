using FlatBrowser.Models;

namespace FlatBrowser.ViewModels {
    public class FileExtensionViewModel : ViewModelBase {

        public string Name { get; private set; }

        private bool includeInSearch;
        public bool IncludeInSearch {
            get { return includeInSearch; }
            set { SetProperty(ref includeInSearch, value); }
        }

        public FileExtensionViewModel(FileExtension fileExtension) {
            Name = fileExtension.Name;
            IncludeInSearch = true;
        }
    }
}
