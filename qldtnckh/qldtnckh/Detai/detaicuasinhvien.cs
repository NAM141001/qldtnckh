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

namespace qldtnckh.Detai
{
    public partial class detaicuasinhvien : DevExpress.XtraEditors.XtraForm
    {
        public detaicuasinhvien()
        {
            InitializeComponent();
        }
        DataConnect connect = new DataConnect();
        void getdata()
        {
            string query = "select * from detaicuasinhvien";
            tb_detaisinhvien.DataSource = connect.GetDataTable(query);
            fix_header();
        }
        void fix_header()
        {
            tb_detaisinhvien.Columns[0].HeaderText = "ID";
            tb_detaisinhvien.Columns[1].HeaderText = "Tên đề tài";
            tb_detaisinhvien.Columns[2].HeaderText = "Thời gian";
            tb_detaisinhvien.Columns[3].HeaderText = "Tiến độ";
            tb_detaisinhvien.Columns[4].HeaderText = "Quyết định thành lập hội đồng";
            tb_detaisinhvien.Columns[5].HeaderText = "Ngày nghiệm thu";
            tb_detaisinhvien.Columns[6].HeaderText = "Kết quả nghiệm thu";
            tb_detaisinhvien.Columns[7].HeaderText = "Ứng dụng của đề tài";
            tb_detaisinhvien.Columns[8].HeaderText = "Chi phí";
            tb_detaisinhvien.Columns[9].HeaderText = "Cấp đề tài";

        }
        private void detaicuasinhvien_Load(object sender, EventArgs e)
        {
            this.tb_detaisinhvien.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_detaisinhvien.DefaultCellStyle.BackColor = Color.Beige;
            this.tb_giangvienhd.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_giangvienhd.DefaultCellStyle.BackColor = Color.Beige;
            this.tb_hoidong.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_hoidong.DefaultCellStyle.BackColor = Color.Beige;
            this.tb_thanhvien.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_thanhvien.DefaultCellStyle.BackColor = Color.Beige;
            getdata();
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String ngaynghiemthu = txt_ngayngiemthu.Text;
            String query = "";
            if (ngaynghiemthu != "")
            {
                query = "SET DATEFORMAT dmy;" + "insert into detaicuasinhvien(tendetai,thoigian,tiendo,quyetdinhthanhlaphoidong,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,capdetai)" +
                   " values(N'" + txt_tendetai.Text + "','" + txt_thoigianthuchien.Text + "',N'" + txt_tiendo.Text + "',N'" + txt_qdthanhlaphoidongnhiemthu.Text + "','" + txt_ngayngiemthu.Text + "',N'" + txt_ketqua.Text + "',N'" + txt_ungdungcuadetai.Text + "'," + txt_chiphi.Text + ",N'" + txt_capdetai.Text + "') ";
                connect.fix(query);
                getdata();
            }
            else
            {
                query = "SET DATEFORMAT dmy;" + "insert into detaicuasinhvien(tendetai,thoigian,tiendo,quyetdinhthanhlaphoidong,ketquanghiemthu,ungdungcuadetai,chiphi,capdetai)" +
                    " values(N'" + txt_tendetai.Text + "','" + txt_thoigianthuchien.Text + "',N'" + txt_tiendo.Text + "',N'" + txt_qdthanhlaphoidongnhiemthu.Text + "',N'" + txt_ketqua.Text + "',N'" + txt_ungdungcuadetai.Text + "'," + txt_chiphi.Text + ",N'" + txt_capdetai.Text + "') ";
                connect.fix(query);
                getdata();
            }
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String ngaynghiemthu = txt_ngayngiemthu.Text;
            String query = "";
            if (ngaynghiemthu != "")
            {
                query = "SET DATEFORMAT dmy;" + "update detaicuasinhvien set tendetai= N'" + txt_tendetai.Text + "', thoigian = '" + txt_thoigianthuchien.Text + "',tiendo =N'" + txt_tiendo.Text + "',quyetdinhthanhlaphoidong =N'" + txt_qdthanhlaphoidongnhiemthu.Text + "',ngaynghiemthu = '" + txt_ngayngiemthu.Text + "',ketquanghiemthu=N'" + txt_ketqua.Text + "',ungdungcuadetai =N'" + txt_ungdungcuadetai.Text + "',chiphi=" + txt_chiphi.Text + ", capdetai =N'" + txt_capdetai.Text + "' where madetai_sinhvien ='" + ma + "'";
                connect.fix(query);
                getdata();
            }
            else
            {
                query = "SET DATEFORMAT dmy;" + "update detaicuasinhvien set tendetai= N'" + txt_tendetai.Text + "', thoigian = '" + txt_thoigianthuchien.Text + "',tiendo =N'" + txt_tiendo.Text + "',quyetdinhthanhlaphoidong =N'" + txt_qdthanhlaphoidongnhiemthu.Text + "', ketquanghiemthu = N'" + txt_ketqua.Text + "',ungdungcuadetai =N'" + txt_ungdungcuadetai.Text + "',chiphi=" + txt_chiphi.Text + ", capdetai =N'" + txt_capdetai.Text + "' where madetai_sinhvien ='" + ma + "'";
                connect.fix(query);
                getdata();
            }
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String query = "delete from detaicuasinhvien where madetai_sinhvien = '" + ma + "'";
            connect.fix(query);
            getdata();
        }
        String ma = null;
        private void tb_detaisinhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_detaisinhvien.CurrentCell.RowIndex;
            ma = tb_detaisinhvien.Rows[i].Cells[0].Value.ToString();
            txt_tendetai.Text = tb_detaisinhvien.Rows[i].Cells[1].Value.ToString();
            txt_thoigianthuchien.Text = tb_detaisinhvien.Rows[i].Cells[2].Value.ToString();
            txt_tiendo.Text = tb_detaisinhvien.Rows[i].Cells[3].Value.ToString();
            txt_qdthanhlaphoidongnhiemthu.Text = tb_detaisinhvien.Rows[i].Cells[4].Value.ToString();
            txt_ngayngiemthu.Text = tb_detaisinhvien.Rows[i].Cells[5].Value.ToString();
            txt_ketqua.Text = tb_detaisinhvien.Rows[i].Cells[6].Value.ToString();
            txt_ungdungcuadetai.Text = tb_detaisinhvien.Rows[i].Cells[7].Value.ToString();
            txt_chiphi.Text = tb_detaisinhvien.Rows[i].Cells[8].Value.ToString();
            txt_capdetai.Text = tb_detaisinhvien.Rows[i].Cells[9].Value.ToString();
            getdata_hd();
            getdata_sv();
            getdata_hoidong();
        }
        void getdata_hd()
        {
            String query1 = "select tv.tenthanhvien,ct.chucvu from detaicuasinhvien dt ,cttv_hd ct,thanhvienthamgiadetai tv where tv.mathanhvien = ct.mathanhvien and dt.madetai_sinhvien = ct.madetai_sinhvien and chucvu =N'Giảng viên hướng dẫn'";
            tb_giangvienhd.DataSource = connect.GetDataTable(query1);
            fix_header_gvhd();
        }
        void fix_header_gvhd()
        {
            tb_giangvienhd.Columns[0].HeaderText = "Tên giảng viên hướng dẫn";
            tb_giangvienhd.Columns[1].HeaderText = "Chức vụ";
        }
        private void btn_themgvhd_Click(object sender, EventArgs e)
        {
            String query = "insert into cttv_hd(mathanhvien,madetai_sinhvien,chucvu) values('" + txt_magiangvien.Text + "','" + ma + "',N'Giảng viên hướng dẫn')";
            connect.fix(query);
            getdata_hd();
        }

