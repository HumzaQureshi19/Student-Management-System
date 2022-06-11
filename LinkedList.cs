using System;
using System.IO; // filing
using System.Windows.Forms; // for messagebox, etc
using System.Data; // for DataTable

namespace StudentManagementSystem
{
    class LinkedList
    {
        private Node current, head;

        public LinkedList()
        {
            head = current = null;
        }

        public void addToLast(string ID, string name, string age, string semester, string department, string CGPA, string email)
        {
            Node temp = new Node(ID, name, age, semester, department, CGPA, email);

            if (head == null)
            {
                head = temp;
            }

            else
            {
                current = head;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = temp;
            }
        }

        public void forwardTraversal(DataTable table)
        {
            if (head == null)
            {
               // MessageBox.Show("LinkedList is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                bubbleSort();
                current = head;

                /*Creating New Row Each Time and adding it to table, for displaying in DataGridView*/
                while (current != null)
                {
                    DataRow row = table.NewRow(); // calling new row method
                    row["ID"] = current.ID;
                    row["Name"] = current.name;
                    row["Age"] = current.age;
                    row["Semester"] = current.semester;
                    row["Department"] = current.department;
                    row["CGPA"] = current.CGPA;
                    row["Email"] = current.email;

                    table.Rows.Add(row);
                    current = current.next;
                }
            }
        }

        public bool search(string ID)
        {
            current = head;

            while(current != null && current.ID != ID)
            {
                current = current.next;
            }

            if(current != null)
            {
                MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else
            {
                return true;
            }
        }

        public void searchRecord(string ID)
        {
            current = head;

            while (current != null && current.ID != ID)
            {
                current = current.next;
            }

            if (current != null)
            {
                MessageBox.Show("Name: " + current.name + "\n" + "Age: " + current.age + "\n" + "Semester: " + current.semester + "\n" + "Department: " + current.department + "\n" + "CGPA: " + current.CGPA + "\n" + "Email: " + current.email, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }

            else
            {
                MessageBox.Show("Record Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void update(string ID, string name, string age, string semester, string department, string CGPA, string email)
        {
            current = head;

            while (current != null && current.ID != ID)
            {
                current = current.next;
            }

            if (current != null)
            {
                current.ID = ID;
                current.name = name;
                current.age = age;
                current.semester = semester;
                current.department = department;
                current.CGPA = CGPA;
                current.email = email;
                MessageBox.Show("Record Has Been Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Record Not Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void addToFile(string fileName)
        {
            if (head == null)
            {
                //MessageBox.Show("Linkedlist empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            else
            {
                FileStream fileStream = new FileStream(fileName + ".txt", FileMode.Create);  // Creating FileStream object in Create Mode
                StreamWriter writer = new StreamWriter(fileStream); // Creating StreamWriter Object For Reading Files, passing filestream object in its constructor, as StreamWriter class is inherited from FileStream Class
                current = head;

                while (current != null)
                {
                    writer.WriteLine(current.ID);
                    writer.WriteLine(current.name);
                    writer.WriteLine(current.age);
                    writer.WriteLine(current.semester);
                    writer.WriteLine(current.department);
                    writer.WriteLine(current.CGPA);
                    writer.WriteLine(current.email);
                    writer.WriteLine("-------------------------");
                    current = current.next;
                }

                writer.Close();
            }
        }

        public void readFile(string fileName)
        {
            if(File.Exists(fileName + ".txt"))
            {
                StreamReader reader = new StreamReader(fileName + ".txt");
                string name = "", line = "", ID = "", age = "", semester = "", department = "", CGPA = "", email = "";

                while ((ID = reader.ReadLine()) != null)
                {
                    name = reader.ReadLine();
                    age = reader.ReadLine();
                    semester = reader.ReadLine();
                    department = reader.ReadLine();
                    CGPA = reader.ReadLine();
                    email = reader.ReadLine();
                    addToLast(ID, name, age, semester, department, CGPA, email);
                    line = reader.ReadLine(); // Skipping ----------
                }

                reader.Close();
            }
            
        }

        public void deleteByID(string ID)
        {
            if (head == null)
            {
                MessageBox.Show("No Record Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                Node prev = null;
                current = head;
                bool found = false;

                while (current != null)
                {
                    if (current.ID == ID)
                    {
                        found = true;
                        break;
                    }

                    prev = current;
                    current = current.next;
                }

                if (found == true)
                {
                    if (prev == null)
                    {
                        //temp = current;
                        prev = current.next;
                        head = prev;
                    }

                    else
                    {
                        //temp = current;
                        prev.next = current.next;
                    }
                }

                else
                {
                    MessageBox.Show("No Record Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void bubbleSort()
        {
            if (head == null)
            {
                
            }

            else
            {
                int l = getLength();

                for(int i=0; i<l; i++)
                {
                    Node prev = null;
                    current = head;
                    Node temp = new Node();

                    while(current != null && current.next != null)
                    {
                        if(string.Compare(current.ID, current.next.ID) == 1) // if greater, it returns 1
                        {
                            if(prev == null)
                            {
                                temp = current.next;
                                current.next = temp.next;
                                temp.next = current;
                                head = prev = temp;
                            }

                            else
                            {
                                temp = current.next;
                                prev.next = temp;
                                current.next = temp.next;
                                temp.next = current;
                            }
                        }

                        prev = current;
                        current = current.next;
                    }
                }
            }
        }

        public int getLength()
        {
            int count = 0;
            current = head;

            while(current != null)
            {
                count++;
                current = current.next;
            }

            return count;
        }

        public Node getHead() //function
        {
            return head;
        }

    }
}
