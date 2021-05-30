
using System.Collections.Generic;

namespace APIxkom5
    {
    public class Meeting {
       
        private List<User> users = new List<User>(); 
        private const int quantityMaxUser = 25;
        private string name;

        public string Name 
            {
            get { return name; }
            set { name = value; }
        }

        public bool AddUser(User user) 
        {
            if (quantityMaxUser > users.Count) {
                users.Add(user);
                return true;
            }
            return false;
        }

        public Meeting(string name) {
            this.name = name;
        }

        public override string ToString() {
            string result = " " + name + "\n";
            int index = 1;
            foreach (User u in users) 
            {
                result += "[" + index + "] Name = " + u.UserName + " Email = " + u.Email + "\n";
                index++;
            }

            return result;
        }
    }
}