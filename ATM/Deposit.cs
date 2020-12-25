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
    public partial class Deposit : Form
    {
        Account acdeposit = new Account();


        public Deposit()
        {
            InitializeComponent();
        }

        public Deposit(string usernamefrommf2, int accountfrommf2)
        {
            InitializeComponent();
            acdeposit.Username = usernamefrommf2;
            acdeposit.Accid = accountfrommf2;
            this.button1.Click += new EventHandler(button_Click);
            this.button2.Click += new EventHandler(button_Click);
            this.button3.Click += new EventHandler(button_Click);
            this.button4.Click += new EventHandler(button_Click);
            this.button5.Click += new EventHandler(button_Click);
            this.button6.Click += new EventHandler(button_Click);
            this.button7.Click += new EventHandler(button_Click);
            this.button8.Click += new EventHandler(button_Click);
            this.button9.Click += new EventHandler(button_Click);
            this.button10.Click += new EventHandler(button_Click);
            this.button11.Click += new EventHandler(button_Click);

        }

        private void button_Click(object sender, EventArgs e)
        {
            textBox1.Text += ((Button)sender).Text; 

        }


        private void Deposit_Load(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            float balance = DAO.get_balance(acdeposit.Accid);
            Console.WriteLine(balance);
            float newbalance = balance + float.Parse(textBox1.Text.ToString());
            if (DAO.deposit(acdeposit.Accid, newbalance)) 
            MessageBox.Show("存款成功！");
            else MessageBox.Show("存款失败！");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            //Account accountfrommf1 = new Account();
            //accountfrommf1.Accid = selectedaccount;
            //accountfrommf1.Username = this.u1.Username;
            MainFrame2 m2 = new MainFrame2(acdeposit);
            m2.Show();
            this.Visible = false;
        }
    }
}
