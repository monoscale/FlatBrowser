using FlatBrowser.Database;
using FlatBrowser.Models;
using FlatBrowser.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace FlatBrowser.ViewModels {
    public class MainWindowViewModel : ViewModelBase {

        private IFolderCategoryRepository folderCategoryRepository;

        private IList<FolderTreeViewModel> folderTreeViews;
        public IList<FolderTreeViewModel> FolderTreeViews {
            get { return folderTreeViews; }
            set {
                SetProperty(ref folderTreeViews, value);
            }
        }

        public File SelectedFile { get; set; }

        private FolderCategory selectedFolderCategory;
        public FolderCategory SelectedFolderCategory {
            get { return selectedFolderCategory; }
            set {
                SetProperty(ref selectedFolderCategory, value);
                UpdateTreeView();
            }
        }
        public ICollection<FolderCategory> FolderCategories { get; set; }


        private string searchText;
        public string SearchText {
            get { return searchText; }
            set {
                SetProperty(ref searchText, value);
                FilterTreeView();
            }
        }

        public RelayCommand OpenSettingsWindowCommand { get; private set; }
        public RelayCommand OpenFileCommand { get; private set; }
        public RelayCommand RefreshWindowCommand { get; private set; }
        public RelayCommand CollapseAllCommand { get; private set; }
        public RelayCommand ExpandAllCommand { get; private set; }

        public MainWindowViewModel(IFolderCategoryRepository repository) {
            folderCategoryRepository = repository;

            RefreshWindow();

            OpenSettingsWindowCommand = new RelayCommand(OpenSettingsWindow);
            OpenFileCommand = new RelayCommand(OpenFile, IsFileSelected);
            RefreshWindowCommand = new RelayCommand(RefreshWindow);
            CollapseAllCommand = new RelayCommand(CollapseAll);
            ExpandAllCommand = new RelayCommand(ExpandAll);

        }

        private void CollapseAll() {
            foreach (FolderTreeViewModel vm in FolderTreeViews)
                vm.IsExpanded = false;

        }

        private void ExpandAll() {
            foreach (FolderTreeViewModel vm in FolderTreeViews)
                vm.IsExpanded = true;
        }

        private void RefreshWindow() {
            FolderCategories = (from folderCategory in folderCategoryRepository.GetAll()
                                select folderCategory).ToList();
            if (FolderCategories.Count > 0) {
                SelectedFolderCategory = FolderCategories.ElementAt(0);
                UpdateTreeView();
            }
        }

        private void UpdateTreeView() {
            FolderTreeViews = SelectedFolderCategory.Folders.Select(folder => new FolderTreeViewModel(folder)).ToList();
        }

        private void FilterTreeView() {
            foreach (FolderTreeViewModel viewModel in FolderTreeViews) {
                foreach (FileViewModel fileViewModel in viewModel.Files) {
                    if (!fileViewModel.Name.ToLower().Contains(SearchText.ToLower())) {
                        fileViewModel.Visibility = Visibility.Collapsed;
                    } else {
                        fileViewModel.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        private void OpenSettingsWindow() {
            SettingsWindow window = new SettingsWindow(folderCategoryRepository);
            window.Show();
        }

        private bool IsFileSelected() {
            return SelectedFile != null;
        }

        private void OpenFile() {
            OpenFile(SelectedFile);
        }
        public void OpenFile(File file) {
            Process.Start(file.FullName);
        }

    }

}
