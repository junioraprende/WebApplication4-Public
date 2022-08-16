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
                return RedirectToAction(nameof(Index)); //finalizado la grabacion de cambio, regreso a la vista principal de index Categoria
            }
            return View(categoria); //en caso de dar un error regresa a la vista sin guardar cambios,
                                    //esto gracias al uso ModelState.IsValid
        }


        //Get Editar
        public IActionResult Editar(int? Id) //Esperamos el párametro Id de tipo int la ? es valores nulos
        {
            if (Id==null || Id==0) //validadmos en caso ser nulo o igual a cero nos diga que nos encontro la solicitud
            {
                return NotFound();
            }
            var obj =_db.Categoria.Find(Id); //Mediante la clase Find(párametro) Entity nos busca el valor de la base de datos
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj); //Si encontramos algo en la vista mediante el id, lo traemos a la vista del usuario
        }
    }
}
