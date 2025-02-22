namespace ui085
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.左揃えToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中央揃えToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.右揃えToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.左揃えToolStripMenuItem,
            this.中央揃えToolStripMenuItem,
            this.右揃えToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 70);
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
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.Location = new System.Drawing.Point(35, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 19);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox2.Location = new System.Drawing.Point(35, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(153, 19);
            this.textBox2.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 125);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 左揃えToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中央揃えToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 右揃えToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

