﻿using System.Collections.Generic;
using System.ServiceModel;

namespace SakilaWFC
{
    [ServiceContract]
    public interface IService1
    {
        //COUNTRY
        [OperationContract]
        List<Models.CountryModel> MostrarTodosCountry(string sortOrder, string filter);

        [OperationContract]
        bool InsertarCountry(country nuevoCountry);

        [OperationContract]
        Models.CountryModel VerCountry(int idCountry);

        [OperationContract]
        bool ActualizarCountry(country countryActualizado);

        [OperationContract]
        bool BorrarCountry(int idCountry);

        //CITY
        [OperationContract]
        List<Models.CityModel> MostrarTodosCity();

        [OperationContract]
        bool InsertarCity(city nuevoCity);

        [OperationContract]
        Models.CityModel VerCity(int idCity);

        [OperationContract]
        bool ActualizarCity(city cityActualizado);

        [OperationContract]
        bool BorrarCity(int idCity);

        //ADDRESS
        [OperationContract]
        List<Models.AddressModel> MostrarTodosAddress();

        [OperationContract]
        bool InsertarAddress(address nuevoAddress);

        [OperationContract]
        bool ActualizarAddress(address addressActualizado);

        [OperationContract]
        bool BorrarAddress(address delAddress);

        //CUSTOMER
        [OperationContract]
        List<Models.CustomerModel> MostrarTodosCustomer();

        [OperationContract]
        bool InsertarCustomer(customer nuevoCustomer);

        [OperationContract]
        bool ActualizarCustomer(customer customerActualizado);

        [OperationContract]
        bool BorrarCustomer(customer delCustomer);
    }
}
