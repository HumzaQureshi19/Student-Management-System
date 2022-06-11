using System;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class SearchForm : Form
    {
        string fileName = "";
        public SearchForm(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName;
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyValue == (char)Keys.Enter)
            {
                if (searchTextBox.Text == string.Empty.Trim())
                {
                    MessageBox.Show("Please Enter ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }

                else
                {
                    LinkedList l1 = new LinkedList();

                    l1.readFile(fileName);
                    l1.searchRecord(searchTextBox.Text);

                    this.Close();
                }
                
            }
        }
    }
}
