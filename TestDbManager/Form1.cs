using DataBase;
using DataBase.DTO;
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

                var child = new Subject()
                {
                    Product = "Диздок",
                    Type = "Документ"
                };

                var link = new Link()
                {
                    Parent = subj,
                    Child = child,
                };

                db.Objects.Add(subj);
                db.Objects.Add(child);
                db.Links.Add(link);

                db.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new UserContext())
            {
                treeView1.Nodes.Clear();
                var listObjects = db.Objects.ToList();
                List<SubjectView> nodeList = listObjects.Select(x => GenerateTreeNode(x)).ToList();

                foreach (var link in db.Links)
                {
                    AddLink(nodeList, link);
                }

                var roots = nodeList.Where(x => x.Parent == null);
                this.treeView1.Nodes.AddRange(nodeList.ToArray());
            }
        }

        private void AddLink(List<SubjectView> subjects, Link link)
        {
            var parent = link.Parent;
            var child = link.Child;
            var parentSubject = subjects.FirstOrDefault(x => x.Subject == parent);
            var childSubject = subjects.FirstOrDefault(x => x.Subject == child);
            parentSubject.Childs.Add(parent);
            childSubject.Parent = parent;
        }

        private SubjectView GenerateTreeNode(Subject subject)
        {

            return new SubjectView() { Subject = subject};
        }

    }
}
