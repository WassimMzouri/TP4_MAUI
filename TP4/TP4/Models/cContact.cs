using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace TP4.Models
{
    public class cContact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email{ get; set; }
    }
    public class cListeContact
    {
        private readonly SQLiteConnection _database;

        public cListeContact(string dbName)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbName);
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<cContact>();
        }

        public List<cContact> GetList()
        {
            return _database.Table<cContact>().ToList();
        }
        public int CreateContact(cContact objet)
        {
            return _database.Insert(objet);
        }
        
        public int DeleteContact (cContact objet)
        {
            return _database.Delete(objet);
        }
        
        public int UpdateContact (cContact objet)
        {

            
            return _database.Update(objet);
        }

    }
}
