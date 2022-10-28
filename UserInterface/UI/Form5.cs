using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace 前台
{
    

    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
           
        }
        private void Form5_Load(object sender, EventArgs e)
        {

            Chart1.Legends.Add(legend2);
        }
        Legend legend2 = new Legend();
        static string earthquake = "Data Source=.;Initial Catalog=earthquake;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection(earthquake);
            string search1 = "select left(F1,10) as 日期,count(F6) as 发生次数 from earthquake_data where F1>= " +"'" + dateTimePicker1.Value.ToString("yyyy-MM-dd")+ "'"+"AND F1<= " +"'" +dateTimePicker2.Value.ToString("yyyy-MM-dd ")+"' group by left(F1,10)";  
            SqlDataAdapter myadapter1 = new SqlDataAdapter(search1, mycon);
            DataTable mytable1 = new DataTable();
            DataTable mytable2 = new DataTable();
            myadapter1.Fill(mytable1); myadapter1.Fill(mytable2);
            if (mytable1.Rows.Count > 900)
            {
                string search2 = "select left(F1,4) as 日期,count(F6) as 发生次数 from earthquake_data where F1>= " + "'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + "AND F1<= " + "'" + dateTimePicker2.Value.ToString("yyyy-MM-dd ") + "' group by left(F1,4)";
                SqlDataAdapter myadapter2 = new SqlDataAdapter(search2, mycon);
                mytable1.Clear();
                myadapter2.Fill(mytable1);
 
            }
            else if (mytable1.Rows.Count > 15)
            {
                string search2 = "select left(F1,7) as 日期,count(F6) as 发生次数 from earthquake_data where F1>= " + "'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + "AND F1<= " + "'" + dateTimePicker2.Value.ToString("yyyy-MM-dd ") + "' group by left(F1,7)";
                SqlDataAdapter myadapter2 = new SqlDataAdapter(search2, mycon);
                mytable1.Clear();
                myadapter2.Fill(mytable1);
            }
            Chart1.Series.Clear();
            Chart1.Series.Add("地震频数");
            Chart1.DataSource = mytable1;
            Chart1.Series["地震频数"].XValueMember = "日期";
            Chart1.Series["地震频数"].YValueMembers = "发生次数";

            Chart1.Titles.Clear();
            Chart1.Titles.Add("地震频度分析图");
            Chart1.Titles[0].ForeColor = Color.Black;
            Chart1.Titles[0].Font = new Font("微软雅黑", 14f, FontStyle.Bold);
            Chart1.Titles[0].Alignment = ContentAlignment.TopCenter;
            Chart1.Titles.Add("合计："+mytable2.Rows.Count.ToString()+" 天");
            Chart1.Titles[1].ForeColor = Color.Black;
            Chart1.Titles[1].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
            Chart1.Titles[1].Alignment = ContentAlignment.TopRight;

            //控件背景
            Chart1.BackColor = Color.Transparent;
            //图表区背景
            Chart1.ChartAreas[0].BackColor = Color.Transparent;
            Chart1.ChartAreas[0].BorderColor = Color.Transparent;



            //X坐标轴颜色
            Chart1.ChartAreas[0].AxisX.LineColor = ColorTranslator.FromHtml("#38587a"); ;
            Chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            Chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
            //X坐标轴标题
            Chart1.ChartAreas[0].AxisX.Title = "日期";
            Chart1.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            Chart1.ChartAreas[0].AxisX.TitleForeColor = Color.White;
            Chart1.ChartAreas[0].AxisX.TextOrientation = TextOrientation.Horizontal;
            Chart1.ChartAreas[0].AxisX.ToolTip = "日期";
  
            if (mytable1.Rows.Count < 10)
            {
                //X轴标签间距
                Chart1.ChartAreas[0].AxisX.Interval = 1;
                Chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;
                Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                Chart1.ChartAreas[0].AxisX.TitleFont = new Font("微软雅黑", 14f, FontStyle.Regular);
                Chart1.ChartAreas[0].AxisX.TitleForeColor = Color.White;
                //X轴网络线条
                Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                Chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");
            }

            //Y坐标轴颜色
            Chart1.ChartAreas[0].AxisY.LineColor = ColorTranslator.FromHtml("#38587a");
            Chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            Chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("微软雅黑", 10f, FontStyle.Regular);
            //Y坐标轴标题
            Chart1.ChartAreas[0].AxisY.Title = "频数(次)";
            Chart1.ChartAreas[0].AxisY.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            Chart1.ChartAreas[0].AxisY.TitleForeColor = Color.White;
            Chart1.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Rotated270;
            Chart1.ChartAreas[0].AxisY.ToolTip = "频数(次)";
            //Y轴网格线条
            Chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            Chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = ColorTranslator.FromHtml("#2c4c6d");

            Chart1.ChartAreas[0].AxisY2.LineColor = Color.Transparent;
            Chart1.ChartAreas[0].BackGradientStyle = GradientStyle.TopBottom;
            Legend legend = new Legend("legend");
            legend.Title = "legendTitle";

            Chart1.Series["地震频数"].XValueType = ChartValueType.String;  //设置X轴上的值类型
            Chart1.Series["地震频数"].Label = "#VAL";                //设置显示X Y的值    
            Chart1.Series["地震频数"].LabelForeColor = Color.DarkBlue;
            Chart1.Series["地震频数"].ToolTip = "#VALX:#VAL(次)";     //鼠标移动到对应点显示数值
            Chart1.Series["地震频数"].ChartType = SeriesChartType.Line;    //图类型(折线)


            

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection mycon2 = new SqlConnection(earthquake);
            string search2 = "select count(case when F5<60 then F5 end) as 浅源地震,count(case when F5<300 and F5>60 then F5 end) as 中源地震,count(case when F5>300 then F5 end) as 深源地震 from earthquake_data where F1>= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND F1<= " + "'" + dateTimePicker2.Value.ToString("yyyy-MM-dd ") + "'";
            SqlDataAdapter myadapter2 = new SqlDataAdapter(search2, mycon2);
            DataTable mytable2 = new DataTable();
            myadapter2.Fill(mytable2);
            string[] x={"浅源地震","中源地震","深源地震"};
            double[] y=new double[3];
            if (mytable2.Rows.Count==0)
            {
                MessageBox.Show("出错！");
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    y[i] = Convert.ToDouble(mytable2.Rows[0].ItemArray[i]);
                }
            }
            Chart1.Series.Clear(); Chart1.Titles.Clear();
            Chart1.Series.Add("Series1");
            Chart1.Titles.Add("震源深度分析表");
            Chart1.Titles[0].ForeColor = Color.Black;
            Chart1.Titles[0].Font = new Font("微软雅黑", 14f, FontStyle.Bold);
            Chart1.Titles[0].Alignment = ContentAlignment.TopCenter;
            Chart1.Titles.Add("合计："+(y.Sum()).ToString()+"次");
            Chart1.Titles[1].ForeColor = Color.Black;
            Chart1.Titles[1].Font = new Font("微软雅黑", 8f, FontStyle.Regular);
            Chart1.Titles[1].Alignment = ContentAlignment.TopRight;

            //控件背景
            Chart1.BackColor = Color.Transparent;
            //图表区背景
            Chart1.ChartAreas[0].BackColor = Color.Transparent;
            Chart1.ChartAreas[0].BorderColor = Color.Transparent;


            //背景渐变
            Chart1.ChartAreas[0].BackGradientStyle = GradientStyle.None;

            //图例样式
            Legend legend2 = new Legend();
            legend2.Title = "图例";
            legend2.TitleBackColor = Color.Transparent;
            legend2.BackColor = Color.Transparent;
            legend2.TitleForeColor = Color.Pink;
            legend2.TitleFont = new Font("微软雅黑", 10f, FontStyle.Regular);
            legend2.Font = new Font("微软雅黑", 8f, FontStyle.Regular);
            legend2.ForeColor = Color.Pink;

            Chart1.Series["Series1"].XValueType = ChartValueType.String;  //设置X轴上的值类型
            Chart1.Series["Series1"].Label = "#VAL";                //设置显示X Y的值    
            Chart1.Series["Series1"].LabelForeColor = Color.White;
            Chart1.Series["Series1"].ToolTip = "#VALX:#VAL(次)";     //鼠标移动到对应点显示数值
            Chart1.Series["Series1"].ChartType = SeriesChartType.Pie;    //图类型(折线)

            Chart1.Series["Series1"].Color = Color.Lime;
            Chart1.Series["Series1"].LegendText = legend2.Name;
            Chart1.Series["Series1"].IsValueShownAsLabel = true;
            Chart1.Series["Series1"].LabelForeColor = Color.Black;
            Chart1.Series["Series1"].CustomProperties = "DrawingStyle = Cylinder";
            Chart1.Series["Series1"].CustomProperties = "PieLabelStyle = Outside";
            
            Chart1.Legends[0].Position.Auto = true;
            Chart1.Series["Series1"].IsValueShownAsLabel = true;
            //是否显示图例
            Chart1.Series["Series1"].IsVisibleInLegend = true;
            Chart1.Series["Series1"].ShadowOffset = 0;

            //饼图折线
            Chart1.Series["Series1"]["PieLineColor"] = "Black";
            //绑定数据
            Chart1.Series["Series1"].Points.DataBindXY(x, y);
            Chart1.Series["Series1"].Points[0].Color = Color.Pink;
            //绑定颜色
            Chart1.Series["Series1"].Palette = ChartColorPalette.BrightPastel;

        }


        private void 首页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
            Form0 f0 = new Form0();
            f0.ShowDialog();
            if (f0.DialogResult == DialogResult.Cancel)
                this.Close();

        }
        private void 历史查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            if (f1.DialogResult == DialogResult.Cancel)
                this.Close();


        }

        private void 快捷查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.DialogResult == DialogResult.Cancel)
                this.Close();


        }

        private void 地震专题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
            if (f6.DialogResult == DialogResult.Cancel)
                this.Close();
        }

        private void 地震活动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            if (f4.DialogResult == DialogResult.Cancel)
                this.Close();

        }




        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
