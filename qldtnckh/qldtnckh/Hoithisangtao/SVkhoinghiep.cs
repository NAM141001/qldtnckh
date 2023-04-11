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

namespace qldtnckh.Hoithisangtao
{
    public partial class SVkhoinghiep : DevExpress.XtraEditors.XtraForm
    {
        public SVkhoinghiep()
        {
            InitializeComponent();
        }
        DataConnect connect = new DataConnect();
        void getdata()
        {
            String query = "select maduan,tenduan,thoigian,giaithuong from sinhvienkhoinghiep";
            tb_sinhvienkhoinghiep.DataSource = connect.GetDataTable(query);
            fix_header();
        }
        void fix_header()
        {
            tb_sinhvienkhoinghiep.Columns[0].HeaderText = "Mã dự án";
            tb_sinhvienkhoinghiep.Columns[1].HeaderText = "Tên dự án";
            tb_sinhvienkhoinghiep.Columns[2].HeaderText = "Thời gian bắt đầu dự án";
            tb_sinhvienkhoinghiep.Columns[3].HeaderText = "Giải thưởng";
        }
        private void SVkhoinghiep_Load(object sender, EventArgs e)
        {
            this.tb_sinhvienkhoinghiep.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_sinhvienkhoinghiep.DefaultCellStyle.BackColor = Color.Beige;
            this.tb_sinhvien.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_sinhvien.DefaultCellStyle.BackColor = Color.Beige;
            getdata();
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String query = "SET DATEFORMAT dmy;" + "insert into sinhvienkhoinghiep(tenduan,thoigian,giaithuong) values (N'" + txt_tenduan.Text + "','" + txt_thoigian.Text + "',N'" + txt_giaithuong.Text + "')";
            connect.fix(query);
            getdata();
        }
        String ma = null;
        private void tb_sinhvienkhoinghiep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_sinhvienkhoinghiep.CurrentRow.Index;
            ma = tb_sinhvienkhoinghiep.Rows[i].Cells[0].Value.ToString();
            txt_tenduan.Text = tb_sinhvienkhoinghiep.Rows[i].Cells[1].Value.ToString();
            txt_thoigian.Text = tb_sinhvienkhoinghiep.Rows[i].Cells[2].Value.ToString();
            txt_giaithuong.Text = tb_sinhvienkhoinghiep.Rows[i].Cells[3].Value.ToString();
            getdata_sv();
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String query = "SET DATEFORMAT dmy;" + "update sinhvienkhoinghiep set tenduan=N'" +txt_tenduan.Text + "',thoigian='" + txt_thoigian.Text + "',giaithuong = N'" + txt_giaithuong.Text + "' where maduan ='" + ma + "'";
            connect.fix(query);
            getdata();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String query = "delete from sinhvienkhoinghiep where maduan ='" + ma + "'";
            connect.fix(query);
            getdata();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if(cb_select.SelectedIndex == 0)
            {

            }
            else if (cb_select.SelectedIndex == 1)
            {

            }
            else if (cb_select.SelectedIndex == 2)
            {
                String query = "select tenduan,thoigian,giaithuong from sinhvienkhoinghiep where maduan ='"+txt_search.Text+"'";
                tb_sinhvienkhoinghiep.DataSource = connect.GetDataTable(query);
                fix_header();
            }
            else if (cb_select.SelectedIndex == 3)
            {
                String query = "select tenduan,thoigian,giaithuong from sinhvienkhoinghiep where tenduan ='" + txt_search.Text + "'";
                tb_sinhvienkhoinghiep.DataSource = connect.GetDataTable(query);
                fix_header();
            }
            else if (cb_select.SelectedIndex == 4)
            {
                String query = "select tenduan,thoigian,giaithuong from sinhvienkhoinghiep where Year(thoigian) ='" + txt_search.Text + "'";
                tb_sinhvienkhoinghiep.DataSource = connect.GetDataTable(query);
                fix_header();
            }
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
        void getdata_sv()
        {
            String query1 = "select dv.masinhvien, dv.tensinhvien,ct.chucvu from sinhvienkhoinghiep dt,cttv_svkn ct ,sinhvien dv where dt.maduan = ct.maduan and ct.masinhvien = dv.masinhvien and ct.chucvu in( N'Thành viên chính',N'Thành viên phụ',N'Chủ nhiệm') and dt.maduan = '" + ma + "';";
            DataTable dt1 = connect.GetDataTable(query1);
            tb_sinhvien.DataSource = dt1;
            fix_header_tbthanhvien();
        }
        void fix_header_tbthanhvien()
        {

            tb_sinhvien.Columns[0].HeaderText = "Mã thành viên";
            tb_sinhvien.Columns[1].HeaderText = "Tên thành viên";
            tb_sinhvien.Columns[2].HeaderText = "Chức vụ thành viên";

        }
        private void btn_them_tv_Click(object sender, EventArgs e)
        {
            if (ma != null)
            {
                String query = "insert into cttv_svkn(masinhvien,maduan,chucvu) values('" + txt_mathanhvien.Text + "', '" + ma + "', N'" + txt_chucvu.Text + "')";
                connect.fix(query);
                getdata_sv();
            }
            else
            {
                MessageBox.Show("hãy chọn  dự án mà bạn muốn thêm thành viên");
            }
        }
    }
}