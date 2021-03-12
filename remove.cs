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

namespace ErecruiterForm
{
    public partial class remove : Form
    {
        public remove()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
                return;
            }
            try

            {

                String str = "server=.;database=Erecruiter;UID=sa;password=admin123";
                SqlConnection con = new SqlConnection(str);

                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Registration where username='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Student has been removed succesfully ");
                con.Close();

            }

            catch (Exception es)

            {

                MessageBox.Show(es.Message);



            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Erecruiter_home h = new Erecruiter_home();
            h.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
