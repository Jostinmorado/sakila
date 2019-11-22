using System;
using System.Collections.Generic;
using System.Linq;

namespace SakilaWFC
{
    public class Service1 : IService1
    {
        //COUNTRY
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

        //CITY
        public List<Models.CityModel> MostrarTodosCity()
        {
            sakilaEntities contexto = new sakilaEntities();
            List<Models.CityModel> listaResultado = (from l in contexto.city
                                                        select new Models.CityModel
                                                        {
                                                            cityId = l.city_id,
                                                            city = l.city1,
                                                            countryId = l.country_id,
                                                            last_update = l.last_update
                                                        }).ToList();
            return listaResultado;
        }

        public bool InsertarCity(city nuevoCity)
        {
            sakilaEntities contexto = new sakilaEntities();
            nuevoCity.last_update = DateTime.Now;

            contexto.city.Add(nuevoCity);
            contexto.SaveChanges();
            return true;
        }

        public bool ActualizarCity(city cityActualizado)
        {
            sakilaEntities contexto = new sakilaEntities();

            var city_ = (from T0 in contexto.city
                            where T0.city_id == cityActualizado.city_id
                         select T0).FirstOrDefault();

            city_.city1 = cityActualizado.city1;
            city_.last_update = DateTime.Now;

            contexto.SaveChanges();
            return true;
        }

        public bool BorrarCity(city delCity)
        {
            sakilaEntities contexto = new sakilaEntities();
            var city_ = (from T0 in contexto.city
                         where T0.city_id == delCity.city_id
                         select T0).FirstOrDefault();

            contexto.city.Remove(city_);
            contexto.SaveChanges();
            return true;
        }

        //ADDRESS


        //CUSTOMER
    }
}
