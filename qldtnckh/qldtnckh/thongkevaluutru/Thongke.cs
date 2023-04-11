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
using DevExpress.XtraCharts;
namespace qldtnckh.thongkevaluutru
{
    public partial class Thongke : DevExpress.XtraEditors.XtraForm
    {
        public Thongke()
        {
            InitializeComponent();
        }
        DataConnect connect = new DataConnect();
        private void fillChart()
        {
           


            String query2 = "select capdetai,count(*) as sl from detai group by capdetai";
            DataTable dt1 = connect.GetDataTable(query2);

            // chartControl1.DataSource = dt;
            //set the member of the chart data source used to data bind to the X-values of the series  
            // chartControl1.Series["Quantity"]. = "Name";
            //set the member columns of the chart data source used to data bind to the X-values of the series  
            // chartControl1.Series["Salary"].YValueMembers = "Salary";
            Series series2 = new Series("Số lượng", ViewType.Bar);
            foreach (DataRow dr in dt1.Rows)
            {
                series2.Points.Add(new SeriesPoint(dr["capdetai"].ToString(), dr["sl"].ToString()));

            }
            chartControl2.Series.Add(series2);
        }

        private void Thongke_Load(object sender, EventArgs e)
        {
            fillChart();
        }
    }
}