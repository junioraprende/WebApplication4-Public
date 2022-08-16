using System.ComponentModel.DataAnnotations;//para validaciones usamos DataAnnotations de .net para hacerlo y no ocupar javascript

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
        //Range(numeroMenor,numeroMayor) o usando anteriormente para indicar el valor inicia de 1 y que permite el maximo valor
        //soportador por int, si no mostrar un mensaje de error.
        public int MostrarOrden { get; set; }
    }
}
