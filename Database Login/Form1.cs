using System.Configuration;
using System.Data.SqlClient;
namespace Database_Login
{
    public partial class Form1 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Please fill the id ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Please fill the password ");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from LOGIN_TABLE where ID = @user and PASS = @pass";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("Successfully Logged-In", "Logged In", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                inserDATABASE ins = new inserDATABASE();
                ins.Show();
                ins.label4.Text = $"Logged in as: {this.textBox1.Text}";
            }
            else
            {
                MessageBox.Show("Incorrect Credentials !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();

        }
    }
}