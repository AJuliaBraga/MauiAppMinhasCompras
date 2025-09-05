using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Descricao { 
            get => Descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha a descrição");
                }

               Descricao = value;
            }
        }

        public double Quantidade { get; set; }

        public double Preco { get; set; }

        public double Total { get => Quantidade * Preco; }
    }
}
