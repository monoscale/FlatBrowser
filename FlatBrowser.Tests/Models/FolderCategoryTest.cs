using FlatBrowser.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowserTests.Models {


    [TestClass]
    public class FolderCategoryTest {

        private FolderCategory folderCategory;

        [TestMethod]
        public void ConstructorTakesArbitraryAmountOfExtensions() {
            folderCategory = new FolderCategory(new string[] { ".jpg", ".txt" }.ToList());
            Assert.AreEqual(2, folderCategory.Extensions.Count);
        }

    }
}
