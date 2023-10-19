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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sAA
{
    public partial class Student_Registrarion : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dilshan\Documents\StudentData.mdf;Integrated Security=True;Connect Timeout=30");
        public Student_Registrarion()
        {
            InitializeComponent();
        }


        private void populate()
        {
            con.Open();
            string query = "select * from Registration";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
           
          


             con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dilshan\Documents\StudentData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Registration set regNo=@regNo,firstname=@firstname,lastName=@lastName,dateOfBirth=@dateOfBirth,gender=@gender,address=@address,email=@email,mobilePhone=@mobilePhone,homePhone=@homePhone,parentName=@parentName,nic=@nic,contactNo=@contactNo", con);
           // cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBox1.Text));
            cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
            cmd.Parameters.AddWithValue("@lastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@gender", radioButton1.Text);
            cmd.Parameters.AddWithValue("@address", textBox3.Text);
            cmd.Parameters.AddWithValue("@email", textBox4.Text);
            cmd.Parameters.AddWithValue("@mobilePhone", int.Parse( textBox6.Text));
            cmd.Parameters.AddWithValue("@homePhone", int.Parse( textBox5.Text));
            cmd.Parameters.AddWithValue("@parentName", textBox7.Text);
            cmd.Parameters.AddWithValue("@nic", textBox8.Text);
            cmd.Parameters.AddWithValue("@contactNo", int.Parse(textBox9.Text));

            cmd.ExecuteNonQuery();


            string message = "record update successfully";
            string title = "UPDATE Student";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Asterisk);
            MessageBox.Show("Successfully Update");
            con.Close();
          




        }
        string gender;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert INTO Registration(regNo,firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,parentName,nic,contactNo)values('" + comboBox1.Text + "' ,'" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + gender + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')", con);
                cmd.ExecuteNonQuery();

                //  MessageBox.Show("Record add successfully");

                string message = "Record add successfully";
                string title = "Register Student";
                 MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title,buttons , MessageBoxIcon.Asterisk);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();




        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dilshan\Documents\StudentData.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            if (comboBox1.Text != "")
            {
                SqlCommand cmd = new SqlCommand("select firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,parentName,nic,contactNo from Registration where regNo=@regNo", con);
                cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBox1.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBox1.Text = da.GetValue(0).ToString();
                    textBox2.Text = da.GetValue(1).ToString();
                    dateTimePicker1.Text = da.GetValue(2).ToString();
                    radioButton1.Text = da.GetValue(3).ToString();
                    textBox3.Text = da.GetValue(4).ToString();
                    textBox4.Text = da.GetValue(5).ToString();
                    textBox6.Text = da.GetValue(6).ToString();
                    textBox5.Text = da.GetValue(7).ToString();
                    textBox7.Text = da.GetValue(8).ToString();
                    textBox8.Text = da.GetValue(9).ToString();
                    textBox9.Text = da.GetValue(10).ToString();
                }
                con.Close();
            }

        }

        private void Student_Registrarion_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            radioButton1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();

            textBox9.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {


             string message = "Are you sure, Do you really want to Delete...?";
           string title = "Delete";
           MessageBoxButtons buttons = MessageBoxButtons.YesNo;
           DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);
           if (result == DialogResult.Yes)
           {
               mass();
           }
           else
           {
               // Do something  
           }



           /*   SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dilshan\Documents\StudentData.mdf;Integrated Security=True;Connect Timeout=30");
              con.Open();
              SqlCommand cmd = new SqlCommand("Delete Registration where regNo=@regNo", con);
              cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBox1.Text));
              cmd.ExecuteNonQuery();

              string message = "Record add successfully";
              string title = "Register Student";
              //  MessageBoxButtons buttons = MessageBoxButtons.Yes;
              DialogResult result = MessageBox.Show(message, title);
              MessageBox.Show("Successfully Deleted");

           */

        } 
        public void mass()
        {


              SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dilshan\Documents\StudentData.mdf;Integrated Security=True;Connect Timeout=30");
               con.Open();
               SqlCommand cmd = new SqlCommand("Delete Registration where regNo=@regNo", con);
               cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBox1.Text));
               cmd.ExecuteNonQuery();

               string message = "record delete successfully";
               string title = "delete Student";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
               DialogResult result = MessageBox.Show(message, title,buttons,MessageBoxIcon.Asterisk);
               MessageBox.Show("Successfully Deleted");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            radioButton1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";



        }

        private void label16_Click(object sender, EventArgs e)
        {
           Form1 sss = new Form1();
            sss.Show();
            this.Hide();

        }
    }
    }
    

    

