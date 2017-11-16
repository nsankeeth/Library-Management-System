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
    public partial class manageMembers : Form
    {
        SqlConnection conn;
        public manageMembers()
        {
            InitializeComponent();
            conn = ConnectionManager.GetConnection();
            groupBox2.Hide();
            panel1.Show();
            panel2.Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Query = "DELETE FROM membership WHERE mID = '" + label10.Text + "'";
            SqlCommand cmdDb = new SqlCommand(Query, conn); ;
            try
            {
                conn.Open();
                cmdDb.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Membership Deleted Successfully");
                groupBox2.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Member has borrowed a book. Return the book to cancel membership");
            }
        }

        private void manageMembers_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
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
            if (comboBox1.SelectedIndex == 0)
            {
                Validation val = new Validation();
                if (val.validateNum(textBox1.Text, "Index no"))
                {
                    string Query = "select * from membership where indexNo = '" + Convert.ToInt32(textBox1.Text) + "'";
                    SqlCommand cmd = new SqlCommand(Query, conn);
                    SqlDataReader reader;
                    try
                    {
                        conn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            count++;
                            label2.Text = reader["indexNo"].ToString();
                            label10.Text = reader["mID"].ToString();
                            label7.Text = reader["mName"].ToString();
                            label11.Text = reader["mAddress"].ToString();
                            label12.Text = reader["mContactNo"].ToString();
                            label13.Text = reader.GetDateTime(5).Date.ToString("dd-MM-yyyy");
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Member Not Found");
                    }
                    if (count != 0)
                    {
                        groupBox2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Member Not Found");
                    }
                }
                val = null;
                GC.Collect();
            }
            else
            {
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
                            label2.Text = reader["indexNo"].ToString();
                            label10.Text = reader["mID"].ToString();
                            label7.Text = reader["mName"].ToString();
                            label11.Text = reader["mAddress"].ToString();
                            label12.Text = reader["mContactNo"].ToString();
                            label13.Text = reader.GetDateTime(5).Date.ToString("dd-MM-yyyy");
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Member Not Found");
                    }
                    if (count != 0)
                    {
                        groupBox2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Member Not Found");
                    }
                }
                val = null;
                GC.Collect();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Members : Show")
            {
                button3.Text = "Members : Hide";
                panel1.Hide();
                panel2.Show();

                SqlDataAdapter sda = new SqlDataAdapter("select * from membership", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();

                    dataGridView1.Rows[n].Cells[0].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                }
            }
            else
            {
                button3.Text = "Members : Show";
                panel1.Show();
                panel2.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Members mem = new Members();
            mem.Show();
        }
    }
}
