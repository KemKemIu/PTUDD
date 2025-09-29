using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_PTUDD
{
    public partial class frmSinhVien : Form
    {
        ThongTinSinhVien ttsv = new ThongTinSinhVien();
        

        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);  
                ThietLapThongTin(sv);                 
            }
            

        }

        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();

            foreach (SinhVien sv in ttsv.ttSinhVien)
            {
                Them(sv);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            if (sv == null) return;

            ttsv.Them(sv); 
            LoadListView();
            ttsv.GhiFile("DanhSachSV.txt");
        }


        private void Them(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.HoVaTenLot);
            lvitem.SubItems.Add(sv.Ten);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.SoCMND.ToString());
            lvitem.SubItems.Add(sv.SoDT.ToString());
            lvitem.SubItems.Add(sv.DiaChi);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            string cn = "";
            foreach (string s in sv.MonDanhKy)
                cn += s + ",";
            cn = cn.Substring(0, cn.Length - 1);
            lvitem.SubItems.Add(cn);
            this.lvSinhVien.Items.Add(lvitem);
        }


        private SinhVien GetSinhVien() 
        {
            SinhVien sv = new SinhVien();
            bool gt = rdNam.Checked;
            List<string> cn = new List<string>();
            sv.MSSV = this.txtMSSV.Text;
            sv.HoVaTenLot = this.txtHoTenLot.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = this.cbLop.Text;


            int cmnd;
            if (!int.TryParse(this.txtSoCMND.Text, out cmnd))
                cmnd = 0; 
            sv.SoCMND = cmnd;

            int dt;
            if (!int.TryParse(this.txtSoDT.Text, out dt))
                dt = 0;
            sv.SoDT = dt;


            sv.DiaChi = this.txtDiaChi.Text;
            sv.GioiTinh = gt;
            for (int i = 0; i < clbMonDangKy.Items.Count; i++)
            {
                if (clbMonDangKy.GetItemChecked(i))
                    cn.Add(clbMonDangKy.Items[i].ToString());
            }
            sv.MonDanhKy = cn;
            return sv;

        }

        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoVaTenLot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;

            int socmnd, sodt;
            int.TryParse(lvitem.SubItems[5].Text, out socmnd);
            int.TryParse(lvitem.SubItems[6].Text, out sodt);
            sv.SoCMND = socmnd;
            sv.SoDT = sodt;

            sv.DiaChi = lvitem.SubItems[7].Text;

            sv.GioiTinh = false;
            if (lvitem.SubItems[8].Text == "Nam")
                sv.GioiTinh = true;

            List<string> cn = new List<string>();  
            string[] s = lvitem.SubItems[9].Text.Split(',');

            foreach (string inMon in s)
            {
                cn.Add(inMon);
            }

            sv.MonDanhKy = cn;
            return sv;
        }

        private void ThietLapThongTin(SinhVien sv)
        {
            this.txtMSSV.Text = sv.MSSV;
            this.txtHoTenLot.Text = sv.HoVaTenLot;
            this.txtTen.Text = sv.Ten;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cbLop.Text = sv.Lop;

            this.txtSoCMND.Text = sv.SoCMND.ToString();
            this.txtSoDT.Text = sv.SoDT.ToString();
            this.txtDiaChi.Text = sv.DiaChi;
            if (sv.GioiTinh)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
            for (int i = 0; i < this.clbMonDangKy.Items.Count; i++)
                this.clbMonDangKy.SetItemChecked(i, false);

            foreach (string s in sv.MonDanhKy)
            {
                for (int i = 0; i < this.clbMonDangKy.Items.Count; i++)
                    if (s.CompareTo(this.clbMonDangKy.Items[i]) == 0)
                        this.clbMonDangKy.SetItemChecked(i, true);
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ttsv = new ThongTinSinhVien();
            LoadListView();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private int SoSanhTheoMa(object sv1, object sv2)
        {
            SinhVien sv = sv2 as SinhVien;
            return sv.MSSV.CompareTo(sv1);
        }


        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kq;
            kq = ttsv.Sua(sv, sv.MSSV, SoSanhTheoMa);
            if(kq)
            {
                this.LoadListView();
                ttsv.GhiFile("DanhSachSV.txt");
            }    
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tukhoa = btnTimKiem.Text.Trim().ToLower();
            lvSinhVien.Items.Clear();

            var ketqua = ttsv.ttSinhVien.Where(sv =>
                sv.MSSV.ToLower().Contains(tukhoa) ||
                sv.HoVaTenLot.ToLower().Contains(tukhoa) ||
                sv.Ten.ToLower().Contains(tukhoa) ||
                sv.Lop.ToLower().Contains(tukhoa)
            );

            foreach (SinhVien sv in ketqua)
            {
                Them(sv);
            }
        }

       
    }
}
