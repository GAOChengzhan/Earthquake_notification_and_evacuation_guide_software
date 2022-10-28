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
    public partial class register : Form
    {
        SqlConnection myconn = new SqlConnection(@"Database=earthquake;Data Source=.;Integrated Security=True;");

        public register()
        {
            InitializeComponent();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool a = false;
            string id = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();
            string str1 = "SELECT * FROM account WHERE id='" + id + "'";
            string str2 = "INSERT INTO account VALUES ('" + id + "','" + password + "');";

            //MessageBox.Show(str2);
            SqlCommand mycmd = new SqlCommand(str1, myconn);
            SqlCommand mycmd1 = new SqlCommand(str2, myconn);
            myconn.Open();
            {
                SqlDataReader myreader = mycmd.ExecuteReader();
                if (id == "" || password == "")
                {
                    MessageBox.Show("账号和密码不能为空！");
                }
                else if (myreader.HasRows == true)
                {
                    MessageBox.Show("账号已经存在！");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    myreader.Close();
                    mycmd1.ExecuteNonQuery();
                    MessageBox.Show("注册成功！");
                    a = true;
                }
            }
            myconn.Close();
            if (a)
                Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox2.PasswordChar = new char();
            else
                textBox2.PasswordChar = '*';
        }

        private void register_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
