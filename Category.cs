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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
        public string combobox()
        {
            string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            return selectedItem;

        }

        private void Category_Load(object sender, EventArgs e)
        {
           
        }

       
        private void load_details(object sender, EventArgs e)
        {
            
            
          
            try

            {
                SqlConnection con = new SqlConnection("server =.;Database=Erecruiter;UID=sa;Password=admin123;");
                string value = combobox();
                SqlCommand cmd = new SqlCommand("Select * from  " + value, con);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;

                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;

                con.Close();

            }

            catch (Exception ec)

            {

                MessageBox.Show("Please Select the Category !!!");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            upload i = new upload();
            i.ShowDialog();
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
