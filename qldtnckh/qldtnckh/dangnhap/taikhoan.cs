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
    public partial class taikhoan : DevExpress.XtraEditors.XtraForm
    {
        public taikhoan()
        {
            InitializeComponent();
        }
        public String mataikhoan = null;
        public String username = null;
        public String pass = null;
        public String phanquyen = null;
        DataConnect connect = new DataConnect();
        void getdata()
        {
            tb_taikhoan.DataSource =connect.GetDataTable("select * from taikhoan");
            tb_taikhoan.Columns[0].HeaderText = "Mã tài khoản";
            tb_taikhoan.Columns[1].HeaderText = "Username";
            tb_taikhoan.Columns[2].HeaderText = "Password";
            tb_taikhoan.Columns[3].HeaderText = "Quyền người dùng";

        }
        private void taikhoan_Load(object sender, EventArgs e)
        {
            this.tb_taikhoan.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_taikhoan.DefaultCellStyle.BackColor = Color.Beige;
            getdata();
            cb_phanquyen.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cb_phanquyen.SelectedIndex = 0;
        }
        String ma = null;
        private void tb_taikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_taikhoan.CurrentCell.RowIndex;
             ma = tb_taikhoan.Rows[i].Cells[0].Value.ToString();
            Console.Write(ma);
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String query = "insert into taikhoan(username,pass,phanquyen) values ('" + txt_username.Text + "','" + txt_password.Text + "',N'" + cb_phanquyen.Text + "')";
            connect.fix(query);
            getdata();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {      
           if (ma == tb_taikhoan.Rows[0].Cells[0].Value.ToString())
            { MessageBox.Show("Đây là tài khoản mặc định không thể xóa");  }
        else  if(ma == mataikhoan)
            {
                MessageBox.Show("Không được xóa tài khoản đang dùng");
            } 
            else if (ma != null)
            {
                DialogResult dt = MessageBox.Show("Bạn có muốn xóa lịch sử và toàn khoản của tài khoản mã :" + ma, "Thông báo", MessageBoxButtons.YesNo);
                if (dt == DialogResult.Yes)
                {
                    String query1 = "delete from lichsu where mataikhoan = '" + ma + "'";
                    connect.fix(query1);
                    String query = "delete from taikhoan where mataikhoan ='" + ma + "'";
                    connect.fix(query);
                    getdata();
                }
            }
            else MessageBox.Show("Bạn cần chọn tài khoản để xóa");
        }
    }
}