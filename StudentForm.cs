using System;
using System.Data; // for using DataTable(DataGridView)
using System.Drawing; // For Printing
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class StudentForm : Form
    {
        DataTable table = new DataTable(); // Creating an Object of DataTable
        string fileName = "";

        public StudentForm(string fileName)
        {
            InitializeComponent();
            this.fileName = fileName; // the user which login his account, the program will save its filename
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure To Logout?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Program.l.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(IDTextBox.Text.Length != 8)
            {
                MessageBox.Show("ID Must Be Of Length 8", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(Convert.ToDecimal(CGPATextBox.Text) > 4)
            {
                MessageBox.Show("CGPA Must Be Less Than 4.0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = NameTextBox.Text;
            string age = AgeTextBox.Text;

            foreach (int i in name)
            {
                if (i >= '0' && i <= '9')
                {
                    MessageBox.Show("Name Must Not Contain Any Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (int i in age)
            {
                if(i >= 'A' && i <= 'Z' || i >= 'a' && i <= 'z')
                {
                    MessageBox.Show("Age Must Not Contain Any Char", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (NameTextBox.Text == string.Empty.Trim() || IDTextBox.Text == string.Empty.Trim() || AgeTextBox.Text == string.Empty.Trim() || SemesterComboBox.Text == string.Empty || DepartmentTextBox.Text == string.Empty.Trim() || CGPATextBox.Text == string.Empty.Trim() || EmailTextBox.Text == string.Empty.Trim())
            {
                MessageBox.Show("Please fill all boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            else
            {
                LinkedList l3 = new LinkedList();

                l3.readFile(fileName);

                if(l3.search(IDTextBox.Text) == true)
                {
                    LinkedList l = new LinkedList();
                    l.readFile(fileName);
                    l.addToLast(IDTextBox.Text, NameTextBox.Text, AgeTextBox.Text, SemesterComboBox.Text, DepartmentTextBox.Text, CGPATextBox.Text, EmailTextBox.Text);
                    l.addToFile(fileName);

                    MessageBox.Show("Record Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IDTextBox.Clear();
                    NameTextBox.Clear();
                    AgeTextBox.Clear();
                    DepartmentTextBox.Clear();
                    CGPATextBox.Clear();
                    EmailTextBox.Clear();
                    IDTextBox.Focus();

                    loadData();
                }
            }

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", typeof(String));
            table.Columns.Add("Name", typeof(String));
            table.Columns.Add("Age", typeof(String));
            table.Columns.Add("Semester", typeof(String));
            table.Columns.Add("Department", typeof(String));
            table.Columns.Add("CGPA", typeof(String));
            table.Columns.Add("Email", typeof(String));
            loadData();
        }

        private void loadData()
        {
            table.Rows.Clear();

            LinkedList l2 = new LinkedList();

            l2.readFile(fileName); // saving all data from file in linkedlist
            l2.forwardTraversal(table); // adding data in table

            StudenDataGridView.DataSource = table; // displaying all the added data in table in DataGridView
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            loadData();

            IDTextBox.Clear();
            NameTextBox.Clear();
            AgeTextBox.Clear();
            DepartmentTextBox.Clear();
            CGPATextBox.Clear();
            EmailTextBox.Clear();
            IDTextBox.Focus();
        }

        private void StudenDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int i = e.RowIndex; // getting current row index

                DataGridViewRow row = StudenDataGridView.Rows[i]; // getting all row data, on that index

                /*Displaying each and every row index data to specific textbox*/
                IDTextBox.Text = row.Cells[0].Value.ToString();
                NameTextBox.Text = row.Cells[1].Value.ToString();
                AgeTextBox.Text = row.Cells[2].Value.ToString();
                SemesterComboBox.Text = row.Cells[3].Value.ToString();
                DepartmentTextBox.Text = row.Cells[4].Value.ToString();
                CGPATextBox.Text = row.Cells[5].Value.ToString();
                EmailTextBox.Text = row.Cells[6].Value.ToString();
            }
            
            catch(Exception)
            {
                // this exception is for, if a user clicks the header row or if row index < 0
                //MessageBox.Show("", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if(NameTextBox.Text == string.Empty.Trim() || IDTextBox.Text == string.Empty.Trim() || AgeTextBox.Text == string.Empty.Trim() || SemesterComboBox.Text == string.Empty || DepartmentTextBox.Text == string.Empty.Trim() || CGPATextBox.Text == string.Empty.Trim() || EmailTextBox.Text == string.Empty.Trim())
            {
                MessageBox.Show("Please fill all boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            else
            {
                LinkedList l3 = new LinkedList();

                l3.readFile(fileName);
                l3.update(IDTextBox.Text, NameTextBox.Text, AgeTextBox.Text, SemesterComboBox.Text, DepartmentTextBox.Text, CGPATextBox.Text, EmailTextBox.Text);
                l3.addToFile(fileName);

                //MessageBox.Show("Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IDTextBox.Clear();
                NameTextBox.Clear();
                AgeTextBox.Clear();
                DepartmentTextBox.Clear();
                CGPATextBox.Clear();
                EmailTextBox.Clear();
                IDTextBox.Focus();
                
                loadData();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == string.Empty.Trim() || IDTextBox.Text == string.Empty.Trim() || AgeTextBox.Text == string.Empty.Trim() || SemesterComboBox.Text == string.Empty || DepartmentTextBox.Text == string.Empty.Trim() || CGPATextBox.Text == string.Empty.Trim() || EmailTextBox.Text == string.Empty.Trim())
            {
                MessageBox.Show("Please fill all boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure To Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(dialogResult == DialogResult.Yes)
                {
                    LinkedList l4 = new LinkedList();

                    l4.readFile(fileName);
                    l4.deleteByID(IDTextBox.Text);
                    l4.addToFile(fileName);

                    MessageBox.Show("Record Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IDTextBox.Clear();
                    NameTextBox.Clear();
                    AgeTextBox.Clear();
                    DepartmentTextBox.Clear();
                    CGPATextBox.Clear();
                    EmailTextBox.Clear();
                    IDTextBox.Focus();

                    loadData();
                }
                
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(fileName);
            searchForm.ShowDialog();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font F = new Font("Yu Gothic UI", 12, FontStyle.Bold); // font
            Brush B = Brushes.Black; // font colour
            int y = 350;
            LinkedList l = new LinkedList();
            l.readFile(fileName);
            l.bubbleSort();
            Node records = l.getHead(); // getting address of first block for traversing

            /* In draw string method, 5 arguments are needed, string, Font, Colour, X-coordinate, Y- coordinate*/
            e.Graphics.DrawImage(Properties.Resources.DSULogo, 300, 1); // Header Image
            e.Graphics.DrawString("ID", F, B, 10, 320);
            e.Graphics.DrawString("NAME", F, B, 100, 320);
            e.Graphics.DrawString("AGE", F, B, 250, 320);
            e.Graphics.DrawString("SEMESTER", F, B, 300, 320);
            e.Graphics.DrawString("DEPART", F, B, 400, 320);
            e.Graphics.DrawString("CGPA", F, B, 520, 320);
            e.Graphics.DrawString("EMAIL", F, B, 640, 320);

            while(records != null)
            {
                e.Graphics.DrawString(records.ID, F, B, 10, y);
                e.Graphics.DrawString(records.name, F, B, 100, y);
                e.Graphics.DrawString(records.age, F, B, 250, y);
                e.Graphics.DrawString(records.semester, F, B, 300, y);
                e.Graphics.DrawString(records.department, F, B, 350, y);
                e.Graphics.DrawString(records.CGPA, F, B, 520, y);
                e.Graphics.DrawString(records.email, F, B, 600, y);
                y = y + 30;
                records = records.next;
            }

            e.Graphics.DrawImage(Properties.Resources.DSUFooter, 240, 960); // Footer Image
        }

        private void SaveButton_MouseEnter(object sender, EventArgs e)
        {
            SaveButton.BackColor = Color.SteelBlue;
        }

        private void SaveButton_MouseLeave(object sender, EventArgs e)
        {
            SaveButton.BackColor = Color.Transparent;
        }

        private void UpdateButton_MouseEnter(object sender, EventArgs e)
        {
            UpdateButton.BackColor = Color.SteelBlue;
        }

        private void UpdateButton_MouseLeave(object sender, EventArgs e)
        {
            UpdateButton.BackColor = Color.Transparent;
        }

        private void DeleteButton_MouseEnter(object sender, EventArgs e)
        {
            DeleteButton.BackColor = Color.SteelBlue;
        }

        private void DeleteButton_MouseLeave(object sender, EventArgs e)
        {
            DeleteButton.BackColor = Color.Transparent;
        }

        private void LoadButton_MouseEnter(object sender, EventArgs e)
        {
            LoadButton.BackColor = Color.SteelBlue;
        }

        private void LoadButton_MouseLeave(object sender, EventArgs e)
        {
            LoadButton.BackColor = Color.Transparent;
        }

        private void searchButton_MouseEnter(object sender, EventArgs e)
        {
            searchButton.BackColor = Color.SteelBlue;
        }

        private void searchButton_MouseLeave(object sender, EventArgs e)
        {
            searchButton.BackColor = Color.Transparent;
        }

        private void printButton_MouseEnter(object sender, EventArgs e)
        {
            printButton.BackColor = Color.SteelBlue;
        }

        private void printButton_MouseLeave(object sender, EventArgs e)
        {
            printButton.BackColor = Color.Transparent;
        }

        private void LogoutButton_MouseEnter(object sender, EventArgs e)
        {
            LogoutButton.BackColor = Color.Red;
        }

        private void LogoutButton_MouseLeave(object sender, EventArgs e)
        {
            LogoutButton.BackColor = Color.Transparent;
        }
    }
}