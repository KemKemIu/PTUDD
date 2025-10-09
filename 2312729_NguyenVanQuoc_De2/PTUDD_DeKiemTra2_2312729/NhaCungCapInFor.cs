using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTUDD_DeKiemTra2_2312729
{
    public class NhaCungCapInFor
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }

        public int SDT { get; set; }
        public string MoTa { get; set; }

        public NhaCungCapInFor(string maNCC, string tenNCC, string diaChi, int sDT, string moTa)
        {
            this.MaNCC = maNCC;
            this.TenNCC = tenNCC;
            this.DiaChi = diaChi;
            this.SDT = sDT;
            this.MoTa = moTa;
        }
    }
}
