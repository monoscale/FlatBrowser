using FlatBrowser.Database;
using FlatBrowser.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowser.Windows {
    public class SettingsWindowViewModel {

        private IFolderCategoryRepository folderCategoryRepository;

        public IList<FolderCategory> FolderCategories { get; set; }

        private FolderCategory selectedFolderCategory;
        public FolderCategory SelectedFolderCategory {
            get {
                return selectedFolderCategory;
            }
            set {
                this.selectedFolderCategory = value;
                Folders = SelectedFolderCategory.Folders;
                Extensions = SelectedFolderCategory.Extensions;
            }
        }

        public ICollection<Folder> Folders { get; set; }



        public string NewFileExtension { get; set; }


        public FileExtension SelectedFileExtension { get; set; }



        public ICollection<FileExtension> Extensions { get; set; }


        public RelayCommand<string> AddFileExtensionCommand { get; private set; }
        public RelayCommand<FileExtension> EditFileExtensionCommand { get; private set; }
        public RelayCommand<FileExtension> DeleteFileExtensionCommand { get; private set; }

        public SettingsWindowViewModel(IFolderCategoryRepository folderCategoryRepository) {
            this.folderCategoryRepository = folderCategoryRepository;
            FolderCategories = folderCategoryRepository.GetAll().ToList();
            SelectedFolderCategory = FolderCategories[0];
            Folders = SelectedFolderCategory.Folders;
            Extensions = SelectedFolderCategory.Extensions;


            AddFileExtensionCommand = new RelayCommand<string>(AddFileExtension);
            EditFileExtensionCommand = new RelayCommand<FileExtension>(EditFileExtension);
            DeleteFileExtensionCommand = new RelayCommand<FileExtension>(DeleteFileExtension);

        }

        public void AddFolder(string path) {
            Folder folder = new Folder(path);
            SelectedFolderCategory.Folders.Add(folder);
            folderCategoryRepository.Edit(SelectedFolderCategory);
            folderCategoryRepository.SaveChanges();
        }

        public void EditFolder(Folder folder) {
            throw new NotImplementedException();
        }

        public void DeleteFolder(Folder folder) {
            SelectedFolderCategory.Folders.Remove(folder);
            folderCategoryRepository.Edit(SelectedFolderCategory);
            folderCategoryRepository.SaveChanges();
        }

        public void AddFileExtension(string extension) {
            FileExtension fileExtension = new FileExtension(extension);
            SelectedFolderCategory.Extensions.Add(fileExtension);
            folderCategoryRepository.Edit(SelectedFolderCategory);
            folderCategoryRepository.SaveChanges();
        }

        public void EditFileExtension(FileExtension parameter) {
            FileExtension original = SelectedFolderCategory.Extensions.First(ext => ext.Name == parameter.Name);
            original.Name = parameter.Name;
            folderCategoryRepository.Edit(SelectedFolderCategory);
            folderCategoryRepository.SaveChanges();
        }

        public void DeleteFileExtension(FileExtension parameter) {
            SelectedFolderCategory.Extensions.Remove(parameter);
            folderCategoryRepository.Edit(SelectedFolderCategory);
            folderCategoryRepository.SaveChanges();

        }
    }
}
