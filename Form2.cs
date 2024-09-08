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
using Dapper;


namespace FinalProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        //public String conString = "DataSource=DESKTOP-SFP3OI1\\SQLEXPRESS;InitialCatalog=Students;IntegratedSecurity=True;TrustServerCertificate=True";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int regNo = int.Parse(comboBox1.Text);
            string firstName = textBox1.Text;
            string lastName = textBox2.Text;

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SFP3OI1\\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            // String sql = "INSERT IN TO Registration(regNo,firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,parentName,nic,contactNo) VALUES (";
            SqlCommand cmd = new SqlCommand("INSERT INTO Registration(regNo,firstName,lastName,dateOfBirth,gender,address,email,mobilePhone,homePhone,parentName,nic,contactNo) VALUES (@regNo, @firstName, @lastName, @dateOfBirth, @gender, @address, @email, @mobilePhone, @homePhone, @parentName, @nic, @contactNo)");
            connection.Open();
            cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBox1.Text));
            cmd.Parameters.AddWithValue("@firstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@lastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@gender", radioButton1.Checked ? "Male" : "Female");
            cmd.Parameters.AddWithValue("@address", textBox3.Text);
            cmd.Parameters.AddWithValue("@email", textBox4.Text);
            cmd.Parameters.AddWithValue("@mobilePhone", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@homePhone", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@parentName", textBox7.Text);
            cmd.Parameters.AddWithValue("@nic", textBox8.Text);
            cmd.Parameters.AddWithValue("@contactNo", int.Parse(textBox9.Text));
            cmd.Connection = connection;
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Registration successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SFP3OI1\\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Registration SET firstName=@firstName, lastName=@lastName, dateOfBirth=@dateOfBirth, gender=@gender, address=@address, email=@email, mobilePhone=@mobilePhone, homePhone=@homePhone, parentName=@parentName, nic=@nic, contactNo=@contactNo WHERE regNo=@regNo", connection);
            cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBox1.Text));
            cmd.Parameters.AddWithValue("@firstName", textBox1.Text);
            cmd.Parameters.AddWithValue("@lastName", textBox2.Text);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@gender", radioButton1.Checked ? "Male" : "Female");
            cmd.Parameters.AddWithValue("@address", textBox3.Text);
            cmd.Parameters.AddWithValue("@email", textBox4.Text);
            cmd.Parameters.AddWithValue("@mobilePhone", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@homePhone", int.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@parentName", textBox7.Text);
            cmd.Parameters.AddWithValue("@nic", textBox8.Text);
            cmd.Parameters.AddWithValue("@contactNo", int.Parse(textBox9.Text));
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Update successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you really want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SFP3OI1\\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Registration WHERE regNo=@regNo", connection);
                    cmd.Parameters.AddWithValue("@regNo", int.Parse(comboBox1.Text));
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Delete successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            
        }
    }
}


//wpf technology