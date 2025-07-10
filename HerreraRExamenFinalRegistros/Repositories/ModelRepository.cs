using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using HerreraRExamenFinalRegistros.Models;

namespace HerreraRExamenFinalRegistros.Repositories
{
    public class ModelRepository
    {
        private readonly SQLiteAsyncConnection _db;
        public ModelRepository(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Proyecto>().Wait();
        }

        public Task<int> InsertProyectoAsync(Proyecto proyecto)
        {
            return _db.InsertAsync(proyecto);
        }

        public Task<List<Proyecto>> GetProyectosAsync()
        {
            return _db.Table<Proyecto>().ToListAsync();
        }

    }
}
