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
    public partial class taikhoannguoidung : DevExpress.XtraEditors.XtraForm
    {
        public String mataikhoan = null;
        public String username = null;
        public String pass = null;
        public String phanquyen = null;
        public taikhoannguoidung()
        {
            InitializeComponent();
        }

        private void taikhoannguoidung_Load(object sender, EventArgs e)
        {
            lb_quyen.Text = phanquyen;
            lb_username.Text = username;
        }
        DataConnect connect = new DataConnect();
        private void btn_dmk_Click(object sender, EventArgs e)
        {
            if (txt_pass_old.Text == pass)
            {
                if (txt_pass_new.Text == txt_check_pass_new.Text)
                {
                    String query = "update taikhoan set pass = N'" + txt_pass_new.Text + "' where mataikhoan ='"+mataikhoan+"'";
                    connect.fix(query);
                    MessageBox.Show("Đã thay đổi mật khẩu thành công");
                }
                else { MessageBox.Show("kiểm tra lại mật khẩu mới"); }
            }
            else { MessageBox.Show("kiểm tra lại mật khẩu cũ"); }
        }
    }
}