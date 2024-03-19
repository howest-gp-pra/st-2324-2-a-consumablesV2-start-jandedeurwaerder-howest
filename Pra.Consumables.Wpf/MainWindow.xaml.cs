using Pra.Consumables.Core.Entities;
using Pra.Consumables.Core.Enums;
using Pra.Consumables.Core.Services;
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
        ConsumableService consumableService = new ConsumableService();
        bool isNew;
        Type type;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayConsumables();
            DisplayHealthLabels();
            EnableLeft();
            ClearControls();
        }
        private void LstConsumables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grdFood.Visibility = Visibility.Hidden;
            grdBeverage.Visibility = Visibility.Hidden;
            if(lstConsumables.SelectedItem != null)
            {
                Consumable consumable = (Consumable)lstConsumables.SelectedItem;
                txtDescription.Text = consumable.Description;
                txtUnit.Text = consumable.Unit;
                txtPricePerUnit.Text = consumable.PricePerUnit.ToString();
                if(consumable is Food)
                {
                    grdFood.Visibility = Visibility.Visible;
                    Food food = (Food)consumable;
                    lstHealthLabel.SelectedIndex = (int)food.HealthLabel;
                }
                if(consumable is Beverage)
                {
                    grdBeverage.Visibility = Visibility.Visible;
                    chkAlcohol.IsChecked = ((Beverage)consumable).IsAlcoholic;
                }
            }
        }

        private void BtnNewFood_Click(object sender, RoutedEventArgs e)
        {
            EnableRight();
            ClearControls();
            grdBeverage.Visibility = Visibility.Hidden;
            grdFood.Visibility = Visibility.Visible;
            txtUnit.IsEnabled = true;
            isNew = true;
            type = typeof(Food);
            txtDescription.Focus();
        }
        private void BtnNewBeverage_Click(object sender, RoutedEventArgs e)
        {
            EnableRight();
            ClearControls();
            grdBeverage.Visibility = Visibility.Visible;
            grdFood.Visibility = Visibility.Hidden;
            txtUnit.IsEnabled = false;
            txtUnit.Text = "cl.";
            isNew = true;
            type = typeof(Beverage);
            txtDescription.Focus();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(lstConsumables.SelectedItem != null)
            {
                EnableRight();
                isNew = false;
                Consumable consumable = (Consumable)lstConsumables.SelectedItem;
                type = consumable.GetType();
                //if (type == typeof(Beverage))
                if (consumable is Beverage)
                    txtUnit.IsEnabled = false;
                else
                    txtUnit.IsEnabled = true;
                txtDescription.Focus();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstConsumables.SelectedItem == null) return;
            if(MessageBox.Show("Zeker?","Wissen",MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Consumable consumable = (Consumable)lstConsumables.SelectedItem;
                consumableService.Delete(consumable);
                ClearControls();
                DisplayConsumables();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string description = txtDescription.Text.Trim();
            if(description.Length == 0)
            {
                ShowErrorMessage("Beschrijving opgeven", txtDescription);
                return;
            }
            string unit = txtUnit.Text.Trim();
            decimal.TryParse(txtPricePerUnit.Text, out decimal pricePerUnit);
            if(pricePerUnit <= 0m)
            {
                ShowErrorMessage("Prijs opgeven", txtPricePerUnit);
                return;
            }

            Consumable selectConsumable=null;

            if(isNew)
            {
                if(type == typeof(Beverage))
                {
                    bool isAlcohol = (bool)chkAlcohol.IsChecked;
                    Beverage beverage = new Beverage(description, pricePerUnit, isAlcohol);
                    consumableService.Insert(beverage);
                    selectConsumable = beverage;
                }
                if(type == typeof(Food))
                {
                    if(lstHealthLabel.SelectedItem == null)
                    {
                        ShowErrorMessage("Gezondheidslabel selecteren", lstHealthLabel);
                        return;
                    }
                    HealthLabel healthLabel = (HealthLabel)lstHealthLabel.SelectedIndex;
                    Food food = new Food(description, pricePerUnit, healthLabel, unit);
                    consumableService.Insert(food);
                    selectConsumable = food;
                }
            }
            else
            {
                if(type == typeof(Beverage))
                {
                    bool isAlcohol = (bool)chkAlcohol.IsChecked;
                    Beverage beverage = (Beverage)lstConsumables.SelectedItem;
                    beverage.Description = description;
                    beverage.PricePerUnit = pricePerUnit;
                    beverage.IsAlcoholic = isAlcohol;
                    selectConsumable = beverage;
                }
                if(type == typeof(Food))
                {
                    if (lstHealthLabel.SelectedItem == null)
                    {
                        ShowErrorMessage("Gezondheidslabel selecteren", lstHealthLabel);
                        return;
                    }
                    HealthLabel healthLabel = (HealthLabel)lstHealthLabel.SelectedIndex;
                    Food food = (Food)lstConsumables.SelectedItem;
                    food.Description = description;
                    food.PricePerUnit = pricePerUnit;
                    food.Unit = unit;
                    food.HealthLabel = healthLabel;
                    selectConsumable = food;
                }
            }
            DisplayConsumables();
            EnableLeft();
            lstConsumables.SelectedItem = selectConsumable;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            EnableLeft();
            ClearControls();
            LstConsumables_SelectionChanged(null, null);
        }

        private void DisplayConsumables()        
        {
            lstConsumables.ItemsSource = consumableService.Consumables;
            lstConsumables.Items.Refresh();
        }
        private void DisplayHealthLabels()
        {
            lstHealthLabel.ItemsSource = Enum.GetValues(typeof(HealthLabel));
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
