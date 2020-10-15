using FlatBrowser.Models;
using Microsoft.EntityFrameworkCore;

namespace FlatBrowser.Database {
    public class FlatBrowserDBContext : DbContext {

        public DbSet<FolderCategory> FolderCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite("Data Source=flatbrowser.db"); // can't get this from app.json
        }

    }
}
