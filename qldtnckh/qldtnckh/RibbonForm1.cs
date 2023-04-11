using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
namespace qldtnckh
{
    public partial class RibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
        }
        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            barStaticItem1.Caption = phanquyen;
      if (phanquyen!="Trưởng phòng")
            {
                ribbonPage7.Visible = false;
            }

        }
        public String mataikhoan = null;
        public String username = null;
        public String pass = null;
        public String phanquyen = null;

        private void barbtn_detaicapnhanuoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Detai.detaicapnhanuoc dt = new Detai.detaicapnhanuoc();
            dt.MdiParent = this;
            dt.Show();
        }

        private void barBtn_detaicapbo_ItemClick(object sender, ItemClickEventArgs e)
        {
            Detai.detaicapbo dt = new Detai.detaicapbo();
            dt.MdiParent = this;
            dt.Show();
        }

        private void barbtn_captinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            Detai.detaicaptinh dt = new Detai.detaicaptinh();
            dt.MdiParent = this;
            dt.Show();
        }

        private void barbtn_captruong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Detai.detaicaptruong_b dt = new Detai.detaicaptruong_b();
            dt.MdiParent = this;
            dt.Show();
        }

        private void barbtn_capkhoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            Detai.detaicapkhoa dt = new Detai.detaicapkhoa();
            dt.MdiParent = this;
            dt.Show();
        }

        private void barbtn_capbomon_ItemClick(object sender, ItemClickEventArgs e)
        {
            Detai.detaicapbomon dt = new Detai.detaicapbomon();
            dt.MdiParent = this;
            dt.Show();
        }

        private void barbtn_toanbodetai_ItemClick(object sender, ItemClickEventArgs e)
        {
            Detai.toanbodetai dt = new Detai.toanbodetai();
            dt.MdiParent = this;
            dt.Show();
        }

        private void btn_nckhcuagv_ItemClick(object sender, ItemClickEventArgs e)
        {
            nckh.nckhgv nckhgv = new nckh.nckhgv();
            nckhgv.MdiParent = this;
            nckhgv.Show();
        }

        private void btn_thongke_ItemClick(object sender, ItemClickEventArgs e)
        {
            thongkevaluutru.Thongke tk = new thongkevaluutru.Thongke();
            tk.MdiParent = this;
            tk.Show();
        }

        private void btn_lichsu_ItemClick(object sender, ItemClickEventArgs e)
        {
            dangnhap.lichsu tk = new dangnhap.lichsu();
            tk.MdiParent = this;
            tk.Show();
        }
        DataConnect connect = new DataConnect();
        private void btn_dangxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            String thoigian = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            String query = "insert into lichsu (thoigiandangxuat,mataikhoan) values ('" + thoigian + "','"+mataikhoan+"')";
            connect.GetDataTable(query);

            this.Hide();
            dangnhap.Login l = new dangnhap.Login();
            l.ShowDialog();
            this.Close();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            /*String thoigian = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            String query = "insert into lichsu (thoigiandangxuat,mataikhoan) values ('" + thoigian + "','" + mataikhoan + "')";
            connect.GetDataTable(query);*/
            Application.Exit();
        }

        private void RibbonForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            String thoigian = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
            String query = "insert into lichsu (thoigiandangxuat,mataikhoan) values ('" + thoigian + "','" + mataikhoan + "')";
            connect.GetDataTable(query);
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            nckh.nckhsv nc = new nckh.nckhsv();
            nc.MdiParent = this;
            nc.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            dangnhap.taikhoan tk = new dangnhap.taikhoan();
            tk.MdiParent = this;
            tk.mataikhoan = mataikhoan;
            tk.username = username;
            tk.pass = pass;
            tk.phanquyen = phanquyen;
            tk.Show();
            
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            dangnhap.taikhoannguoidung tk = new dangnhap.taikhoannguoidung();
            tk.mataikhoan = mataikhoan;
            tk.username = username;
            tk.pass = pass;
            tk.phanquyen = phanquyen;
            tk.Show();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Detai.detaicuasinhvien tk = new Detai.detaicuasinhvien();
                tk.MdiParent = this;
            tk.Show();
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            hoithaocapqg.hoithaocaptruong ht = new hoithaocapqg.hoithaocaptruong();
            ht.MdiParent = this;
            ht.Show();
        }

        private void btn_hoithaocapquocgia_ItemClick(object sender, ItemClickEventArgs e)
        {
            hoithaocapqg.htcapqg ht = new hoithaocapqg.htcapqg();
            ht.MdiParent = this;
            ht.Show();
        }

        private void btn_hoithaocaptinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            hoithaocapqg.htcaptinh ht = new hoithaocapqg.htcaptinh();
            ht.MdiParent = this;
            ht.Show();
        }

        private void btn_hoithaocapkhoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            hoithaocapqg.htcapkhoa ht = new hoithaocapqg.htcapkhoa();
            ht.MdiParent = this;
            ht.Show();
        }

        private void btn_hoithaocapbomon_ItemClick(object sender, ItemClickEventArgs e)
        {
            hoithaocapqg.htcapbomon ht = new hoithaocapqg.htcapbomon();
            ht.MdiParent = this;
            ht.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Tapsan.tapsantbu kh = new Tapsan.tapsantbu();
            kh.MdiParent = this;
            kh.Show();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            Tapsan.baibaokh kh = new Tapsan.baibaokh();
            kh.MdiParent = this;
            kh.Show();
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            Tapsan.baibaokhngoainuoc kh = new Tapsan.baibaokhngoainuoc();
            kh.MdiParent = this;
            kh.Show();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            Detai.detaicuasinhvien tk = new Detai.detaicuasinhvien();
            tk.MdiParent = this;
            tk.Show();
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            Hoithisangtao.SVkhoinghiep tk = new Hoithisangtao.SVkhoinghiep();
            tk.MdiParent = this;
            tk.Show();
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            quanlygionghiencuu.quanlygionghiencuu tk = new quanlygionghiencuu.quanlygionghiencuu();
            tk.MdiParent = this;
            tk.Show();
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            Hoithisangtao.quanlynckhcaptinh tk = new Hoithisangtao.quanlynckhcaptinh();
            tk.MdiParent = this;
            tk.Show();
        }
    }
}