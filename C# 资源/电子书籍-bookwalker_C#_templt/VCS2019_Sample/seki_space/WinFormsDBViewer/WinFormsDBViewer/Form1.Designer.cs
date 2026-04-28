namespace WinFormsDBViewer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            button1 = new Button ();
            userDataDataGridView = new DataGridView ();
            textBox1 = new TextBox ();
            listBox1 = new ListBox ();
            listView1 = new ListView ();
            ((System.ComponentModel.ISupportInitialize)userDataDataGridView).BeginInit ();
            SuspendLayout ();
            // 
            // button1
            // 
            button1.Location = new Point (46, 29);
            button1.Name = "button1";
            button1.Size = new Size (75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // userDataDataGridView
            // 
            userDataDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            userDataDataGridView.Location = new Point (46, 103);
            userDataDataGridView.Name = "userDataDataGridView";
            userDataDataGridView.Size = new Size (240, 150);
            userDataDataGridView.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point (46, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size (158, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "10";
            textBox1.Validating += textBoxAge_Validating;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point (47, 283);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size (239, 79);
            listBox1.TabIndex = 3;
            // 
            // listView1
            // 
            listView1.Location = new Point (47, 390);
            listView1.Name = "listView1";
            listView1.Size = new Size (239, 62);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF (7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size (1019, 606);
            Controls.Add (listView1);
            Controls.Add (listBox1);
            Controls.Add (textBox1);
            Controls.Add (userDataDataGridView);
            Controls.Add (button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)userDataDataGridView).EndInit ();
            ResumeLayout (false);
            PerformLayout ();
        }

        #endregion

        private Button button1;
        private DataGridView userDataDataGridView;
        private TextBox textBox1;
        private ListBox listBox1;
        private ListView listView1;
    }
}
