using System;
using System.Collections;
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
    public partial class MainFrame1 : Form
    {
        User u1 = new User();
        int selectedaccount;

        public MainFrame1(string usernameValue)
        { 
           InitializeComponent();
            u1.Username = usernameValue;
        }

        
        private void MainFrame1_Load(object sender, EventArgs e)
        {
            this.Text = "欢迎您：" + u1.Username.ToString();
            this.dataGridView1.RowHeadersVisible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DAO.viewAccount(u1.Username.ToString()).Tables["Account"];
            dataGridView1.ReadOnly = false;
            DataGridViewCheckBoxColumn CheckColunms = new DataGridViewCheckBoxColumn();
            CheckColunms.Name = "选择";
            CheckColunms.Width = 50;

            this.dataGridView1.Columns.Insert(0, CheckColunms);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].Cells[0].Value = false;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

            dataGridView1.Columns[1].HeaderText = "账号";
            dataGridView1.Columns[2].HeaderText = "银行";
            dataGridView1.Columns[3].HeaderText = "卡类型";
            dataGridView1.Columns[4].HeaderText = "余额";
            dataGridView1.Columns[5].HeaderText = "用户";
            dataGridView1.Columns[6].HeaderText = "额度";

            this.button2.Enabled = false;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells[0].Selected == true)
                    selectedaccount = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                else
                    selectedaccount = 8888;
            }
            catch {
                Console.WriteLine( "异常{0}", e.ToString());

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("是否选择账号" + selectedaccount + "进行操作", "确认", MessageBoxButtons.YesNo);
            Account accountfrommf1 = new Account();
            accountfrommf1.Accid = selectedaccount;
            accountfrommf1.Username = this.u1.Username;
            MainFrame2 m2 = new MainFrame2(accountfrommf1);
            m2.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassword m3 = new ChangePassword(u1.Username);
            m3.Show();
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateAccount m4 = new CreateAccount(u1.Username);
            m4.Show();
            this.Visible = false;
        }
    }
}


