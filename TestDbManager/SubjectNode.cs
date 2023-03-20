using DataBase.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestDbManager
{
    [XmlRoot("Subject")]
    public class SubjectNode
    {
        private Subject subject;

        [XmlAttribute]
        public int Id { get => subject.Id; set => subject.Id = value; }

        [XmlAttribute]
        public string Product { get => subject.Product; set => subject.Product = value; }

        [XmlAttribute]
        public string Type { get => subject.Type; set => subject.Type = value; }

        [XmlIgnore]
        public SubjectNode Parent { get; set; }

        public List<SubjectNode> Childs = new List<SubjectNode>();

        public SubjectNode(Subject subject)
        {
            this.subject = subject;
            this.Id = subject.Id;
        }

        public SubjectNode() { }
    }
}
