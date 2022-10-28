namespace 前台
{
    partial class Form3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.首页ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.快捷查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.历史查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地震专题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地震活动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地震统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.首页ToolStripMenuItem,
            this.快捷查询ToolStripMenuItem,
            this.历史查询ToolStripMenuItem,
            this.地震专题ToolStripMenuItem,
            this.地震活动ToolStripMenuItem,
            this.地震统计ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 28);
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
            // 快捷查询ToolStripMenuItem
            // 
            this.快捷查询ToolStripMenuItem.Name = "快捷查询ToolStripMenuItem";
            this.快捷查询ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.快捷查询ToolStripMenuItem.Text = "快捷查询";
            // 
            // 历史查询ToolStripMenuItem
            // 
            this.历史查询ToolStripMenuItem.Name = "历史查询ToolStripMenuItem";
            this.历史查询ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.历史查询ToolStripMenuItem.Text = "历史查询";
            // 
            // 地震专题ToolStripMenuItem
            // 
            this.地震专题ToolStripMenuItem.Name = "地震专题ToolStripMenuItem";
            this.地震专题ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.地震专题ToolStripMenuItem.Text = "地震专题";
            // 
            // 地震活动ToolStripMenuItem
            // 
            this.地震活动ToolStripMenuItem.Name = "地震活动ToolStripMenuItem";
            this.地震活动ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.地震活动ToolStripMenuItem.Text = "地震活动";
            // 
            // 地震统计ToolStripMenuItem
            // 
            this.地震统计ToolStripMenuItem.Name = "地震统计ToolStripMenuItem";
            this.地震统计ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.地震统计ToolStripMenuItem.Text = "地震统计";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 518);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 首页ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 快捷查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 历史查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地震专题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地震活动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地震统计ToolStripMenuItem;
    }
}