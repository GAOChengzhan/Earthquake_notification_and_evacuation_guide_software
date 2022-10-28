using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;

namespace 前台
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        static string mystr = "Data Source=.;Initial Catalog=earthquake;Integrated Security=True";
        //注意转义字符的设置
        SqlConnection myconn = new SqlConnection(mystr);

        private void button10_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2<3 order by F1 desc", myconn);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "ear");
            dataGridView1.DataSource = mydataset.Tables["ear"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where (getdate()-cast(F1 as datetime))<=1 order by F1 desc", myconn);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "ear");
            dataGridView1.DataSource = mydataset.Tables["ear"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where (getdate()-cast(F1 as datetime))<=2 order by F1 desc", myconn);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "ear");
            dataGridView1.DataSource = mydataset.Tables["ear"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where (getdate()-cast(F1 as datetime))<=30 order by F1 desc", myconn);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "ear");
            dataGridView1.DataSource = mydataset.Tables["ear"];
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2>3 order by F1 desc", myconn);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "ear");
            dataGridView1.DataSource = mydataset.Tables["ear"];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2>4 order by F1 desc", myconn);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "ear");
            dataGridView1.DataSource = mydataset.Tables["ear"];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2>5 order by F1 desc", myconn);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "ear");
            dataGridView1.DataSource = mydataset.Tables["ear"];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2>6 order by F1 desc", myconn);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "ear");
            dataGridView1.DataSource = mydataset.Tables["ear"];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where (getdate()-cast(F1 as datetime))<=7 order by F1 desc", myconn);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "ear");
            dataGridView1.DataSource = mydataset.Tables["ear"];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where (getdate()-cast(F1 as datetime))<=365 order by F1 desc", myconn);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "ear");
            dataGridView1.DataSource = mydataset.Tables["ear"];
        }



        public class ExportToExcel
        {
            public Excel.Application m_xlApp = null;

            public void OutputAsExcelFile(DataGridView dataGridView)
            {
                if (dataGridView.Rows.Count <= 0)
                {
                    MessageBox.Show("无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
                string filePath = "";
                SaveFileDialog s = new SaveFileDialog();
                s.Title = "保存Excel文件";
                s.Filter = "Excel文件(*.xls)|*.xls";
                s.FilterIndex = 1;
                if (s.ShowDialog() == DialogResult.OK)
                    filePath = s.FileName;
                else
                    return;

                //第一步：将dataGridView转化为dataTable,这样可以过滤掉dataGridView中的隐藏列  

                DataTable tmpDataTable = new DataTable("tmpDataTable");
                DataTable modelTable = new DataTable("ModelTable");
                for (int column = 0; column < dataGridView.Columns.Count; column++)
                {
                    if (dataGridView.Columns[column].Visible == true)
                    {
                        DataColumn tempColumn = new DataColumn(dataGridView.Columns[column].HeaderText, typeof(string));
                        tmpDataTable.Columns.Add(tempColumn);
                        DataColumn modelColumn = new DataColumn(dataGridView.Columns[column].Name, typeof(string));
                        modelTable.Columns.Add(modelColumn);
                    }
                }
                for (int row = 0; row < dataGridView.Rows.Count; row++)
                {
                    if (dataGridView.Rows[row].Visible == false)
                        continue;
                    DataRow tempRow = tmpDataTable.NewRow();
                    for (int i = 0; i < tmpDataTable.Columns.Count; i++)
                        tempRow[i] = dataGridView.Rows[row].Cells[modelTable.Columns[i].ColumnName].Value;
                    tmpDataTable.Rows.Add(tempRow);
                }
                if (tmpDataTable == null)
                {
                    return;
                }

                //第二步：导出dataTable到Excel  
                long rowNum = tmpDataTable.Rows.Count;//行数  
                int columnNum = tmpDataTable.Columns.Count;//列数  
                Excel.Application m_xlApp = new Excel.Application();
                m_xlApp.DisplayAlerts = false;//不显示更改提示  
                m_xlApp.Visible = false;

                Excel.Workbooks workbooks = m_xlApp.Workbooks;
                Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                try
                {
                    string[,] datas = new string[rowNum + 1, columnNum];
                    for (int i = 0; i < columnNum; i++) //写入字段  
                        datas[0, i] = tmpDataTable.Columns[i].Caption;
                    //Excel.Range range = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, columnNum]);  
                    Excel.Range range = m_xlApp.Range[worksheet.Cells[1, 1], worksheet.Cells[1, columnNum]];
                    range.Interior.ColorIndex = 15;//15代表灰色  
                    range.Font.Bold = true;
                    range.Font.Size = 10;

                    int r = 0;
                    for (r = 0; r < rowNum; r++)
                    {
                        for (int i = 0; i < columnNum; i++)
                        {
                            object obj = tmpDataTable.Rows[r][tmpDataTable.Columns[i].ToString()];
                            datas[r + 1, i] = obj == null ? "" : "'" + obj.ToString().Trim();//在obj.ToString()前加单引号是为了防止自动转化格式  
                        }
                        System.Windows.Forms.Application.DoEvents();
                        //添加进度条  
                    }
                    //Excel.Range fchR = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]);  
                    Excel.Range fchR = m_xlApp.Range[worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]];
                    fchR.Value2 = datas;

                    worksheet.Columns.EntireColumn.AutoFit();//列宽自适应。  
                    //worksheet.Name = "dd";  

                    //m_xlApp.WindowState = Excel.XlWindowState.xlMaximized;  
                    m_xlApp.Visible = false;

                    // = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]);  
                    range = m_xlApp.Range[worksheet.Cells[1, 1], worksheet.Cells[rowNum + 1, columnNum]];

                    //range.Interior.ColorIndex = 15;//15代表灰色  
                    range.Font.Size = 9;
                    range.RowHeight = 14.25;
                    range.Borders.LineStyle = 1;
                    range.HorizontalAlignment = 1;
                    workbook.Saved = true;
                    workbook.SaveCopyAs(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出异常：" + ex.Message, "导出异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    EndReport();
                }

                m_xlApp.Workbooks.Close();
                m_xlApp.Workbooks.Application.Quit();
                m_xlApp.Application.Quit();
                m_xlApp.Quit();
                MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            private void EndReport()
            {
                object missing = System.Reflection.Missing.Value;
                try
                {
                    //m_xlApp.Workbooks.Close();  
                    //m_xlApp.Workbooks.Application.Quit();  
                    //m_xlApp.Application.Quit();  
                    //m_xlApp.Quit();  
                }
                catch { }
                finally
                {
                    try
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp.Workbooks);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp.Application);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(m_xlApp);
                        m_xlApp = null;
                    }
                    catch { }
                    try
                    {
                        //清理垃圾进程  
                        this.killProcessThread();
                    }
                    catch { }
                    GC.Collect();
                }
            }

            private void killProcessThread()
            {
                ArrayList myProcess = new ArrayList();
                for (int i = 0; i < myProcess.Count; i++)
                {
                    try
                    {
                        System.Diagnostics.Process.GetProcessById(int.Parse((string)myProcess[i])).Kill();
                    }
                    catch { }
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExportToExcel d = new ExportToExcel();
            d.OutputAsExcelFile(dataGridView1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
        private void 地震活动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            if (f4.DialogResult == DialogResult.Cancel)
                this.Close();

        }

        private void 地震统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();
            if (f5.DialogResult == DialogResult.Cancel)
                this.Close();

        }

        private void 快捷查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
