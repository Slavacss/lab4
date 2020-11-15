using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ClientModel
    {

        public int clientID { get; set; }
        public string FIO { get; set; }
        public string type_of_face { get; set; }
        public string city { get; set; }

        public string OrderedContracts { get; set; }
        public List<int> OrderedContractsIds { get; set; }
        public ClientModel() { }
            public ClientModel(client m)
            {
                clientID = m.clientID;
                FIO = m.FIO;
                type_of_face = m.type_of_face;
                city = m.city;
            OrderedContracts = String.Join(",", m.contract.Select(i => i.contract_name).ToList());
            OrderedContractsIds = m.contract.Select(i => i.contractID).ToList();
        }

    }
}
