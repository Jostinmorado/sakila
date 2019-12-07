using System.Web.Mvc;

namespace Cons.Controllers
{
    public class CityController : Controller
    {
        ServiceReference1.Service1Client SC = new ServiceReference1.Service1Client();

        public ActionResult MostrarTodos()
        {
            var lista = SC.MostrarTodosCity();

            return View(lista);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ServiceReference1.CityModel model)
        {
            if (ModelState.IsValid)
            {
                ServiceReference1.city cc = new ServiceReference1.city();

                cc.city1 = model.city;
                cc.country_id = short.Parse(model.countryId.ToString());

                bool al = SC.InsertarCity(cc);

                if (al == true)
                {
                    return RedirectToAction("Crear");
                }
            }
            return View(model);
        }

        public ActionResult Modificar(int id)
        {
            var city_ = SC.VerCity(id);
            return View(city_);
        }

        [HttpPost]
        public ActionResult Modificar(ServiceReference1.CityModel model)
        {
            if (ModelState.IsValid)
            {
                ServiceReference1.city cc = new ServiceReference1.city();
                cc.city1 = model.city;
                cc.city_id = model.cityId;

                bool al = SC.ActualizarCity(cc);

                if (al == true)
                {
                    return RedirectToAction("MostrarTodos");
                }

            }
            return View(model);
        }

        public ActionResult Eliminar(int id)
        {
            bool city_ = SC.BorrarCity(id);
            return RedirectToAction("MostrarTodos");
        }
    }
}