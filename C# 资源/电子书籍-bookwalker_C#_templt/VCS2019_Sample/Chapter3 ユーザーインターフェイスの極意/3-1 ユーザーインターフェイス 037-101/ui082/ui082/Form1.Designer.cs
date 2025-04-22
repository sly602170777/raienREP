namespace ui082
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.左揃えToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中央揃えToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.右揃えToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(277, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.左揃えToolStripMenuItem,
            this.中央揃えToolStripMenuItem,
            this.右揃えToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 左揃えToolStripMenuItem
            // 
            this.左揃えToolStripMenuItem.Name = "左揃えToolStripMenuItem";
            this.左揃えToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.左揃えToolStripMenuItem.Text = "左揃え";
            this.左揃えToolStripMenuItem.Click += new System.EventHandler(this.左揃えToolStripMenuItem_Click);
            // 
            // 中央揃えToolStripMenuItem
            // 
            this.中央揃えToolStripMenuItem.Name = "中央揃えToolStripMenuItem";
            this.中央揃えToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.中央揃えToolStripMenuItem.Text = "中央揃え";
            this.中央揃えToolStripMenuItem.Click += new System.EventHandler(this.中央揃えToolStripMenuItem_Click);
            // 
            // 右揃えToolStripMenuItem
            // 
            this.右揃えToolStripMenuItem.Name = "右揃えToolStripMenuItem";
            this.右揃えToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.右揃えToolStripMenuItem.Text = "右揃え";
            this.右揃えToolStripMenuItem.Click += new System.EventHandler(this.右揃えToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 105);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 19);
            this.textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 142);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 左揃えToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中央揃えToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 右揃えToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}

