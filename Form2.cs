using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market_Inventory
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new Report());
        }

        public void loadForm(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form form = Form as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(form);
            this.mainpanel.Tag = form;
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadForm(new ProductManager());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadForm(new UserManager());
        }
    }
}
