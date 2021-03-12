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
using System.IO;
using System.Diagnostics;

namespace ErecruiterForm
{
    public partial class upload : Form
    {
        public upload()
        {
            InitializeComponent();
        }


        SqlConnection sqlcon = new SqlConnection("server=.;database=Erecruiter;UID=sa;password=admin123");

        private void button1_Click(object sender, EventArgs e)
        {
            string filetype;
            string filename;

            filename = textBox1.Text.Substring(Convert.ToInt32(textBox1.Text.LastIndexOf("\\")) + 1, textBox1.Text.Length - (Convert.ToInt32(textBox1.Text.LastIndexOf("\\")) + 1));
            filetype = textBox1.Text.Substring(Convert.ToInt32(textBox1.Text.LastIndexOf(".")) + 1, textBox1.Text.Length - (Convert.ToInt32(textBox1.Text.LastIndexOf(".")) + 1));

            //Validate user upload only specific bytes - un comment below lines if you need to validate only PDF files

            if (filetype.ToUpper() != "PDF")
            {
                MessageBox.Show("Upload Only PDF Files");
                return;
            }

            byte[] FileBytes = null;

            try
            {
                // Open file to read using file path
                FileStream FS = new FileStream(textBox1.Text, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                // Add filestream to binary reader
                BinaryReader BR = new BinaryReader(FS);

                // get total byte length of the file
                long allbytes = new FileInfo(textBox1.Text).Length;

                // read entire file into buffer
                FileBytes = BR.ReadBytes((Int32)allbytes);

                // close all instances
                FS.Close();
                FS.Dispose();
                BR.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during File Read " + ex.ToString());
            }

            //Store File Bytes in database image filed 
             
            sqlcon.Open();
            SqlCommand sqlcmd = new SqlCommand("Update Registration set resume= @FB  where username = '" + textBox2.Text + "'", sqlcon);
            sqlcmd.Parameters.AddWithValue("@FN", filename);
            sqlcmd.Parameters.AddWithValue("@FB", FileBytes);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("The resume " + filename + " has been uploaded");


        }



        private void upload_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select file to be upload";
            //fDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
            fDialog.Filter = "PDF Files|*.pdf";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fDialog.FileName.ToString();
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
