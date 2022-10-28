namespace 前台
{
    partial class Form0
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form0));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.首页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.快速查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地震信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地震活动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地震统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.首页ToolStripMenuItem,
            this.快速查询ToolStripMenuItem,
            this.历史查询ToolStripMenuItem,
            this.地震信息ToolStripMenuItem,
            this.地震活动ToolStripMenuItem,
            this.地震统计ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1100, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 首页ToolStripMenuItem
            // 
            this.首页ToolStripMenuItem.Name = "首页ToolStripMenuItem";
            this.首页ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.首页ToolStripMenuItem.Text = "首页";
            this.首页ToolStripMenuItem.Click += new System.EventHandler(this.首页ToolStripMenuItem_Click);
            // 
            // 快速查询ToolStripMenuItem
            // 
            this.快速查询ToolStripMenuItem.Name = "快速查询ToolStripMenuItem";
            this.快速查询ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.快速查询ToolStripMenuItem.Text = "快速查询";
            this.快速查询ToolStripMenuItem.Click += new System.EventHandler(this.快速查询ToolStripMenuItem_Click);
            // 
            // 历史查询ToolStripMenuItem
            // 
            this.历史查询ToolStripMenuItem.Name = "历史查询ToolStripMenuItem";
            this.历史查询ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.历史查询ToolStripMenuItem.Text = "历史查询";
            this.历史查询ToolStripMenuItem.Click += new System.EventHandler(this.历史查询ToolStripMenuItem_Click);
            // 
            // 地震信息ToolStripMenuItem
            // 
            this.地震信息ToolStripMenuItem.Name = "地震信息ToolStripMenuItem";
            this.地震信息ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.地震信息ToolStripMenuItem.Text = "地震专题";
            this.地震信息ToolStripMenuItem.Click += new System.EventHandler(this.地震信息ToolStripMenuItem_Click);
            // 
            // 地震活动ToolStripMenuItem
            // 
            this.地震活动ToolStripMenuItem.Name = "地震活动ToolStripMenuItem";
            this.地震活动ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.地震活动ToolStripMenuItem.Text = "地震活动";
            this.地震活动ToolStripMenuItem.Click += new System.EventHandler(this.地震活动ToolStripMenuItem_Click);
            // 
            // 地震统计ToolStripMenuItem
            // 
            this.地震统计ToolStripMenuItem.Name = "地震统计ToolStripMenuItem";
            this.地震统计ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.地震统计ToolStripMenuItem.Text = "地震统计";
            this.地震统计ToolStripMenuItem.Click += new System.EventHandler(this.地震统计ToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(890, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 48);
            this.button1.TabIndex = 3;
            this.button1.Text = "最近地震";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(890, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 48);
            this.button2.TabIndex = 4;
            this.button2.Text = "更新数据";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(890, 412);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 48);
            this.button3.TabIndex = 5;
            this.button3.Text = "逃生通道";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Location = new System.Drawing.Point(890, 319);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 48);
            this.button4.TabIndex = 6;
            this.button4.Text = "定位";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button5.ForeColor = System.Drawing.Color.Transparent;
            this.button5.Location = new System.Drawing.Point(890, 569);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 37);
            this.button5.TabIndex = 7;
            this.button5.Text = "退出";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(0, 29);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(21, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(806, 628);
            this.webBrowser1.TabIndex = 1;
            // 
            // Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(200, 170);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form0";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form0_FormClosed);
            this.Load += new System.EventHandler(this.Form0_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 首页ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 快速查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地震信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地震活动ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem 地震统计ToolStripMenuItem;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}