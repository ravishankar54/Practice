using System.Windows;

namespace DateCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (dpFrom.SelectedDate.HasValue && dpTo.SelectedDate.HasValue)
            {
                var dateDifference = new DateDifference(dpTo.SelectedDate.Value, dpFrom.SelectedDate.Value);
                lblValue.Content = "Difference between " + dpFrom.SelectedDate.Value.ToShortDateString()
                                    + " and " + dpTo.SelectedDate.Value.ToShortDateString() + " is :\n"
                                    + dateDifference.ToString();
                txtError.Text = "";
            }
            else
            {
                txtError.Text = "Please enter From and To date values.";
                lblValue.Content = "";
            }
        }
    }
}
