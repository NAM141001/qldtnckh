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

namespace qldtnckh.nckh
{
    public partial class nckhsv : DevExpress.XtraEditors.XtraForm
    {
        public nckhsv()
        {
            InitializeComponent();
        }
        DataConnect connect = new DataConnect();
        void getdata()
        {
            String query = "select * from sinhvien";
            tb_sinhvien.DataSource = connect.GetDataTable(query);
            fix_header_sv();
        }
        void fix_header_sv()
        {
            tb_sinhvien.Columns[0].HeaderText = "Mã sinh viên";
            tb_sinhvien.Columns[1].HeaderText = "Tên sinh viên";
            tb_sinhvien.Columns[2].HeaderText = "Ngày sinh";
            tb_sinhvien.Columns[3].HeaderText = "Giới tính";
            tb_sinhvien.Columns[4].HeaderText = "Địa chỉ";
            tb_sinhvien.Columns[5].HeaderText = "Số điện thoại ";
            tb_sinhvien.Columns[6].HeaderText = "Lớp";
            tb_sinhvien.Columns[7].HeaderText = "Khoa";
            tb_sinhvien.Columns[8].HeaderText = "Trường";
          
        }
        private void nckhsv_Load(object sender, EventArgs e)
        {

            this.tb_sinhvien.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_sinhvien.DefaultCellStyle.BackColor = Color.Beige;
            getdata();
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String gioitinh = "nam";
            if (rb_nu.Checked) gioitinh = "nữ";
            String query = "SET DATEFORMAT dmy; "+"insert into sinhvien(masinhvien,tensinhvien,ngaysinh,gioitinh,diachi,sodienthoai,lop,khoa,truong)" +
            "values(N'" + txt_masv.Text + "', '" + txt_tensv.Text + "', N'" + txt_ngaysinh.Text + "', N'" + gioitinh + "', N'" + txt_diachi.Text + "', N'" + txt_sdt.Text + "',N'" + txt_lop.Text + "','" + txt_khoa.Text + "', N'" + txt_truong.Text + "')";
            connect.fix(query);
            getdata();
        }
        void resetform()
        {
            txt_masv.Text = "";
            txt_tensv.Text = "";
            rb_nam.Checked = true;
            txt_lop.Text = "";
            txt_diachi.Text = "";
            txt_sdt.Text = "";
            txt_khoa.Text = "";
            txt_truong.Text = "";
            txt_email.Text = "";
           


        }
        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String query = "delete from sinhvien where masinhvien=N'" + ma + "'";
            if (ma != null)
            {
                DialogResult dt = MessageBox.Show("Bạn có muốn xóa thông tin giảng viên mã : " + ma, "Thông báo", MessageBoxButtons.YesNo);
                if (dt == DialogResult.Yes)
                {
                    connect.fix(query);
                    getdata();
                    resetform();
                }
            }
            else MessageBox.Show("Hãy chọn sinh viên cần xóa");
        }
        String ma = null;
        private void tb_sinhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_sinhvien.CurrentRow.Index;
            ma = tb_sinhvien.Rows[i].Cells[0].Value.ToString();
            txt_masv.Text = tb_sinhvien.Rows[i].Cells[0].Value.ToString();
            txt_tensv.Text = tb_sinhvien.Rows[i].Cells[1].Value.ToString();
            txt_ngaysinh.Text = tb_sinhvien.Rows[i].Cells[2].Value.ToString();
            if (tb_sinhvien.Rows[i].Cells[3].Value.ToString().Equals("nam"))
            {
                rb_nam.Checked = true;
            }
            else rb_nu.Checked = true;
            txt_diachi.Text = tb_sinhvien.Rows[i].Cells[4].Value.ToString();
            txt_sdt.Text = tb_sinhvien.Rows[i].Cells[5].Value.ToString();
            txt_lop.Text = tb_sinhvien.Rows[i].Cells[6].Value.ToString();
            txt_khoa.Text = tb_sinhvien.Rows[i].Cells[7].Value.ToString();
            txt_truong.Text = tb_sinhvien.Rows[i].Cells[8].Value.ToString();
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String gioitinh = "nam";
            if (rb_nu.Checked) gioitinh = "nữ";
            String query = "SET DATEFORMAT dmy; " + "update sinhvien set masinhvien = N'" +txt_masv.Text+"' tenthanhvien = N'" + txt_tensv.Text + "', ngaysinh = '" + txt_ngaysinh.Text + "', gioitinh = N'" + gioitinh + "', diachi = N'" + txt_diachi.Text + "', sodienthoai = N'" + txt_sdt.Text + "', lop = N'" + txt_lop.Text + "', khoa = N'" + txt_khoa.Text + "', truong = N'" + txt_truong.Text + "' "+ " where mathanhvien = '" + ma + "'";
            if (ma != null)
            {
                DialogResult dt = MessageBox.Show("Bạn có muốn sửa thông tin sinhvien mã : " + ma, "Thông báo", MessageBoxButtons.YesNo);
                if (dt == DialogResult.Yes)
                {
                    connect.fix(query);
                    getdata();
                }

            }
            else MessageBox.Show("Hãy chọn sinh viên cần sửa");
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cb_select.SelectedIndex == 0)
            {
                String query = "Select * from sinhvien where masinhvien='" + txt_search.Text + "'";
                tb_sinhvien.DataSource = connect.GetDataTable(query);
                fix_header_sv();
            }
            else if (cb_select.SelectedIndex == 1)
            {
                String query = "Select * from sinhvien where tensinhvien=N'" + txt_search.Text + "'";
                tb_sinhvien.DataSource = connect.GetDataTable(query);
                fix_header_sv();
            }
        }
    }
}