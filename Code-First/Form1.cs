using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_First
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (Model1 dbc = new Model1())
            {
                dbc.clients.Select(i => i).ToList();
                //Можно сразу добавить данные:
                dbc.clients.Add(new client() { clientId = 1, FIO = "Juventus", city="Ivanovo", type_of_face = "legal" });
                dbc.SaveChanges();
            }
        }
    }
}
