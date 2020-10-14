using FlatBrowser.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowserTests.Models {
    [TestClass]
    public class FileExtensionTest {

        private FileExtension fileExtension;
        [TestMethod]
        public void ConstructorAddsDotToExtensionWithoutDot() {
            fileExtension = new FileExtension("jpg");
            Assert.IsTrue(fileExtension.Name[0] == '.');
        }

    }
}
