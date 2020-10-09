using FlatBrowser.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowserTests {
    public class DummyData {

        private string ProjectDirectory => Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;

        public Folder TestFolder => new Folder(ProjectDirectory + "/TestFolder");
        public string FolderThatDoesNotExist => "xxxxxxxxxxxxxxx";

        public FileExtension HTML => new FileExtension("html");
        public FileExtension BMP => new FileExtension("bmp");
        public FileExtension TXT => new FileExtension("txt");

        public ICollection<FolderCategory> FolderCategories => new List<FolderCategory> {
            new FolderCategory(".html", ".bmp"),
            new FolderCategory(".txt")
        };
    }
}
