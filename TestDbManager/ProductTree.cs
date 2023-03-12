using DataBase.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDbManager
{
    internal class ProductTree
    {

    }

    class SubjectView : TreeNode
    {
        public Subject Subject;
        public Subject Parent;
        public List<Subject> Childs = new List<Subject>();

        public string Name => Subject.Product;
    }

}
