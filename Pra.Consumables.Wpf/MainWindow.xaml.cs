using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pra.Consumables.Wpf
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void LstConsumables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void BtnNewFood_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnNewBeverage_Click(object sender, RoutedEventArgs e)
        {
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
        }

        private void DisplayConsumables()        {

        }
        private void DisplayHealthLabels()
        {
        }
        private void EnableLeft()
        {
            grpMain.IsEnabled = true;
            grpDetails.IsEnabled = false;
        }
        private void EnableRight()
        {
            grpMain.IsEnabled = false;
            grpDetails.IsEnabled = true;
        }
        private void ClearControls()
        {
            txtDescription.Clear();
            txtPricePerUnit.Clear();
            txtUnit.Clear();
            chkAlcohol.IsChecked = false;
            lstHealthLabel.SelectedIndex = -1;
            grdFood.Visibility = Visibility.Hidden;
            grdBeverage.Visibility = Visibility.Hidden;
        }
        private void ShowErrorMessage(string message, Control control)
        {
            MessageBox.Show(message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            control.Focus();            
        }
    }
}
