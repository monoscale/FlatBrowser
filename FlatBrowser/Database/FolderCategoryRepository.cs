using FlatBrowser.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlatBrowser.Database {
    public class FolderCategoryRepository : IFolderCategoryRepository {
        private FlatBrowserDBContext context;
        private DbSet<FolderCategory> categories;

        public FolderCategoryRepository(FlatBrowserDBContext context) {
            this.context = context;
            this.categories = context.FolderCategories;
        }

        public void Add(FolderCategory folderCategory) {
            categories.Add(folderCategory);
        }

        public IQueryable<FolderCategory> GetAll() {
            return categories
                .Include(cat => cat.Extensions)
                .Include(cat => cat.Folders);
        }

        public FolderCategory GetById(int id) {
            return categories.First(c => c.FolderCategoryId == id);
        }

        public void Edit(FolderCategory folderCategory) {
            categories.Update(folderCategory);
        }

        public void Remove(FolderCategory folderCategory) {
            categories.Remove(folderCategory);
        }

        public void SaveChanges() {
            context.SaveChanges();
        }
    }
}
