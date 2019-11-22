using System.Collections.Generic;
using System.ServiceModel;

namespace SakilaWFC
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Models.CountryModel> MostrarTodosCountry();

        [OperationContract]
        bool InsertarCountry(country nuevoCountry);

        [OperationContract]
        bool ActualizarCountry(country countryActualizado);

        [OperationContract]
        bool BorrarCountry(country countryDel);
    }
}
