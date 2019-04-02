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
    public partial class Form2 : Form {
        public Form2(string pwd) {
            this.pwd = pwd;
            InitializeComponent();
        }

        string pwd;
        string host = "http://119.23.8.232/register/123.php?";
        string host1 = "http://119.23.8.232/Get/delete.php?";


        void writeFaileLog(string log) {
            textBox3.AppendText(log + "\r\n");
        }

        private void Form2_Load(object sender, EventArgs e) {

        }


        private void button1_Click(object sender, EventArgs e) {
            HttpHelper h = new HttpHelper();

            if(textBox2.Text == "") {
                MessageBox.Show("你还没有输入工作室名称");
                return;
            }

            string dealText = textBox1.Text;
            string[] sStr = dealText.Split(new char[2] { '\r', '\n' });

            Int32 faileNum = 0;

            for (int i = 0; i < sStr.Length;i += 2) {
                if (sStr[i].Length != 39) {
                    writeFaileLog("导入失败：第" + (i - 1) / 2 + "行，机器码:" + sStr[i] + "格式错误");
                    faileNum++;
                    continue;
                }

                HttpItem hi = new HttpItem {
                    URL = host + "p=" + pwd +
                    "&f=1" +
                    "&m=" + sStr[i] +
                    "&t=" + dateTimePicker1.Text +
                    "&n=" + textBox2.Text
                };
                HttpResult hr = h.GetHtml(hi);
                string html = hr.Html;
                if (html != "success") {
                    if (html == "")
                        html = "未知";
                    writeFaileLog("执行失败：第" + (i - 1) / 2 + "行，机器码:" + "错误原因:" + html);
                    faileNum++;
                }
            }

            MessageBox.Show("导入成功:" + (sStr.Length - faileNum) / 2 + "张，导入失败:" + faileNum + "张");
        }

        private void button6_Click(object sender, EventArgs e) {
            HttpHelper h = new HttpHelper();

            string dealText = textBox1.Text;
            string[] sStr = dealText.Split(new char[2] { '\r', '\n' });

            Int32 faileNum = 0;

            for (int i = 0; i < sStr.Length; i += 2) {
                if (sStr[i].Length != 39) {
                    writeFaileLog("导入失败：第" + (i - 1) / 2 + "行，机器码:" + sStr[i] + "格式错误");
                    faileNum++;
                    continue;
                }

                HttpItem hi = new HttpItem {
                    URL = host1 + "p=" + pwd +
                    "&m=" + sStr[i]
                };
                HttpResult hr = h.GetHtml(hi);
                string html = hr.Html;
                if (html != "success") {
                    if (html == "")
                        html = "未知";
                    writeFaileLog("执行失败：第" + (i - 1) / 2 + "行，机器码:" + "错误原因:" + html);
                    faileNum++;
                }
            }

            MessageBox.Show("成功:" + (sStr.Length - faileNum) / 2 + "张，失败:" + faileNum + "张");
        }
    }
}
