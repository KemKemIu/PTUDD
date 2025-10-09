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



namespace PTUDD_DeKiemTra2_2312729
{
    public partial class frmQuanLyNhaCungCap : Form
    {
        QuanLyNhaCungCap qlncc = new QuanLyNhaCungCap();
        public frmQuanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            qlncc = new QuanLyNhaCungCap();
            LoadListView();
        }

        private void lvNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.lvNhaCungCap.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvNhaCungCap.SelectedItems[0];
                NhaCungCap sv = GetNhaCungCapLV(lvitem);
                ThietLapThongTin(sv);
            }
        }

        private void LoadListView()
        {
            this.lvNhaCungCap.Items.Clear();

            foreach (NhaCungCap ncc in qlncc.qlNhaCungCap)
            {
                Them(ncc);
            }
        }

        private void Them(NhaCungCap ncc)
        {
            ListViewItem lvitem = new ListViewItem(ncc.MaNCC);
            lvitem.SubItems.Add(ncc.MaNCC);
            lvitem.SubItems.Add(ncc.TenNCC);
            lvitem.SubItems.Add(ncc.DiaChi);
            lvitem.SubItems.Add(ncc.SDT.ToString());
            lvitem.SubItems.Add(ncc.MoTa);

            string cn = "";

            foreach (string s in ncc.DanhSach)
                cn += s + ",";
            cn = cn.Substring(0, cn.Length - 1);
            lvitem.SubItems.Add(cn);
            this.lvNhaCungCap.Items.Add(lvitem);
        }


        private NhaCungCap GetNhaCungCap() 
        {
            NhaCungCap ncc = new NhaCungCap();
           
            List<string> cn = new List<string>();
            ncc.MaNCC = this.txtMaNCC.Text;
            ncc.TenNCC = this.txtTenNCC.Text;
            ncc.DiaChi = this.txtTenNCC.Text;
           
            ncc.MoTa = this.txtMoTa.Text;

            int dt;
            if (!int.TryParse(this.mtbSDT.Text, out dt))
                dt = 0;
            ncc.SDT = dt;

            return ncc;

        }

        private NhaCungCap GetNhaCungCapLV(ListViewItem lvitem)
        {
            NhaCungCap sv = new NhaCungCap();
            sv.MaNCC = lvitem.SubItems[0].Text;
            sv.TenNCC = lvitem.SubItems[1].Text;
            sv.DiaChi = lvitem.SubItems[2].Text;
            sv.MoTa = lvitem.SubItems[3].Text;

            int sodt;
            int.TryParse(lvitem.SubItems[4].Text, out sodt);
            sv.SDT = sodt;
            
            List<string> cn = new List<string>();
            string[] s = lvitem.SubItems[5].Text.Split(',');


            return sv;
        }

        private void ThietLapThongTin(NhaCungCap ncc)
        {
            this.txtMaNCC.Text = ncc.MaNCC;
            this.txtTenNCC.Text = ncc.TenNCC;
            this.txtDiaChi.Text = ncc.DiaChi;
            this.mtbSDT.Text = ncc.SDT.ToString();
            this.txtMoTa.Text = ncc.MoTa;
            

        }


        private int SoSanhTheoMa(object ncc1, object ncc2)
        {
            NhaCungCap ncc = ncc2 as NhaCungCap;
            return ncc.MaNCC.CompareTo(ncc1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhaCungCap sv = GetNhaCungCap();
            if (sv == null) return;

            qlncc.Them(sv);
            LoadListView();
            qlncc.GhiFile("DanhSachNCC.txt");
        }
    }
}
