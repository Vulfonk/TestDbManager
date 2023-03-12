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

                var child2 = new Subject()
                {
                    Product = "Диздок диздока",
                    Type = "Документ"
                };

                var link = new Link()
                {
                    Parent = subj,
                    Child = child,
                };

                var link2 = new Link()
                {
                    Parent = child,
                    Child = child2,
                };

                db.Objects.Add(subj);
                db.Objects.Add(child);
                db.Objects.Add(child2);

                db.Links.Add(link);
                db.Links.Add(link2);

                db.SaveChanges();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new UserContext())
            {
                treeView1.Nodes.Clear();
                var listObjects = db.Objects.ToList();
                List<TreeNode> nodeList = listObjects.Select(x => GenerateTreeNode(x)).ToList();

                foreach (var link in db.Links)
                {
                    AddLink(nodeList, link);
                }

                var roots = nodeList.Where(x => x.Parent == null);


                this.treeView1.Nodes.AddRange(roots.ToArray());
            }
        }

        private void AddLink(List<TreeNode> nodes, Link link)
        {
            var parent = link.Parent;
            var child = link.Child;

            var parentNode = nodes.FirstOrDefault(x => x.Tag == parent);
            var childNode = nodes.FirstOrDefault(x => x.Tag == child);

            parentNode.Nodes.Add(childNode);
        }

        private TreeNode GenerateTreeNode(Subject subject)
        {
            return new TreeNode() { Tag = subject, Text = subject.Product};
        }
    }
}
