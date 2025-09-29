using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_PTUDD
{
    public class StudentInfor
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }
        public double Diem { get; set; }
        public bool TonGiao {  get; set; }
        
        public StudentInfor(string mSSV, string hoTen, int tuoi, double diem, bool tonGiao)
        {
            this.MSSV = mSSV;
            this.HoTen = hoTen;
            this.Tuoi = tuoi;
            this.Diem = diem;
            this.TonGiao = tonGiao;
        }
    }
}
