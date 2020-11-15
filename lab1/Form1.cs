using lab1.EF;
using BLL;
using BLL.Models;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab1
{//WorkerModel
    public partial class Form1 : Form
    {
        DbDataOperation dbo = new DbDataOperation();
        List<WorkerModel> allWorkers;
        List<ClientModel> allClients;
        List<ObjectModel> allObjects;
        //   List<PhoneModel> allPhones;
        public Form1()
        {
            InitializeComponent();
            loadWorkers();
            loadClients();
            allClients = dbo.GetAllClients();
            comboBox1.DataSource = allClients;
            comboBox1.DisplayMember = "FIO";
            comboBox1.ValueMember = "clientID";
           
        }
        private void loadWorkers()
        {
            allWorkers = dbo.GetAllWorkers();
            // Отображаем данные
            bindingSourceWorkers.DataSource = allWorkers;
            // Заполнение комбобокса "Производитель" в таблице "Товары".
           // FillManufacturerCombobox();
        }
      
        private void loadClients()
        {
            bindingSourceClients.DataSource = dbo.GetAllClients();
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            bool res = Validate();
            if (res)
            {
                dbo.Save();
            }
        }

        private void buttonReport1_Click(object sender, EventArgs e)
        {
            //         var request = dbcontext.contract
            //// .Join(dbcontext.client, ph => ph.clientFK, m => m.clientID, (ph, m) => ph)
            // .Where(i => i.clientFK == (int)comboBox1.SelectedValue)
            // .Select(i => new { i.contract_name, i.price })
            // .ToList();
            //         dataGridView1.DataSource = request;
           dataGridView1.DataSource = logic.ReportOrdersByMonth((int)comboBox1.SelectedValue);
        }

    
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = logic.ExecuteSP(Convert.ToInt32(textBox1.Text));
            dataGridView2.Refresh();
        }


            private void btnAdd_Click(object sender, EventArgs e)
        {
            AddClientForm f = new AddClientForm();
            

            DialogResult result = f.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            WorkerModel wor = new WorkerModel();
            wor.FIO = f.t1;
            wor.post = f.t2;
            wor.age = f.t3;
            wor.workerID = 10;
            dbo.CreateWorker(wor);
            allWorkers = dbo.GetAllWorkers();
            bindingSourceWorkers.DataSource = allWorkers;
            MessageBox.Show("Новый объект добавлен");
        }
        private int getSelectedRow(DataGridView dataGridView)
        {
            int index = -1;
            if (dataGridView.SelectedRows.Count > 0 || dataGridView.SelectedCells.Count == 1)
            {
                if (dataGridView.SelectedRows.Count > 0)
                    index = dataGridView.SelectedRows[0].Index;
                else index = dataGridView.SelectedCells[0].RowIndex;
            }
            return index;
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = getSelectedRow(dataGridViewWorkers);
            if (index != -1)
            {
                int id = 0;
                bool converted = Int32.TryParse(dataGridViewWorkers[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;
                dbo.DeleteWorker(id);
                bindingSourceWorkers.DataSource = dbo.GetAllWorkers();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            addContract ff = new addContract();
            DialogResult result = ff.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;
        }
    }
}
