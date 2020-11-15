using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ObjectModel
    {
        public int objectID { get; set; }

        public string name { get; set; }


        public string value { get; set; }

        public string type { get; set; }

        public string city { get; set; }

        public int? contractFK { get; set; }
        public ObjectModel() { }
        public ObjectModel(obje m)
        {
            objectID = m.objectID;
            name = m.name;
            value = m.value;
            type = m.type;
            city = m.city;
            contractFK = m.contractFK;
         

        }
    }
}
