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

namespace sAA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dilshan\Documents\StudentDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select Count (*) From Login where UserName= '"+ textBox1.Text+ "' and Password ='" + textBox2.Text + "'", con);
            DataTable dt= new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Student_Registrarion ss = new Student_Registrarion();
                ss.Show();
                this.Hide();

            }
            else
            {
                //string message = "Invalid Login credentials, please check Username and pasword and try again";
                //string title = "Invalid login Details";
               // int  3 = MessageBoxIcon.Question;
                      //MessageBox.Show(message, title);

                string message = "Invalid Login credentials, please check Username and pasword and try again?";
                string title = "Invalid login Details";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
            }
         
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            string message = "Are you sure, Do you really want to Exit...?";
            string title = "Exit";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title,buttons);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                // Do something  
            }

        }
    }
}
