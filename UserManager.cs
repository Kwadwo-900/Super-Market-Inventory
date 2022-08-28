using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Super_Market_Inventory
{
    public partial class UserManager : Form
    {
        public UserManager()
        {
            InitializeComponent();
        }

        public static string connString = "Data Source=SILASPC\\SQLEXPRESS;Initial Catalog=mktdb;Integrated Security=True";

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(aname.Text == "" || npass.Text == "" || contact.Text == "" || email.Text =="" )
            {
                MessageBox.Show("Enter the full details of the user!! ");
            }

            try
            {
                SqlCommand command;
                SqlConnection conn = new SqlConnection(connString);


                string sql = "INSERT INTO user_table VALUES('" + this.aname.Text + "','" + this.npass.Text + "', '" + this.roleBox.Text + "', '" + this.contact.Text + "', '" + this.email.Text + "') ";
                command = new SqlCommand(sql,conn);
                conn.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("New User Addded Successfully!!");
                aname.Clear();
                npass.Clear();
                roleBox.ResetText();
                contact.Clear();
                email.Clear();

                conn.Close();
             }
            catch(Exception es)
            {
                MessageBox.Show(es + " error occured!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommand command;
            SqlConnection conn = new SqlConnection(connString);

            command = new SqlCommand("DELETE FROM user_table WHERE uname = '" + dname.Text + "'", conn);
            conn.Open();
            command.ExecuteNonQuery();

            MessageBox.Show("User removed successfully");
                dname.Clear();

                conn.Close();
                }
            catch(Exception es)
            {
                MessageBox.Show(es + " error occured!!!");
                
            }
        }
    }
}
