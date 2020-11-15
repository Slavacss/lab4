using lab1.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab1
{
    public partial class AddClientForm : Form
    {

        Model1 dbcontext = new Model1();
        public AddClientForm()
        {
            InitializeComponent();
        }
        public string t1
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public string t2
        {
            get { return textBox2.Text; }
            set { textBox2.Text = value; }
        }
        public int t3
        {
            get { return int.Parse(textBox3.Text); }
          
        }
       public int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            worker cli = new worker();
            cli.FIO = t1;
            cli.post = t2;
            cli.age = t3;
    

            dbcontext.worker.Add(cli);
            dbcontext.SaveChanges();

            MessageBox.Show("Новый объект добавлен");
        }
    }
}
