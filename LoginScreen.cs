using System;
using System.Drawing;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class LoginScreen : Form
    {

        public LoginScreen()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            /* DialogResult dialogResult = MessageBox.Show("Are You Sure Want To Exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

             if(dialogResult == DialogResult.Yes)
             {
                 Application.Exit();
             }*/
            this.Dispose();
            Application.Exit();
        }

        private void LoginScreen_VisibleChanged(object sender, EventArgs e)
        {
            UserTextBox.Clear();
            PasswordTextBox.Clear();
            UserTextBox.Focus();
        }

        private void SignInButton_Click_1(object sender, EventArgs e)
        {
            if(isValidated())
            {
                StudentForm f = new StudentForm(UserTextBox.Text);
                this.Hide();
                f.Show();
            }

            else
            {
                MessageBox.Show("USERNAME OR PASSWORD INCORRECT", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserTextBox.Clear();
                PasswordTextBox.Clear();
                UserTextBox.Focus();
            }
        }

        private bool isValidated()
        {
            if (UserTextBox.Text == string.Empty.Trim() || PasswordTextBox.Text == string.Empty.Trim())
            {
                return false;
            }

            LoginLinkedList l1 = new LoginLinkedList();
            l1.readFile();

            if(l1.search(UserTextBox.Text, PasswordTextBox.Text) == true)
            {
                return true;
            }

            else
            {
                return false;
            }
          
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void SignInButton_MouseEnter(object sender, EventArgs e)
        {
            SignInButton.BackColor = Color.SteelBlue;
        }

        private void SignInButton_MouseLeave(object sender, EventArgs e)
        {
            SignInButton.BackColor = Color.Transparent;
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.Red;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.BackColor = Color.Transparent;
        }

        private void signUpButton_MouseEnter(object sender, EventArgs e)
        {
            signUpButton.BackColor = Color.SteelBlue;
        }

        private void signUpButton_MouseLeave(object sender, EventArgs e)
        {
            signUpButton.BackColor = Color.Transparent;
        }
    }
}