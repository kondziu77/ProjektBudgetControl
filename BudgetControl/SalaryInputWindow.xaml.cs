using System.Windows;

namespace BudgetControl
{
    public partial class SalaryInputWindow : Window
    {
        private void CenterWindowOnScreen()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private User _loggedInUser;

        public SalaryInputWindow(User user)
        {
            CenterWindowOnScreen();
            InitializeComponent();
            _loggedInUser = user;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(SalaryTextBox.Text, out double salary))
            {
                _loggedInUser.Salary = salary;

                MessageBox.Show("Pensja zapisana!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                BudgetPanelWindow budgetPanelWindow = new BudgetPanelWindow(_loggedInUser);
                budgetPanelWindow.Show();
            }
            else
            {
                MessageBox.Show("Proszę wprowadzić prawidłową kwotę.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
