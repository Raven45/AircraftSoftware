using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Aircraft.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int Persist(int Id, string Model, string Serial);

        [OperationContract]
        bool Remove(int Id);

        [OperationContract]
        List<AircraftView> Retrieve();

        // TODO: Add your service operations here
    }
}
