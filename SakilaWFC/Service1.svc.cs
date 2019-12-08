using System;
using System.Collections.Generic;
using System.Linq;

namespace SakilaWFC
{
    public class Service1 : IService1
    {
        //COUNTRY
        public List<Models.CountryModel> MostrarTodosCountry(string sortOrder, string filter)
        {
            sakilaEntities contexto = new sakilaEntities();
            var listaResultado = (from l in contexto.country
                                  select new Models.CountryModel
                                  {
                                      country = l.country1,
                                      country_id = l.country_id,
                                      last_update = l.last_update
                                  }).ToList();

            if (!string.IsNullOrEmpty(filter))
            {
                listaResultado = (from l in contexto.country
                                  where l.country1.ToLower().Contains(filter.ToLower())
                                  select new Models.CountryModel
                                  {
                                      country = l.country1,
                                      country_id = l.country_id,
                                      last_update = l.last_update
                                  }).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    listaResultado = (from l in contexto.country
                                     orderby l.country1 descending
                                     select new Models.CountryModel
                                     {
                                         country = l.country1,
                                         country_id = l.country_id,
                                         last_update = l.last_update
                                     }).ToList();

                    break;
                case "Date":
                    listaResultado = (from l in contexto.country
                                     orderby l.last_update
                                     select new Models.CountryModel
                                     {
                                         country = l.country1,
                                         country_id = l.country_id,
                                         last_update = l.last_update
                                     }).ToList();
                    break;
                case "date_desc":
                    listaResultado = (from l in contexto.country
                                      orderby l.last_update descending
                                      select new Models.CountryModel
                                      {
                                          country = l.country1,
                                          country_id = l.country_id,
                                          last_update = l.last_update
                                      }).ToList();
                    break;
                case "ID":
                    listaResultado = (from l in contexto.country
                                      orderby l.country_id
                                      select new Models.CountryModel
                                      {
                                          country = l.country1,
                                          country_id = l.country_id,
                                          last_update = l.last_update
                                      }).ToList();
                break;
                case "id_desc":
                    listaResultado = (from l in contexto.country
                                      orderby l.country_id descending
                                      select new Models.CountryModel
                                      {
                                          country = l.country1,
                                          country_id = l.country_id,
                                          last_update = l.last_update
                                      }).ToList();
                break;
                case "name":
                    listaResultado = (from l in contexto.country
                                      orderby l.country1
                                      select new Models.CountryModel
                                      {
                                          country = l.country1,
                                          country_id = l.country_id,
                                          last_update = l.last_update
                                      }).ToList();
                    break;
            }

            return listaResultado.ToList();
        }

        public bool InsertarCountry(country nuevoCountry)
        {
            sakilaEntities contexto = new sakilaEntities();
            nuevoCountry.last_update = DateTime.Now;

            contexto.country.Add(nuevoCountry);
            contexto.SaveChanges();
            return true;
        }

