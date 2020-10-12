using FlatBrowser.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBrowser.Database {
    public interface IFolderCategoryRepository {

        void Add(FolderCategory folderCategory);
        IQueryable<FolderCategory> GetAll();
        FolderCategory GetById(int id);
        void Edit(FolderCategory folderCategory);
        void Remove(FolderCategory folderCategory);
        void SaveChanges();
    }
}
