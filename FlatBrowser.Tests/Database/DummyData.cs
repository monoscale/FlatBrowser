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

        public Folder TestFolder => new Folder(ProjectDirectory + "/TestFolder");
        public Folder TestFolderForAdd => new Folder(ProjectDirectory + "/TestFolder/Folder1");
        public string FolderThatDoesNotExist => "xxxxxxxxxxxxxxx";

        public FileExtension HTML => new FileExtension("html");
        public FileExtension BMP => new FileExtension("bmp");
        public FileExtension TXT => new FileExtension("txt");

        public ICollection<FolderCategory> FolderCategories => new List<FolderCategory> {
            new FolderCategory(".html", ".bmp") {Name="Test1", FolderCategoryId = 1},
            new FolderCategory(".txt") {Name="Test2",FolderCategoryId = 2, Folders = new List<Folder>() {TestFolder }}
        };

        public DummyData() {
            TestFolder.FolderCategory = FolderCategories.ElementAt(0);
            FolderCategories.ElementAt(0).Folders.Add(TestFolder);
        }
    }
}
