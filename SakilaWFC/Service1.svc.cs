using System;
using System.Collections.Generic;
using System.Linq;

namespace SakilaWFC
{
    public class Service1 : IService1
    {
        public List<Models.CountryModel> MostrarTodosCountry()
        {
            sakilaEntities contexto = new sakilaEntities();
            List<Models.CountryModel> listaResultado = (from l in contexto.country
                                            select new Models.CountryModel {
                                                country= l.country1,
                                                country_id = l.country_id,
                                                last_update = l.last_update
                                            }).ToList();
            return listaResultado;
        }

        public bool InsertarCountry(country nuevoCountry)
        {
            sakilaEntities contexto = new sakilaEntities();
            nuevoCountry.last_update = DateTime.Now;

            contexto.country.Add(nuevoCountry);
            contexto.SaveChanges();
            return true;
        }

        public bool ActualizarCountry(country countryActualizado)
        {
            sakilaEntities contexto = new sakilaEntities();

            var country_ = (from T0 in contexto.country
                             where T0.country_id == countryActualizado.country_id
                            select T0).FirstOrDefault();

            country_.country1 = countryActualizado.country1;
            country_.last_update = DateTime.Now;

            contexto.SaveChanges();
            return true;
        }

        public bool BorrarCountry(country delCountry)
        {
            sakilaEntities contexto = new sakilaEntities();
            var country_ = (from T0 in contexto.country
                            where T0.country_id == delCountry.country_id
                            select T0).FirstOrDefault();

            contexto.country.Remove(country_);
            contexto.SaveChanges();
            return true;
        }
    }
}
