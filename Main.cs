using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class Main : Form
    {
        static String usr;
        public Main()
        {
            InitializeComponent();
            label4.Text = usr;
        }

        public Main(string user)
        {
            InitializeComponent();
            label4.Text = user;
            usr = user;

        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            label4.Text = usr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login ln = new Login();
            ln.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            addBook adB = new addBook();
            adB.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageBooks mngB = new manageBooks();
            mngB.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            addMember adM = new addMember();
            adM.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            manageMembers mngM = new manageMembers();
            mngM.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            issueBook isB = new issueBook();
            isB.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            returnBook retB = new returnBook();
            retB.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            lostBook lb = new lostBook();
            lb.Show();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataBE db = new DataBE();
            this.Hide();
            db.Show();
        }
    }
}
