using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library_Management_System
{
    class Book
    {
        int ISBN;
        string name;
        string subject;
        string author;
        int edition;
        int noOfCopies;
        float price;

        public Book()
        {

        }
        ~Book()
        {
            
        }
        SqlConnection conn = ConnectionManager.GetConnection();
        public void setBook(int bISBN, string bname, string bsubject,string bauthor, int bedition, int bnoOfCopies, float bprice)
        {
            ISBN = bISBN;
            name = bname;
            subject = bsubject;
            author = bauthor;
            edition = bedition;
            noOfCopies = bnoOfCopies;
            price = bprice;
        }
        public void addBook()
        {
            string Query = "INSERT INTO book(ISBN, bName, bSubject, price, author, edition, noOfCopies) VALUES('" + ISBN + "', '" + name + "', '" + subject + "', '" + price + "', '" + author + "', '" + edition + "', '" + noOfCopies + "')";
            SqlCommand cmdDb = new SqlCommand(Query, conn); ;
            try
            {
                conn.Open();
                cmdDb.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Book Successfully Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Failed to Add");
            }
        }
        public void deleteBook(int bISBN)
        {
            string Query = "DELETE FROM book WHERE ISBN = '" + bISBN + "'";
            SqlCommand cmdDb = new SqlCommand(Query, conn); ;
            try
            {
                conn.Open();
                cmdDb.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Book Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete!!! Book currently borrowed by a member");
            }
        }
        public void updateBook()
        {
            string Query = "UPDATE book SET bName = '" + name + "', bSubject = '" + subject + "', price = '" + price + "', author = '" + author + "', edition = '" + edition + "', noOfCopies = '" + noOfCopies + "' WHERE ISBN = '" + ISBN + "'";
            SqlCommand cmdDb = new SqlCommand(Query, conn); ;
            try
            {
                conn.Open();
                cmdDb.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Book Successfully Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Update");
            }
        }
    }
}
