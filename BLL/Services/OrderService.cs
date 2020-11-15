using DAL;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   public class OrderService
    {
        Model1 db;
        public OrderService()
        {
            db = new Model1();
        }
        public bool MakeOrder(ContractModel orderDto)
        {
            List<obje> orderedphones = new List<obje>();
           
            foreach (var pId in orderDto.OrderedObjectsIds)
            {
                obje phone = db.obje.Find(pId);
                // валидация

                orderedphones.Add(phone);
            }
            // применяем скидку
          
            contract order = new contract
            {
                date = DateTime.Now,
                contract_name = orderDto.contract_name,
                price = orderDto.price,
                contract_type = orderDto.contract_type,
                clientFK = orderDto.clientFK,
                workerFK = orderDto.workerFK
            };
            db.contract.Add(order);
            if (db.SaveChanges() > 0)
                return true;
            return false;

        }

    }
}
