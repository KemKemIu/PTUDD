using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Lab3_PTUDD
{
    public class Class1
    {
        public static void TaoFileXML()
        {
            List<Book> sampleBooks = new List<Book>
            {
                new Book { ISBN="9831123212", Title="ADO .Net using C#", Author="Mahesh Chand", Price=44.99m, YearPublished=2002 },
                new Book { ISBN="9781484234", Title="Pro Entity Framework Core 1", Author="Adam Freeman", Price=44.99m, YearPublished=2018 }
            };

            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (StreamWriter writer = new StreamWriter("books.xml"))
            {
                serializer.Serialize(writer, sampleBooks);
            }
        }

    }
}
