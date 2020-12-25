using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class ChangePassword : Form
    {
        private string thisname, thispassword, newpassword;
        public ChangePassword(string a)
        {
            thisname = a;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            thispassword = textBox1.Text.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainFrame1 m1 = new MainFrame1(thisname);
            m1.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int judge;
            judge = DAO.ChangePassword(thisname, thispassword, newpassword);
            if (judge == 2)
                MessageBox.Show("不存在该用户");
            else if (judge == 3)
                MessageBox.Show("当前密码有误请重新输入！");
            else if (judge == 4)
                MessageBox.Show("异常！");
            else
            {
                MessageBox.Show("修改成功！");
                MainFrame1 m1 = new MainFrame1(thisname);
                m1.Show();
                this.Visible = false;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            newpassword = textBox2.Text.ToString();
        }
    }
}
