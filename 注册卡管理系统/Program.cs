using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 注册卡管理系统 {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form3 fm3 = new Form3();
            fm3.ShowDialog();
            if (fm3.DialogResult == DialogResult.OK)
                Application.Run(new Form1());
            else
                Application.Exit();
        }
    }
}
