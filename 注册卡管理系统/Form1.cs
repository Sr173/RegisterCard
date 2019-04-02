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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e) {
            this.listView1.FullRowSelect = true;//是否可以选择行
            this.listView1.GridLines = true; //显示表格线

        }

        string pwd;

        string host = "http://119.23.8.232/register/123.php?";

        private void button1_Click(object sender, EventArgs e) {
            listView1.Items.Clear();
            pwd = textBox3.Text;
            HttpHelper h = new HttpHelper();
            
            HttpItem hi = new HttpItem {
                URL = host + "p=" + pwd +
                "&f=0"
            };
            HttpResult hr = h.GetHtml(hi);
            string html = hr.Html;
            html = html.Substring(0, html.Length - 1);

            string[] result = html.Split('|');

            foreach (string s in result) {
                ListViewItem lvi = new ListViewItem();
                string[] sp = s.Split('/');
                lvi.Text = sp[0];
                for (int i = 1; i < sp.Length; i++) 
                    lvi.SubItems.Add(sp[i]);
                listView1.Items.Add(lvi);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Form2 fm2 = new Form2(pwd);
            fm2.ShowDialog();
        }
    }
}
