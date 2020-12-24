using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class TestClass
    {
        public string Say(string message)
        {
            return "server say: " + message;
        }
        public void ShowBox()
        {
            MessageBox.Show("来自客户端的调用");
        }
    }
}
