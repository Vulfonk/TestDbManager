using DataBase.DTO;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDbManager
{
    public class TestData
    {


        public void FillTestData()
        {

        }

        public void FillDataBase()
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

                var attributeName = new DataBase.DTO.Attribute()
                {
                    Object = child,
                    Name = "Название",
                    Value = "ГОСТ",
                };

                var attributeMaterial = new DataBase.DTO.Attribute()
                {
                    Object = child,
                    Name = "Материал",
                    Value = "Бумага",
                };

                db.Objects.Add(subj);
                db.Objects.Add(child);
                db.Objects.Add(child2);

                db.Links.Add(link);
                db.Links.Add(link2);

                db.Attributes.Add(attributeName);
                db.Attributes.Add(attributeMaterial);

                db.SaveChanges();
            }
        }
    }
}