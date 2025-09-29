using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_PTUDD
{
    public class SinhVien
    {
        public string MSSV {  get; set; }
        public string HoVaTenLot {  get; set; }
        public string Ten {  get; set; }
        public DateTime NgaySinh {  get; set; }
        public string Lop {  get; set; }
        public int SoCMND {  get; set; }
        public int SoDT {  get; set; }
        public string DiaChi {  get; set; }
        public bool GioiTinh {  get; set; }
        public List<string> MonDanhKy { get; set; }
        public SinhVien() { MonDanhKy = new List<string>(); }

        public SinhVien(string mssv, string hotenlot, string ten, DateTime ngaysinh, string lop, int socmnd, int sodt, string diachi, bool gioitinh, List<string> mondk)
        {
            this.MSSV = mssv;
            this.HoVaTenLot = hotenlot;
            this.Ten = ten;
            this.NgaySinh = ngaysinh;
            this.Lop = lop;
            this.SoCMND = socmnd;
            this.SoDT = sodt;
            this.DiaChi = diachi;
            this.GioiTinh = gioitinh;
            this.MonDanhKy = mondk;
        }
    }
}
