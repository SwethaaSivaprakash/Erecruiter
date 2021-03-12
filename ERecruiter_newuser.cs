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
    public partial class ERecruiter_newuser : Form
    {
        public ERecruiter_newuser()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ERecruiter_newuser_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private string RadioButtonText()
        {
            if (radioButton1.Checked)
            {
                return radioButton1.Text;
            }
            else
            {
                return radioButton2.Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try

            {

                String str = "server=.;database=Erecruiter;UID=sa;password=admin123";
                SqlConnection con = new SqlConnection(str);

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Registration(name,email,gender,dob,address,qualification,ph,username,password) values('" + textBox1.Text + "', '" + maskedTextBox1.Text + "',  '" + RadioButtonText() + "',  '" + dateTimePicker1.Value + "', '" + richTextBox1.Text + "', '" + textBox2.Text + "' , '" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Student has successfully registered ");
                con.Close();

            }

            catch (Exception es)

            {

                MessageBox.Show(es.Message);



            }


        }

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
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

