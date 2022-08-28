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
    public partial class ProductManager : Form
    {
        public ProductManager()
        {
            InitializeComponent();
        }

        public static string connString = "Data Source=SILASPC\\SQLEXPRESS;Initial Catalog=mktdb;Integrated Security=True";

        private void addItem_Click(object sender, EventArgs e)
        {
            if(pname.Text == "" || sprice.Text == "" || cprice.Text == "" || quantity.Text == "" || category.Text == "")
            {
                MessageBox.Show("Enter the details of the product!!!");
            }
            try 
            {
                SqlCommand command;
                SqlConnection conn = new SqlConnection(connString);

                string sql = "INSERT INTO product_table VALUES('" + this.pname.Text + "','" + this.quantity.Text + "', '" + this.category.Text + "', '" + this.sprice.Text + "', '" + this.cprice.Text + "') ";
                command = new SqlCommand(sql,conn);
                conn.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("New Product Successfuly Added!!!");
                pname.Clear();
                sprice.Clear();
                cprice.Clear();
                quantity.Clear();
                category.ResetText();

                conn.Close();
            }
            catch { }

        }
    }
}
