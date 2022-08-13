using System.ComponentModel.DataAnnotations;
namespace WebApplication4.Models
{
	public class TipoAplicacion
	{
		[Key]
		public int Id { get; set; }
		public string Nombre { get; set; }
	}
}
