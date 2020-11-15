using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
  public class logic
    {
        public class ContractsByDate
        {
            public string name { get; set; }
            public string type   { get; set; }
           
        }
        public class OrdersByPrice
        {
            public string contract_name { get; set; }
            public string price { get; set; }

        }
        private class SPResult
        {
            public string Name { get; set; }
            public string price { get; set; }

        }
        public class ReportData
        {
            public string Name { get; set; }
            public string Price { get; set; }
        }


        /// <summary>
        /// ////////////// PROCEDURE
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static List<ReportData> ReportOrdersByMonth(int clientId)
        {
            Model1 db = new Model1();
            var request = db.contract
             .Join(db.client, ph => ph.clientFK, m => m.clientID, (ph, m) => ph)
             .Where(i => i.clientFK == clientId)
              .Select(i => new ReportData() { Name = i.contract_name, Price = i.price })
             .ToList();
            return request;

            //         var request = dbcontext.contract
            //// .Join(dbcontext.client, ph => ph.clientFK, m => m.clientID, (ph, m) => ph)
            // .Where(i => i.clientFK == (int)comboBox1.SelectedValue)
            // .Select(i => new { i.contract_name, i.price })
            // .ToList();
            //         dataGridView1.DataSource = request;
        }


        public static List<OrdersByPrice> ExecuteSP(int price)
        {
            System.Data.SqlClient.SqlParameter param1 = new System.Data.SqlClient.SqlParameter("@priceCon", price);
            Model1 db = new Model1();
            var result = db.Database.SqlQuery<OrdersByPrice>("GOD @priceCon", new object[] { param1 } ).ToList();
            
            return result;


        }
       
    }
}
