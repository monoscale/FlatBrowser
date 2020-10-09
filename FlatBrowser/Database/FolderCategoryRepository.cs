using FlatBrowser.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return categories;
        }

        public void Remove(FolderCategory folderCategory) {
            categories.Remove(folderCategory);
        }
    }
}
