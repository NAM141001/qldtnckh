using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace qldtnckh.dangnhap
{
    public partial class lichsu : DevExpress.XtraEditors.XtraForm
    {
        public lichsu()
        {
            InitializeComponent();
        }
        DataConnect connect = new DataConnect();
        void getData()
        {
            String query = "select malichsu,tk.mataikhoan,username,phanquyen,thoigiandangnhap,thoigiandangxuat from lichsu ls ,taikhoan tk where ls.mataikhoan=tk.mataikhoan";
            tb_lichsudangnhap.DataSource = connect.GetDataTable(query);
            fix_header();

        }
        private void lichsu_Load(object sender, EventArgs e)
        {
            this.tb_lichsudangnhap.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_lichsudangnhap.DefaultCellStyle.BackColor = Color.Beige;
            getData();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ma != null)
            {
                DialogResult dt = MessageBox.Show("Bạn có muốn xóa lịch sử mã :" + ma, "Thông báo", MessageBoxButtons.YesNo);
                if (dt == DialogResult.Yes)
                {
                    String query = "delete from lichsu where malichsu = '" + ma + "'";
                    connect.fix(query);
                    getData();
                }
            }
            else MessageBox.Show("hãy chọn lịch sử mà bạn cần xóa");

        }
        String ma=null;
        private void tb_lichsudangnhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_lichsudangnhap.CurrentCell.RowIndex;
            ma = tb_lichsudangnhap.Rows[i].Cells[0].Value.ToString();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dt = MessageBox.Show("Bạn có muốn xóa toàn bộ lịch sử ", "Thông báo", MessageBoxButtons.YesNo);
            if (dt == DialogResult.Yes)
            {
                String query = "delete from lichsu";
                connect.fix(query);
                getData();
            }
        }
        void fix_header()
        {
           
            tb_lichsudangnhap.Columns[0].HeaderText = "Mã lịch sử";
            tb_lichsudangnhap.Columns[1].HeaderText = "Mã tài khoản";
            tb_lichsudangnhap.Columns[2].HeaderText = "username";
            tb_lichsudangnhap.Columns[3].HeaderText = "Phân quyển";
            tb_lichsudangnhap.Columns[4].HeaderText = "Thời gian đăng nhập";
            tb_lichsudangnhap.Columns[5].HeaderText = "Thời gian đăng xuất";
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_chose.SelectedIndex ==0)
            {
                string query = "select malichsu,tk.mataikhoan,username,phanquyen,thoigiandangnhap,thoigiandangxuat from lichsu ls ,taikhoan tk where ls.mataikhoan=tk.mataikhoan and tk.mataikhoan ='"+txt_search.Text+"'";
                tb_lichsudangnhap.DataSource = connect.GetDataTable(query);
                fix_header();
            }
            else if(txt_chose.SelectedIndex == 1)
            {
                string query1= "select malichsu,tk.mataikhoan,username,phanquyen,thoigiandangnhap,thoigiandangxuat from lichsu ls ,taikhoan tk where ls.mataikhoan=tk.mataikhoan and tk.username ='" + txt_search.Text + "'";
                tb_lichsudangnhap.DataSource = connect.GetDataTable(query1);
                fix_header();
            }
        }
    }
}