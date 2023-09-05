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
    public partial class HomeForm : Form
    {
        Form1 logingForm;
        public HomeForm(Form1 loginForm, string user)
        {
            InitializeComponent();
            this.logingForm = loginForm;
            this.usernameLabel.Text = user;
        }

        private void HomeFormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Is Dot Net Perls awesome", "", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            logingForm.Show();
        }
    }
}
