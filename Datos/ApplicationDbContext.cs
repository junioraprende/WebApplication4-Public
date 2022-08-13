using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Datos
{
    public class ApplicationDbContext:DbContext
    {
        //constructor en donde se referencia DbContextOption
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        //esto es para modificar
        //este modelo categoria se va crear como una tabla en la base de datos
        public DbSet<Categoria> Categoria { get; set; }

        //cramos esta clase para agregar esta nueva base de datos
        public DbSet<TipoAplicacion> TipoAplicacion { get; set; }
        
    }
}
