using FlatBrowser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowserTests {
    public class DummyData {

        private string ProjectDirectory => Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public Folder TestFolder { get; }
        public Folder TestFolderForAdd => new Folder(ProjectDirectory + "/TestFolder/Folder1") { FolderId = 2 };
        public string FolderThatDoesNotExist => "xxxxxxxxxxxxxxx";

        public FileExtension HTML => new FileExtension("html");
        public FileExtension BMP => new FileExtension("bmp");
        public FileExtension TXT => new FileExtension("txt");

        public ICollection<FolderCategory> FolderCategories { get; }

        public DummyData() {
            TestFolder = new Folder(ProjectDirectory + "/TestFolder") { FolderId = 1 };
            FolderCategories = new List<FolderCategory> {
                new FolderCategory(new string[]{".html", ".bmp" }.ToList()) {Name="Test1", FolderCategoryId = 1, Folders = new List<Folder>() {TestFolder }},
                new FolderCategory(new string[]{".txt" }.ToList()) {Name="Test2",FolderCategoryId = 2, Folders = new List<Folder>() {TestFolder }}
            };
            TestFolder.FolderCategory = FolderCategories.ElementAt(0);
        }
    }
}
