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
    public partial class manageBooks : Form
    {
        SqlConnection conn;
        public manageBooks()
        {
            InitializeComponent();
            conn = ConnectionManager.GetConnection();
        }

        void loadTable()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select * from book", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[3].ToString();

            }

        }

        void loadDetails()
        {
            label12.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        void borrowCount()
        {
            string querry = "Select coalesce((select COUNT(ISBN) from borrow where ISBN = '" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()) + "' group by ISBN),0) as count";
            SqlCommand cmd = new SqlCommand(querry, conn);
            SqlDataReader reader;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label11.Text = Convert.ToString(reader.GetInt32(0));
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void reset()
        {
            label12.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            label11.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void manageBooks_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            comboBox1.SelectedIndex = 0;

            
            int count = 0;
            string Query = "select * from book";
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
                loadTable();

                //to fill book details from the table
                loadDetails();
                borrowCount();
            }
            else
            {
                MessageBox.Show("There is no book to manage");
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                dataGridView1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Validation valBEdition = new Validation();
            Validation noOfCps = new Validation();
            Validation valPrice = new Validation();
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && valBEdition.validateNum(textBox5.Text, "Book edition") && noOfCps.validateNum(textBox6.Text, "No of copies") && valPrice.validateDecNum(textBox7.Text, "Price"))
            {
                int ISBN = Convert.ToInt32(label12.Text);
                string bName = textBox2.Text;
                string bSubject = textBox3.Text;
                string bAuthor = textBox4.Text;
                int bEdition = Convert.ToInt32(textBox5.Text);
                int bNoOfCopies = Convert.ToInt32(textBox6.Text);
                float bPrice = float.Parse(textBox7.Text);

                Book mngBook = new Book();
                mngBook.setBook(ISBN, bName, bSubject, bAuthor, bEdition, bNoOfCopies, bPrice);
                mngBook.updateBook();

                mngBook = null;
                GC.Collect();
                loadTable();
                loadDetails();
                borrowCount();
            }
            else
            {
                MessageBox.Show("Provide all the details");
            }
            valBEdition = null;
            noOfCps = null;
            valPrice = null;

            GC.Collect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = 0;
            string Query = "select * from book";
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

            if (count == 1)
            {
                int bISBN = Convert.ToInt32(label12.Text);
                Book mngBook = new Book();
                mngBook.deleteBook(bISBN);

                mngBook = null;
                GC.Collect();
                loadTable();
                reset();

                MessageBox.Show("There is no book to manage");
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                dataGridView1.Enabled = false;
            }
            else
            {
                int bISBN = Convert.ToInt32(label12.Text);
                Book mngBook = new Book();
                mngBook.deleteBook(bISBN);

                mngBook = null;
                GC.Collect();
                loadTable();
                loadDetails();
                borrowCount();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mn = new Main();
            mn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Books bk = new Books();
            bk.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from book where ISBN like '" + textBox1.Text + "%'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();

                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[3].ToString();
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from book where bName like '" + textBox1.Text + "%'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();

                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[3].ToString();
                }
            }
            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("select * from book where author like '" + textBox1.Text + "%'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();

                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[3].ToString();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void manageBooks_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            loadDetails();
            borrowCount();
        }
    }
}
