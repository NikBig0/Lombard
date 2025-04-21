using Lombard.Moduls;
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
using System.Windows.Shapes;

namespace Lombard.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {

        Deal _currentOrder;
        User _currentUser;

        public NewOrderWindow()
        {
            InitializeComponent();
            LoadDataAndInit();
        }


        void LoadDataAndInit()
        {
            // источник данных корзина
            ListBoxOrderProducts.ItemsSource = BasketClass.GetBasket;
            // создаем новый заказ
            _currentOrder = CreateNewOrder();
            // текущий пользователь
            _currentUser = AdminClass.CurrentUser;
            if (_currentUser != null)
            {
                TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.Deal_id} на имя " + $"{_currentUser.FIO}";
            }
            else
            {
                TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.Deal_id}";
            }
            TextBlockTotalCost.Text = $"Итого {BasketClass.GetTotalCost:C}";
            TextBlockOrderCreateDate.Text = _currentOrder.Date.ToString();
            CmbBuyer.ItemsSource = LombardEntities.GetContext().Clients.ToList();
            //Seller.Text = _currentOrder.Client1.ToString();
            //CmbEmploer.ItemsSource = LombardEntities.GetContext().Users.ToList();

        }

        static Deal CreateNewOrder()
        {

            Deal order = new Deal();
            order.Deal_id = LombardEntities.GetContext().Deals.Max(p => p.Deal_id) + 1; ;
            order.Date = DateTime.Now;
            return order;

        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) // при нажатии на кнопку Enter
            {
                TextBox textBox = sender as TextBox;
                int k = ListBoxOrderProducts.SelectedIndex;
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    int x = 0;
                    if (!int.TryParse(textBox.Text, out x))
                    {
                        MessageBox.Show("Количество только число");
                        return;
                    }
                    x = Convert.ToInt32(textBox.Text);
                    if (x < 0)
                    {
                        MessageBox.Show("Количество не может быть отрицательным");
                    }
                    else if (x == 0)
                    {
                        Item product = textBox.Tag as Item;
                        MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {product.Item_Name} из корзины??? ", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (messageBoxResult == MessageBoxResult.OK)
                        {

                            BasketClass.DeleteProductFromBasket(product);
                            ListBoxOrderProducts.Items.Refresh();
                            ListBoxOrderProducts.SelectedIndex = k;
                        }
                    }
                    else
                    {
                        Item product = textBox.Tag as Item;
                        BasketClass.SetCount(product, x);
                        ListBoxOrderProducts.Items.Refresh();
                        ListBoxOrderProducts.SelectedIndex = k;
                    }
                }
            }
            if (e.Key == Key.Escape) // клавиша ESC
            {
                int k = ListBoxOrderProducts.SelectedIndex;
                ListBoxOrderProducts.Items.Refresh();
                ListBoxOrderProducts.SelectedIndex = k;
            }
            TextBlockTotalCost.Text = $"Итого {BasketClass.GetTotalCost:C}";
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???",
           "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                if (ListBoxOrderProducts.SelectedIndex >= 0)
                {
                    var x = (ListBoxOrderProducts.SelectedValue as Item);
                    BasketClass.DeleteProductFromBasket(x);
                    ListBoxOrderProducts.Items.Refresh();
                    TextBlockTotalCost.Text = $"Итого {BasketClass.GetTotalCost:C}";
                }
            }
        }

        private void BtnBuyItem_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult messageBoxResult = MessageBox.Show($"Оформить покупку???",
            "Оформление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                

                // добавляем товар
                LombardEntities.GetContext().Deals.Add(_currentOrder);
                //формируем данные в OrderProduct (товары заказа)
                foreach (var item in BasketClass.GetBasket)
                {
                    _currentOrder.Item_ID = item.Key.Item_id;
                    _currentOrder.Cost = item.Key.evaluation_cost;
                    _currentOrder.Buyer_ID = item.Key.Client_ID;
                    


                    Item product = LombardEntities.GetContext().Items.FirstOrDefault(p =>
                    p.Item_id == item.Key.Item_id);
                    if (item.Value.Count >= product.Count)
                        product.Count = 0;
                    else product.Count = item.Value.Count;

                }
                LombardEntities.GetContext().SaveChanges(); // Сохраняем изменения в БД
                                                             

                BasketClass.ClearBasket();
                this.Close();
            }
        }
    }
}

