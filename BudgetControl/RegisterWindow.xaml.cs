using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BudgetControl
{
    public partial class RegisterWindow : Window
    {
        private void CenterWindowOnScreen()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private List<User> _users;

        public RegisterWindow(List<User> users)
        {
            CenterWindowOnScreen();
            InitializeComponent();
            _users = users;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = LoginTextBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string email = EmailTextBox.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Hasła nie są zgodne!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_users.Any(u => u.Username == username))
            {
                MessageBox.Show("Użytkownik o takiej nazwie już istnieje!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = new User(username, password, email, 0);
            _users.Add(user);

            MessageBox.Show("Rejestracja zakończona sukcesem! Możesz się teraz zalogować.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
