using FlatBrowser.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowser.Database {
    public class FlatBrowserDBContext : DbContext {

        public DbSet<FolderCategory> FolderCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlite(ConfigurationManager.ConnectionStrings["FlatBrowserDatabase"].ConnectionString);
        }

    }
}
