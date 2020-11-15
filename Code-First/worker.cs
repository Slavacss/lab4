using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_First
{
  public  class worker
    {
        public int workerId { get; set; }
        public string FIO { get; set; }
        public string post { get; set; }
        public int age { get; set; }
        public List<client> clients { get; set; }
    }
}
