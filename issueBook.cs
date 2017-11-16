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

namespace Library_Management_System
{
    public partial class issueBook : Form
    {
        SqlConnection conn;
        DateTime memDate;
        public issueBook()
        {
            InitializeComponent();
            conn = ConnectionManager.GetConnection();
            groupBox2.Hide();
            groupBox3.Enabled = false;
            groupBox4.Hide();
            button5.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mn = new Main();
            mn.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void issueBook_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            int count2 = 0;
            Validation val = new Validation();
            if (val.validateNum(textBox1.Text, "Member ID"))
            {
                string Query = "select * from membership where mID = '" + Convert.ToInt32(textBox1.Text) + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader;
                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                        label1.Text = reader["indexNo"].ToString();
                        label10.Text = reader["mID"].ToString();
                        label7.Text = reader["mName"].ToString();
                        label11.Text = reader["mAddress"].ToString();
                        label12.Text = reader["mContactNo"].ToString();
                        label13.Text = reader.GetDateTime(5).Date.ToString("dd-MM-yyyy");
                        memDate = reader.GetDateTime(5).Date;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Member Not Found");
                }

                string Query2 = "select * from borrow where mID = '" + Convert.ToInt32(textBox1.Text) + "'";
                SqlCommand cmd2 = new SqlCommand(Query2, conn);
                SqlDataReader reader2;
                try
                {
                    conn.Open();
                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        count2++;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Member Not Found");
                }

                if (count2 == 0)
                {
                    label16.Text = "No book to return";
                }
                else
                {
                    label16.Text = "Please return the book";
                }
                if (count != 0)
                {
                    groupBox2.Show();
                }
                else
                {
                    MessageBox.Show("Member Not Found");
                    textBox1.Text = "";
                }
            }
            val = null;
            GC.Collect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;
            Validation val = new Validation();
            if (val.validateNum(textBox2.Text, "ISBN"))
            {
                string Query = "select * from book where ISBN = '" + Convert.ToInt32(textBox2.Text) + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader;
                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                        label25.Text = reader["ISBN"].ToString();
                        label26.Text = reader["bName"].ToString();
                        label27.Text = reader["bSubject"].ToString();
                        label28.Text = reader["author"].ToString();
                        label29.Text = reader["edition"].ToString();
                        label30.Text = reader["noOfCopies"].ToString();
                        label31.Text = reader["price"].ToString();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Book Not Found");
                }
                if (count != 0)
                {
                    groupBox4.Show();
                }
                else
                {
                    MessageBox.Show("Book Not Found");
                }
            }
            val = null;
            GC.Collect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label16.Text == "No book to return")
            {
                groupBox3.Enabled = true;
                label34.Text = label10.Text;
                dateTimePicker1.MinDate = memDate;
            }
            else
            {
                MessageBox.Show("Member has to return the borrowed book");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(label30.Text) == 0)
            {
                MessageBox.Show("Book is not available at the moment");
            }
            else
            {
                label35.Text = label25.Text;
                button5.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Query = "INSERT INTO borrow(ISBN, mID, bDate) VALUES('" + Convert.ToInt32(label35.Text) + "', '" + Convert.ToInt32(label34.Text) + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')";
            SqlCommand cmdDb = new SqlCommand(Query, conn); ;
            try
            {
                conn.Open();
                cmdDb.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Borrow Details Added");

                string Querry2 = "Update book set noOfCopies = noOfCopies-1 where ISBN = '" + Convert.ToInt32(label35.Text) + "'";
                SqlCommand cmd = new SqlCommand(Querry2, conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                }
                groupBox2.Hide();
                groupBox4.Hide();
                groupBox3.Enabled = false;
                label34.Text = "";
                label35.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";

                button5.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
