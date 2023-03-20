using TestDbManager.DataBase;
using TestDbManager.DataBase.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using TestDbManager.Views;

namespace TestDbManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Database.SetInitializer(
        new DropCreateDatabaseIfModelChanges<UserContext>());
        }

        private void buttonFillDb_Click(object sender, EventArgs e)
        {
            TestData.FillTestData();
        }

        private void buttonShowDb_Click(object sender, EventArgs e)
        {
            UpdateTreeView();
        }

        private void UpdateTreeView()
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
            return new TreeNode() { Tag = subject, Text = subject.Product };
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            using (var db = new UserContext())
            {
                dataGridView1.Rows.Clear();
                Subject subject = node.Tag as Subject;
                var attributes = db.Attributes.Where(x => x.ObjectId == subject.Id);
                foreach (var attr in attributes)
                {
                    dataGridView1.Rows.Add(attr.Name, attr.Value);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersVisible = false;
        }

        private void buttonClearDb_Click(object sender, EventArgs e)
        {
            TestData.ClearDataBase();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var dialog = new AddDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var parent = (this.treeView1.SelectedNode.Tag as Subject);
                var child = dialog.Subject;
                var type = dialog.LinkName;

                var link = new Link()
                {
                    ParentId = parent.Id,
                    ChildId = child.Id,
                    Type = type,
                };
                
                using (var db = new UserContext())
                {
                    db.Links.Add(link);
                    db.SaveChanges();
                    var node = GenerateTreeNode(child);
                    treeView1.SelectedNode.Nodes.Add(node);
                    treeView1.SelectedNode.Expand();
                }
            }

            dialog.Dispose();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView1.SelectedNode;
            if (selectedNode == null)
            {
                return;
            }
            if (selectedNode.Nodes?.Count > 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                var result = MessageBox.Show("Удалить дочерние элементы?", "", buttons);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            DeleteNode(selectedNode);
            treeView1.Nodes.Remove(selectedNode);
        }

        private void DeleteNode(TreeNode node)
        {
            new DataBaseService().DeleteObject(node.Tag as Subject);
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Title = "Save XML Document";
            dlg.Filter = "XML Files (*.xml)|*.xml";
            if(dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            using (var db = new UserContext())
            {
                var objs = db.Objects.ToList();
                var links = db.Links.ToList();

                var root = new SubjectsTreeFactory().GetTree(links, objs);

                var serializer = new XmlSerializer(typeof(SubjectNode));

                using (var writer = new StreamWriter(dlg.FileName))
                {
                    serializer.Serialize(writer, root);
                }
            }
        }
    }


}
