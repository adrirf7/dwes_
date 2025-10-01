using Curiosidades.Modelo;
using Microsoft.AspNetCore.Mvc;


namespace Curiosidades.Controladores
{
    public class CuriosidadesController : Controller
    {
        public IActionResult Index(int? id)
        {
            ViewData["Titulo"] = "Curiosidad " + id;


            if (id == 1)
            {
                ViewBag.Horario = ObtenerHorario();
                return View("curiosidad1");
            }

            if (id == 2)
            {
                ViewBag.Productos = ObtenerProductos();
                return View("curiosidad2");
            }

            if (id == 3)
            {
                ViewBag.Productos = ObtenerProductos();
                return View("curiosidad3");
            }

            if (id == 4)
            {
                return RedirectToAction("IMC");
            }



            ViewData["Titulo"] = "Curiosidades";
            return View("index");
        }

        private string[,] ObtenerHorario()
        {
            return new string[6, 5]
            {
                { "Matemáticas", "Lengua", "Inglés", "Historia", "Programación" },
                { "Física", "Lengua", "Biología", "Historia", "Programación" },
                { "Física", "Mates", "Inglés", "Economía", "Programación" },
                { "Educ. Física", "Filosofía", "Inglés", "Historia", "Programación" },
                { "Física", "Lengua", "Tutoría", "Historia", "Programación" },
                { "Física", "Lengua", "Libre", "Historia", "Programación" }
            };
        }

        private List<Producto> ObtenerProductos()
        {
            return new List<Producto>
     {
         new Producto { Nombre = "Ratón óptico", Categoria = "Periféricos", Precio = 12.99 },
         new Producto { Nombre = "Teclado mecánico", Categoria = "Periféricos", Precio = 45.50 },
         new Producto { Nombre = "Disco SSD 1TB", Categoria = "Almacenamiento", Precio = 89.90 },
         new Producto { Nombre = "Monitor 24\"", Categoria = "Pantallas", Precio = 129.99 }
     };
        }

        [HttpGet]
        public IActionResult IMC()
        {
            return View("curiosidad4");
        }

        [HttpPost]
        public IActionResult IMC(double peso, double altura)
        {
            ViewData["Titulo"] = "Curiosidad 4";
            ViewBag.Peso = peso;
            ViewBag.Altura = altura;


            if (altura > 0)
            {
                double imc = peso / (altura * altura);
                ViewBag.IMC = imc;
            }
            else
            {
                ViewBag.IMC = null;
            }


            return View("Curiosidad4");
        }


    }
}
