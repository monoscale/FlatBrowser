using FlatBrowser.Database;
using FlatBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowserTests.Database {
    public class MockFolderCategoryRepository : IFolderCategoryRepository {

        public bool IsSaved { get; private set; }

        private ICollection<FolderCategory> categories;

        public MockFolderCategoryRepository(DummyData dummyData) {
            IsSaved = false;
            categories = dummyData.FolderCategories;
        }

        public void Add(FolderCategory folderCategory) {
            IsSaved = false;
            categories.Add(folderCategory);
        }

        public void Edit(FolderCategory folderCategory) {
            IsSaved = false;
            FolderCategory editFc = categories.Where(f => f.FolderCategoryId == folderCategory.FolderCategoryId).First();
            categories.Remove(editFc);
            categories.Add(folderCategory);
        }

        public IQueryable<FolderCategory> GetAll() {
            return categories.AsQueryable();
        }

        public FolderCategory GetById(int id) {
            return categories.First(c => c.FolderCategoryId == id);
        }

        public void Remove(FolderCategory folderCategory) {
            IsSaved = false;
            categories.Remove(folderCategory);
        }

        public void SaveChanges() {
            IsSaved = true;
        }
    }
}
