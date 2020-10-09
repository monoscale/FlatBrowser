using FlatBrowser.Database;
using FlatBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowserTests.Database {
    public class MockFolderCategoryRepository : IFolderCategoryRepository {

        private ICollection<FolderCategory> categories;

        public MockFolderCategoryRepository(DummyData dummyData) {
            categories = dummyData.FolderCategeories;
        }

        public void Add(FolderCategory folderCategory) {
            categories.Add(folderCategory);
        }

        public IQueryable<FolderCategory> GetAll() {
            return categories.AsQueryable();
        }

        public void Remove(FolderCategory folderCategory) {
            categories.Remove(folderCategory);
        }
    }
}
