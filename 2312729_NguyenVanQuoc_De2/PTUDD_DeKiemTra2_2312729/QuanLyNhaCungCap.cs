using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTUDD_DeKiemTra2_2312729
{
    public delegate int SoSanh(object ncc1, object ncc2);
    class QuanLyNhaCungCap
    {
        public List<NhaCungCap> qlNhaCungCap;

        public QuanLyNhaCungCap()
        {
            qlNhaCungCap = new List<NhaCungCap>();
        }

        public NhaCungCap this[int index]
        {
            get { return this.qlNhaCungCap[index]; }
            set { this.qlNhaCungCap[index] = value; }
        }

        public void Them(NhaCungCap nhacc)
        {
            this.qlNhaCungCap.Add(nhacc);
        }

        public NhaCungCap TimSV(object obj, SoSanh ss)
        {
            NhaCungCap svresult = null;
            foreach (NhaCungCap ncc in qlNhaCungCap)
                if (ss(obj, ncc) == 0)
                {
                    svresult = ncc;
                    break;
                }
            return svresult;
        }

        public void CapNhat(NhaCungCap ncc)
        {
            for (int i = 0; i < qlNhaCungCap.Count; i++)
            {
                if (qlNhaCungCap[i].MaNCC == ncc.MaNCC)
                {
                    qlNhaCungCap[i] = ncc;
                    return;
                }
            }
        }

        public bool Sua(NhaCungCap nccsua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.qlNhaCungCap.Count - 1;
            for (i = 0; i < count; i++)
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = nccsua;
                    kq = true;
                    break;
                }
            return kq;
        }


        public void GhiFile(string filename)
        {
            using (StreamWriter sr = new StreamWriter(new FileStream(filename, FileMode.Create)))
            {
                foreach (NhaCungCap ncc in qlNhaCungCap)
                {
                    sr.WriteLine($"{ncc.MaNCC}\t{ncc.TenNCC} \t{ncc.DiaChi}" + $"\t{ncc.SDT}\t{ncc.MoTa}");
                }
            }
        }
    }
}
