using TestDbManager.DataBase;
using TestDbManager.DataBase.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDbManager.Views
{
    public partial class AddDialog : Form
    {
        public Subject Subject { get; set; }
        public string LinkName { get; set; }

        public AddDialog()
        {
            InitializeComponent();
        }

        private void AddDialog_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            var name = this.textBoxName.Text;
            var type = this.textBoxType.Text;

            var subject = new Subject()
            {
                Type = type,
                Product = name,
            };

            this.Subject = subject;

            var attrRows = this.dataGridViewAttributes.Rows;
            var attributes = new List<DataBase.DTO.Attribute>();
            for(int i = 0; i < attrRows.Count; i++)
            {
                var row = attrRows[i];
                if(row.Cells[0]?.Value == null || row.Cells[1]?.Value == null)
                {
                    continue;
                }

                var attrName = row.Cells[0].Value.ToString();
                var attrValue = row.Cells[1].Value.ToString();

                var attribute = new DataBase.DTO.Attribute()
                {
                    Object = subject,
                    Name = attrName,
                    Value = attrValue
                };
                attributes.Add(attribute);
            }

            using(var db = new UserContext())
            {
                db.Objects.Add(subject);
                db.Attributes.AddRange(attributes);
                db.SaveChanges();
            }

            this.LinkName = this.labelLinkType.Text;

            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
