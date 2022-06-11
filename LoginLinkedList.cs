using System;
using System.IO;

namespace StudentManagementSystem
{
    class LoginLinkedList
    {
        private LoginNode head, current;

        public LoginLinkedList()
        {
            head = current = null;
        }

        public void addToLast(string ID, string passWord)
        {
            LoginNode temp = new LoginNode(ID, passWord);

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

        public bool search(string ID, string passWord)
        {
            current = head;

            while (current != null && current.ID != ID)
            {
                current = current.next;
            }

            if (current != null)
            {
                if(current.passWord == passWord)
                {
                    return true;
                }

                else
                {
                    return false;
                }
                
            }

            return false;
        }

        public void addToFile()
        {
            if (head == null)
            {
                //MessageBox.Show("Linkedlist empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            else
            {
                FileStream fileStream = new FileStream("Users.txt", FileMode.Append);  // Creating FileStream object in Create Mode
                StreamWriter writer = new StreamWriter(fileStream); // Creating StreamWriter Object For Reading Files, passing filestream object in its constructor, as StreamWriter class is inherited from FileStream Class
                current = head;

                while (current != null)
                {
                    writer.WriteLine(current.ID);
                    writer.WriteLine(current.passWord);
                    writer.WriteLine("-------------------------");
                    current = current.next;
                }

                writer.Close();
                File.SetAttributes("Users.txt", FileAttributes.Hidden);
            }
        }

        public void readFile()
        {
            if (File.Exists("Users.txt"))
            {
                StreamReader reader = new StreamReader("Users.txt");
                string passWord = "", line = "", ID = "";

                while ((ID = reader.ReadLine()) != null)
                {
                    passWord = reader.ReadLine();
                    addToLast(ID, passWord);
                    line = reader.ReadLine(); // Skipping ----------
                }

                reader.Close();
            }

        }
    }
}
