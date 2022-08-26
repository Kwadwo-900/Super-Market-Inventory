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

        //static string myconn = System.ConfigurationManager.ConnectionString['connstring']ConnectionString;
        public static string ut;

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
                SqlConnection conn = new SqlConnection("data source=SILASPC\\SQLEXPRESS;initial catalog=mktd;integrated security = True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT role FROM usertable WHERE uname LIKE '"+uname+"' AND password LIKE '"+passw+"'; ", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if(dt.Rows.Count == 1)
                {
                    ut = dt.Rows[0][0].ToString();
                    if(ut == "ADMIN")
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        /*
                         * Show attendant page over here
                         */
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
