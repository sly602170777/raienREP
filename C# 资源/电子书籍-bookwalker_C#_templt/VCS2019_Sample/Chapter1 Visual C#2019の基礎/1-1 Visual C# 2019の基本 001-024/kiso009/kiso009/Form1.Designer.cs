namespace kiso009
{
    //是一个部分类（partial class），这意味着它的定义可以分布在多个文件中
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// components 是一个 IContainer 类型的变量，用于管理窗体中的组件（如控件、定时器等）。
        /// 这个变量通常在窗体的 Dispose 方法中被释放
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// Dispose 方法用于释放窗体使用的非托管资源。如果 disposing 参数为 true，则释放托管资源（如 components）。
        /// 然后调用基类的 Dispose 方法以确保所有资源都被正确释放。
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
        /// InitializeComponent 方法是Windows Forms设计器自动生成的代码，用于初始化窗体及其控件。
        /// 窗体的布局和控件初始化由 InitializeComponent 方法完成，而资源的释放则由 Dispose 方法处理。
        /// 这个方法通常不应该手动修改，因为设计器会根据你在设计视图中的操作自动更新它。
        /// Location 属性设置按钮在窗体中的位置（坐标为 (12, 50)）
        /// Size 属性设置按钮的大小（宽度为164，高度为28）。
        /// Click 事件绑定到 Button1_Click 方法，当用户点击按钮时，将触发 Button1_Click 事件处理程序。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "こんにちは！";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.ForeColor = System.Drawing.Color.DeepPink;
            this.button1.Location = new System.Drawing.Point(12, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.ForeColor = System.Drawing.Color.DeepPink;
            this.button2.Location = new System.Drawing.Point(13, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(285, 169);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        //这些是窗体中使用的控件的声明。label1 是一个 Label 控件，button1 是一个 Button 控件。
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

