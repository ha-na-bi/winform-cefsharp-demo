using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Store
    {
        public double Sell()
        {
            MessageBox.Show("调用了Sell方法");
            return 42d;
        }

        public string Buy(double money)
        {
            if (money >= 10) return "鼠标";
            else if (money >= 50) return "键盘";
            else if (money >= 500) return "显示器";
            return "啥也买不起";
        }
    }
}
