using System.Collections.Generic;
using System.Windows;

namespace BudgetControl
{
    public partial class BudgetPanelWindow : Window
    {
        private void CenterWindowOnScreen()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private User _user;
        private List<Expense> _expenses;

        public BudgetPanelWindow(User user)
        {
            CenterWindowOnScreen();
            InitializeComponent();
            _user = user;
            _expenses = new List<Expense>();

            WelcomeTextBlock.Text = $"Witaj, {_user.Username}!";
            SalaryTextBlock.Text = $"Stan konta: {_user.Salary:C}";
        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            var addExpenseWindow = new AddExpenseWindow();
            if (addExpenseWindow.ShowDialog() == true)
            {
                var expense = new Expense(addExpenseWindow.Amount, addExpenseWindow.Category, addExpenseWindow.Comment);
                if (expense.Amount > _user.Salary)
                {
                    MessageBox.Show("Podana kwota wydatku przekracza aktualny stan konta!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                _expenses.Add(expense);
                _user.Salary -= expense.Amount;
                UpdateBalance(0);
            }
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            var historyWindow = new HistoryWindow(_expenses, this);
            historyWindow.Show();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Do widzenia, {_user.Username}!", "Wylogowano", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        public void UpdateBalance(double amount)
        {
            _user.Salary += amount;
            SalaryTextBlock.Text = $"Stan konta: {_user.Salary:C}";
        }
    }

    public class Expense
    {
        public double Amount { get; }
        public string Category { get; }
        public string Comment { get; }
        public DateTime Date { get; }

        public Expense(double amount, string category, string comment)
        {
            Amount = amount;
            Category = category;
            Comment = comment;
            Date = DateTime.Now;
        }
    }
}
