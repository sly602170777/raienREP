using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg178
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        class Cup
        {
            int _value = 0;
            const int MAX = 100;

            public void add( int x )
            {
                _value += x;
                if ( _value > MAX )
                {
                    _value = MAX;
                }
            }

            public int Value { get => _value; } 
        }

        Cup _cup = new Cup();

        private void Button1_Click(object sender, EventArgs e)
        {
            _cup.add(20);
            label1.Text = $"Value is {_cup.Value}";
        }
    }
}
