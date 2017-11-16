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
    public partial class addBook : Form
    {
        SqlConnection conn;
        public addBook()
        {
            InitializeComponent();
            conn = ConnectionManager.GetConnection();
        }

        private void addBook_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mn = new Main();
            mn.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Validation valISBN = new Validation();
            Validation valBEdition= new Validation();
            Validation noOfCps = new Validation();
            Validation valPrice = new Validation();
            if (valISBN.validateNum(textBox1.Text, "ISBN") && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && valBEdition.validateNum(textBox5.Text, "Book edition") && noOfCps.validateNum(textBox6.Text, "No of copies") && valPrice.validateDecNum(textBox7.Text, "Price"))
            {
                int count = 0;
                string Query = "select * from book where ISBN = '"+ Convert.ToInt32(textBox1.Text) +"'";
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

                if (count == 0)
                {
                    int ISBN = Convert.ToInt32(textBox1.Text);
                    string bName = textBox2.Text;
                    string bSubject = textBox3.Text;
                    string bAuthor = textBox4.Text;
                    int bEdition = Convert.ToInt32(textBox5.Text);
                    int bNoOfCopies = Convert.ToInt32(textBox6.Text);
                    float bPrice = float.Parse(textBox7.Text);

                    Book newBook = new Book();
                    newBook.setBook(ISBN, bName, bSubject, bAuthor, bEdition, bNoOfCopies, bPrice);
                    newBook.addBook();

                    newBook = null;
                    GC.Collect();
                    button2_Click(null, null);
                }
                else
                {
                    MessageBox.Show("The book details already stored");
                }
            }
            else
            {
                MessageBox.Show("Provide all the details");
            }
            valISBN = null;
            valBEdition = null;
            noOfCps = null;
            valPrice = null;

            GC.Collect();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "127";
            textBox2.Text = "Sea shore";
            textBox3.Text = "Story";
            textBox4.Text = "W.A.Williams";
            textBox5.Text = "2003";
            textBox6.Text = "6";
            textBox7.Text = "1255";
        }
    }
    
}
