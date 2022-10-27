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
            DialogResult = DialogResult.Cancel;
            this.Hide();
            Form6 f6 = new Form6();
            f6.ShowDialog();
            if (f6.DialogResult == DialogResult.Cancel)
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

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
static string earthquake = "Data Source=.;Initial Catalog=earthquake;Integrated Security=True";
private void Form4_Load(object sender, EventArgs e)
        {
            string str_url = Application.StartupPath + @"\form4.html";
            Uri url = new Uri(str_url);
            webBrowser1.Url = url;
            webBrowser1.ObjectForScripting = this;
            //加载逆解析地址的html
            webBrowser1.Navigate(Application.StartupPath + @"\form4.html");
            //屏蔽webBrowser浏览器右键菜单
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            //修改webbrowser的属性使c#可以调用js方法： 
            webBrowser1.ObjectForScripting = this;
            //
            string str_ur2 = Application.StartupPath + @"\form4.html";
            Uri ur2 = new Uri(str_ur2);
            webBrowser2.Url = ur2;
            webBrowser2.ObjectForScripting = this;
            //加载逆解析地址的html
            webBrowser2.Navigate(Application.StartupPath + @"\form4.html");
            //屏蔽webBrowser浏览器右键菜单
            webBrowser2.IsWebBrowserContextMenuEnabled = false;
            //修改webbrowser的属性使c#可以调用js方法： 
            webBrowser2.ObjectForScripting = this;
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
      
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = dateTimePicker1.Value.Year.ToString() + "年" + dateTimePicker1.Value.Month.ToString() + "月" + dateTimePicker1.Value.Day.ToString() + "日";
            webBrowser1.Document.InvokeScript("ClearAllMarkers");
            SqlConnection mycon = new SqlConnection(earthquake);
            string search = "select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from Table1$ where F1 like '%" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "%'";
            SqlDataAdapter myadapter1 = new SqlDataAdapter(search, mycon);
            DataSet mydataset = new DataSet();
            myadapter1.Fill(mydataset, "search");

            double[] arraywei = new double[mydataset.Tables["search"].Rows.Count];
            for (int i = 0; i < mydataset.Tables["search"].Rows.Count; i++)
            {
                DataRow datar = mydataset.Tables["search"].Rows[i];
                arraywei[i] = Convert.ToDouble(datar["纬度"]);
                

            }
            double[] arrayjing = new double[mydataset.Tables["search"].Rows.Count];
            for (int i = 0; i < mydataset.Tables["search"].Rows.Count; i++)
            {
                DataRow datar = mydataset.Tables["search"].Rows[i];
                arrayjing[i] = Convert.ToDouble(datar["经度"]);
                //listBox2.Items.Add(arrayjing[i]);

            }
            string[] arrayxin = new string[mydataset.Tables["search"].Rows.Count];
            for (int i = 0; i < mydataset.Tables["search"].Rows.Count; i++)
            {
                DataRow datar = mydataset.Tables["search"].Rows[i];
                arrayxin[i] = "震级大小：" + Convert.ToString(datar["震级"]) + ";发生地点：" + Convert.ToString(datar["参考位置"]) +
                   ";发生时间:" + Convert.ToString(datar["时间"]) + ";经纬度:" + Convert.ToString(datar["经度"]) + "，" + Convert.ToString(datar["纬度"]);
            }
            
            for (int j = 0; j < mydataset.Tables["search"].Rows.Count; j++)
            {
                addpoint(arrayjing[j], arraywei[j],arrayxin[j]);
            }
        }
       
private void addpoint2(double jingdu, double weidu, string xinxi)
        {
            object[] objects1 = new object[3];
            objects1[0] = jingdu;
            objects1[1] = weidu;
            objects1[2] = xinxi;
            //传值给html中的mapInit函数
            webBrowser2.Document.InvokeScript("addmarkerinfo", objects1);

        }
private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = dateTimePicker2.Value.Year.ToString() + "  年  " + dateTimePicker2.Value.Month.ToString() + "  月  ";
            webBrowser2.Document.InvokeScript("ClearAllMarkers");
            SqlConnection mycon = new SqlConnection(earthquake);
            string search = "select F1 as 时间,F2 as 震级,F3 as 纬度,F4 as 经度,F5 as 震源深度,F6 as 参考位置 from Table1$ where F1 like '%" + dateTimePicker2.Value.ToString("yyyy-MM") + "%'";
            SqlDataAdapter myadapter2 = new SqlDataAdapter(search, mycon);
            DataSet mydataset2 = new DataSet();
            myadapter2.Fill(mydataset2, "search");

            double[] arraywei2 = new double[mydataset2.Tables["search"].Rows.Count];
            for (int i = 0; i < mydataset2.Tables["search"].Rows.Count; i++)
            {
                DataRow datar = mydataset2.Tables["search"].Rows[i]; 
                arraywei2[i] = Convert.ToDouble(datar["纬度"]);


            }
            double[] arrayjing2 = new double[mydataset2.Tables["search"].Rows.Count];
            for (int i = 0; i < mydataset2.Tables["search"].Rows.Count; i++)
            {
                DataRow datar = mydataset2.Tables["search"].Rows[i];
                arrayjing2[i] = Convert.ToDouble(datar["经度"]);
                //listBox2.Items.Add(arrayjing[i]);

            }
            string[] arrayxin2 = new string[mydataset2.Tables["search"].Rows.Count];
            for (int i = 0; i < mydataset2.Tables["search"].Rows.Count; i++)
            {
                DataRow datar = mydataset2.Tables["search"].Rows[i];
                arrayxin2[i] = "震级大小：" + Convert.ToString(datar["震级"]) + ";发生地点：" + Convert.ToString(datar["参考位置"]) +
                   ";发生时间:" + Convert.ToString(datar["时间"]) + ";经纬度:" + Convert.ToString(datar["经度"]) + "，" + Convert.ToString(datar["纬度"]);
            }
            
            for (int j = 0; j < mydataset2.Tables["search"].Rows.Count; j++)
            {
                addpoint2(arrayjing2[j], arraywei2[j], arrayxin2[j]);
            }
            
            
        }
private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
