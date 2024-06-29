namespace BudgetControl
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public double Salary { get; set; }

        public User(string username, string password, string email, double salary)
        {
            Username = username;
            Password = password;
            Email = email;
            Salary = salary;
        }

    }
}
