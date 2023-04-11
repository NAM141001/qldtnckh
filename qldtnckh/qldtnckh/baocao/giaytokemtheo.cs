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
using System.IO;
namespace qldtnckh.baocao
{
    public partial class giaytokemtheo : DevExpress.XtraEditors.XtraForm
    {
        public giaytokemtheo()
        {
            InitializeComponent();
        }
        public String madetai = null;
        DataConnect connect = new DataConnect();
        private void giaytokemtheo_Load(object sender, EventArgs e)
        {
            get_data();
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String filename = Path.GetFileName(openFileDialog1.FileName);
            String mota = txt_mota.Text;
            if (filename == null)
            {
                MessageBox.Show("Chon file để upload");
                get_data();
            }
            else
            {

                String query = "insert into hopdong(ten_file,duongdan,mota,madetai) values " +
                    "('" + filename + "','\\Giayto\\" + filename + "',N'" + mota + "'" + ",'" + madetai + "')";
                connect.fix(query);
                //MessageBox.Show(filename);
                try
                {
                    File.Copy(openFileDialog1.FileName, Application.StartupPath + "\\Giayto\\" + filename);
                    // MessageBox.Show(Application.StartupPath + "\\Documents\\" + filename);
                }
                catch { MessageBox.Show("error"); }
                get_data();
            }
        }

        private void btn_xem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (silunchamlon != null)
            {
                string path = Application.StartupPath + "\\Giayto\\" + silunchamlon;
              //  MessageBox.Show(path);
                System.Diagnostics.Process.Start(path);
            }
            else MessageBox.Show("Chọn tài liệu muốn xem");
        }
        String silunchamlon = null;
        String mahopdong = null;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            mahopdong = dataGridView1.Rows[i].Cells[0].Value.ToString();
            silunchamlon = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Chọn tài liệu";
            openFileDialog1.Filter = "Chọn loại file(*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.CheckFileExists == true)
                {
                    string path = Path.GetFullPath(openFileDialog1.FileName);
                    txt_url.Text = path;
                }
                else MessageBox.Show("File không tồn tại");
            }
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String query = "delete from hopdong where mabaocao='" + mahopdong + "' and madetai='" + madetai + "'";
            if (connect.fix(query))
            {
                MessageBox.Show("Đã xóa");
            }
            else MessageBox.Show("Xóa không thành công");
            File.Delete(Application.StartupPath + "\\Documents\\" + silunchamlon);
            get_data();
        }
        void get_data()
        {
            dataGridView1.DataSource = connect.GetDataTable("Select mahopdong,ten_file,mota from hopdong where madetai='" + madetai + "'");
            fix_header();
        }
        void fix_header()
        {
            dataGridView1.Columns[0].HeaderText = "Mã hợp đồng";
            dataGridView1.Columns[1].HeaderText = "Tên hợp đồng";
            dataGridView1.Columns[2].HeaderText = "Mô tả";


        }
    }
}