using CefSharp;
using CefSharp.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1.Samples
{
    public partial class ObsoleteLocalPageForm : Form
    {
        // 本示例演示老版本的对象绑定方案，但目前已经过时，不推荐使用

        private ChromiumWebBrowser _chromiumWebBrowser;

        public ObsoleteLocalPageForm()
        {
            InitializeComponent();
            Load += ObsoleteLocalPageForm_Load;
        }

        private void ObsoleteLocalPageForm_Load(object sender, EventArgs e)
        {
            var localPage = Path.Combine(Environment.CurrentDirectory, "Pages", "obsolete.html");
            _chromiumWebBrowser = new ChromiumWebBrowser(localPage); //加载页面
            _chromiumWebBrowser.Dock = DockStyle.Fill;

            // 页面加载完毕后打开开发者工具
            _chromiumWebBrowser.FrameLoadEnd += (s, eve) =>
            {
                var browser = _chromiumWebBrowser.GetBrowser();
                browser.ShowDevTools();
            };

            JsObjectBinding(); // 新版本的注入方式

            Controls.Add(_chromiumWebBrowser);
        }

        /// <summary>
        /// 现版本已过时方法，不建议使用
        /// </summary>
        private void JsObjectBinding()
        {
            // 新版本默认为 false，所以需要手动打开
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            // 把 TestClass 注入到页面，名称为 obs
            _chromiumWebBrowser.RegisterJsObject("obs", new TestClass());
        }
    }
}
