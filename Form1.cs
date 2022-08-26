using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market_Inventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string connString = "Data Source=SILASPC\\SQLEXPRESS;Initial Catalog=mktdb;Integrated Security=True";
        public static string data;

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
            */
            if(uname.Text == "" || passw.Text == "")
            {
                MessageBox.Show("Please provide your login credentials!!");
            }
            try
            {
                
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT role FROM user_table WHERE uname LIKE '"+uname.Text+"' COLLATE SQL_Latin1_General_CP1_CI_AS AND password LIKE '"+passw.Text+ "' COLLATE SQL_Latin1_General_CP1_CI_AS", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                 

                if (dt.Rows.Count == 1)
                {
                    data = dt.Rows[0][0].ToString();
                    
                    if(data == "ADMIN")
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
                    }
                    else if(data == "ATTENDANT")
                    {
                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect credentials");
                }

            }
            catch(Exception es)
            {
                MessageBox.Show("This " + es + " error was encoutered");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                passw.UseSystemPasswordChar = false;
            }
            else
                passw.UseSystemPasswordChar = true;
        }
    }
}
