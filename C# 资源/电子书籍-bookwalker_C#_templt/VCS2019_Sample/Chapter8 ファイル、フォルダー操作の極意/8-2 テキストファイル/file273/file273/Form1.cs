using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace file273
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public struct BLOCK
        {
            public Int32 X ;
            public Int32 Y ;
            public Int32 Z ;
            public Color color;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            if (path == string.Empty)
            {
                return;
            }

            BLOCK br;
            br.X = 100;
            br.Y = 200;
            br.Z = 0;
            br.color = Color.Red;
            var fs = new System.IO.BinaryWriter(
                System.IO.File.Create(path));
            // 構造体のデータを byte[] に変換する
            var data = new byte[Marshal.SizeOf(typeof(BLOCK))];
            var h = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                Marshal.StructureToPtr(br, h.AddrOfPinnedObject(), false);
            }
            finally
            {
                h.Free();
            }
            for (int i = 0; i < 1024 * 100; i++)
            {
                fs.Write(data);
            }
            fs.Close();
            MessageBox.Show("構造体のファイルを作成しました");
        }
    }
}
