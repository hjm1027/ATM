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
    public partial class Login : Form
    {
        private string thisname, thispassword;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DAO.login(thisname, thispassword) == 2)
                MessageBox.Show("不存在该用户");
            else if (DAO.login(thisname, thispassword) == 3)
                MessageBox.Show("用户名密码有误请重新输入！");
            else if (DAO.login(thisname, thispassword) == 4)
                MessageBox.Show("异常！");
            else
            {
                MessageBox.Show("成功登陆！");
                MainFrame1 m1 = new MainFrame1(thisname);
                m1.Show();
                this.Visible = false;
            
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            thisname = textBox1.Text.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateAccount m = new CreateAccount("CHENG");
            m.Show();
            this.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            thispassword = textBox2.Text.ToString();
        }
    }
}
