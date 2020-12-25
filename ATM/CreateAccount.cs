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
    public partial class CreateAccount : Form
    {
        private string lastname, username, password;
        public CreateAccount(string a)
        {
            lastname = a;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            username = textBox1.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int judge;
            judge = DAO.CreateAccount(username,password);
            if (judge == 4)
                MessageBox.Show("异常！");
            else
            {
                MessageBox.Show("创建成功！");
                Login m1 = new Login();
                m1.Show();
                this.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainFrame1 m1 = new MainFrame1(lastname);
            m1.Show();
            this.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            password = textBox2.Text.ToString();
        }
    }
}
