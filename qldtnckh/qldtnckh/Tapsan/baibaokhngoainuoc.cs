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

namespace qldtnckh.Tapsan
{
    public partial class baibaokhngoainuoc : DevExpress.XtraEditors.XtraForm
    {
        public baibaokhngoainuoc()
        {
            InitializeComponent();
        }
        DataConnect connect = new DataConnect();
        void getdata()
        {
            String query = "select * from baibao where loaibaibao=N'Báo nước ngoài' ";
            tb_baibao.DataSource = connect.GetDataTable(query);
            fix_header();
        }
        void fix_header()
        {
            tb_baibao.Columns[0].HeaderText = "ID";
            tb_baibao.Columns[1].HeaderText = "Tên bài báo";
            tb_baibao.Columns[2].HeaderText = "Ngày tháng xuất bản";
            tb_baibao.Columns[3].HeaderText = "Giấy phép";
            tb_baibao.Columns[4].HeaderText = "Điếm số";
            tb_baibao.Columns[5].HeaderText = "Loại bài báo";
        }
        private void baibaokhngoainuoc_Load(object sender, EventArgs e)
        {
            txt_loaibaibao.Enabled = false;
            txt_loaibaibao.Text = "Báo nước ngoài";
            getdata();
            this.tb_baibao.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_baibao.DefaultCellStyle.BackColor = Color.Beige;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String query = "SET DATEFORMAT dmy; " + "insert into baibao(tenbaibao,ngaythangxuatban,giayphep,diemso,loaibaibao) values(N'" + txt_tenbaibao.Text + "','" + txt_ngaythanhxuatban.Text + "',N'" + txt_giayphepxuatban.Text + "'," + txt_diemso.Text + ",N'Báo nước ngoài')";
            connect.fix(query);
            getdata();
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ma != null)
            {
                String query = "SET DATEFORMAT dmy; " + "update baibao set tenbaibao =N'" + txt_tenbaibao.Text + "',ngaythangxuatban='" + txt_ngaythanhxuatban.Text + "',giayphep =N'" + txt_giayphepxuatban.Text + "',diemso=" + txt_diemso.Text + " where mabaibao ='" + ma + "'";
                connect.fix(query);
                getdata();
            }
            else MessageBox.Show("Chọn bài báo cần sửa");
        }
        String ma = null;

        private void tb_baibao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_baibao.CurrentCell.RowIndex;
            ma = tb_baibao.Rows[i].Cells[0].Value.ToString();
            txt_tenbaibao.Text = tb_baibao.Rows[i].Cells[1].Value.ToString();
            txt_ngaythanhxuatban.Text = tb_baibao.Rows[i].Cells[2].Value.ToString();
            txt_giayphepxuatban.Text = tb_baibao.Rows[i].Cells[3].Value.ToString();
            txt_diemso.Text = tb_baibao.Rows[i].Cells[4].Value.ToString();
            String query = "select ct.mathanhvien,tv.tenthanhvien,ct.chucvu from cttv_bb ct,baibao bb,thanhvienthamgiadetai tv  where ct.mabaibao = bb.mabaibao and ct.mathanhvien = tv.mathanhvien and  ct.mabaibao = '" + ma + "'; ";
            DataTable dt1 = connect.GetDataTable(query);
            tb_thanhvien.DataSource = dt1;
            fix_header_tbthanhvien();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ma != null)
            {

                String query1 = "delete from cttv_bb where mabaibao='" + ma + "'";
                connect.fix(query1);
                String query = "delete from baibao where mabaibao ='" + ma + "'";
                connect.fix(query);
                getdata();
            }
            else MessageBox.Show("Chọn bài báo cần xóa");
        }
        String ma_tv = null;

        private void tb_thanhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_thanhvien.CurrentRow.Index;
            ma_tv = tb_thanhvien.Rows[i].Cells[0].Value.ToString();
        }

        private void txt_mathanhvien_TextChanged(object sender, EventArgs e)
        {
            String query = "select tenthanhvien from thanhvienthamgiadetai where mathanhvien = '" + txt_mathanhvien.Text + "'";
            DataTable data = connect.GetDataTable(query);
            if (data.Rows.Count != 0)
            {
                foreach (DataRow d in data.Rows)
                {
                    txt_tenthanhvien.Text = d["tenthanhvien"].ToString();

                }
            }
            else txt_tenthanhvien.Text = "";
        }
        void fix_header_tbthanhvien()
        {

            tb_thanhvien.Columns[0].HeaderText = "Mã thành viên";
            tb_thanhvien.Columns[1].HeaderText = "Tên thành viên";
            tb_thanhvien.Columns[2].HeaderText = "Chức vụ thành viên";

        }

        private void btn_them_tv_Click(object sender, EventArgs e)
        {
            if (ma != null)
            {
                String query = "insert into cttv_bb(mathanhvien,mabaibao,chucvu) values('" + txt_mathanhvien.Text + "', '" + ma + "', N'" + txt_chucvu.Text + "')";
                connect.fix(query);
                String query1 = "select ct.mathanhvien,tv.tenthanhvien,ct.chucvu from cttv_bb ct,baibao bb,thanhvienthamgiadetai tv  where ct.mabaibao = bb.mabaibao and ct.mathanhvien = tv.mathanhvien and  ct.mabaibao = '" + ma + "'; ";
                DataTable dt1 = connect.GetDataTable(query1);
                tb_thanhvien.DataSource = dt1;
                fix_header_tbthanhvien();
            }
            else { MessageBox.Show("hãy chọn đề tài mà bạn muốn thêm thành viên"); }
        }

        private void btn_xoatv_Click(object sender, EventArgs e)
        {
            String query = "delete from cttv_bb where mathanhvien ='" + ma_tv + "'";
            connect.fix(query);
            String query1 = "select * from cttv_bb ct,baibao bb,thanhvienthamgiadetai tv  where ct.mabaibao = bb.mabaibao and ct.mathanhvien = tv.mathanhvien and  ct.mabaibao = '" + ma + "'; ";
            DataTable dt1 = connect.GetDataTable(query1);
            tb_thanhvien.DataSource = dt1;
            fix_header_tbthanhvien();
        }

        private void btn_refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            getdata();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cb_select.SelectedIndex == 0)
            {
                String query = "select * from baibao where tenbaibao =N'" + txt_search.Text + "' and loaibaibao=N'Báo nước ngoài'";
                connect.fix(query);
                tb_baibao.DataSource = connect.GetDataTable(query);
                fix_header();

            }
            else if (cb_select.SelectedIndex == 1)
            {
                String query = "select * from baibao where mabaibao =N'" + txt_search.Text + "' and loaibaibao=N'Báo nước ngoài'";
                connect.fix(query);
                tb_baibao.DataSource = connect.GetDataTable(query);
                fix_header();
            }
        }
    }
}