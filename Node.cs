using System;

namespace StudentManagementSystem
{
    class Node
    {
        public string ID, name, age, semester, department, CGPA, email;

        public Node next; //star issliye nhi hai kyun ke c# mein pass by reference hota hai

        public Node(string ID, string name, string age, string semester, string department, string CGPA, string email //parameterized constructor
        {
            this.ID = ID;
            this.name = name;
            this.age = age;
            this.semester = semester;
            this.department = department;
            this.CGPA = CGPA;
            this.email = email;
            next = null; 
        }

        public Node() { } //Default constructor
    }
}
