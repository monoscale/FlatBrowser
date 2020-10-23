using FlatBrowser.Database;
using FlatBrowser.Models;
using FlatBrowser.Windows;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace FlatBrowser.ViewModels {
    public class SettingsWindowViewModel : ViewModelBase {

        private IFolderCategoryRepository folderCategoryRepository;


        private string error;
        public string Error {
            get { return error; }
            set { SetProperty(ref error, value); }
        }


        public ObservableCollection<FolderCategory> FolderCategories { get; set; }

        public string NewFolderCategory { get; set; }

        private FolderCategory selectedFolderCategory;
        public FolderCategory SelectedFolderCategory {
            get { return selectedFolderCategory; }
            set {
                SetProperty(ref selectedFolderCategory, value);
                if (value != null) {
                    Folders = new ObservableCollection<Folder>(SelectedFolderCategory.Folders);
                    Extensions = new ObservableCollection<FileExtension>(SelectedFolderCategory.Extensions);
                }
            }
        }

        private ObservableCollection<Folder> folders;
        public ObservableCollection<Folder> Folders {
            get { return folders; }
            set { SetProperty(ref folders, value); }
        }

        private ObservableCollection<FileExtension> extensions;
        public ObservableCollection<FileExtension> Extensions {
            get { return extensions; }
            set { SetProperty(ref extensions, value); }
        }



        public string NewFileExtension { get; set; }
        public FileExtension SelectedFileExtension { get; set; }



        public RelayCommand AddFolderCategoryCommand { get; private set; }
        public RelayCommand<FolderCategory> DeleteFolderCategoryCommand { get; private set; }

        public RelayCommand AddFileExtensionCommand { get; private set; }
        public RelayCommand<FileExtension> DeleteFileExtensionCommand { get; private set; }

        public RelayCommand AddFolderCommand { get; private set; }
        public RelayCommand<Folder> DeleteFolderCommand { get; private set; }


        public SettingsWindowViewModel(IFolderCategoryRepository folderCategoryRepository) {
            this.folderCategoryRepository = folderCategoryRepository;
            FolderCategories = new ObservableCollection<FolderCategory>(folderCategoryRepository.GetAll());
            if (FolderCategories.Count > 0) {
                SelectedFolderCategory = FolderCategories[0];
                Folders = new ObservableCollection<Folder>(SelectedFolderCategory.Folders);
                Extensions = new ObservableCollection<FileExtension>(SelectedFolderCategory.Extensions);
            }


            AddFolderCategoryCommand = new RelayCommand(AddFolderCategory);
            DeleteFolderCategoryCommand = new RelayCommand<FolderCategory>(DeleteFolderCategory);

            AddFileExtensionCommand = new RelayCommand(AddFileExtension, IsFolderCategorySelected);
            DeleteFileExtensionCommand = new RelayCommand<FileExtension>(DeleteFileExtension);

            AddFolderCommand = new RelayCommand(ChooseFolder, IsFolderCategorySelected);
            DeleteFolderCommand = new RelayCommand<Folder>(DeleteFolder);

        }

        private bool IsFolderCategorySelected() {
            return SelectedFolderCategory != null;
        }

        private void AddFolderCategory() {
            AddFolderCategory(NewFolderCategory);
        }

        public void AddFolderCategory(string categoryName) {
            FolderCategory folderCategory = new FolderCategory(categoryName);
            folderCategoryRepository.Add(folderCategory);
            FolderCategories.Add(folderCategory);
            folderCategoryRepository.SaveChanges();
        }

        public void DeleteFolderCategory(FolderCategory folderCategory) {
            folderCategoryRepository.Remove(folderCategory);
            folderCategoryRepository.SaveChanges();
            FolderCategories.Remove(folderCategory);
            if (FolderCategories.Count > 0) {
                SelectedFolderCategory = FolderCategories[0];
            } else {
                Folders.Clear();
                Extensions.Clear();
            }
        }

        private void ChooseFolder() {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK) {
                string path = folderBrowserDialog.SelectedPath;
                AddFolder(path);
            }
        }
        public void AddFolder(string path) {
            Folder folder = new Folder(path);
            SelectedFolderCategory.Folders.Add(folder);
            folderCategoryRepository.Edit(SelectedFolderCategory);
            folderCategoryRepository.SaveChanges();
            Folders.Add(folder);
        }

        public void DeleteFolder(Folder folder) {
            SelectedFolderCategory.Folders.Remove(folder);
            folderCategoryRepository.Edit(SelectedFolderCategory);
            folderCategoryRepository.SaveChanges();
            Folders.Remove(folder);
        }


        /// <summary>
        /// This method is used by the command.
        /// </summary>
        private void AddFileExtension() {
            AddFileExtension(NewFileExtension);
        }
        public void AddFileExtension(string extension) {
            try {
                FileExtension fileExtension = new FileExtension(extension);
                SelectedFolderCategory.Extensions.Add(fileExtension);
                folderCategoryRepository.Edit(SelectedFolderCategory);
                folderCategoryRepository.SaveChanges();
                Extensions.Add(fileExtension);
            } catch (ArgumentException ae) {
                Error = ae.Message;
            }
        }


        public void DeleteFileExtension(FileExtension parameter) {
            SelectedFolderCategory.Extensions.Remove(parameter);
            folderCategoryRepository.Edit(SelectedFolderCategory);
            folderCategoryRepository.SaveChanges();
            Extensions.Remove(parameter);

        }
    }
}
