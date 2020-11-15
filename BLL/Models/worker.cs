using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
  public class WorkerModel
    {

        public int workerID { get; set; }

        public string FIO { get; set; }

        public string post { get; set; }

        public int age { get; set; }



        public string OrderedContracts { get; set; }
        public List<int> OrderedContractsIds { get; set; }
        public WorkerModel() { }
        public WorkerModel(worker m)
        {
            workerID = m.workerID;
            FIO = m.FIO;
            post = m.post;
            age = m.age;
            OrderedContracts = String.Join(",", m.contract.Select(i => i.contract_name).ToList());
            OrderedContractsIds = m.contract.Select(i => i.contractID).ToList();
        }

    }
}
