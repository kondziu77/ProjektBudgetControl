using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BudgetControl
{
    public partial class LoginWindow : Window
    {
        private void CenterWindowOnScreen()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private List<User> _users;

        public LoginWindow(List<User> users)
        {
            InitializeComponent();
            CenterWindowOnScreen();
            _users = users;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginTextBox.Text;
            string password = PasswordBox.Password;

            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                MessageBox.Show($"Zalogowano jako {user.Username}", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                SalaryInputWindow salaryInputWindow = new SalaryInputWindow(user);
                salaryInputWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Błędna nazwa użytkownika lub hasło!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
