using DataBase.DTO;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDbManager
{
    public class SubjectsTreeFactory
    {
        public SubjectNode GetTree(List<Link> links, List<Subject> subjects)
        {
            var subjectDecorators = new List<SubjectNode>();

            foreach (var subject in subjects)
            {
                subjectDecorators.Add(new SubjectNode(subject));
            }

            foreach (var link in links)
            {
                AddLink(subjectDecorators.ToList(), link);
            }

            var root = subjectDecorators.FirstOrDefault(x=>x.Parent == null);
            return root;
        }

        private void AddLink(List<SubjectNode> subjectDecorators, Link link)
        {
            var parentId = link.ParentId;
            var parent = subjectDecorators.FirstOrDefault(x => x.Id == parentId);
            var childId = link.ChildId;
            var child = subjectDecorators.FirstOrDefault(x => x.Id == childId);

            child.Parent = parent;
            parent.Childs.Add(child);
        }
    }
}
