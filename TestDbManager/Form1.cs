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

        /// <summary>
        /// Добавить соединение
        /// </summary>
        /// <param name="nodes">Ноды</param>
        /// <param name="link">Слединение</param>
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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            using (var db = new UserContext())
            {
                dataGridView1.Rows.Clear();
                Subject subject = node.Tag as Subject;
                var attributes = db.Attributes.Where(x => x.ObjectId== subject.Id);
                foreach(var attr in attributes)
                {
                    dataGridView1.Rows.Add(attr.Name, attr.Value);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
        }
    }
}
