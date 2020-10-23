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
            categories.FromSqlRaw("DELETE FROM FileExtensions WHERE FolderCategoryId=NULL");
        }

        public void Remove(FolderCategory folderCategory) {
            categories.Remove(folderCategory);
        }

        public void SaveChanges() {
            context.SaveChanges();

            // dirty hacks incoming...
            // After an Edit, children of FolderCategory (folder and fileextension) could become orphans
            context.Database.ExecuteSqlRaw("DELETE FROM FileExtension WHERE FolderCategoryId IS NULL");
            context.Database.ExecuteSqlRaw("DELETE FROM Folder WHERE FolderCategoryId IS NULL");
        }
    }
}
