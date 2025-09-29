using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lab3_PTUDD
{
    public partial class frmReadJsonFile : Form
    {
        
        public frmReadJsonFile()
        {
            InitializeComponent();
        }

        private void btnReadJSON_Click(object sender, EventArgs e)
        {
            string Str = "";
            string Path = "../../students.json";
            List<StudentInfor> List = LoadJSON(Path);
            for (int i = 0; i < List.Count; i++)
            {
                StudentInfor info = List[i];
                Str += string.Format("Sinh viên {0} có MSSV: {1}, họ tên: {2}," +
                    " điểm TB: {3}\r", (i + 1), info.MSSV, info.HoTen, info.Diem);
            }
            MessageBox.Show(Str);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">D:\Lab3_PTUDD\Lab3_PTUDD\Lab3_PTUDD\students.json</param>
        /// <returns></returns>
        private List<StudentInfor> LoadJSON(string path)
        {
            List<StudentInfor> List = new List<StudentInfor>();
            StreamReader sr = new StreamReader(path);
            string json = sr.ReadToEnd();
            var array = (JObject)JsonConvert.DeserializeObject(json);

            var students = array["sinhvien"].Children();
            foreach (var student in students)
            {
                string mssv = student["MSSV"].Value<string>();  // Change 'item' to 'student'
                string hoten = student["hoten"].Value<string>();
                int tuoi = student["tuoi"].Value<int>();
                double diem = student["diem"].Value<double>();
                bool tongiao = student["tongiao"].Value<bool>();  // Unused variable but included for completeness

                StudentInfor info = new StudentInfor(mssv, hoten, tuoi, diem, tongiao);
                List.Add(info);
            }
            return List;
        }

        private void btnReadXML_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists("books.xml"))
                {
                    MessageBox.Show("Chưa có file books.xml. Hệ thống sẽ tạo mới.");
                    Class1.TaoFileXML();
                }

                var books = BookManager.LoadFromXmlFile("books.xml");
                lvBooks.Items.Clear();

                foreach (var b in books)
                {
                    ListViewItem item = new ListViewItem(b.ISBN);
                    item.SubItems.Add(b.Title);
                    item.SubItems.Add(b.Author);
                    item.SubItems.Add(b.Price.ToString("0.00"));
                    item.SubItems.Add(b.YearPublished.ToString());
                    lvBooks.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc file XML: " + ex.Message);
            }
        }
    

    }
}
