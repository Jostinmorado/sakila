using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Cons.Controllers
{
    public class CountryController : Controller
    {
        ServiceReference1.Service1Client SC = new ServiceReference1.Service1Client();

        public ActionResult MostrarTodos()
        {
            var lista = SC.MostrarTodosCountry();

            return View(lista);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ServiceReference1.CountryModel model)
        {
            if (ModelState.IsValid)
            {
                ServiceReference1.country cc = new ServiceReference1.country();

                cc.country1 = model.country;

                bool al = SC.InsertarCountry(cc);

                if (al == true)
                {
                    return RedirectToAction("Crear");
                }  
            }
            return View(model);
        }

        public ActionResult Modificar(int id)
        {
            var country_ = SC.VerCountry(id);
            return View(country_);
        }

        [HttpPost]
        public ActionResult Modificar(ServiceReference1.CountryModel model)
        {
            if (ModelState.IsValid)
            {
                ServiceReference1.country cc = new ServiceReference1.country();

                cc.country1 = model.country;
                cc.country_id = short.Parse(model.country_id.ToString());

                bool al = SC.ActualizarCountry(cc);

                if (al == true)
                {
                    return RedirectToAction("MostrarTodos");
                }

            }
            return View(model);
        }
    }
}