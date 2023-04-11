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

namespace qldtnckh.hoithaocapqg
{
    public partial class htcaptinh : DevExpress.XtraEditors.XtraForm
    {
        public htcaptinh()
        {
            InitializeComponent();
        }
        DataConnect connect = new DataConnect();
        void getdata()
        {
            String query = "select * from hoithao where caphoithao =N'Cấp tỉnh'";
            tb_hoithao.DataSource = connect.GetDataTable(query);
            fix_header();
        }
        void fix_header()
        {
            tb_hoithao.Columns[0].HeaderText = "ID";
            tb_hoithao.Columns[1].HeaderText = "Tên hội thảo";
            tb_hoithao.Columns[2].HeaderText = "Ngày tổ chức";
            tb_hoithao.Columns[3].HeaderText = "Số lượng người tham gia";
            tb_hoithao.Columns[4].HeaderText = "Số lượng người tham luận";
            tb_hoithao.Columns[5].HeaderText = "Cấp hội thảo";

        }
        private void htcaptinh_Load(object sender, EventArgs e)
        {
            txt_caphoithao.Enabled = false;
            txt_caphoithao.Text = "Cấp tỉnh";
            getdata();
            this.tb_hoithao.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_hoithao.DefaultCellStyle.BackColor = Color.Beige;
            cb_select.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cb_select.SelectedIndex = 0;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String query = "SET DATEFORMAT dmy;" + "insert into hoithao(tenhoithao,ngaytochuc,soluongnguoithamgia,soluongthamluan,caphoithao)" +
                   "values (N'" + txt_tenhoithao.Text + "',N'" + txt_ngaytochuc.Text + "'," + txt_soluongnguoi.Text + "," + txt_soluongnguoithamluan.Text + ",N'Cấp tỉnh')";
            connect.fix(query);
            getdata();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ma != null)
            {
                String query = "delete from hoithao where mahoithao =N'" + ma + "'";
                connect.fix(query);
                getdata();
            }
            else MessageBox.Show("Hãy chọn hội thảo cần xóa");
        }
        String ma = null;

        private void tb_hoithao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_hoithao.CurrentCell.RowIndex;
            ma = tb_hoithao.Rows[i].Cells[0].Value.ToString();
            txt_tenhoithao.Text = tb_hoithao.Rows[i].Cells[1].Value.ToString();
            txt_ngaytochuc.Text = tb_hoithao.Rows[i].Cells[2].Value.ToString();
            txt_soluongnguoi.Text = tb_hoithao.Rows[i].Cells[3].Value.ToString();
            txt_soluongnguoithamluan.Text = tb_hoithao.Rows[i].Cells[4].Value.ToString();
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(ma != null)
            {
                String query = "SET DATEFORMAT dmy;" + "update hoithao set tenhoithao = N'" + txt_tenhoithao.Text + "',ngaytochuc ='" + txt_ngaytochuc.Text + "',soluongnguoithamgia =" + txt_soluongnguoi.Text + ",soluongthamluan=" + txt_soluongnguoithamluan.Text + " where mahoithao =N'" + ma + "'";
                connect.fix(query);
                getdata();
            }
            else MessageBox.Show("hãy chọn đề tài cần sửa");
        }

        private void btn_refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            getdata();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cb_select.SelectedIndex == 0)
            {
                String query = "select * from hoithao where caphoithao =N'Cấp tỉnh' and mahoithao=N'" + txt_search.Text + "'";
                tb_hoithao.DataSource = connect.GetDataTable(query);
                fix_header();
            }
            else if (cb_select.SelectedIndex == 1)
            {
                String query = "select * from hoithao where caphoithao =N'Cấp tỉnh' and tenhoithao=N'" + txt_search.Text + "'";
                tb_hoithao.DataSource = connect.GetDataTable(query);
                fix_header();
            }
        }
    }
}