using FlatBrowser.Database;
using FlatBrowser.Models;
using FlatBrowser.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace FlatBrowser.ViewModels {

    /// <summary>
    /// Viewmodel for the main window. Its main responsibilities are viewing folders and file collections, searching through these collections, and opening the settings menu.
    /// </summary>
    public class MainWindowViewModel : ViewModelBase {

        /// <summary>
        /// The connection to the database. 
        /// </summary>
        private IFolderCategoryRepository folderCategoryRepository;

        private IList<FolderTreeViewModel> folderTreeViews;
        /// <summary>
        /// Gets or sets the list of <see cref="FolderTreeViewModel"/> objects. One such view model corresponds to one folder.
        /// </summary>
        public IList<FolderTreeViewModel> FolderTreeViews {
            get { return folderTreeViews; }
            set {
                SetProperty(ref folderTreeViews, value);
            }
        }

        /// <summary>
        /// Gets or sets the currently selected file path.
        /// </summary>
        public string SelectedFilePath { get; set; }

        private FolderCategory selectedFolderCategory;
        /// <summary>
        /// Gets or sets the currently selected folder category.
        /// </summary>
        public FolderCategory SelectedFolderCategory {
            get { return selectedFolderCategory; }
            set {
                if(value == null) {
                    if(FolderCategories.Count > 0) {
                        SetProperty(ref selectedFolderCategory, FolderCategories.ElementAt(0));
                        UpdateTreeView();
                    } else {
                        SetProperty(ref selectedFolderCategory, null);
                        // do not update tree view
                    }
                } else {
                    SetProperty(ref selectedFolderCategory, value);
                    UpdateTreeView();
                }
                
            }
        }


        private ICollection<FolderCategory> folderCategories;
        /// <summary>
        /// Gets or sets the list of folder categories.
        /// </summary>
        public ICollection<FolderCategory> FolderCategories {
            get { return folderCategories; }
            set { SetProperty(ref folderCategories, value); }
        }


        private string searchText;
        /// <summary>
        /// Gets or sets the search text to be used when filtering through files.
        /// </summary>
        public string SearchText {
            get { return searchText; }
            set {
                SetProperty(ref searchText, value);
                FilterTreeView();
            }
        }

        /// <summary>
        /// Command which should open the settings window.
        /// </summary>
        public RelayCommand OpenSettingsWindowCommand { get; private set; }
        /// <summary>
        /// Command which should open the currently selected file.
        /// </summary>
        public RelayCommand OpenFileCommand { get; private set; }
        /// <summary>
        /// Command which should refresh the window.
        /// </summary>
        public RelayCommand RefreshWindowCommand { get; private set; }
        /// <summary>
        /// Command which should collapses all the folders.
        /// </summary>
        public RelayCommand CollapseAllCommand { get; private set; }
        /// <summary>
        /// Command which should expand all the folders.
        /// </summary>
        public RelayCommand ExpandAllCommand { get; private set; }


        /// <summary>
        /// Main constructor. It takes in the folder category repository and sets all the relevant commands. At the end, it refreshes the window for the user to start using the application.
        /// </summary>
        /// <param name="repository"></param>
        public MainWindowViewModel(IFolderCategoryRepository repository) {
            folderCategoryRepository = repository;

            OpenSettingsWindowCommand = new RelayCommand(OpenSettingsWindow);
            OpenFileCommand = new RelayCommand(OpenFile, IsFileSelected);
            RefreshWindowCommand = new RelayCommand(RefreshWindow);
            CollapseAllCommand = new RelayCommand(CollapseAll);
            ExpandAllCommand = new RelayCommand(ExpandAll);

            RefreshWindow();
        }

        /// <summary>
        /// Collapses all folders
        /// </summary>
        private void CollapseAll() {
            foreach (FolderTreeViewModel vm in FolderTreeViews)
                vm.IsExpanded = false;

        }

        /// <summary>
        /// Expands all folders
        /// </summary>
        private void ExpandAll() {
            foreach (FolderTreeViewModel vm in FolderTreeViews)
                vm.IsExpanded = true;
        }

        /// <summary>
        /// Refreshes the window. This is boils down to a re-initialize of the window.
        /// </summary>
        private void RefreshWindow() {
            FolderCategories = folderCategoryRepository.GetAll().ToList();
            if (FolderCategories.Count > 0) {
                SelectedFolderCategory = FolderCategories.ElementAt(0);
            }
        }


        /// <summary>
        /// Updates the treeview based on the currently selected category. 
        /// </summary>
        private void UpdateTreeView() {
            FolderTreeViews = SelectedFolderCategory.Folders.Select(folder => new FolderTreeViewModel(folder)).ToList();
        }

        /// <summary>
        /// Filters the treeview based on the search query.
        /// </summary>
        private void FilterTreeView() {
            foreach (FolderTreeViewModel viewModel in FolderTreeViews) {
                foreach (FileViewModel fileViewModel in viewModel.Files) {
                    if (!fileViewModel.Name.ToLower().Contains(SearchText.ToLower())) {
                        fileViewModel.Visibility = Visibility.Collapsed;
                    } else {
                        fileViewModel.Visibility = Visibility.Visible;
                    }
                }
                viewModel.IsExpanded = viewModel.AnyChildrenVisible();
            }
        }

        private void OpenSettingsWindow() {
            SettingsWindow window = new SettingsWindow(folderCategoryRepository);
            ((SettingsWindowViewModel)window.DataContext).SettingsChanged += SettingsChanged;
            window.Show();
            
        }

        private void SettingsChanged(object sender, EventArgs e) {
            this.RefreshWindow();
        }

        private bool IsFileSelected() {
            return !string.IsNullOrEmpty(SelectedFilePath);
        }

        private void OpenFile() {
            Process.Start(new ProcessStartInfo(SelectedFilePath) { UseShellExecute = true });
        }

    }

}
