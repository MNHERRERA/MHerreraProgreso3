using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MHerreraProgreso3.Models;

namespace MHerreraProgreso3.Services
{
    class ProductoDatabase
    {
        private readonly SQLiteAsyncConnection _database;
        public ProductoDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Producto>().Wait();
        }
        public Task<List<Producto>> GetProductosAsync() => _database.Table<Producto>().ToListAsync();
        public Task<int> SaveProductoAsync(Producto producto) => _database.InsertAsync(producto);
        public Task<int> DeleteProductoAsync(Producto producto) => _database.DeleteAsync(producto);    
    }
}
