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
    public partial class DataBE : Form
    {
        SqlConnection conn;
        public DataBE()
        {
            InitializeComponent();
            conn = ConnectionManager.GetConnection();
        }

        private void DataBE_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            dataGridView2.Hide();
            dataGridView3.Hide();
            label2.Hide();
            label3.Hide();
            menuStrip1.Select();
            borrowedBooksToolStripMenuItem_Click(null, null);

        }

        public string gtDate(string dateTime)
        {
            return dateTime.Substring(0, dateTime.IndexOf(' '));
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void borrowedBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            dataGridView2.Hide();
            dataGridView3.Hide();

            label1.Show();
            label2.Hide();
            label3.Hide();

            SqlDataAdapter sda = new SqlDataAdapter("select * from borrow", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = gtDate(item[2].ToString());

            }
        }

        private void returnedBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Show();
            dataGridView3.Hide();

            label1.Hide();
            label2.Show();
            label3.Hide();

            SqlDataAdapter sda = new SqlDataAdapter("select * from bReturn", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();

                dataGridView2.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView2.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView2.Rows[n].Cells[3].Value = gtDate(item[3].ToString());
                dataGridView2.Rows[n].Cells[4].Value = gtDate(item[4].ToString());
                dataGridView2.Rows[n].Cells[5].Value = item[5].ToString();
            }
        }

        private void lostBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

            label1.Hide();
            label2.Hide();
            label3.Show();

            dataGridView1.Hide();
            dataGridView2.Hide();
            dataGridView3.Show();

            SqlDataAdapter sda = new SqlDataAdapter("select * from bLost", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView3.Rows.Add();

                dataGridView3.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView3.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView3.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView3.Rows[n].Cells[3].Value = gtDate(item[3].ToString());
                dataGridView3.Rows[n].Cells[4].Value = gtDate(item[4].ToString());
                dataGridView3.Rows[n].Cells[5].Value = item[5].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mn = new Main();
            mn.Show();
        }
    }
}
