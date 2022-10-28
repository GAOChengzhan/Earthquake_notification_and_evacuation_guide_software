using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Data.OleDb;
using System.IO;
using Spire.Xls;
using System.Data.SqlClient;
using System.Diagnostics;//新添加的


namespace 前台
{

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    //ObjectForScripting 的类必须对 COM 可见


    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }
        static double locajin = 0;
        static double locawei = 0;
        int state = 0;

        private void Form0_Load(object sender, EventArgs e)
        {
            string str_url = Application.StartupPath + @"\524.html";
            Uri url = new Uri(str_url);
            webBrowser1.Url = url;
            webBrowser1.ObjectForScripting = this;
            //加载逆解析地址的html
            webBrowser1.Navigate(Application.StartupPath + @"\524.html");
            //屏蔽webBrowser浏览器右键菜单
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            //修改webbrowser的属性使c#可以调用js方法： 
            webBrowser1.ObjectForScripting = this;
            
        }


        private void addpoint(double jingdu, double weidu, string xinxi)
        {
            object[] objects1 = new object[3];
            objects1[0] = jingdu;
            objects1[1] = weidu;
            objects1[2] = xinxi;
            //传值给html中的mapInit函数
            webBrowser1.Document.InvokeScript("addmarkerinfo", objects1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] strArr = new string[2];//参数列表
            string sArguments = Application.StartupPath + @"\5211.py";//这里是python的文件名字
            strArr[0] = "2";
            strArr[1] = "3";
            RunPythonScript(sArguments, "-u", strArr);
            Workbook workbook1 = new Workbook();
            workbook1.LoadFromFile(Application.StartupPath + "\\earthquake.xls");
            Worksheet sheet1 = workbook1.Worksheets[0];
            //显示出来
            DataTable datatable = new DataTable();
            //载入Excel文档
            Workbook workbook2 = new Workbook();
            workbook2.LoadFromFile(Application.StartupPath + "\\earthquake.xls");
            //获取第一个工作表
            Worksheet sheet2 = workbook2.Worksheets[0];
            //将第一个工作表的数据导出到datatable中
            datatable = sheet2.ExportDataTable();
            double[] arraywei = new double[datatable.Rows.Count];
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                DataRow datar = datatable.Rows[i];
                arraywei[i] = Convert.ToDouble(datar["纬度"]);
                //listBox1.Items.Add(arraywei[i]);

            }
            double[] arrayjing = new double[datatable.Rows.Count];
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                DataRow datar = datatable.Rows[i];
                arrayjing[i] = Convert.ToDouble(datar["经度"]);
                //listBox2.Items.Add(arrayjing[i]);

            }
            string[] arrayxin = new string[datatable.Rows.Count];
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                DataRow datar = datatable.Rows[i];
                arrayxin[i] = "震级大小：" + Convert.ToString(datar["震级大小"]) + ";发生地点：" + Convert.ToString(datar["地点"]) +
                   ";发生时间:" + Convert.ToString(datar["时间"]) + ";经纬度:" + Convert.ToString(datar["经度"]) + "，" + Convert.ToString(datar["纬度"]);
            }
            for (int j = 0; j < datatable.Rows.Count; j++)
            {
                addpoint(arrayjing[j], arraywei[j], arrayxin[j]);
            }
        }
        static string earthquake = "Data Source=.;Initial Catalog=earthquake;Integrated Security=True";
        private void button2_Click(object sender, EventArgs e)//更新数据
        {
            string[] strArr = new string[2];//参数列表
            string sArguments = Application.StartupPath + @"\5211.py";//这里是python的文件名字
            strArr[0] = "2";
            strArr[1] = "3";
            RunPythonScript(sArguments, "-u", strArr);
            DataTable datatable = new DataTable();
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(Application.StartupPath + "\\earthquake.xls");
            Worksheet sheet = workbook.Worksheets[0];
            datatable = sheet.ExportDataTable();
            SqlConnection conn = new SqlConnection(earthquake);
            for (int i = 0; i < datatable.Rows.Count; i++)
            {
                DataRow datar = datatable.Rows[i];
                object[] row = { Convert.ToString(datar["时间"]), Convert.ToDouble(datar["震级大小"]), Convert.ToDouble(datar["纬度"]), Convert.ToDouble(datar["经度"]), Convert.ToDouble(datar["震源深度"]), Convert.ToString(datar["地点"]) };
                string strupdate = "insert into earthquake_data values ('" + row[0].ToString() + "'," + row[1].ToString() + "," + row[2].ToString() + "," + row[3].ToString() + "," + row[4].ToString() + ",'" + row[5].ToString() + "')";
                SqlCommand mycmd = new SqlCommand(strupdate, conn);
                conn.Open();
                {    
                    try
                    {
                         mycmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("更新失败!");
                    }
                }
                conn.Close();
            }
            MessageBox.Show("更新成功!");  

        }
        //调用python核心代码

        public static void RunPythonScript(string sArgName, string args = "", params string[] teps)
        {
            Process p = new Process();
            string path = Application.StartupPath + @"\5211.py";// 获得python文件的绝对路径（将文件放在c#的debug文件夹中可以这样操作）
            p.StartInfo.FileName = @"D:\anaconda\python.exe";//没有配环境变量的话，可以像我这样写python.exe的绝对路径。如果配了，直接写"python.exe"即可
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;//传递参数
            }
            sArguments += " " + args;
            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            Console.ReadLine();
            p.WaitForExit();
        }

        //输出打印的信息
        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                Console.WriteLine(e.Data + Environment.NewLine);
            }

        }



        private void button4_Click(object sender, EventArgs e)
        {
           
            webBrowser1.Document.InvokeScript("getlocation");
        }

        public void LngInfo(string message)
        {
            locajin = Convert.ToDouble(message);
            //listBox1.Items.Add(locajin); 
            state = 1;
        }
        public void LatInfo(string message)
        {
            locawei = Convert.ToDouble(message);
            //listBox1.Items.Add(locawei);
            state = 1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (state == 0)
            {
                MessageBox.Show("还未定位");
                return;
            }
            else
            {
                DataTable datatable = new DataTable();
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(Application.StartupPath + "\\earthquake.xls");
                Worksheet sheet = workbook.Worksheets[0];
                datatable = sheet.ExportDataTable();
                double distance = 0;
                int Rows = datatable.Rows.Count;
                double[] earthjing = new double[Rows];
                double[] earthwei = new double[Rows];
                double[] earthmag = new double[Rows];
                string[] happentime = new string[Rows];
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    DataRow datar = datatable.Rows[i];
                    earthjing[i] = Convert.ToDouble(datar["经度"]);
                    earthwei[i] = Convert.ToDouble(datar["纬度"]);
                    earthmag[i] = Convert.ToDouble(datar["震级大小"]);
                    happentime[i] = Convert.ToString(datar["时间"]);
                }
                int clc = 0;//判断是否出消息
                //获取当前时间
                string time = DateTime.Now.ToString("yyyy-MM-dd");
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    distance = 0;
                    bool delttime = happentime[i].StartsWith(time);
                    if (delttime)
                    {
                        if (earthmag[i] > 6)//如果地震
                        {
                            distance = getdistance(locajin, locawei, earthjing[i], earthwei[i]);
                            if (distance < 150)
                            {
                                MessageBox.Show("有强烈震感!距离震源" + distance.ToString() + "公里！将为您指出最近的避难路线。");
                                showway(); clc = 1;
                            }
                        }
                        else if (earthmag[i] > 7)
                        {
                            distance = getdistance(locajin, locawei, earthjing[i], earthwei[i]);
                            if (distance < 300)
                            {
                                MessageBox.Show("有强烈震感!距离震源" + distance.ToString() + "公里！将为您指出最近的避难路线。");
                                showway(); clc = 1;
                            }
                        }
                        else if (earthmag[i] > 8)
                        {
                            distance = getdistance(locajin, locawei, earthjing[i], earthwei[i]);
                            if (distance < 500)
                            {
                                MessageBox.Show("有强烈震感!距离震源" + distance.ToString() + "公里！将为您指出最近的避难路线。");
                                showway(); clc = 1;
                            }
                        }
                        else if (earthmag[i] > 9)
                        {
                            distance = getdistance(locajin, locawei, earthjing[i], earthwei[i]);
                            if (distance < 700)
                            {
                                MessageBox.Show("有强烈震感!距离震源" + distance.ToString() + "公里！将为您指出最近的避难路线。");
                                showway(); clc = 1;
                            }
                        }
                        else
                        {
                        }

                    }
                }
                if (clc == 0)
                {
                    MessageBox.Show("无强烈震感!距离震源较远！不必担心");
                }
            }
        }

        static double EARTH_RADIUS = 6378.137;
        private double getdistance(double lat1, double lng1, double lat2, double lng2)//建立大地坐标系，经纬度算距离
        {	double radLat1 = lat1 *Math.PI / 180.0;   //角度1˚ = π / 180	
            double radLat2 = lat2 * Math.PI/ 180.0;   //角度1˚ = π / 180	
            double a = radLat1 - radLat2;//纬度之差	
            double b = lng1 * Math.PI / 180.0 - lng2* Math.PI/ 180.0;  //经度之差	
            double dst = 2 * Math.Asin((Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))));	
            dst = dst * EARTH_RADIUS;	
            dst = Math.Round(dst * 10000) / 10000;	
            return dst;
        }
        private double[] recentemer(double x1,double y1)
        {
            double[] point = new double[2];
            string str = @"Data Source=.;Initial Catalog=上海;Integrated Security=True";
            SqlConnection myconn = new SqlConnection(str);
            DataSet mydataset = new DataSet();
            string strsearch = @"select lab,lng,场所名称 from emergency_place";
            SqlDataAdapter myadapter = new SqlDataAdapter(strsearch, myconn);
            myadapter.Fill(mydataset,"经纬度");
            double distancemin = 1000; double distance = 0; int k = 0;
            for (int i = 0; i < mydataset.Tables["经纬度"].Rows.Count; i++)
            {
                distance = getdistance(x1, y1, Convert.ToDouble(mydataset.Tables["经纬度"].Rows[i].ItemArray[0]), Convert.ToDouble(mydataset.Tables["经纬度"].Rows[i].ItemArray[1]));
                if(distance<distancemin)
                {
                    distancemin=distance;
                    point[0]=Convert.ToDouble(mydataset.Tables["经纬度"].Rows[i].ItemArray[0]);
                    point[1]=Convert.ToDouble(mydataset.Tables["经纬度"].Rows[i].ItemArray[1]);
                    k = i;
                }
            }
            MessageBox.Show("最近的是" +Convert.ToString(mydataset.Tables["经纬度"].Rows[k].ItemArray[2])+ "应急避难所");
            return point;

        }
        private void showway()
        {
            string lng = webBrowser1.Document.GetElementById("lng").InnerText;
            string lat = webBrowser1.Document.GetElementById("lat").InnerText;
            locajin = Convert.ToDouble(lng);
            locawei = Convert.ToDouble(lat);
            object[] objects1 = new object[4];
            objects1[0] = locajin;
            objects1[1] = locawei;
            double[] point = recentemer(Convert.ToDouble(objects1[1]), Convert.ToDouble(objects1[0]));
            objects1[2] = point[1];
            objects1[3] = point[0];
            webBrowser1.Document.InvokeScript("findemergency", objects1);
 
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
        private void 快速查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            if (f2.DialogResult == DialogResult.Cancel)
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
        private void 地震信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
            if (f6.DialogResult == DialogResult.Cancel)
                this.Close();
        }

        private void Form0_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void 首页ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }





}

