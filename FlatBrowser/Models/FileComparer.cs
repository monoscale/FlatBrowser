using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FlatBrowser.Models {

    /// <summary>
    /// Special File Comparer that treats digits as numerical rather than text
    /// </summary>
    public class FileComparer : IComparer<File> {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern int StrCmpLogicalW(string x, string y);

        /// <summary>
        /// Compares two Unicode strings. Digits in the strings are considered as numerical content rather than text. This test is not case-sensitive.
        /// </summary>
        /// <param name="x">First File instance</param>
        /// <param name="y">Second File instance</param>
        /// <returns>
        /// 0 if identical
        /// 1 if x > y
        /// -1 if x < y
        /// </returns>
        public int Compare(File x, File y) {
            return StrCmpLogicalW(x.FullName, y.FullName);
        }
    }
}