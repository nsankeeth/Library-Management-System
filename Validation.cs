using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    class Validation
    {
        public Validation()
        {

        }
        ~Validation()
        {

        }
        public bool validateNum(string check, string type)
        {
            int temp;
            if (check == "")
            {
                MessageBox.Show(type + " cannot be empty");
                return false;
            }
            else if (!int.TryParse(check, out temp))
            {
                MessageBox.Show(type + " should be numbers");
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool validateDecNum(string check, string type)
        {
            float temp;
            if (check == "")
            {
                MessageBox.Show(type + " cannot be empty");
                return false;
            }
            else if (!float.TryParse(check, out temp))
            {
                MessageBox.Show(type + " should be numbers");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
