using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDbManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new UserContext())
            {
                var subj = new Subject()
                {
                    Product = "СЕ.1235.00.00.000",
                    Type = "Сборочная единица"
                };
                db.Objects.Add(subj);
                db.SaveChanges();
            }
        }
    }
}
