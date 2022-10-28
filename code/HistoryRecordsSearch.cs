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
                    SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from Table1$ where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%' and F6 like '%" + con.ToString() + "%'", myconn);
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
                    SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from Table1$ where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%' and F6 like '%" + con.ToString() + "%'", myconn);
                    DataSet mydataset = new DataSet();
                    myadapter1.Fill(mydataset, "stu");
                    dataGridView1.DataSource = mydataset.Tables["stu"];
                }
                else
                {
                    SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from Table1$ where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%' and F6 like '%" + pro.ToString() + "%'", myconn);
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
                    SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from Table1$ where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%' and F6 like '%" + comboBox8.SelectedItem.ToString() + "%'", myconn);
                    DataSet mydataset = new DataSet();
                    myadapter1.Fill(mydataset, "stu");
                    dataGridView1.DataSource = mydataset.Tables["stu"];
                }
                else
                {
                    SqlDataAdapter myadapter1 = new SqlDataAdapter("select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from Table1$ where F2>" + j.ToString() + "and F2<" + k.ToString() + " and F5>" + h.ToString() + " and F5<" + i.ToString() + " and F4>" + f.ToString() + "and F4<" + g.ToString() + " and F3>" + c.ToString() + " and F3<" + d.ToString() + "and F1 between '" + a.ToString() + "-" + b.ToString() + "-" + r.ToString() + "% 'and '" + x.ToString() + "-" + y.ToString() + "-" + z.ToString() + "%' and F6 like '%" + cit.ToString() + "%'", myconn);
                    DataSet mydataset = new DataSet();
                    myadapter1.Fill(mydataset, "stu");
                    dataGridView1.DataSource = mydataset.Tables["stu"];
                }
            }
        }
private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
