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

namespace 前台
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string mystr = "Data Source=.;Initial Catalog=earthquake;Integrated Security=True";
        //注意转义字符的设置
        SqlConnection myconn = new SqlConnection(mystr);



        private void button1_Click(object sender, EventArgs e)
        {
            string a = "2012";
            string b = "01";
            string r = "01";
            string x = "2019";
            string y = "12";
            string z = "31";
            double c = -90;
            double d = 90;
            double f = -180;
            double g = 180;
            double h = 0;
            double i = 100;
            double j = 0;
            double k = 100;
            if (textBox1.Text != String.Empty)
            {
                c = Convert.ToDouble(textBox1.Text);
            }
            if (textBox2.Text != String.Empty)
            {
                d = Convert.ToDouble(textBox2.Text);
            }
            if (textBox3.Text != String.Empty)
            {
                f = Convert.ToDouble(textBox3.Text);
            }
            if (textBox4.Text != String.Empty)
            {
                g = Convert.ToDouble(textBox4.Text);
            }
            if (textBox5.Text != String.Empty)
            {
                h = Convert.ToDouble(textBox5.Text);
            }
            if (textBox6.Text != String.Empty)
            {
                i = Convert.ToDouble(textBox6.Text);
            }
            if (textBox7.Text != String.Empty)
            {
                j = Convert.ToDouble(textBox7.Text);
            }
            if (textBox8.Text != String.Empty)
            {
                k = Convert.ToDouble(textBox8.Text);
            }
            if (comboBox1.SelectedItem != null)
            {
                a = comboBox1.SelectedItem.ToString();
            }
            if (comboBox2.SelectedItem != null)
            {
                b = comboBox2.SelectedItem.ToString();
            }
            if (comboBox3.SelectedItem != null)
            {
                r = comboBox3.SelectedItem.ToString();
            }
            if (comboBox4.SelectedItem != null)
            {
                x = comboBox4.SelectedItem.ToString();
            }
            if (comboBox5.SelectedItem != null)
            {
                y = comboBox5.SelectedItem.ToString();
            }
            if (comboBox6.SelectedItem != null)
            {
                z = comboBox6.SelectedItem.ToString();
            }
            string con, pro, cit;
            if (comboBox7.SelectedItem != null && comboBox8.SelectedItem == null && comboBox9.SelectedItem == null)
            {
                con = comboBox7.SelectedItem.ToString();
                if (con != "中国")
                {
                    SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%' and F6 like '%" + con.ToString() + "%' order by F1 desc", myconn);
                    DataSet mydataset = new DataSet();
                    myadapter1.Fill(mydataset, "stu");
                    dataGridView1.DataSource = mydataset.Tables["stu"];
                }
            }
            if (comboBox7.SelectedItem != null && comboBox8.SelectedItem != null && comboBox9.SelectedItem == null)
            {
                pro = comboBox8.SelectedItem.ToString();
                con = comboBox7.SelectedItem.ToString();
                if (con != "中国")
                {
                    SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%' and F6 like '%" + con.ToString() + "%' order by F1 desc", myconn);
                    DataSet mydataset = new DataSet();
                    myadapter1.Fill(mydataset, "stu");
                    dataGridView1.DataSource = mydataset.Tables["stu"];
                }
                else
                {
                    SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%' and F6 like '%" + pro.ToString() + "%' order by F1 desc", myconn);
                    DataSet mydataset = new DataSet();
                    myadapter1.Fill(mydataset, "stu");
                    dataGridView1.DataSource = mydataset.Tables["stu"];
                }
            }
            if (comboBox9.SelectedItem != null)
            {
                cit = comboBox9.SelectedItem.ToString();
                if (cit == "北京市" || cit == "上海市" || cit == "天津市" || cit == "重庆市")
                {
                    SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%' and F6 like '%" + comboBox8.SelectedItem.ToString() + "%' order by F1 desc", myconn);
                    DataSet mydataset = new DataSet();
                    myadapter1.Fill(mydataset, "stu");
                    dataGridView1.DataSource = mydataset.Tables["stu"];
                }
                else
                {
                    SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%' and F6 like '%" + cit.ToString() + "%' order by F1 desc", myconn);
                    DataSet mydataset = new DataSet();
                    myadapter1.Fill(mydataset, "stu");
                    dataGridView1.DataSource = mydataset.Tables["stu"];
                }
            }
            if (comboBox7.SelectedItem == null)
            {
                SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from earthquake_data where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%'  order by F1 desc", myconn);
                DataSet mydataset = new DataSet();
                myadapter1.Fill(mydataset, "stu");
                dataGridView1.DataSource = mydataset.Tables["stu"];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: 这行代码将数据加载到表“earthquakeDataSet1._Table1_”中。您可以根据需要移动或删除它。
            //this.table1_TableAdapter.Fill(this.earthquakeDataSet1._Table1_);
            if (comboBox7.SelectedItem == null)
            {
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
            }
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=earthquake;Integrated Security=True"))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select proName from promary";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("proName"));

                            comboBox8.Items.Add(name);
                            comboBox9.Items.Clear();
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void 地震统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
            Form5 f5 = new Form5();
            f5.ShowDialog();
            if (f5.DialogResult == DialogResult.Cancel)
                this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox8.Text = "";
            comboBox9.Text = "";
            comboBox8.Items.Remove("无");
            int i;
            if (comboBox7.SelectedItem.ToString() == "中国")
            {
                i = 1;
                comboBox8.Enabled = true;
                comboBox9.Enabled = true;
            }
            else
                i = 0;
            if (i == 0)
            {
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox9.Text = "";
            comboBox9.Items.Clear();
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=earthquake;Integrated Security=True"))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select cityName from city,promary where city.proID=promary.proID and promary.proName=@pname";
                    cmd.Parameters.Add(new SqlParameter("pname", comboBox8.SelectedItem));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string name = reader.GetString(reader.GetOrdinal("cityName"));

                            comboBox9.Items.Add(name);
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            comboBox8.Text = "";
            comboBox9.Text = "";
            comboBox7.Text = "";
            comboBox6.Text = "";
            comboBox5.Text = "";
            comboBox4.Text = "";
            comboBox3.Text = "";
            comboBox2.Text = "";
            comboBox1.Text = "";
            if (dataGridView1.DataSource != null)//清除dataGraidView所有行
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                dt.Rows.Clear();
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }


    }
}