        private void txt_magiangvien_TextChanged(object sender, EventArgs e)
        {
            String query = "select tenthanhvien from thanhvienthamgiadetai where mathanhvien = '" + txt_magiangvien.Text + "'";
            DataTable data = connect.GetDataTable(query);
            if (data.Rows.Count != 0)
            {
                foreach (DataRow d in data.Rows)
                {
                    txt_tengvhd.Text = d["tenthanhvien"].ToString();

                }
            }
            else txt_tengvhd.Text = "";
        }
        String ma_gv = null;
        private void tb_giangvienhd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_giangvienhd.CurrentRow.Index;
            ma_gv = tb_giangvienhd.Rows[i].Cells[0].Value.ToString();
        }

        private void txt_mathanhvien_TextChanged(object sender, EventArgs e)
        {
            String query = "select tensinhvien from sinhvien where masinhvien = '" + txt_mathanhvien.Text + "'";
            DataTable data = connect.GetDataTable(query);
            if (data.Rows.Count != 0)
            {
                foreach (DataRow d in data.Rows)
                {
                    txt_tenthanhvien.Text = d["tensinhvien"].ToString();

                }
            }
            else txt_tenthanhvien.Text = "";
        }

        private void txt_matvhd_TextChanged(object sender, EventArgs e)
        {
            String query = "select tenthanhvien from thanhvienthamgiadetai where mathanhvien = '" + txt_matvhd.Text + "'";
            DataTable data = connect.GetDataTable(query);
            if (data.Rows.Count != 0)
            {
                foreach (DataRow d in data.Rows)
                {
                    txt_tentvhd.Text = d["tenthanhvien"].ToString();

                }
            }
            else txt_tentvhd.Text = "";
        }
        String ma_tv = null;
        private void tb_thanhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_thanhvien.CurrentRow.Index;
            ma_tv = tb_thanhvien.Rows[i].Cells[0].Value.ToString();
        }
        String ma_hd = null;
        String diem = null;
        String ten_tv_hd = null;
        private void tb_thanhvienhoidong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_hoidong.CurrentRow.Index;
            ma_hd = tb_hoidong.Rows[i].Cells[0].Value.ToString();
            ten_tv_hd = tb_hoidong.Rows[i].Cells[1].Value.ToString();
            diem = tb_hoidong.Rows[i].Cells[2].Value.ToString();
        }
        void fix_header_tbthanhvien()
        {

            tb_thanhvien.Columns[0].HeaderText = "Mã thành viên";
            tb_thanhvien.Columns[1].HeaderText = "Tên thành viên";
            tb_thanhvien.Columns[2].HeaderText = "Chức vụ thành viên";

        }
        void getdata_sv()
        {
            String query1 = "select dv.masinhvien, dv.tensinhvien,ct.chucvu from detaicuasinhvien dt,cttv_sv ct ,sinhvien dv where dt.madetai_sinhvien = ct.madetai_sinhvien and ct.masinhvien = dv.masinhvien and ct.chucvu in( N'Thành viên chính',N'Thành viên phụ',N'Chủ nhiệm') and dt.madetai_sinhvien = '" + ma + "';";
            DataTable dt1 = connect.GetDataTable(query1);
            tb_thanhvien.DataSource = dt1;
            fix_header_tbthanhvien();
        }
        private void btn_them_tv_Click(object sender, EventArgs e)
        {
            if (ma != null)
            {
                String query = "insert into cttv_sv(masinhvien,madetai_sinhvien,chucvu) values('" + txt_mathanhvien.Text + "', '" +ma + "', N'" + txt_chucvu.Text + "')";
                connect.fix(query);
                getdata_sv();
            }
            else
            {
                MessageBox.Show("hãy chọn đề tài mà bạn muốn thêm thành viên");
            }
        }

        private void btn_xoatv_Click(object sender, EventArgs e)
        {
            if (ma != null)
            {
                if (ma_tv != null)
                {
                    String query = "delete from cttv_sv where madetai_sinhvien='" + ma + "'and masinhvien = '" + ma_tv + "'";
                    connect.fix(query);
                    getdata_sv();
                }
                else MessageBox.Show("hãy chon thành viên cần xóa");
            }
            else MessageBox.Show("hãy chọn đề tài cần xóa thành viên");
        }

        private void btn_xoagvhd_Click(object sender, EventArgs e)
        {
            String query = "delete from cttv_hd  where mathanhvien ='"+ma_gv+"' and madetai_sinhvien ='"+ma+"') ";
            connect.fix(query);
            getdata_hd();
        }
        void getdata_hoidong()
        {
            String query = "select tv.mathanhvien ,tv.tenthanhvien,ct.diem from detaicuasinhvien dt,cttv_hd ct,thanhvienthamgiadetai tv where dt.madetai_sinhvien =ct.madetai_sinhvien and ct.mathanhvien =tv.mathanhvien and ct.chucvu = N'Thành viên hội đồng' and  ct.madetai_sinhvien = '"+ma+"'";
            tb_hoidong.DataSource = connect.GetDataTable(query);
            fix_header_hoidong();
        }
        void fix_header_hoidong()
        {
            tb_hoidong.Columns[0].HeaderText ="ID";
            tb_hoidong.Columns[1].HeaderText = "Tên thành viên hd";
            tb_hoidong.Columns[2].HeaderText = "Điểm số";
        }
        private void btn_themtvhd_Click(object sender, EventArgs e)
        {
            String query = "insert into cttv_hd(mathanhvien,madetai_sinhvien,chucvu,diem) values ('"+txt_matvhd.Text+"','"+ma+"',N'Thành viên hội đồng','"+txt_diem.Text+"')";
            connect.fix(query);
            getdata_hoidong();
        }

        private void btn_xoatvhd_Click(object sender, EventArgs e)
        {
            String query = "delete from cttv_hd where mathanhvien ='" + ma_hd + "',madetai_sinhvien ='" + ma + "' ";
            connect.fix(query);
            getdata_hoidong();
        }

        private void tb_hoidong_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            int i = tb_hoidong.RowCount;

            if (i < 7 && i > 0)
            {
                lb_soluong.Text = "Số lượng : " + i + "(Chưa đủ thành viên)";
                lb_soluong.ForeColor = Color.Red;
            }
            else if (i >= 7)
            {
                lb_soluong.Text = "Số lượng : " + i + "(Đã đủ thành viên)";
                lb_soluong.ForeColor = Color.Green;
            }
            // MessageBox.Show(tb_hoidong.Rows[0].Cells[2].Value.ToString());
            Double sum = 0;

            for (int j = 0; j < this.tb_hoidong.RowCount; j++)
            {
                Double a = Convert.ToDouble(tb_hoidong.Rows[j].Cells[2].Value.ToString());
                sum += a;
            }

            this.lb_sum.Text = "SUM : " + sum.ToString() + " Point";
            Double avg = sum / i;

            this.lb_avg.Text = "AVG : " + avg.ToString() + " Point";
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ma != null)
            {
                baocao.giaytokemtheo gt = new baocao.giaytokemtheo();
                gt.madetai = ma;
                gt.ShowDialog();
            }
            else MessageBox.Show("Chọn đề tài muốn xem giấy tờ hợp đồng");
        }
    }
}