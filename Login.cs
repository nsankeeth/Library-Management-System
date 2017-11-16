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

namespace Library_Management_System
{
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login()
        {
            InitializeComponent();
            conn = ConnectionManager.GetConnection();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter valid user ID and password");
            }
            else
            {
                int count = 0;
                string Query = "select * from Login where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "' and type = 'libraryMS'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader;

                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {

                }
                if (count != 0)
                {
                    this.Hide();
                    Main mn = new Main(textBox1.Text);
                    mn.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }


            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
