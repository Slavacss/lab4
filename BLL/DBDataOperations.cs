using BLL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DbDataOperation
    {
        private Model1 db;
        public DbDataOperation()
        {
            db = new Model1();
            db.worker.Load();
        }

        public List<WorkerModel> GetAllWorkers()
        {
            return db.worker.ToList().Select(i => new WorkerModel(i)).ToList();
        }

        public List<ClientModel> GetAllClients()
        {
            return db.client.ToList().Select(i => new ClientModel(i)).ToList();
        }
        public List<ObjectModel> GetAllObjects()
        {
            return db.obje.ToList().Select(i => new ObjectModel(i)).ToList();
        }
        public WorkerModel GetWorker(int Id)
        {
            return new WorkerModel(db.worker.Find(Id));
        }

        public void CreateWorker(WorkerModel p)
        {
            db.worker.Add(new worker() { workerID = p.workerID, post = p.post, FIO = p.FIO, age = p.age });
            Save();
            //db.Phones.Attach(p);
        }

        public void UpdateWorker(WorkerModel p)
        {
            worker ph = db.worker.Find(p.workerID);
            ph.FIO = p.FIO;
            ph.age = p.age;
            ph.post = p.post;
         //   ph.ManufacturerId = p.ManufacturerId;
            Save();
        }

        public void DeleteWorker(int id)
        {
            worker p = db.worker.Find(id);
            if (p != null)
            {
                db.worker.Remove(p);
                Save();
            }
        }


        public bool Save()
        {
            
                if (db.SaveChanges() > 0) return true;
                return false;
            
           
        }

        //public List<ManufacturerModel> GetManufacturers()
        //{
        //    return db.Manufacturers.ToList().Select(i => new ManufacturerModel(i)).ToList();
        //}

    }
}
