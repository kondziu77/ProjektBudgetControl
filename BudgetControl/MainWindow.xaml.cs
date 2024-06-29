using System.Collections.Generic;
using System.Windows;

namespace BudgetControl
{
    public partial class MainWindow : Window
    {
        private void CenterWindowOnScreen()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private List<User> _users;

        public MainWindow()
        {
            CenterWindowOnScreen();
            InitializeComponent();
            _users = new List<User>();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow(_users);
            registerWindow.ShowDialog();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow(_users);
            loginWindow.ShowDialog();
        }
    }
}
