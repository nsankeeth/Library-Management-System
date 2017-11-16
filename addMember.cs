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
    public partial class addMember : Form
    {
        SqlConnection conn;
        public addMember()
        {
            InitializeComponent();
            conn = ConnectionManager.GetConnection();
            dateTimePicker1.Value = DateTime.Now;
            groupBox2.Hide();
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void addMember_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mn = new Main();
            mn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            int check = 0;
            Validation val = new Validation();
            if (val.validateNum(textBox1.Text, "Index no"))
            {
                string Query = "select * from student where indexNo = '" + Convert.ToInt32(textBox1.Text) + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader;

                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                        label10.Text = reader["indexNo"].ToString();
                        label6.Text = reader["firstName"].ToString();
                        label7.Text = reader["address"].ToString();
                        label11.Text = reader["contactNo"].ToString();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {

                }

                string Query2 = "select indexNo from membership where indexNo = '" + Convert.ToInt32(textBox1.Text) + "'";
                SqlCommand cmd2 = new SqlCommand(Query2, conn);
                SqlDataReader reader2;

                try
                {
                    conn.Open();
                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        check++;
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {

                }
                if (count != 0)
                {
                    if (check == 0)
                    {
                        groupBox2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Student is already a member");
                    }
                }
                else
                {
                    MessageBox.Show("Student Not Found");
                }
            }
            val = null;
            GC.Collect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Query = "INSERT INTO membership(mName, mAddress, mContactNo, indexNo, memDate) VALUES('" + label6.Text + "', '" + label7.Text + "', '" + Convert.ToInt32(label11.Text) + "', '" + Convert.ToInt32(label10.Text) + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')";
            SqlCommand cmdDb = new SqlCommand(Query, conn); ;
            try
            {
                conn.Open();
                cmdDb.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Membership Added");
                groupBox2.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Add");
            }
        }
    }
}
