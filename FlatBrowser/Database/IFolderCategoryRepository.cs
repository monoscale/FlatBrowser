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
        void Remove(FolderCategory folderCategory);
    }
}
