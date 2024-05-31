using ProjetoCRM.API.Models;

namespace ProjetoCRM.API.Data
{
    //Cria um data context para conectar a aplicação à base de dados
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; } //dbset para a entidade clientes
    }
}
