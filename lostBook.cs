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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace Library_Management_System
{
    public partial class lostBook : Form
    {
        DateTime bDate;
        Double rtCharge;
        SqlConnection conn;
        public lostBook()
        {
            InitializeComponent();
            conn = ConnectionManager.GetConnection();
            groupBox4.Hide();
            button5.Enabled = false;
        }

        private void lostBook_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mn = new Main();
            mn.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);

                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\vithu\\Documents\\Visual Studio 2015\\Projects\\ITPProject\\ITPProject\\bin\\Debug\\Receipt.pdf", FileMode.Create));
                doc.Open();
                
                iTextSharp.text.Image JPG = iTextSharp.text.Image.GetInstance("C:\\Users\\vithu\\Documents\\Visual Studio 2015\\Projects\\ITPProject\\ITPProject\\bin\\Debug\\Banner.jpg");
                JPG.ScalePercent(24f);
                JPG.Border = iTextSharp.text.Rectangle.BOX;
                JPG.BorderColor = iTextSharp.text.BaseColor.BLACK;
                JPG.BorderWidth = 8f;
                doc.Add(JPG);

                Paragraph paragraph = new Paragraph();
                paragraph.Add(new Chunk("\n"));
                doc.Add(paragraph);




                Paragraph paragraph3 = new Paragraph();
                paragraph3.Alignment = Element.ALIGN_LEFT;
                paragraph3.Add(new Chunk("Member ID : "));
                paragraph3.Add(Chunk.TABBING);
                paragraph3.Add(Chunk.TABBING);
                paragraph3.Add(new Chunk(label4.Text));

                Paragraph paragraph4 = new Paragraph();
                paragraph4.Alignment = Element.ALIGN_LEFT;
                paragraph4.Add(new Chunk("Borrowed Date : "));
                paragraph4.Add(Chunk.TABBING);
                paragraph4.Add(new Chunk(label3.Text));

                Paragraph paragraph5 = new Paragraph();
                paragraph5.Alignment = Element.ALIGN_LEFT;
                paragraph5.Add(new Chunk("ISBN : "));
                paragraph5.Add(Chunk.TABBING);
                paragraph5.Add(Chunk.TABBING);
                paragraph5.Add(new Chunk(label25.Text));

                Paragraph paragraph6 = new Paragraph();
                paragraph6.Alignment = Element.ALIGN_LEFT;
                paragraph6.Add(new Chunk("Book Name : "));
                paragraph6.Add(Chunk.TABBING);
                paragraph6.Add(new Chunk(label26.Text));

                Paragraph paragraph7 = new Paragraph();
                paragraph7.Alignment = Element.ALIGN_LEFT;
                paragraph7.Add(new Chunk("Subject : "));
                paragraph7.Add(Chunk.TABBING);
                paragraph7.Add(Chunk.TABBING);
                paragraph7.Add(new Chunk(label27.Text));

                Paragraph paragraph8 = new Paragraph();
                paragraph8.Alignment = Element.ALIGN_LEFT;
                paragraph8.Add(new Chunk("Author : "));
                paragraph8.Add(Chunk.TABBING);
                paragraph8.Add(Chunk.TABBING);
                paragraph8.Add(new Chunk(label28.Text));

                Paragraph paragraph9 = new Paragraph();
                paragraph9.Alignment = Element.ALIGN_LEFT;
                paragraph9.Add(new Chunk("Edition : "));
                paragraph9.Add(Chunk.TABBING);
                paragraph9.Add(Chunk.TABBING);
                paragraph9.Add(new Chunk(label29.Text));

                Paragraph paragraph10 = new Paragraph();
                paragraph10.Alignment = Element.ALIGN_LEFT;
                paragraph10.Add(new Chunk("Price : "));
                paragraph10.Add(Chunk.TABBING);
                paragraph10.Add(Chunk.TABBING);
                paragraph10.Add(new Chunk(label31.Text));

                Paragraph paragraphb = new Paragraph();
                paragraphb.Add(new Chunk("\n"));
                doc.Add(paragraphb);

                Paragraph paragraph11 = new Paragraph();
                paragraph11.Alignment = Element.ALIGN_LEFT;
                paragraph11.Add(new Chunk("Total Fine : "));
                paragraph11.Add(Chunk.TABBING);
                paragraph11.Add(Chunk.TABBING);
                paragraph11.Add(new Chunk(label2.Text));



                doc.Add(paragraph);
                doc.Add(paragraph3);
                doc.Add(paragraph4);
                doc.Add(paragraph5);
                doc.Add(paragraph6);
                doc.Add(paragraph7);
                doc.Add(paragraph8);
                doc.Add(paragraph9);
                doc.Add(paragraph10);


                Paragraph paragraphb1 = new Paragraph();
                paragraphb1.Add(new Chunk("\n"));
                doc.Add(paragraphb1);

                Paragraph paragraphb2 = new Paragraph();
                paragraphb2.Add(new Chunk("\n"));
                doc.Add(paragraphb2);

                doc.Add(paragraph11);

                Paragraph paragraph2 = new Paragraph();
                paragraph2.Alignment = Element.ALIGN_RIGHT;
                paragraph2.Add(new Chunk("Printed as at " + DateTime.Now.ToString("dd/MM/yyyy" + " on " + "hh:mm tt")));
                doc.Add(paragraph2);
                doc.Close();
                MessageBox.Show("Document Saved");
                System.Diagnostics.Process.Start("C:\\Users\\vithu\\Documents\\Visual Studio 2015\\Projects\\ITPProject\\ITPProject\\bin\\Debug\\Receipt.pdf");

            }catch(Exception ex)
            {
                MessageBox.Show("The Receipt is already open");
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            Validation val = new Validation();
            if (val.validateNum(textBox1.Text, "Member ID"))
            {
                string Query = "select * from book b, borrow bw where b.ISBN = bw.ISBN and bw.mID = '" + Convert.ToInt32(textBox1.Text) + "'";
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader reader;
                try
                {
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count++;
                        label4.Text = reader["mID"].ToString();
                        label3.Text = reader.GetDateTime(9).Date.ToString("yyyy-MM-dd");
                        label25.Text = reader["ISBN"].ToString();
                        label26.Text = reader["bName"].ToString();
                        label27.Text = reader["bSubject"].ToString();
                        label28.Text = reader["author"].ToString();
                        label29.Text = reader["edition"].ToString();
                        label30.Text = reader["noOfCopies"].ToString();
                        label31.Text = reader["price"].ToString();

                        bDate = reader.GetDateTime(9);
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Member has no book");
                }

                if (count != 0)
                {
                    DateTime dNow = DateTime.Now.Date;
                    Double totDays = (dNow - bDate).TotalDays;
                    if (totDays > 5)
                    {
                        rtCharge = (totDays - 5) * 50;
                    }
                    else
                    {
                        rtCharge = 0;
                    }
                    Double totFine = rtCharge + Convert.ToDouble(label31.Text);

                    label2.Text = Convert.ToString(totFine);
                    button5.Enabled = true;
                    groupBox4.Show();
                }
                else
                {
                    MessageBox.Show("Member has no book");
                }
            }
            val = null;
            GC.Collect();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Query = "INSERT INTO bLost(ISBN, bName, mID, bDate, lDate, fine) VALUES('" + Convert.ToInt32(label25.Text) + "', '" + label26.Text + "', '" + Convert.ToInt32(label4.Text) + "', '" + Convert.ToDateTime(label3.Text).ToString("yyyy-MM-dd") + "', '" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "', '" + float.Parse(label2.Text) + "')";
            SqlCommand cmdDb = new SqlCommand(Query, conn); ;
            try
            {
                conn.Open();
                cmdDb.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Recorded Successfully");

                string Query1 = "DELETE FROM borrow WHERE mID = '" + label4.Text + "' and ISBN = '" + label25.Text + "'";
                SqlCommand cmdDb1 = new SqlCommand(Query1, conn); ;
                try
                {
                    conn.Open();
                    cmdDb1.ExecuteNonQuery();
                    conn.Close();
                }
                catch(Exception ex)
                {

                }
                MessageBox.Show("Printing Receipt....");
                button5.PerformClick();
                button5.Enabled = false;
                groupBox4.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Add");
            }
        }
    }
}
