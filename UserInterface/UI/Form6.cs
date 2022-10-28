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
using System.IO;

namespace 前台
{
    public partial class Form6 : Form
    {
        static string str = @"Database=earthquake;Data Source=.;Integrated Security=True;";
        static SqlConnection myconn = new SqlConnection(str);
        static SqlDataAdapter myadapter = new SqlDataAdapter("select * from information",myconn);
        DataSet ds = new DataSet();
        string str1 = Application.StartupPath+"\\pic\\";
        static int i ;
        static int n=0;

        void load()
        {
            myadapter.Fill(ds, "_information");
            label1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString() + ds.Tables[0].Rows[i].ItemArray[4].ToString() + "地震";
            label8.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString().Trim();
            label9.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString().Trim();
            label10.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString().Trim();
            label11.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString().Trim();
            label12.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString().Trim();
            label13.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString().Trim();
            button1.Text = ds.Tables[0].Rows[i].ItemArray[9].ToString().Trim();
            button2.Text = ds.Tables[0].Rows[i].ItemArray[10].ToString().Trim();
            button3.Text = ds.Tables[0].Rows[i].ItemArray[11].ToString().Trim();

            Image image = Image.FromFile(str1 + ds.Tables[0].Rows[i].ItemArray[6].ToString());

            pictureBox1.Image = image;
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            i = 0;
            myadapter.Fill(ds, "_information");
            n = ds.Tables[0].Rows.Count;
            //MemoryStream buf = new MemoryStream(System.Text.Encoding.Default.GetBytes(str1));
            label1.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString()+ds.Tables[0].Rows[i].ItemArray[4].ToString()+"地震";
            label8.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString().Trim();
            label9.Text = ds.Tables[0].Rows[i].ItemArray[2].ToString().Trim();
            label10.Text = ds.Tables[0].Rows[i].ItemArray[3].ToString().Trim();
            label11.Text = ds.Tables[0].Rows[i].ItemArray[4].ToString().Trim();
            label12.Text = ds.Tables[0].Rows[i].ItemArray[5].ToString().Trim();
            label13.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString().Trim();


            Image image = Image.FromFile(str1+ ds.Tables[0].Rows[i].ItemArray[6].ToString());

            pictureBox1.Image = image;

             
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myadapter.Fill(ds, "_information");

            Image image = Image.FromFile(str1 + ds.Tables[0].Rows[i].ItemArray[6].ToString());

            pictureBox1.Image = image;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myadapter.Fill(ds, "_information");

            Image image = Image.FromFile(str1 + ds.Tables[0].Rows[i].ItemArray[7].ToString());

            pictureBox1.Image = image;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myadapter.Fill(ds, "_information");

            Image image = Image.FromFile(str1 + ds.Tables[0].Rows[i].ItemArray[8].ToString());

            pictureBox1.Image = image;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                MessageBox.Show("已经没有啦！即将切换到最后一个。");
                i = n-1;
                load();
            }
            else
            {
                i = i - 1;
                load();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (i >= n - 1)
            {
                MessageBox.Show( "已经没有啦！即将切换到第一个。");
                i = 0;
                load();
            }
            else
            {
                i = i + 1;
                load();
            }
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
            f2.Show();
            if (f2.DialogResult == DialogResult.Cancel)
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

        private void 地震专题ToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
