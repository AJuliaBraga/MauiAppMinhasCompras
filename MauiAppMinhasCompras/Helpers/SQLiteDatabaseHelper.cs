using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
     public class SQLiteDatabaseHelper
    {

        readonly SQLiteAsyncConnection _conect;
        public SQLiteDatabaseHelper(string path) 
        {
            _conect = new SQLiteAsyncConnection(path);
            _conect.CreateTableAsync<Produto>().Wait(); 
        }

        public Task<int> Insert (Produto p) 
        {
            return _conect.InsertAsync(p);
        }

        public Task<List<Produto>> Update (Produto p) 
        {
           
            string sql = "UPDATE Produto SET Decricao=?, Quantidade=?, Preco=? Where Id=?"; 
            return _conect.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id);
        }

        public Task<int> Delete(int id ) 
        {
            return _conect.Table<Produto>().DeleteAsync(i => i.Id == id);
           
        }

        public Task<List<Produto>> GetAll() 
        {
          return  _conect.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search (string q ) 
        {
            string sql = "SELECT * Produto Where Descricao LIKE '%"+ q + "%'";
            return _conect.QueryAsync<Produto>(sql);
        }
    }
}
