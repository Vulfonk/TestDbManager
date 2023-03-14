using DataBase;
using DataBase.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TestDbManager
{
    public class DataBaseService
    {
        public void DeleteObject(Subject subject, UserContext db)
        {
            var childs = db.Links.Where(x=>x.ParentId == subject.Id).Select(x=>x.Child).ToList();

            foreach (var sub in childs)
            {
                DeleteObject(sub, db);
            }

            var link = db.Links.FirstOrDefault(x => x.ChildId == subject.Id);
            
            if (link != null)
            {
                db.Links.Remove(link);
                db.SaveChanges();
            }

            db.Objects.Attach(subject);
            db.Entry(subject).State = EntityState.Deleted;
            db.Objects.Remove(subject);
            db.SaveChanges();
        }

        public void DeleteObject(Subject subject)
        {
            using(var db = new UserContext())
            {
                this.DeleteObject(subject, db);
            }
        }

        public DataBaseService() { }
    }
}
