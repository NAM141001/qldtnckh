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
    public partial class nckhgv : DevExpress.XtraEditors.XtraForm
    {
        public nckhgv()
        {
            InitializeComponent();
        }

        private void labelControl16_Click(object sender, EventArgs e)
        {

        }
        DataConnect connect = new DataConnect();
        void fix_header()
        {
            tb_giangvien.Columns[0].HeaderText = "ID";
            tb_giangvien.Columns[1].HeaderText = "Tên giảng viên";
            tb_giangvien.Columns[2].HeaderText = "Ngày sinh";
            tb_giangvien.Columns[3].HeaderText = "Giới tính";
            tb_giangvien.Columns[4].HeaderText = "Học vị";
            tb_giangvien.Columns[5].HeaderText = "Học hàm ";
            tb_giangvien.Columns[6].HeaderText = "Trình độ tiếng anh";
            tb_giangvien.Columns[7].HeaderText = "Chuyên ngành";
            tb_giangvien.Columns[8].HeaderText = "Chuyên môn";
            tb_giangvien.Columns[9].HeaderText = "Địa chỉ";
            tb_giangvien.Columns[10].HeaderText = "Email";
            tb_giangvien.Columns[11].HeaderText = "Số điện thoại";
            tb_giangvien.Columns[12].HeaderText = "Định mức";
            tb_giangvien.Columns[13].HeaderText = "Số giờ thực hiện";
            tb_giangvien.Columns[14].HeaderText = "Hiệu số";
        }
        void get_data()
        {
            String query = "select * from thanhvienthamgiadetai";
            tb_giangvien.DataSource = connect.GetDataTable(query);
            fix_header();
        }
        private void nckhgv_Load(object sender, EventArgs e)
        {
            this.tb_giangvien.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_giangvien.DefaultCellStyle.BackColor = Color.Beige;
            
            get_data();
            //cb_select.Properties.DropDownStyle = DropDownStyle.DropDownList;
            cb_select.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cb_select.SelectedIndex = 0;

        }

        private void btn_refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            get_data();
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String gioitinh = "nam";
            if (rbd_nu.Checked) gioitinh = "nữ";
            String query = "SET DATEFORMAT dmy;  " +  "insert into thanhvienthamgiadetai(tenthanhvien,ngaysinh,gioitinh,hocvi,hocham,trinhdotienganh,chuyennganh,chuyenmon,diachi,email,sodienthoai,dinhmuc,sogiothuchien)" +
"values(N'" + txt_giangvien.Text + "', '" + txt_ngaysinh.Text + "', N'" + gioitinh + "', N'" + txt_hocvi.Text + "', N'" + txt_hocham.Text + "', N'" + txt_trinhdotienganh.Text + "',N'"+txt_chuyennganh.Text+"','"+txt_chuyenmon.Text+"', N'" + txt_diachi.Text + "', N'" + txt_email.Text + "', N'" + txt_sdt.Text + "', " + txt_dinhmuc.Text + ", " + txt_sogiothuchien.Text + ")";
            connect.fix(query);
            get_data();

            
}
        String ma = null;
        private void tb_giangvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_giangvien.CurrentRow.Index;
            ma = tb_giangvien.Rows[i].Cells[0].Value.ToString();
            txt_giangvien.Text = tb_giangvien.Rows[i].Cells[1].Value.ToString();
            txt_ngaysinh.Text = tb_giangvien.Rows[i].Cells[2].Value.ToString();
            if (tb_giangvien.Rows[i].Cells[3].Value.ToString().Equals("nam"))
            {
                rbd_nam.Checked = true;
            }
            else rbd_nu.Checked = true;
            txt_hocvi.Text = tb_giangvien.Rows[i].Cells[4].Value.ToString();
            txt_hocham.Text = tb_giangvien.Rows[i].Cells[5].Value.ToString();
            txt_trinhdotienganh.Text = tb_giangvien.Rows[i].Cells[6].Value.ToString();
            txt_chuyennganh.Text = tb_giangvien.Rows[i].Cells[7].Value.ToString();
            txt_chuyenmon.Text = tb_giangvien.Rows[i].Cells[8].Value.ToString();
            txt_diachi.Text = tb_giangvien.Rows[i].Cells[9].Value.ToString();
            txt_email.Text = tb_giangvien.Rows[i].Cells[10].Value.ToString();
            txt_sdt.Text = tb_giangvien.Rows[i].Cells[11].Value.ToString();
            txt_dinhmuc.Text= tb_giangvien.Rows[i].Cells[12].Value.ToString();
            txt_sogiothuchien.Text = tb_giangvien.Rows[i].Cells[13].Value.ToString();
        }
        void resetform()
        {
            txt_giangvien.Text = "";
            txt_ngaysinh.Text = "";
            rbd_nam.Checked = true;
            txt_hocvi.Text = "";
            txt_hocham.Text = "";
            txt_trinhdotienganh.Text = "";
            txt_chuyennganh.Text = "";
            txt_diachi.Text = "";
            txt_email.Text = "";
            txt_sdt.Text = "";
            txt_dinhmuc.Text = "";
            txt_sogiothuchien.Text = "";


        }
        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String gioitinh = "nam";
            if (rbd_nu.Checked) gioitinh = "nữ";
            String query = "SET DATEFORMAT dmy;" + "update thanhvienthamgiadetai set tenthanhvien = N'"+txt_giangvien.Text+"', ngaysinh = '"+txt_ngaysinh.Text+"', gioitinh = N'"+gioitinh+"', hocham = N'"+txt_hocham.Text+"', trinhdotienganh = N'"+txt_trinhdotienganh.Text+"', chuyennganh = N'"+txt_chuyennganh.Text+"', chuyenmon = N'"+txt_chuyenmon.Text+"', sodienthoai = '"+txt_sdt.Text+"', dinhmuc = "+txt_dinhmuc.Text+", sogiothuchien = "+txt_sogiothuchien.Text+" where mathanhvien = '"+ma+"'";
            if (ma != null)
            {
                DialogResult dt = MessageBox.Show("Bạn có muốn sửa thông tin giảng viên mã : " + ma, "Thông báo", MessageBoxButtons.YesNo);
                if (dt == DialogResult.Yes)
                {
                    connect.fix(query);
                    get_data();
                }

            }
            else MessageBox.Show("Hãy chọn giảng viên cần sửa");
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String query = "delete from thanhvienthamgiadetai where mathanhvien=N'" + ma + "'";
            if (ma != null)
            {
                DialogResult dt = MessageBox.Show("Bạn có muốn xóa thông tin giảng viên mã : " + ma, "Thông báo", MessageBoxButtons.YesNo);
                if (dt == DialogResult.Yes)
                {
                    connect.fix(query);
                    get_data();
                    resetform();
                }
            }
            else MessageBox.Show("Hãy chọn giảng viên cần xóa");
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cb_select.SelectedIndex == 0)
            {
                String query = "Select * from thanhvienthamgiadetai where mathanhvien='" + txt_search.Text + "'";
                tb_giangvien.DataSource = connect.GetDataTable(query);
                fix_header();
            }
            else if (cb_select.SelectedIndex == 1)
            {
                String query = "Select * from thanhvienthamgiadetai where tenthanhvien=N'" + txt_search.Text + "'";
                tb_giangvien.DataSource = connect.GetDataTable(query);
                fix_header();
            }
            if(txt_search.Text.Equals("Sa Tị")|| txt_search.Text.Equals("messi"))
            {
              DialogResult st=  MessageBox.Show("Sạ tị hay tên gọi khác là si lùn trước kia chơi cho fifalona , sau đó chạy sang psg lánh nạn khi thấy đội bóng chủ bị lộ vụ hối lộ trọng tài . Vơi tuyệt kỹ đi bộ vuốt râu gãi đít anh đã ăn bám thành thành công và hôi được chiếc nhà vệ sinh cúp do fifatina tổ chức.Bạn có muốn xem ảnh của pessi?","Thông báo",MessageBoxButtons.YesNo);
                if (st == DialogResult.Yes)
                {
                    string path = Application.StartupPath + "\\imges\\" + "silun.mp4";
                    System.Diagnostics.Process.Start(path);
                }
            }
        }
    }
}