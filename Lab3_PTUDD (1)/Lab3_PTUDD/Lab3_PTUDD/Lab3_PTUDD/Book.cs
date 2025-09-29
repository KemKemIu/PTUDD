using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab3_PTUDD
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int YearPublished { get; set; }
    }

    public class BookManager
    {
        // Ghi danh sách sách ra file XML
        public static void SaveToXmlFile(List<Book> books, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Book>));
            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, books);
            }
        }

        // Đọc danh sách sách từ file XML
        public static List<Book> LoadFromXmlFile(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Book>));
            using (var reader = new StreamReader(fileName))
            {
                return (List<Book>)serializer.Deserialize(reader);
            }
        }
    }
}
