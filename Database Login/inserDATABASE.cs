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
using System.Configuration;
using System.CodeDom;
using System.Diagnostics.Eventing.Reader;

namespace Database_Login
{
    public partial class inserDATABASE : Form
    {
        public inserDATABASE()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "CNIC IS MANDATORY FIELD");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Name IS MANDATORY FIELD");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Focus();
                errorProvider3.SetError(textBox3, "Income IS MANDATORY FIELD");
            }
            else
            {
                errorProvider3.Clear();
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Focus();
                errorProvider4.SetError(textBox4, "Address IS MANDATORY FIELD");
            }
            else
            {
                errorProvider4.Clear();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "CNIC IS MANDATORY FIELD");
            }
            else if (textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Name IS MANDATORY FIELD");
            }
            else if (textBox3.Text == "")
            {
                textBox3.Focus();
                errorProvider3.SetError(textBox3, "Income IS MANDATORY FIELD");
            }
            else if (textBox4.Text == "")
            {
                textBox4.Focus();
                errorProvider4.SetError(textBox4, "Address IS MANDATORY FIELD");
            }
            else
            {
                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string query1 = "select CNIC from BIO_DATA where CNIC = @cnic;";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                cmd1.Parameters.AddWithValue("@cnic", textBox1.Text);
                con.Open();
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Confliction at primary key constraints");
                    con.Close();
                }
                else
                {

                    con.Close();
                    string query = " insert into BIO_DATA (CNIC,_Name,INCOME, _Address) values (@cnic,@name,@income,@address);"; // remove ; if sql exception occurs;
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@cnic", textBox1.Text);
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@income", textBox3.Text);
                    cmd.Parameters.AddWithValue("@address", textBox4.Text);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Data stored successfully", "Status", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Data lost !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    con.Close();
                }
            }
        }

        private void inserDATABASE_Load(object sender, EventArgs e)
        {
            timer1.Start(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   DateTime d = DateTime.Now;
            label7.Text = d.ToLongTimeString();
        }
    }
}

