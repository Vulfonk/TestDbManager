using DataBase.DTO;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace TestDbManager
{
    public static class TestData
    {

        public static void ClearDataBase()
        {
            using (var db = new UserContext())
            {
                var listObj = db.Objects.ToList();
                foreach (var obj in listObj)
                {
                    db.Objects.Remove(obj);
                }

                var listLinks = db.Links.ToList();
                foreach (var link in listLinks)
                {
                    db.Links.Remove(link);
                }

                var listAttrs = db.Attributes.ToList();
                foreach (var attr in listAttrs)
                {
                    db.Attributes.Remove(attr);
                }


                db.SaveChanges();
            }
        }

        public static void FillTestData()
        {
            var subjects = new List<Subject>()
            {
                new Subject{ Id=103, Product="СЕ.1235.00.00.000", Type="Сборочная единица"},
                new Subject{ Id=104, Product="СЕ.1235.01.00.000", Type="Сборочная единица"},
                new Subject{ Id=105, Product="СЕ.1235.01.01.000", Type="Сборочная единица"},
                new Subject{ Id=106, Product="СЕ.1235.01.01.001", Type="Деталь"},
                new Subject{ Id=107, Product="СЕ.1235.01.01.002", Type="Деталь"},
                new Subject{ Id=108, Product="СЕ.1235.01.02.000", Type="Деталь"},
                new Subject{ Id=109, Product="СЕ.1235.01.00.001", Type="Деталь"},
                new Subject{ Id=110, Product="СЕ.1235.01.00.001", Type="Сборочная единица"},
                new Subject{ Id=111, Product="СЕ.1235.02.00.001", Type="Деталь"},
                new Subject{ Id=112, Product="СЕ.1235.00.00.001", Type="Сборочная единица"},
                new Subject{ Id=113, Product="Сталь 09Г2С", Type="Материал по КД"},
                new Subject{ Id=114, Product="СЕ.1005.00.00.000", Type="Сборочная единица"},
                new Subject{ Id=115, Product="Канат стальной", Type="Материал по КД"},
                new Subject{ Id=116, Product="СЕ.1235.01.01.000 ВП", Type="Документ СЕ.1235.01.01.000"},
            };

            var links = new List<Link>()
            {
                new Link { ParentId = 103, ChildId = 104, Type = "Состоит из …" },
                new Link { ParentId = 104, ChildId = 105, Type = "Состоит из …" },
                new Link { ParentId = 104, ChildId = 108, Type = "Состоит из …" },
                new Link { ParentId = 104, ChildId = 109, Type = "Состоит из …" },
                new Link { ParentId = 105, ChildId = 106, Type = "Состоит из …" },
                new Link { ParentId = 105, ChildId = 107, Type = "Состоит из …" },
                new Link { ParentId = 112, ChildId = 113, Type = "Изготавливается из …" },
                new Link { ParentId = 105, ChildId = 115, Type = "Материал по КД" },
                new Link { ParentId = 105, ChildId = 116, Type = "Документы" },
                new Link { ParentId = 110, ChildId = 111, Type = "Состоит из …" },
                new Link { ParentId = 103, ChildId = 112, Type = "Состоит из …" },
                new Link { ParentId = 103, ChildId = 114, Type = "Состоит из …" },
                new Link { ParentId = 103, ChildId = 110, Type = "Состоит из …" },

            };

            var attributes = new List<DataBase.DTO.Attribute>()
            {
                new DataBase.DTO.Attribute { ObjectId = 103, Name = "Наименование", Value = "Фланец" },
                new DataBase.DTO.Attribute { ObjectId = 103, Name = "Раздел спецификации", Value = "Сборочные единицы" },
                new DataBase.DTO.Attribute { ObjectId = 114, Name = "Наименование", Value = "Колпак" },
                new DataBase.DTO.Attribute { ObjectId = 115, Name = "Марка материала Сталь", Value = "09Г2С" },
            };

            using (var db = new UserContext())
            {
                db.Objects.AddRange(subjects);
                db.Links.AddRange(links);
                db.Attributes.AddRange(attributes);

                db.SaveChanges();
            }
        }
    }
}