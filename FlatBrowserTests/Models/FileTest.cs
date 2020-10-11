using FlatBrowser.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowserTests.Models {
    [TestClass]
    public class FileTest {

        private File file;

        [TestInitialize]
        public void TestInitialize() {
            file = new File("Q:/Source/FlatBrowser/FlatBrowserTests/TestFolder/Folder1/Folder2/image2.bmp");
        }

        [TestMethod]
        public void ConstructorExtractsFileNameAndExtensionFromFullName() {
            Assert.AreEqual("image2", file.Name);
            Assert.AreEqual(".bmp", file.FileExtension.Name);
        }
    }
}
