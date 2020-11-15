using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ContractModel
    { 


   public int contractID { get; set; }

    public string contract_name { get; set; }

    public string contract_type { get; set; }


    public string price { get; set; }

    public DateTime date { get; set; }

    public int clientFK { get; set; }

    public int workerFK { get; set; }
      public string OrderedObjects { get; set; }
        public List<int> OrderedObjectsIds { get; set; }


        public ContractModel() { }
        public ContractModel(contract m)
        {
            contractID = m.contractID;
            contract_name = m.contract_name;
            contract_type = m.contract_type;
            price = m.price;
            date = m.date;
            clientFK = m.clientFK;
            workerFK = m.workerFK;
            OrderedObjects = String.Join(",", m.obje.Select(i => i.name).ToList());
            OrderedObjectsIds = m.obje.Select(i => i.objectID).ToList();
        }

    }
    
    
}
