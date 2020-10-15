using FlatBrowser.Database;
using FlatBrowser.Models;
using FlatBrowser.Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatBrowser {
    public class MainWindowViewModel : ViewModelBase {

        private IFolderCategoryRepository folderCategoryRepository;
        public class FolderTreeView {
            public Folder Folder { get; set; }
            public IList<File> Files { get; set; }

            public FolderTreeView(Folder folder) {
                Folder = folder;
                Files = folder.GetFiles();
            }
        }

        private List<FolderTreeView> folderTreeViews;
        public List<FolderTreeView> FolderTreeViews {
            get { return folderTreeViews; }
            set { SetProperty(ref folderTreeViews, value); }
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

        public RelayCommand OpenSettingsWindowCommand { get; private set; }
        public RelayCommand OpenFileCommand { get; private set; }
        public RelayCommand RefreshWindowCommand { get; private set; }

        public MainWindowViewModel(IFolderCategoryRepository repository) {
            folderCategoryRepository = repository;

            RefreshWindow();

            OpenSettingsWindowCommand = new RelayCommand(OpenSettingsWindow);
            OpenFileCommand = new RelayCommand(OpenFile, IsFileSelected);
            RefreshWindowCommand = new RelayCommand(RefreshWindow);
        }

        private void RefreshWindow() {
            FolderCategories = (from folderCategory in folderCategoryRepository.GetAll()
                                select folderCategory).ToList();
            if(FolderCategories.Count > 0) {
                SelectedFolderCategory = FolderCategories.ElementAt(0);
            }
            
            UpdateTreeView();
        }

        private void UpdateTreeView() {
            FolderTreeViews = SelectedFolderCategory.Folders.Select(folder => new FolderTreeView(folder)).ToList();
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
