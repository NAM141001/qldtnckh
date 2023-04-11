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
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void exit_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void exit_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox5.BringToFront();
            txt_password.PasswordChar = '\0';
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox4.BringToFront();
            txt_password.PasswordChar = '*';
        }
        DataConnect connect = new DataConnect();
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            String username = txt_user.Text;
            String pass = txt_password.Text;
            String phanquyen = "Nhân sự";
            if (checkBox1.Checked)
            {
                phanquyen = "Trưởng phòng";
            }
            String query = "Select * from taikhoan where username='" + username + "' and pass='" + pass + "' and phanquyen =N'"+phanquyen+"'";
            DataTable dt = connect.GetDataTable(query);
            if (dt.Rows.Count > 0)
            {
                String mataikhoan = null;
                foreach(DataRow dr in dt.Rows)
                {
                    mataikhoan = dr["mataikhoan"].ToString();
                }
                if (phanquyen == "Trưởng phòng")
                {
                    String thoigian = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                   // MessageBox.Show(thoigian);
                    String query2 = "insert into lichsu(thoigiandangnhap ,mataikhoan) values ('"+thoigian+"','"+mataikhoan+"')";
                    connect.fix(query2);
                    this.Hide();
                    RibbonForm1 r = new RibbonForm1();
                    r.phanquyen = "Trưởng phòng";
                    r.username = username;
                    r.pass = pass;
                    r.mataikhoan = mataikhoan;
                    r.ShowDialog();
                    this.Close();
                }
                else
                {
                    String thoigian = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
                    String query3 = "insert into lichsu(thoigiandangnhap ,mataikhoan) values ('" + thoigian + "','" + mataikhoan + "')";
                    connect.fix(query3);
                    this.Hide();
                    RibbonForm1 r = new RibbonForm1();
                    r.phanquyen = "Nhân sự";
                    r.username = username;
                    r.pass = pass;
                    r.mataikhoan = mataikhoan;
                    r.ShowDialog();
                    this.Close();
                }
            }
            else { MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác"); }
        }
    }
}