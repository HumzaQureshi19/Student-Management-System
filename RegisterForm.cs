using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if(isValidated())
            {
                LoginLinkedList l1 = new LoginLinkedList();

                l1.addToLast(UserNameTextBox.Text, PasswordTextBox.Text);
                l1.addToFile();
                FileStream fileStream = new FileStream(UserNameTextBox.Text + ".txt", FileMode.Create);

                MessageBox.Show("Succeesfully Registered", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileStream.Close();
            }
            
        }

        private bool isValidated()
        {
            if (UserNameTextBox.Text == string.Empty.Trim() || PasswordTextBox.Text == string.Empty.Trim() || ReEnterPasswordTextBox.Text == string.Empty.Trim())
            {
                MessageBox.Show("Please Fill All Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserNameTextBox.Clear();
                PasswordTextBox.Clear();
                ReEnterPasswordTextBox.Clear();
                UserNameTextBox.Focus();
                return false;
            }

            else if(PasswordTextBox.Text != ReEnterPasswordTextBox.Text)
            {
                MessageBox.Show("PASSWORD Does Not Match!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordTextBox.Clear();
                ReEnterPasswordTextBox.Clear();
                return false;
            }

            else
            {
                return true;
            }
        }

        private void RegisterButton_MouseEnter(object sender, EventArgs e)
        {
            RegisterButton.BackColor = Color.SteelBlue;
        }

        private void RegisterButton_MouseLeave(object sender, EventArgs e)
        {
            RegisterButton.BackColor = Color.Transparent;
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.SteelBlue;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.BackColor = Color.Transparent;
        }
    }
}
