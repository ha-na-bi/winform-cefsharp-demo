using CefSharp;
using CefSharp.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1.Samples
{
    public partial class LocalPageForm : Form
    {
        // 本示例提供以下演示
        // 1. 加载本地页面
        // 2. 如何打开开发者工具
        // 3. 如何在页面中注册 C# 操作类
        // 4. 如何从 JS 调用 C# 操作类

        private ChromiumWebBrowser _chromiumWebBrowser;

        public LocalPageForm()
        {
            InitializeComponent();
            Load += LocalPageForm_Load;
        }

        private void LocalPageForm_Load(object sender, EventArgs e)
        {
            var localPage = Path.Combine(Environment.CurrentDirectory, "Pages", "new.html");
            _chromiumWebBrowser = new ChromiumWebBrowser(localPage); //加载页面
            _chromiumWebBrowser.Dock = DockStyle.Fill;

            // 页面加载完毕后打开开发者工具
            _chromiumWebBrowser.FrameLoadEnd += (s, eve) =>
            {
                var browser = _chromiumWebBrowser.GetBrowser();
                browser.ShowDevTools();
            };

            JsObjectResolver(); // 新版本的注入方式

            Controls.Add(_chromiumWebBrowser);
        }

        /// <summary>
        /// 目前版本推荐的注入方式，老版本请参考 ObsoleteLocalPageForm.cs
        /// </summary>
        private void JsObjectResolver()
        {
            // 由网页端 CefSharp.BindObjectAsync 触发
            _chromiumWebBrowser.JavascriptObjectRepository.ResolveObject += (s, eve) =>
            {
                var repo = eve.ObjectRepository;
                if (eve.ObjectName == "obj")
                {
                    // 因为没有绑定这个，所以不会被触发
                    repo.Register("obj", new TestClass(), isAsync: true, options: BindingOptions.DefaultBinder);
                }
                else if (eve.ObjectName == "storeObj")
                {
                    // 在 new.html 使用 storeObj 触发
                    repo.Register("storeObj", new Store(), isAsync: true);
                }

                // 通过 if-else 简单的在不同的页面注入需要的类
                // 以上均为用法举例
            };
        }
    }
}
