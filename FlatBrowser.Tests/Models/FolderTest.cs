using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FlatBrowser.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlatBrowserTests.Models {


    /// <summary>
    /// Directory structure:
    /// <br></br>
    /// TestFolder     <br></br>
    /// | text1.txt    <br></br>
    /// | text2.txt    <br></br>
    /// | image1.bmp   <br></br>
    /// | Folder1      <br></br>
    /// || web1.html   <br></br>
    /// || text3.txt   <br></br>
    /// || Folder2     <br></br>
    /// ||| image2.bmp <br></br>
    /// 
    /// </summary>
    [TestClass]
    public class FolderTest {

        private Folder folder;
        private DummyData dummyData;
        [TestInitialize]
        public void TestInitialize() {
            dummyData = new DummyData();
            folder = dummyData.TestFolder;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyStringConstructorThrowsArgumentException() {
            new Folder(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullStringConstructorThrowsArgumentException() {
            new Folder(null);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void NonExistingDirectoryThrowsDirectoryNotFoundException() {
            new Folder(dummyData.FolderThatDoesNotExist);
        }

        [TestMethod]
        public void GetFilesReturnsNoFilesWhenNoFilter() {
            FolderCategory category = new FolderCategory();
            folder.FolderCategory = category;

            Assert.AreEqual(0, folder.GetFiles().Count);
        }

        [TestMethod]
        public void GetFilesReturnsOnlyRelevantFiles() {
            folder.FolderCategory = dummyData.FolderCategories.ElementAt(0);
            Assert.AreEqual(3, folder.GetFiles().Count);
        }

    }
}

