using Microsoft.Data.Sqlite;
using System.IO;

namespace FlatBrowser.Database {
    public class FlatBrowserDb {

        private const string dbName = "flatbrowser.sqlite";

        private const string sqliteVersion = "3";
        private const string connectionString = "Data Source=" + dbName;

        private const string CreateFolderCategoryTable =
            "CREATE TABLE IF NOT EXISTS [FolderCategories]( "
            + " FolderCategoryId INTEGER NOT NULL PRIMARY KEY,"
            + " Name TEXT" +
            ")";

        private const string CreateFolderTable =
            "CREATE TABLE IF NOT EXISTS [Folders](" +
            " FolderId INTEGER NOT NULL PRIMARY KEY," +
            " Path TEXT," +
            " FolderCategoryId INTEGER" +
            ")";

        private const string CreateFileExtensionTable =
            "CREATE TABLE IF NOT EXISTS [FileExtensions](" +
            " FileExtensionId INTEGER NOT NULL PRIMARY KEY," +
            " Name TEXT," +
            " FolderCategoryId INTEGER" +
            ")";



        public FlatBrowserDb() {
            if (!File.Exists(dbName)) {
                CreateDatabase();
            }
        }

        private void CreateDatabase() {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();

            string[] commands = new string[] {
                CreateFolderCategoryTable,
                CreateFileExtensionTable,
                CreateFolderTable
            };

            try {
                foreach (string command in commands) {
                    using SqliteCommand sqliteCommand = new SqliteCommand(command, connection);
                    sqliteCommand.ExecuteNonQuery();
                }
            } catch (SqliteException) {
                File.Delete(dbName);
                throw;
            }

            connection.Close();
        }

        public SqliteConnection GetConnection() {
            return new SqliteConnection(connectionString);
        }

    }
}
