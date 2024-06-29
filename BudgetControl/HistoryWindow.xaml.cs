using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BudgetControl
{
    public partial class HistoryWindow : Window
    {
        private void CenterWindowOnScreen()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private List<Expense> _expenses;
        private BudgetPanelWindow _budgetPanelWindow;

        public HistoryWindow(List<Expense> expenses, BudgetPanelWindow budgetPanelWindow)
        {
            CenterWindowOnScreen();
            InitializeComponent();
            _expenses = expenses;
            _budgetPanelWindow = budgetPanelWindow;
            TransactionsListView.ItemsSource = _expenses;
        }

        private void DeleteTransactionButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Expense expense)
            {
                _expenses.Remove(expense);
                TransactionsListView.Items.Refresh();
                _budgetPanelWindow.UpdateBalance(expense.Amount);
            }
        }

        private void TransactionsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
