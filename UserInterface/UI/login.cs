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
    public partial class login : Form
    {
        SqlConnection myconn = new SqlConnection(@"Database=earthquake;Data Source=.;Integrated Security=True;");
        
        public login()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string str1 = "SELECT * FROM account WHERE id='" + id + "' and password='" + password + "'";
            //MessageBox.Show(str1);
            SqlCommand mycmd = new SqlCommand(str1,myconn);
            myconn.Open();
            {
                SqlDataReader myreader=mycmd.ExecuteReader();
                if (myreader.HasRows == false)
                {
                    MessageBox.Show("账号或密码错误！");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                }
                else
                { 
                    MessageBox.Show("登陆成功！");
                    this.Hide();
                    Form0 f0 = new Form0();
                    f0.ShowDialog();
                    if (f0.DialogResult == DialogResult.Cancel)
                        this.Close();

                }
            }
            myconn.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            register f2 = new register();
            f2.ShowDialog();
            if (f2.DialogResult == DialogResult.Cancel)
                this.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox2.PasswordChar = new char();
            else
                textBox2.PasswordChar = '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
