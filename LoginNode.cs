namespace StudentManagementSystem
{
    class LoginNode
    {
        public string ID, passWord;

        public LoginNode next;

        public LoginNode()
        {
            ID = passWord = "";
            next = null;
        }

        public LoginNode(string ID, string passWord)
        {
            this.ID = ID;
            this.passWord = passWord;
            next = null;
        }
    }
}
