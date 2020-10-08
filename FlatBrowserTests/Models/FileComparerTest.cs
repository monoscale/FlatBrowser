using FlatBrowser.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowserTests.Models {
    [TestClass]
    public class FileComparerTest {

        private FileComparer fileComparer;

        private File x, y;

        [TestInitialize]
        public void TestInitialize() {
            fileComparer = new FileComparer();
            // these are not physical files. 
            x = new File("C:/Test/10fileX");
            y = new File("C:/Test/9fileY");
        }

        [TestMethod]
        public void FileComparerReturnsZeroIfEqual() {
            Assert.AreEqual(0, fileComparer.Compare(x, x));
        }

        [TestMethod]
        public void FileComparerReturnsNumericalFirst() {
            List<File> files = new List<File>() { x, y };
            files.Sort(fileComparer);
            Assert.AreEqual(y, files[0]);
        }


    }
}
