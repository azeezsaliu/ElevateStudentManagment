using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElevateStudentManagment
{
    public partial class Form1 : Form
    {
        private string Username { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string user = usernameTextBox.Text;
            string pwd = passwordTextBox.Text;

            AdminOperation opr = new AdminOperation();
            Admin admin = opr.GetByUsernameAndPassword(user, pwd);

            if(admin == null)
            {
                MessageBox.Show("Wrong Or Password");
            }
            else
            {
                Username = user;
                this.Hide();
                HomeForm homeForm = new HomeForm(this, user);
                homeForm.ShowDialog();
            }

        }

        private void LoginFormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
