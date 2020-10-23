using FlatBrowser.Models;
using System.Linq;

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
