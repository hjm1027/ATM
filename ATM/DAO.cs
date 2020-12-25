using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ATM
{
    class DAO
    {

        public static int login(string Username, string Password)
        {
            try
            {
                string conStr = "Data Source=(localdb)\\MSSQLlocalDB;Initial Catalog=mydatabase;Integrated Security=True";
                string sqlQuery1 = "select * from [Login] where username='" + Username + "'";
                string sqlQuery2 = "select * from [Login] where username='" + Username + "'and password='" + Password + "'";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                Console.WriteLine(Username);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlQuery1;
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    Console.WriteLine("不存在该用户，请重新输入！");
                    reader.Close();
                    conn.Close();
                    return 2;
                }
                else
                {
                    reader.Close();

                    cmd.CommandText = sqlQuery2;
                    reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        Console.WriteLine("用户名或密码输入有误，请重新输入！");
                        reader.Close();
                        conn.Close();
                        return 3;

                    }
                    else
                    { conn.Close(); Console.WriteLine("成功登陆"); return 1; }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return 4;
            }


        }

        public static DataSet viewAccount(string Username)
        {
            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            SqlConnection con = new SqlConnection(conStr);
            string sqlQuery = "SELECT * FROM [Account] WHERE username = '" + Username + "'";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Account");
            con.Close();
            return ds;
        }//熟练运用datadapter操作dataset

        public static float get_balance(int Account)
        {
            //创建连接对象
            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            string sqlQuery = "select Balance from [Account] where AccountID = '" + Account + "'";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                reader.Read();
                return float.Parse(reader["Balance"].ToString());
            }

            catch (Exception e)
            {
                float f = 3;
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return f;
            }

            finally
            {
                con.Close();
            }
        }


        public static Boolean deposit(int Account, float deposit_money)
        {

            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            string sqlQuery1 = "update [Account] set Balance = " + deposit_money + " where AccountID ='" + Account + "'";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery1, con);
            try
            {
                con.Open();
                cmd = new SqlCommand(sqlQuery1, con);
                cmd.ExecuteNonQuery();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }

            finally
            {

                con.Close();
            }
        }

        public static Boolean withdrawal(int Account, float withdrawal_money)
        {

            string conStr = "Data Source = (localdb)\\MSSQLlocalDB; Initial Catalog = mydatabase; Integrated Security = True";
            string sqlQuery1 = "update [Account] set Balance = " + withdrawal_money + " where AccountID ='" + Account + "'";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sqlQuery1, con);
            try
            {
                con.Open();
                cmd = new SqlCommand(sqlQuery1, con);
                cmd.ExecuteNonQuery();
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return false;
            }

            finally
            {

                con.Close();
            }
        }

        public static int ChangePassword(string Username, string thispassword, string newpassword)
        {
            try
            {
                string conStr = "Data Source=(localdb)\\MSSQLlocalDB;Initial Catalog=mydatabase;Integrated Security=True";
                string sqlQuery1 = "select * from [Login] where username='" + Username + "'";
                string sqlQuery2 = "select * from [Login] where username='" + Username + "'and password='" + thispassword + "'";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlQuery1;
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    Console.WriteLine("不存在该用户，请重新输入！");
                    reader.Close();
                    conn.Close();
                    return 2;
                }
                else
                {
                    reader.Close();

                    cmd.CommandText = sqlQuery2;
                    reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        Console.WriteLine("当前密码输入有误，请重新输入！");
                        reader.Close();
                        conn.Close();
                        return 3;

                    }
                    else
                    {
                        reader.Close();
                        string sqlQuery3 = "update [Login] set password='" + newpassword + "'where username='" + Username + "'and password='" + thispassword + "'";
                        cmd.CommandText = sqlQuery3;
                        reader = cmd.ExecuteReader();
                        conn.Close();
                        Console.WriteLine("修改成功");
                        return 1;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return 4;
            }
        }

        public static int CreateAccount(string Username, string password)
        {
            try
            {
                string conStr = "Data Source=(localdb)\\MSSQLlocalDB;Initial Catalog=mydatabase;Integrated Security=True";
                string sqlQuery = "insert into [Login] values('" + Username + "','" + password + "')";
                SqlConnection conn = new SqlConnection(conStr);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlQuery;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                conn.Close();
                Console.WriteLine("创建成功");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("异常:{0}", e.Message.ToString());
                return 4;
            }
        }
    }
}
