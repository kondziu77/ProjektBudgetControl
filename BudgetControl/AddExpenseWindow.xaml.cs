using System.Windows;
using System.Windows.Controls;

namespace BudgetControl
{
    public partial class AddExpenseWindow : Window
    {
        public double Amount { get; private set; }
        public string Category { get; private set; } = string.Empty;
        public string Comment { get; private set; } = string.Empty;

        private void CenterWindowOnScreen()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public AddExpenseWindow()
        {
            CenterWindowOnScreen();
            InitializeComponent();
        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(AmountTextBox.Text, out double amount))
            {
                Amount = amount;
                Category = ((ComboBoxItem)CategoryComboBox.SelectedItem).Content.ToString();
                Comment = CommentTextBox.Text;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Podaj prawidłową kwotę.");
            }
        }
    }
}
