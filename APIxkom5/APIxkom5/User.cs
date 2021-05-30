
namespace APIxkom5 {
    public class User {
        private string userName;

        public string UserName {
            get { return userName; }
            set { userName = value; }
        }

        private string email;

        public string Email 
        {
            get { return email; }
            set { email = value; }
        }

        public User(string userName, string email) {
            this.userName = userName;
            this.email = email;
        }
    }
}