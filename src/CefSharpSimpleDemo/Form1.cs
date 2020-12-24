using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Samples;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new LocalPageForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ObsoleteLocalPageForm().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new RemotePageForm().ShowDialog();
        }
    }
}
