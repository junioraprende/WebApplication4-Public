using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Categoria
    {
        [Key] //primary key de data annotation
        public int Id { get; set; } //primary key

		[Required(ErrorMessage="Nombre de Categoria es Obligatorio.")]
        public string NombreCategoria { get; set; }

		[Required(ErrorMessage ="Orden es Obligatorio")]
		[Range(1, int.MaxValue, ErrorMessage ="El Orden debe ser Mayor a cero.")]    
        public int MostrarOrden { get; set; }
    }
}
