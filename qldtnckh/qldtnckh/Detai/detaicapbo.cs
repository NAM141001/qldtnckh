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
using DevExpress.XtraReports.UI;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace qldtnckh.Detai
{
    public partial class detaicapbo : DevExpress.XtraEditors.XtraForm
    {
        public detaicapbo()
        {
            InitializeComponent();
        }
        DataConnect connect = new DataConnect();
       void fix_header()
        {
            tb_detaicapbo.Columns[0].HeaderText = "ID";
            tb_detaicapbo.Columns[1].HeaderText = "Tên đề tài";
            tb_detaicapbo.Columns[2].HeaderText = "Thời gian";
            tb_detaicapbo.Columns[3].HeaderText = "Quyết định giao";
            tb_detaicapbo.Columns[4].HeaderText = "Tiến độ";
            tb_detaicapbo.Columns[5].HeaderText = "Quyết định kiểm duyệt";
            tb_detaicapbo.Columns[6].HeaderText = "Quyết định thành lập hội đồng";
            tb_detaicapbo.Columns[7].HeaderText = "Ngày nghiệm thu";
            tb_detaicapbo.Columns[8].HeaderText = "Kết quả nghiệm thu";
            tb_detaicapbo.Columns[9].HeaderText = "Ứng dụng của đề tài";
            tb_detaicapbo.Columns[10].HeaderText = "Chi phí";
            tb_detaicapbo.Columns[11].HeaderText = "Lĩnh vực";
            tb_detaicapbo.Columns[12].HeaderText = "Cấp đề tài";
            tb_detaicapbo.Columns[13].HeaderText = "Định hướng mục tiêu";
            tb_detaicapbo.Columns[14].HeaderText = "Kết quả dự kiến";
            tb_detaicapbo.Columns[15].HeaderText = "Trạng thái";
        }
        void getdata()
        {
            tb_detaicapbo.DataSource = connect.GetDataTable("select madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where  dt.capdetai = N'Cấp bộ'");
            fix_header();
           
        }
        private void detaicapbo_Load(object sender, EventArgs e)
        {
            this.tb_detaicapbo.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_detaicapbo.DefaultCellStyle.BackColor = Color.Beige;
            this.tb_thanhvien.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_thanhvien.DefaultCellStyle.BackColor = Color.Beige;
            this.tb_hoidong.DefaultCellStyle.ForeColor = Color.Black;
            this.tb_hoidong.DefaultCellStyle.BackColor = Color.Beige;
            tb_detaicapbo.RowHeadersVisible = false;
            tb_detaicapbo.AllowUserToAddRows = false;
            tb_hoidong.RowHeadersVisible = false;
            tb_hoidong.AllowUserToAddRows = false;
            tb_thanhvien.RowHeadersVisible = false;
            tb_thanhvien.AllowUserToAddRows = false;
            txt_capdetai.Text = "Cấp bộ ";
            txt_capdetai.Enabled = false;
            getdata();
            cb_select.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cb_select.SelectedIndex = 0;
            tb_detaicapbo.ClearSelection();
            txt_linhvuc.Text = "";
            txt_quyetdinhgiao.Text = "";
            cb_nam.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cb_nam.SelectedIndex = 0;
            cb_trangthai.Visible = false;
            cb_trangthai.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cb_trangthai.SelectedIndex = 0;
            txt_trangthai.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            txt_trangthai.SelectedIndex = 0;
        }
        void reset()
        {
            txt_tendetai.Text = "";
            txt_ngayngiemthu.Text = "";
            txt_chiphi.Text = "";
            txt_ketquanghiemthu.Text = "";
            txt_qdkiemduyet.Text = "";
            txt_ungdungcuadetai.Text = "";
            txt_qdthanhlaphoidongnhiemthu.Text = "";
            txt_tiendo.Text = "";
            txt_dinhhuongmuctieu.Text = "";
            txt_ketquanghiemthu.Text = "";
           
        }
        private void btn_reset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            reset();
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String chiphi = txt_chiphi.Text;
            if (chiphi == "")
            {
                chiphi = "null";
            }
            String ngaythu = txt_ngayngiemthu.Text;
            String query = null;
            if (ngaythu == "")
            {
                query= "SET DATEFORMAT dmy;" + "insert into detai(tendetai ,thoigian,quyetdinhgiao,tiendo ,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu ,ketquanghiemthu,ungdungcuadetai,linhvuc,chiphi,capdetai,dinhhuongmuctieu,ketquadukien,trangthai)" +
                "values(N'" + txt_tendetai.Text + "','" + txt_thoigianthuchien.Text + "',N'" + txt_quyetdinhgiao.Text + "',N'" + txt_tiendo.Text + "', N'" + txt_qdkiemduyet.Text + "', N'" + txt_qdthanhlaphoidongnhiemthu.Text + "', N'" + txt_ketquanghiemthu.Text + "', N'" + txt_ungdungcuadetai.Text + "', N'" + txt_linhvuc.Text + "'," + chiphi + ", N'Cấp bộ',N'" + txt_dinhhuongmuctieu.Text + "',N'" + txt_ketquasukien.Text + "',N'"+txt_trangthai.Text+"')";
            }
           else query = "SET DATEFORMAT dmy;" + "insert into detai(tendetai ,thoigian,quyetdinhgiao,tiendo ,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu ,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,linhvuc,chiphi,capdetai,dinhhuongmuctieu,ketquadukien,trangthai)" +
                "values(N'" + txt_tendetai.Text + "','" + txt_thoigianthuchien.Text +"',N'"+txt_quyetdinhgiao.Text+ "',N'"+ txt_tiendo.Text + "', N'" + txt_qdkiemduyet.Text + "', N'" + txt_qdthanhlaphoidongnhiemthu.Text + "', N'" + ngaythu + "', N'" + txt_ketquanghiemthu.Text + "', N'" + txt_ungdungcuadetai.Text + "', N'"+txt_linhvuc.Text+"'," + chiphi + ", N'Cấp bộ',N'"+txt_dinhhuongmuctieu.Text+"',N'"+txt_ketquasukien.Text+ "',N'" + txt_trangthai.Text + "')";
            connect.fix(query);
            getdata();
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tb_detaicapbo.SelectedCells.Count != 0)
            {
               DialogResult dt= MessageBox.Show( "Bạn có muốn sửa đề tài mã :" + ma, "Thông báo", MessageBoxButtons.YesNo);
                if (dt == DialogResult.Yes) {
                    String chiphi = txt_chiphi.Text;
                    if (chiphi == "")
                    {
                        chiphi = "null";
                    }
                    String ngaythu = txt_ngayngiemthu.Text;
                    String query = null;
                    if (ngaythu != "")
                    {

                        query = "SET DATEFORMAT dmy;" + "update detai set tendetai = N'" + txt_tendetai.Text + "', thoigian = '" + txt_thoigianthuchien.Text + "',quyetdinhgiao =N'" + txt_quyetdinhgiao.Text + "' , tiendo =N'" + txt_tiendo.Text + "', quyetdinhkiemduyet =N'" + txt_qdkiemduyet.Text + "', quyetdinhthanhlaphoidongnghiemthu =N'" + txt_qdthanhlaphoidongnhiemthu.Text + "',  ngaynghiemthu = '" + txt_ngayngiemthu.Text + "', ketquanghiemthu =N'" + txt_ketquanghiemthu.Text + "', ungdungcuadetai =N'" + txt_ungdungcuadetai.Text + "',linhvuc=N'" + txt_linhvuc.Text + "', chiphi = '" + chiphi + "', dinhhuongmuctieu= N'" + txt_dinhhuongmuctieu.Text + "',ketquadukien='" + txt_ketquasukien.Text + "',trangthai=N'" + txt_trangthai.Text + "' "
                        + "where madetai = '" + ma + "'";
                        connect.fix(query);
                        getdata();
                    }
                    else
                    {
                        query = "SET DATEFORMAT dmy;" + "update detai set tendetai = N'" + txt_tendetai.Text + "', thoigian = '" + txt_thoigianthuchien.Text + "',quyetdinhgiao =N'" + txt_quyetdinhgiao.Text + "' , tiendo =N'" + txt_tiendo.Text + "', quyetdinhkiemduyet =N'" + txt_qdkiemduyet.Text + "', quyetdinhthanhlaphoidongnghiemthu =N'" + txt_qdthanhlaphoidongnhiemthu.Text + "',  ketquanghiemthu =N'" + txt_ketquanghiemthu.Text + "', ungdungcuadetai =N'" + txt_ungdungcuadetai.Text + "',linhvuc=N'" + txt_linhvuc.Text + "', chiphi = '" + chiphi + "', dinhhuongmuctieu= N'" + txt_dinhhuongmuctieu.Text + "',ketquadukien='" + txt_ketquasukien.Text + "',trangthai=N'" + txt_trangthai.Text + "' "
                        + "where madetai = '" + ma + "'";
                    }
                }
            }
            else MessageBox.Show("Hãy chọn đối tượng cần thay đổi");
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tb_detaicapbo.SelectedCells.Count != 0)
            {
                DialogResult dt = MessageBox.Show("Bạn có muốn xóa đề tài mã :" + ma, "Thông báo", MessageBoxButtons.YesNo);
                if (dt == DialogResult.Yes)
                {
                    String query1 = "delete from cttv where madetai='" + ma + "'";
                    connect.fix(query1);
                    String query = "delete from detai where madetai='" + ma + "'";
                    connect.fix(query);
                    getdata();
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    reset();
                }
            }
            else MessageBox.Show("Hãy chọn dòng cần xóa");
        }
        String ma = null;

        String tendetai = null;
        private void tb_detaicapbo_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_detaicapbo.CurrentRow.Index;
            ma = tb_detaicapbo.Rows[i].Cells[0].Value.ToString();
            tendetai = tb_detaicapbo.Rows[i].Cells[1].Value.ToString();
            txt_tendetai.Text = tb_detaicapbo.Rows[i].Cells[1].Value.ToString();
            txt_thoigianthuchien.Text = tb_detaicapbo.Rows[i].Cells[2].Value.ToString();
            txt_quyetdinhgiao.Text=tb_detaicapbo.Rows[i].Cells[3].Value.ToString();
            txt_tiendo.Text = tb_detaicapbo.Rows[i].Cells[4].Value.ToString();
            txt_qdkiemduyet.Text = tb_detaicapbo.Rows[i].Cells[5].Value.ToString();
            txt_qdthanhlaphoidongnhiemthu.Text = tb_detaicapbo.Rows[i].Cells[6].Value.ToString();
            txt_ngayngiemthu.Text = tb_detaicapbo.Rows[i].Cells[7].Value.ToString();
            txt_ketquanghiemthu.Text = tb_detaicapbo.Rows[i].Cells[8].Value.ToString();
            txt_ungdungcuadetai.Text = tb_detaicapbo.Rows[i].Cells[9].Value.ToString();
            txt_linhvuc.Text= tb_detaicapbo.Rows[i].Cells[10].Value.ToString();
            txt_chiphi.Text = tb_detaicapbo.Rows[i].Cells[11].Value.ToString();
            txt_ketquasukien.Text= tb_detaicapbo.Rows[i].Cells[13].Value.ToString();
            txt_dinhhuongmuctieu.Text= tb_detaicapbo.Rows[i].Cells[14].Value.ToString();
            String query1 = "select dv.mathanhvien, dv.tenthanhvien,ct.chucvu from detai dt,cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien and ct.chucvu in( N'Thành viên chính',N'Thành viên phụ',N'Chủ nhiệm') and dt.madetai = '"+ tb_detaicapbo.Rows[i].Cells[0].Value.ToString() + "';";
            DataTable dt1 = connect.GetDataTable(query1);
            tb_thanhvien.DataSource = dt1;
            fix_header_tbthanhvien();
            String query2= "select dv.mathanhvien, dv.tenthanhvien,ct.diem from detai dt,cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien and ct.chucvu in( N'Thành viên hội đồng') and dt.madetai = '" + tb_detaicapbo.Rows[i].Cells[0].Value.ToString() + "'";
            tb_hoidong.DataSource = connect.GetDataTable(query2);
            fix_header_tbhoidong();
        }
        void fix_header_tbhoidong()
        {
            tb_hoidong.Columns[0].HeaderText = "Mã tv hội đồng";
            tb_hoidong.Columns[1].HeaderText = "Tên tv hội đồng";
            tb_hoidong.Columns[2].HeaderText = "Chấm điểm";
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
                String query = "SET DATEFORMAT dmy;" + "insert into cttv(madetai,mathanhvien,chucvu) values('" + ma + "', '" + txt_mathanhvien.Text + "', N'" + txt_chucvu.Text + "')";
                connect.fix(query);
                String query1 = "select dv.mathanhvien, dv.tenthanhvien,ct.chucvu from detai dt,cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien and ct.chucvu in( N'Thành viên chính',N'Thành viên phụ',N'Chủ nhiệm') and dt.madetai = '" + ma + "';";
                DataTable dt1 = connect.GetDataTable(query1);
                tb_thanhvien.DataSource = dt1;
                fix_header_tbthanhvien();
            }
            else { MessageBox.Show("hãy chọn đề tài mà bạn muốn thêm thành viên"); }
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

        private void btn_themtvhd_Click(object sender, EventArgs e)
        {
            if (ma != null)
            {
                String query = "insert into cttv(madetai,mathanhvien,chucvu,diem) values('" + ma + "', '" + txt_matvhd.Text + "', N'Thành viên hội đồng',"+txt_diem.Text+")";
                connect.fix(query);
                String query1 = "select dv.mathanhvien, dv.tenthanhvien,ct.diem from detai dt,cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien and ct.chucvu in( N'Thành viên hội đồng') and dt.madetai = '" + ma + "'";
                DataTable dt1 = connect.GetDataTable(query1);
                tb_hoidong.DataSource = dt1;
                fix_header_tbhoidong();
            }
            else { MessageBox.Show("hãy chọn đề tài mà bạn muốn thêm thành viên hội đồng"); }
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

        private void btn_xoatv_Click(object sender, EventArgs e)
        {
            if (ma != null) {
                if (ma_tv != null) {
                    String query = "delete from cttv where madetai='" + ma + "'and mathanhvien = '" + ma_tv + "'";
                    connect.fix(query);
                    String query1 = "select dv.mathanhvien, dv.tenthanhvien,ct.chucvu from detai dt,cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien and ct.chucvu in( N'Thành viên chính',N'Thành viên phụ',N'Chủ nhiệm') and dt.madetai = '" + ma + "';";
                    DataTable dt1 = connect.GetDataTable(query1);
                    tb_thanhvien.DataSource = dt1;
                    fix_header_tbthanhvien();
                }
                else MessageBox.Show("hãy chon thành viên cần xóa");
            }
            else MessageBox.Show("hãy chọn đề tài cần xóa thành viên");
        }
        String ma_tv = null;
        String ten_tv_hd = null;
        private void tb_thanhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_thanhvien.CurrentRow.Index;
            ma_tv = tb_thanhvien.Rows[i].Cells[0].Value.ToString();
            
        }
        String ma_hd = null;
        String diem = null;
        private void tb_hoidong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = tb_hoidong.CurrentRow.Index;
            ma_hd = tb_hoidong.Rows[i].Cells[0].Value.ToString();
            ten_tv_hd = tb_hoidong.Rows[i].Cells[1].Value.ToString();
            diem = tb_hoidong.Rows[i].Cells[2].Value.ToString();
        }

        private void btn_xoatvhd_Click(object sender, EventArgs e)
        {
            if (ma != null)
            {
                if (ma_hd != null)
                {
                    String query = "delete from cttv where madetai='" + ma + "'and mathanhvien = '" + ma_hd + "'";
                    connect.fix(query);
                    String query2 = "select dv.mathanhvien, dv.tenthanhvien,ct.diem from detai dt,cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien and ct.chucvu in( N'Thành viên hội đồng') and dt.madetai = '" +ma + "'";
                    tb_hoidong.DataSource = connect.GetDataTable(query2);
                    fix_header_tbhoidong();
                }
                else MessageBox.Show("hãy chọn thành viên hội đồng cần xóa");
            }
            else { MessageBox.Show("hãy chọn đề tài cần xóa thành viên hội đồng"); }
        }

        private void btn_inphieu_Click(object sender, EventArgs e)
        {
            report.phieudanhgia f = new report.phieudanhgia();
           /* f.Parameters["parameter1"].Value = tendetai;
            f.Parameters["parameter2"].Value = ten_tv_hd;
            f.Parameters["parameter3"].Value = diem;*/
            f.ShowRibbonPreviewDialog();
        }

        private void btn_baocao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ma != null)
            {
                baocao.XtraForm1 bc = new baocao.XtraForm1();
                bc.madetai = ma;
                bc.ShowDialog();
            }
            else MessageBox.Show("Chọn đề tài muốn xem báo cáo");
        }
        private void export(string path)
        {
            Excel.Application application = new Excel.Application();
            application.Application.Workbooks.Add(Type.Missing);
            //dòng đầu
            for (int i = 0; i < tb_detaicapbo.Columns.Count; i++)
            {

                application.Cells[1, i + 1] = tb_detaicapbo.Columns[i].HeaderText;

            }
            //dữ liệu
            for (int i = 0; i < tb_detaicapbo.Rows.Count; i++)
            {
                for (int j = 0; j < tb_detaicapbo.Columns.Count; j++)
                {

                    application.Cells[i + 2, j + 1] = tb_detaicapbo.Rows[i].Cells[j].Value;

                }
            }
            //auto fig dữ liệu
            application.Columns.AutoFit();

            application.ActiveWorkbook.SaveCopyAs(path);
            //application.ActiveWorkbook.Saved = true;
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                System.Diagnostics.Process.Start(path);
                return;
            }

        }
        private void btn_export_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook(*.xls)|*.xls|All Files|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                export(saveFileDialog.FileName);
            }
        }

        private void btn_giaytokemtheo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ma != null)
            {
                baocao.giaytokemtheo gt = new baocao.giaytokemtheo();
                gt.madetai = ma;
                gt.ShowDialog();
            }
            else MessageBox.Show("Chọn đề tài muốn xem giấy tờ hợp đồng");
        }

        private void tb_hoidong_LocationChanged(object sender, EventArgs e)
        {
          
        }

        private void tb_hoidong_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
         
        }


        private void tb_hoidong_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            
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
            
                for (int j = 0; j<this.tb_hoidong.RowCount; j++)
                {
                Double a = Convert.ToDouble (tb_hoidong.Rows[j].Cells[2].Value.ToString());
                sum += a;
                }

                this.lb_sum.Text = "SUM : "+sum.ToString()+" Point";
            Double avg = sum / i;

            this.lb_avg.Text = "AVG : " + avg.ToString() + " Point";


        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cb_select.SelectedIndex == 0)
            {
                if (cb_nam.SelectedIndex == 2)
                {
                    String query = "select dt.madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien from detai dt, cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien  and ct.mathanhvien = '" + txt_search.Text + "' and ct.chucvu = N'Chủ nhiệm' and dt.capdetai = N'Cấp bộ'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
                else if(cb_nam.SelectedIndex == 0)
                {
                    String query = "select dt.madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien from detai dt, cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien  and ct.mathanhvien = '" + txt_search.Text + "' and ct.chucvu = N'Chủ nhiệm' and dt.capdetai = N'Cấp bộ' and year(dt.thoigian)='"+txt_nam.Text+"' ";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
                else if (cb_nam.SelectedIndex == 1)
                {
                    String query = "select dt.madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien from detai dt, cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien  and ct.mathanhvien = '" + txt_search.Text + "' and ct.chucvu = N'Chủ nhiệm' and dt.capdetai = N'Cấp bộ' and year(dt.ngaynghiemthu)='" + txt_nam.Text + "' ";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
            }
            else if (cb_select.SelectedIndex == 1)
            {
                if (cb_nam.SelectedIndex == 2) {
                    String query = "select dt.madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien from detai dt, cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien  and dv.tenthanhvien = N'" + txt_search.Text + "' and ct.chucvu = N'Chủ nhiệm' and dt.capdetai = N'Cấp bộ' ";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header(); }
                else if (cb_nam.SelectedIndex == 0)
                {
                    String query = "select dt.madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt, cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien  and dv.tenthanhvien = N'" + txt_search.Text + "' and ct.chucvu = N'Chủ nhiệm' and dt.capdetai = N'Cấp bộ' and year(dt.thoigian)='" + txt_nam.Text + "'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
                else if(cb_nam.SelectedIndex == 1)
                {
                    String query = "select dt.madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt, cttv ct ,thanhvienthamgiadetai dv where dt.madetai = ct.madetai and ct.mathanhvien = dv.mathanhvien  and dv.tenthanhvien = N'" + txt_search.Text + "' and ct.chucvu = N'Chủ nhiệm' and dt.capdetai = N'Cấp bộ' and year(dt.ngaynghiemthu)='" + txt_nam.Text + "'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
            }
            else if(cb_select.SelectedIndex == 2)
            {
                if (cb_nam.SelectedIndex == 2)
                {
                    String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where  dt.madetai = '" + txt_search.Text + "'  and dt.capdetai = N'Cấp bộ'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
                else if(cb_nam.SelectedIndex == 0)
                {
                    String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where  dt.madetai = '" + txt_search.Text + "'  and dt.capdetai = N'Cấp bộ'  and year(dt.thoigian)='" + txt_nam.Text + "'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
                else if(cb_nam.SelectedIndex == 1)
                {
                    String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where  dt.madetai = '" + txt_search.Text + "'  and dt.capdetai = N'Cấp bộ'  and year(dt.ngaynghiemthu)='" + txt_nam.Text + "'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
            }
            else if(cb_select.SelectedIndex == 3)
            {
                if (cb_nam.SelectedIndex == 2) {
                    String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where  dt.tendetai = N'" + txt_search.Text + "'  and dt.capdetai = N'Cấp bộ'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header(); }
                else if (cb_nam.SelectedIndex == 0)
                {
                    String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where  dt.tendetai = N'" + txt_search.Text + "'  and dt.capdetai = N'Cấp bộ'and year(dt.thoigian)='" + txt_nam.Text + "'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
                else if (cb_nam.SelectedIndex == 1)
                {
                    String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where  dt.tendetai = N'" + txt_search.Text + "'  and dt.capdetai = N'Cấp bộ' and year(dt.ngaynghiemthu)='" + txt_nam.Text + "'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
            }
            else if(cb_select.SelectedIndex == 4)
            {
                if (cb_nam.SelectedIndex == 0)
                {
                    if (cb_trangthai.SelectedIndex == 0) {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Đã hoàn thành' and YEAR(dt.thoigian) = '" + txt_nam.Text + "'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header(); }
                    else if(cb_trangthai.SelectedIndex == 1)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Đang thực hiện' and YEAR(dt.thoigian) = '" + txt_nam.Text + "'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                   else if(cb_trangthai.SelectedIndex == 2)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Quá hạn' and YEAR(dt.thoigian) = '" + txt_nam.Text + "'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                    else if(cb_trangthai.SelectedIndex == 3)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Hủy' and YEAR(dt.thoigian) = '" + txt_nam.Text + "'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                }
                else if(cb_nam.SelectedIndex == 1)
                {
                    if (cb_trangthai.SelectedIndex == 0)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Đã hoàn thành' and YEAR(dt.ngaynghiemthu) = '" + txt_nam.Text + "'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                    else if(cb_trangthai.SelectedIndex == 1)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Đang thực hiện' and YEAR(dt.ngaynghiemthu) = '" + txt_nam.Text + "'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                    else if(cb_trangthai.SelectedIndex == 2)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Quá hạn' and YEAR(dt.ngaynghiemthu) = '" + txt_nam.Text + "'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                    else if(cb_trangthai.SelectedIndex == 3)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Hủy' and YEAR(dt.ngaynghiemthu) = '" + txt_nam.Text + "'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                }
                else if (cb_nam.SelectedIndex == 2)
                {
                    if (cb_trangthai.SelectedIndex == 0)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Đã hoàn thành'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                    else if(cb_trangthai.SelectedIndex == 1)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Đang thực hiện'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                    else if(cb_trangthai.SelectedIndex == 2)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Quá hạn'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                    else if(cb_trangthai.SelectedIndex == 3)
                    {
                        String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where dt.trangthai=N'Hủy'  and dt.capdetai = N'Cấp bộ'";
                        tb_detaicapbo.DataSource = connect.GetDataTable(query);
                        tb_thanhvien.DataSource = null;
                        tb_hoidong.DataSource = null;
                        fix_header();
                    }
                }
            }
            else if(cb_select.SelectedIndex == 5)
            {
                if (cb_nam.SelectedIndex == 0)
                {
                    String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where  YEAR(dt.thoigian) = '" + txt_nam.Text + "'  and dt.capdetai = N'Cấp bộ'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
                else if (cb_nam.SelectedIndex == 1)
                {
                    String query = "select DISTINCT madetai,tendetai,thoigian,quyetdinhgiao,tiendo,quyetdinhkiemduyet,quyetdinhthanhlaphoidongnghiemthu,ngaynghiemthu,ketquanghiemthu,ungdungcuadetai,chiphi,linhvuc,capdetai,dinhhuongmuctieu,ketquadukien,trangthai from detai dt where  YEAR(dt.ngaynghiemthu) = '" + txt_nam.Text + "'  and dt.capdetai = N'Cấp bộ'";
                    tb_detaicapbo.DataSource = connect.GetDataTable(query);
                    tb_thanhvien.DataSource = null;
                    tb_hoidong.DataSource = null;
                    fix_header();
                }
                else if(cb_nam.SelectedIndex == 2)
                {
                    getdata();
                }
            }
        }

        private void btn_refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            getdata();
        }

        private void cb_select_TextChanged(object sender, EventArgs e)
        {
            if(cb_select.SelectedIndex == 5)
            {
                txt_search.Enabled = false;
                txt_search.Text = "";
                cb_trangthai.Visible = false;
                txt_search.Visible = true;
            }
            else if(cb_select.SelectedIndex == 4)
            {
                txt_search.Visible = false;
                txt_search.Text = "";
                cb_trangthai.Visible = true;
            }
            else if(cb_select.SelectedIndex != 5 && cb_select.SelectedIndex != 4)
            {
                txt_search.Enabled = true;
                cb_trangthai.Visible = false;
                txt_search.Visible = true;
            }
        }

        private void cb_nam_TextChanged(object sender, EventArgs e)
        {
            if(cb_nam.SelectedIndex == 2)
            {
                txt_nam.Enabled = false;
                txt_nam.Text = "";
            }
            else if(cb_nam.SelectedIndex != 2)
            {
                txt_nam.Enabled = true;
            }
        }
    }
}