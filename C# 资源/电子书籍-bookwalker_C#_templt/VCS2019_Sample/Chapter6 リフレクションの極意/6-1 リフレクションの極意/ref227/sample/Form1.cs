using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


    }
    public class SampleClass
    {
        /// 別アセンブリで定義したプロパティ
        private string _Name = "マスダトモアキ";
        public string MyName
        {
            get => _Name;
            set => _Name = value;
        }
    }
}
