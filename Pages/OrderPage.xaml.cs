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

namespace Lombard.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DataGridUslugi.ItemsSource = null;
                LombardEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                List<Deal> orders = LombardEntities.GetContext().Deals.OrderBy(p => p.Deal_id).ToList();
                DataGridUslugi.ItemsSource = orders;
            }
        }

        private void DataGridUslugi_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnEdits_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrder = DataGridUslugi.SelectedItems.Cast<Deal>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {selectedOrder.Count()} записей???", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    Deal x = selectedOrder[0];
                    
                    LombardEntities.GetContext().Deals.Remove(x);
                    LombardEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<Deal> orders = LombardEntities.GetContext().Deals.OrderBy(p => p.Deal_id).ToList();
                    DataGridUslugi.ItemsSource = null;
                    DataGridUslugi.ItemsSource = orders;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
