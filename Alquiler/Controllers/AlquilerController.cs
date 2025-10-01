using Microsoft.AspNetCore.Mvc;

namespace Alquiler.Controllers
{
    public class AlquilerController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("CalculoAlquiler");
        }

        [HttpGet]
        public IActionResult CalculoAlquiler()
        {
            return View("index");
        }

        [HttpPost]
        public IActionResult CalculoAlquiler(string zona, double m2, string piscina)
        {
            ViewBag.zona = zona;
            ViewBag.m2 = m2;

            bool tienePiscina = !string.IsNullOrEmpty(piscina);
            ViewBag.piscina = tienePiscina;

            double precio = 0;

                if (zona == "getafe")
                {
                    precio = 10 * m2;
                }
                else if (zona == "fuenlabrada")
                {
                    precio = 9 * m2;
                }
                else if (zona == "mostoles")
                {
                    precio = 8 * m2;
                }
                else if (zona == "alcorcon")
                {
                    precio = 11 * m2;
                }

                if(tienePiscina)
            {
                precio += 100;
            }

            ViewBag.precio = precio;
            return View("index");
        }
    }
}
