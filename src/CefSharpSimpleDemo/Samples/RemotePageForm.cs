using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Samples
{
    public partial class RemotePageForm : Form
    {
        // 本示例解决2个问题：
        // 1. 加载远程页面
        // 2. 加载时注入自定义内容（如下面演示中的 lodash.js ）

        private ChromiumWebBrowser _chromiumWebBrowser;

        public RemotePageForm()
        {
            InitializeComponent();
            Load += RemotePageForm_Load;
        }

        private void RemotePageForm_Load(object sender, EventArgs e)
        {
            _chromiumWebBrowser = new ChromiumWebBrowser("https://www.baidu.com");
            _chromiumWebBrowser.Dock = DockStyle.Fill;
            _chromiumWebBrowser.FrameLoadEnd += (s, eve) =>
            {
                var browser = _chromiumWebBrowser.GetBrowser();
                browser.ShowDevTools();

                var scritps = new string[] {
                    "var scr = document.createElement('script');",
                    "scr.type = 'text/javascript';",
                    "scr.src = 'https://cdn.bootcdn.net/ajax/libs/lodash.js/4.17.15/lodash.js';",
                    "document.head.appendChild(scr);"
                };

                // 让页面执行指定的脚本来创建额外的元素
                _chromiumWebBrowser.EvaluateScriptAsync(string.Join(";", scritps));
                MessageBox.Show("可在控制台中使用 _.VERSION 调用测试", "Loadsh.js 注入完成");
            };
            Controls.Add(_chromiumWebBrowser);
        }
    }
}
