using FlatBrowser.Models;
using FlatBrowser.ViewModels;
using FlatBrowserTests.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FlatBrowserTests.ViewModels {
    [TestClass]
    public class SettingsWindowTest {

        private SettingsWindowViewModel vm;
        private MockFolderCategoryRepository mockRepository;
        private DummyData dummyData;
        private FolderCategory fc;

        [TestInitialize]
        public void TestInitialize() {
            dummyData = new DummyData();
            mockRepository = new MockFolderCategoryRepository(dummyData);
            vm = new SettingsWindowViewModel(mockRepository);
            vm.SelectedFolderCategory = dummyData.FolderCategories.ElementAt(0);
            fc = GetFolderCategory();
        }

        private FolderCategory GetFolderCategory() {
            return mockRepository.GetById(1);
        }

        [TestMethod]
        public void AddFolderCategoryAddsToRepository() {
            int originalCount = mockRepository.GetAll().Count();
            vm.AddFolderCategory("testName");
            Assert.AreEqual(originalCount + 1, mockRepository.GetAll().Count());
        }

        [TestMethod]
        public void DeleteFolderCategoryRemovesFromRepository() {
            int originalCount = mockRepository.GetAll().Count();
            vm.DeleteFolderCategory(GetFolderCategory());
            Assert.AreEqual(originalCount - 1, mockRepository.GetAll().Count());
        }

        [TestMethod]
        public void AddFolderAddsToRepository() {

            int originalCount = fc.Folders.Count;
            vm.AddFolder(dummyData.TestFolderForAdd.Path);
            fc = GetFolderCategory();
            Assert.AreEqual(originalCount + 1, fc.Folders.Count);
        }

        [TestMethod]
        public void DeleteFolderDeletesFromRepository() {
            int originalCount = fc.Folders.Count;
            vm.DeleteFolder(dummyData.TestFolderForAdd);
            fc = GetFolderCategory();
            Assert.AreEqual(originalCount - 1, fc.Folders.Count);
        }

        [TestMethod]
        public void AddFileExtensionAddsToRepository() {
            int originalCount = fc.Extensions.Count;
            vm.AddFileExtension(".test");
            fc = GetFolderCategory();
            Assert.AreEqual(originalCount + 1, fc.Extensions.Count);

        }

        [TestMethod]
        public void DeleteFileExtensionDeletesFromRepository() {
            int originalCount = fc.Extensions.Count;
            vm.DeleteFileExtension(fc.Extensions.ElementAt(0));
            fc = GetFolderCategory();
            Assert.AreEqual(originalCount - 1, fc.Extensions.Count);
        }


        [TestMethod]
        public void AddCategoryCallsSaveChanges() {
            vm.AddFolderCategory("categoryName");
            Assert.IsTrue(mockRepository.IsSaved);
        }

        [TestMethod]
        public void DeleteCategoryCallsSaveChanges() {
            vm.DeleteFolderCategory(new FolderCategory());
            Assert.IsTrue(mockRepository.IsSaved);
        }

        [TestMethod]
        public void AddFolderCallsSaveChanges() {
            vm.AddFolder(dummyData.TestFolder.Path);
            Assert.IsTrue(mockRepository.IsSaved);
        }



        [TestMethod]
        public void AddExtensionCallsSaveChanges() {
            vm.AddFileExtension(".test");
            Assert.IsTrue(mockRepository.IsSaved);
        }

        [TestMethod]
        public void DeleteExtensionCallsSaveChanges() {
            vm.DeleteFileExtension(fc.Extensions.ElementAt(0));
            Assert.IsTrue(mockRepository.IsSaved);
        }

    }
}
