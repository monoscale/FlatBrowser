﻿using FlatBrowser.ViewModels;
using FlatBrowserTests.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlatBrowserTests.ViewModels {

    [TestClass]
    public class MainWindowTest {

        private MainWindowViewModel vm;
        private MockFolderCategoryRepository mockRepository;
        private DummyData dummyData;


        [TestInitialize]
        public void TestInitialize() {
            dummyData = new DummyData();
            mockRepository = new MockFolderCategoryRepository(dummyData);
            vm = new MainWindowViewModel(mockRepository);
        }


        [TestMethod]
        public void FilterShowsOnlyRelevantFiles() {
            vm.SelectedFolderCategory = mockRepository.GetById(1);
            vm.SearchText = "1";

            int count = 0;
            foreach (FolderTreeViewModel viewModel in vm.FolderTreeViews) {
                foreach (FileViewModel fileViewModel in viewModel.Files) {
                    if (fileViewModel.Visibility == Visibility.Visible) {
                        count++;
                    }
                }
            }

            Assert.AreEqual(2, count);
        }


    }
}