        public Models.CountryModel VerCountry(int idCountry)
        {
            sakilaEntities contexto = new sakilaEntities();

            Models.CountryModel country_ = (from c in contexto.country
                                           where c.country_id == idCountry
                                           select new Models.CountryModel
                                           {
                                                country_id = c.country_id,
                                                country = c.country1,
                                                last_update = c.last_update
                                            }).FirstOrDefault();
            return country_;
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

        public bool BorrarCountry(int idCountry)
        {
            sakilaEntities contexto = new sakilaEntities();
            var country_ = (from T0 in contexto.country
                            where T0.country_id == idCountry
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
                                                     orderby l.city_id descending
                                                     select new Models.CityModel
                                                        {
                                                            cityId = l.city_id,
                                                            city = l.city1,
                                                            countryId = l.country_id,
                                                            last_update = l.last_update
                                                        }).Take(200).ToList();
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

        public Models.CityModel VerCity(int idCity)
        {
            sakilaEntities contexto = new sakilaEntities();

            Models.CityModel city_ = (from c in contexto.city
                                            where c.city_id == idCity
                                      select new Models.CityModel
                                      {
                                          city = c.city1,
                                          cityId = c.city_id,
                                          countryId = c.country_id,
                                          last_update = c.last_update
                                      }).FirstOrDefault();
            return city_;
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

        public bool BorrarCity(int idCity)
        {
            sakilaEntities contexto = new sakilaEntities();
            var city_ = (from T0 in contexto.city
                         where T0.city_id == idCity
                         select T0).FirstOrDefault();

            contexto.city.Remove(city_);
            contexto.SaveChanges();
            return true;
        }

        //ADDRESS

        public List<Models.AddressModel> MostrarTodosAddress()
        {
            sakilaEntities contexto = new sakilaEntities();
            List<Models.AddressModel> listaResultado = (from l in contexto.address
                                                     select new Models.AddressModel
                                                     {
                                                         address_id = l.address_id,
                                                         desc_address = l.address1,
                                                         desc_address2 = l.address2,
                                                         district = l.district,
                                                         city_id = l.city_id,
                                                         postal_code = l.postal_code,
                                                         phone = l.phone,
                                                         last_update = l.last_update
                                                     }).ToList();
            return listaResultado;
        }

        public bool InsertarAddress(address nuevoAddress)
        {
            sakilaEntities contexto = new sakilaEntities();
            nuevoAddress.last_update = DateTime.Now;

            contexto.address.Add(nuevoAddress);
            contexto.SaveChanges();
            return true;
        }

        public bool ActualizarAddress(address addressActualizado)
        {
            sakilaEntities contexto = new sakilaEntities();

            var address_ = (from T0 in contexto.address
                            where T0.address_id == addressActualizado.address_id
                            select T0).FirstOrDefault();

            address_.address1 = addressActualizado.address1;
            address_.address2 = addressActualizado.address2;
            address_.district = addressActualizado.district;
            address_.city_id = addressActualizado.city_id;
            address_.postal_code = addressActualizado.postal_code;
            address_.phone = addressActualizado.phone;
            address_.last_update = DateTime.Now;

            contexto.SaveChanges();
            return true;
        }

        public bool BorrarAddress(address delAddress)
        {
            sakilaEntities contexto = new sakilaEntities();
            var address_ = (from T0 in contexto.address
                         where T0.address_id == delAddress.address_id
                            select T0).FirstOrDefault();

            contexto.address.Remove(address_);
            contexto.SaveChanges();
            return true;
        }

        //CUSTOMER

        public List<Models.CustomerModel> MostrarTodosCustomer()
        {
            sakilaEntities contexto = new sakilaEntities();
            List<Models.CustomerModel> listaResultado = (from l in contexto.customer
                                                        select new Models.CustomerModel
                                                        {
                                                            customer_id = l.customer_id,
                                                            store_id = l.store_id,
                                                            first_name = l.first_name,
                                                            last_name = l.last_name,
                                                            email = l.email,
                                                            address_id = l.address_id,
                                                            active = l.active,
                                                            create_date = l.create_date,
                                                            last_update = l.last_update
                                                        }).ToList();
            return listaResultado;
        }

        public bool InsertarCustomer(customer nuevoCustomer)
        {
            sakilaEntities contexto = new sakilaEntities();
            nuevoCustomer.create_date = DateTime.Now;
            nuevoCustomer.last_update = DateTime.Now;

            contexto.customer.Add(nuevoCustomer);
            contexto.SaveChanges();
            return true;
        }

        public bool ActualizarCustomer(customer customerActualizado)
        {
            sakilaEntities contexto = new sakilaEntities();

            var customer_ = (from T0 in contexto.customer
                             where T0.customer_id == customerActualizado.customer_id
                            select T0).FirstOrDefault();

            customer_.first_name = customerActualizado.first_name;
            customer_.last_name = customerActualizado.last_name;
            customer_.email = customerActualizado.email;
            customer_.address_id = customerActualizado.address_id;
            customer_.active = customerActualizado.active;
            customer_.last_update = DateTime.Now;

            contexto.SaveChanges();
            return true;
        }

        public bool BorrarCustomer(customer delCustomer)
        {
            sakilaEntities contexto = new sakilaEntities();
            var customer_ = (from T0 in contexto.customer
                             where T0.customer_id == delCustomer.customer_id
                             select T0).FirstOrDefault();

            contexto.customer.Remove(customer_);
            contexto.SaveChanges();
            return true;
        }
    }
}
