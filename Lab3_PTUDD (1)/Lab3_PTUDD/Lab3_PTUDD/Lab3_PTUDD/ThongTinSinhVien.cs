using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_PTUDD
{

    public delegate int SoSanh(object sv1, object sv2);

    class ThongTinSinhVien
    {
        public List<SinhVien> ttSinhVien;

        public ThongTinSinhVien() 
        {
            ttSinhVien = new List<SinhVien>();
        }

        public SinhVien this[int index]
        {
            get { return this.ttSinhVien[index]; }
            set { this.ttSinhVien[index] = value; }
        }

        public void Them(SinhVien sv)
        {
            this.ttSinhVien.Add(sv);
        }

        public SinhVien TimSV(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in ttSinhVien) 
                if(ss(obj, sv) == 0)
                {
                    svresult = sv;
                    break;
                }    
            return svresult;
        }


        //public void DocFile(string filename)
        //{
        //    string t;
        //    string[] s;
        //    SinhVien sv;
        //    using (StreamReader sr = new StreamReader(new FileStream(filename, FileMode.Open))) 
        //    {
        //        while((t = sr.ReadLine()) != null) 
        //        {
        //            s = t.Split('\t');
        //            sv = new SinhVien();
        //            sv.MSSV = s[0];
        //            sv.HoVaTenLot = s[1];
        //            sv.Ten = s[2];
        //            sv.NgaySinh = DateTime.Parse(s[3]);
        //            sv.Lop = s[4];
        //            sv.SoCMND = int.Parse(s[5]);
        //            sv.SoDT = int.Parse(s[6]);
        //            sv.DiaChi = s[7];
        //            sv.GioiTinh = false;
        //            sv.GioiTinh = (s[8] == "1");
        //               // sv.GioiTinh = true;
        //            string[] cn = s[9].Split(',');
        //            foreach (string cn2 in cn)
        //                sv.MonDanhKy.Add(cn2);
        //            this.Them(sv);
        //        }
            
        //    }
        //}

        public void GhiFile(string filename)
        {
            using (StreamWriter sr = new StreamWriter(new FileStream(filename, FileMode.Create)))
            {
                foreach(SinhVien sv in ttSinhVien)
                {
                    string gioiTinh = sv.GioiTinh ? "1" : "Đ";
                    string monHoc = string.Join(",", sv.MonDanhKy);
                    sr.WriteLine($"{sv.MSSV}\t{sv.HoVaTenLot} \t{sv.Ten}\t{ sv.NgaySinh:dd/mm/yy}" + $"\t{sv.Lop}\t{sv.SoCMND}\t{sv.SoDT}\t{sv.DiaChi}\t{gioiTinh}\t{monHoc}");
                }    
            }    
        }


        public void CapNhat(SinhVien sv)
        {
            for (int i = 0; i < ttSinhVien.Count; i++)
            {
                if (ttSinhVien[i].MSSV == sv.MSSV)
                {
                    ttSinhVien[i] = sv;
                    return;
                }
            }
        }

        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.ttSinhVien.Count - 1;
            for (i = 0; i < count; i++)
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            return kq;
        }      


    }
}
