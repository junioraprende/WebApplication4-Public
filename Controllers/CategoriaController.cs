using Microsoft.AspNetCore.Mvc;
using WebApplication4.Datos;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CategoriaController: Controller

    {
        private readonly ApplicationDbContext _db;
        public CategoriaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() //este método nos muestra los datos en pantalla
        {
            IEnumerable<Categoria> lista = _db.Categoria; //IEnumerable es para listas
            return View(lista);//presentando datos en la vista Index
        }

        //Get
        public IActionResult Crear()
        {

            return View();
        }


		//Post
		[HttpPost]
		[ValidateAntiForgeryToken]//esto es para validar, es un sistema antifalsificaciones
        public IActionResult Crear(Categoria categoria)
        {

			if (ModelState.IsValid)
			{
                _db.Categoria.Add(categoria);//Cargo los datos recibidos de la vista a la base de datos
                _db.SaveChanges();//Con este párametro queda grabado en la base de datos
                return RedirectToAction(nameof(Index));
            }
            return View(categoria); //en caso de dar un error regresa a la vista sin guardar cambios,
                                    //esto gracias al uso ModelState.IsValid
        }
        
    }
}
