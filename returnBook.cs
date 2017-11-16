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
    public partial class returnBook : Form
    {
        DateTime stDate;
        DateTime enDate;
        double rtCharge;
        SqlConnection conn;
        public returnBook()
        {
            InitializeComponent();
            conn = ConnectionManager.GetConnection();
            groupBox2.Hide();
            dateTimePicker1.MaxDate = DateTime.Now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mn = new Main();
            mn.Show();
        }

        private void returnBook_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            Validation val = new Validation();
            if (val.validateNum(textBox1.Text, "Member ID"))
            {
                string Query = "select * from membership m, borrow b where m.mID = b.mID and b.mID = '" + Convert.ToInt32(textBox1.Text) + "'";
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
                        label13.Text = reader.GetDateTime(5).Date.ToString("yyyy-MM-dd");
                        label20.Text = reader["ISBN"].ToString();
                        label16.Text = reader.GetDateTime(8).Date.ToString("yyyy-MM-dd");

                        stDate = reader.GetDateTime(8);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Member has no book to return");
                }

                if (count != 0)
                {
                    enDate = dateTimePicker1.Value.Date;
                    Double totDays = (enDate - stDate).TotalDays;
                    if (totDays > 5)
                    {
                        rtCharge = (totDays - 5) * 50;
                    }
                    else
                    {
                        rtCharge = 0;
                    }
                    label18.Text = Convert.ToString(rtCharge);
                    groupBox2.Show();
                    dateTimePicker1.MinDate = Convert.ToDateTime(label16.Text);
                }
                else
                {
                    MessageBox.Show("Member has no book to return");
                }
            }
            val = null;
            GC.Collect();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString((enDate - stDate).TotalDays));
        }

        private void toolTip1_Popup_1(object sender, PopupEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            enDate = dateTimePicker1.Value.Date;
            Double totDays = (enDate - stDate).TotalDays;
            if (totDays > 5)
            {
                rtCharge = (totDays - 5) * 50;
            }
            else
            {
                rtCharge = 0;
            }
            label18.Text = Convert.ToString(rtCharge);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Query1 = "DELETE FROM borrow WHERE mID = '" + label10.Text + "' and ISBN = '" + label20.Text + "'";
            SqlCommand cmdDb1 = new SqlCommand(Query1, conn); ;
            try
            {
                conn.Open();
                cmdDb1.ExecuteNonQuery();
                conn.Close();

                string Query = "INSERT INTO bReturn(ISBN, bName, mID, bDate, rDate, charges) VALUES('" + Convert.ToInt32(label20.Text) + "', '" + label7.Text + "', '" + Convert.ToInt32(label10.Text) + "', '" + Convert.ToDateTime(label16.Text).ToString("yyyy-MM-dd") + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + float.Parse(label18.Text) + "')";
                SqlCommand cmdDb = new SqlCommand(Query, conn); ;
                try
                {
                    conn.Open();
                    cmdDb.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Recorded Successfully");

                    groupBox2.Hide();
                    textBox1.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to Record");
                }
                string Querry2 = "Update book set noOfCopies = noOfCopies+1 where ISBN = '" + Convert.ToInt32(label20.Text) + "'";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Record");
            }
        }
    }
}
