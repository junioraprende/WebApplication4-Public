using Microsoft.AspNetCore.Mvc;
using WebApplication4.Datos;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class TipoAplicacionController : Controller

    {
        private readonly ApplicationDbContext _db;
        public TipoAplicacionController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<TipoAplicacion> lista = _db.TipoAplicacion;
            return View(lista);
        }

        //Get
        public IActionResult Crear()
        {

            return View();
        }


		//Post
		[HttpPost]
		[ValidateAntiForgeryToken]//esto es para validar, es un sistema antifalsificaciones
        public IActionResult Crear(TipoAplicacion tipoAplicacion)
        {

            _db.TipoAplicacion.Add(tipoAplicacion);//Cargo los datos recibidos de la vista a la base de datos
            _db.SaveChanges();//Con este párametro queda grabado en la base de datos
            return RedirectToAction(nameof(Index));
        }
    }
}
