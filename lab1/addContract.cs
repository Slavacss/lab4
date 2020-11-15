using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Models;
using BLL.Services;

namespace lab1
{
    public partial class addContract : Form
    {
        DbDataOperation db = new DbDataOperation();

        public addContract()
        {
            InitializeComponent();
            listBox1.DataSource = db.GetAllObjects();
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "objectID";
            listBoxClients.DataSource = db.GetAllClients();
            listBoxClients.DisplayMember = "FIO";
            listBoxClients.ValueMember = "clientID";
            listBoxWorkers.DataSource = db.GetAllWorkers();
            listBoxWorkers.DisplayMember = "FIO";
            listBoxWorkers.ValueMember = "workerID";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (listBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Не выбран ни один товар в заказ!");
                return;
            }
            List<int> items = new List<int>();
            foreach (var i in listBox1.CheckedItems)
                items.Add((i as ObjectModel).objectID);

            ContractModel order = new ContractModel()
            {
                contract_name = textBox1.Text,
                price = textBox2.Text,
                contract_type = textBox3.Text,
                OrderedObjectsIds = items,
                clientFK = (int)listBoxClients.SelectedValue,
                workerFK = (int)listBoxWorkers.SelectedValue

            };

            OrderService service = new OrderService();
            bool result = service.MakeOrder(order);
            if (result)
            {
                MessageBox.Show("Success");
            }
            else MessageBox.Show("Failed");

        }
    }
}
