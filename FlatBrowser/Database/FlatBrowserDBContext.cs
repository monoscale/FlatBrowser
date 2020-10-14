using FlatBrowser.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace FlatBrowser.Database {
    public class FlatBrowserDBContext : DbContext {

        public DbSet<FolderCategory> FolderCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite("Data Source=flatbrowser.db"); // can't get this from app.json
        }

    }
}
