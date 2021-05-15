using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для CurrencyWindow.xaml
    /// </summary>
    public partial class CurrencyWindow : Window
    {
        CurrencyConverter currencyConverter;


        public CurrencyWindow()
        {
            InitializeComponent();           
           
            currencyConverter = new CurrencyConverter();
            List<string> currencyList  = new List<string>(currencyConverter.Currencies.Keys);
            currencyList.Sort();
            ComboBox_CurrencyTo.ItemsSource = currencyList;
            ComboBox_CurrencyFrom.ItemsSource = currencyList;            
        }

       

        private void Button_ConvertCurrency_Click(object sender, RoutedEventArgs e)
        {
            
            double moneyFrom;
            bool isSuccessfull = Double.TryParse(TextBox_CurrencyFrom.Text, out moneyFrom);
            if (!isSuccessfull)
            {
                MessageBox.Show("money is not a number");
                return;
            }
            string currencyFrom = ComboBox_CurrencyFrom.SelectedItem as string;
            string currencyTo = ComboBox_CurrencyTo.SelectedItem as string;
            double moneyTo = moneyFrom * currencyConverter.Currencies[currencyFrom].Rate /
                currencyConverter.Currencies[currencyTo].Rate;
            TextBox_CurrencyTo.Text = moneyTo.ToString();
            
        }
    }
}
