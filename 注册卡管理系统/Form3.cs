using SufeiUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 注册卡管理系统 {
    public partial class Form3 : Form {
        public Form3() {
            InitializeComponent();
        }
        string pwd;

        Byte[] key = new Byte[] { 0xCC, 0x33, 0x33, 0x33, 0x35, 0x36, 0x37, 0x38, 0x39, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x31, 0x32, 0x33, 0x34, 0x35 };

        private void Form3_Load(object sender, EventArgs e) {

            HttpHelper http = new HttpHelper();
            HttpResult result = http.GetHtml(new HttpItem { URL = "http://119.23.8.232/pwd/pwd" });
            pwd = StdAes.AesDecrypt(result.Html, key);

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            if (pwd == textBox1.Text) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
