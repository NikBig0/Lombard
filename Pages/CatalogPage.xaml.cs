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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lombard.Windows;

namespace Lombard.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {

        int _itemcount = 0; // 
        Item _selectedProduct = null;

        public CatalogPage()
        {
            InitializeComponent();
            LoadAndInitData();
        }

        void LoadAndInitData()
        {

            // загрузка данных в listview сортируем по названию
            ListBoxProducts.ItemsSource =
           LombardEntities.GetContext().Items.OrderBy(p => p.Item_Name).ToList();
            _itemcount = ListBoxProducts.Items.Count;
            // скрываем кнопки корзины
            BtnBasket.Visibility = Visibility.Collapsed;
            TextBlockBasketInfo.Visibility = Visibility.Collapsed;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {_itemcount} записей из {_itemcount}";
            BasketClass.ClearBasket();


        }

        private void UpdateData()
        {

            // получаем текущие данные из бд
            var currentGoods = LombardEntities.GetContext().Items.OrderBy(p =>
           p.Item_Name).ToList();
            
            // выбор тех товаров, в названии которых есть поисковая строка
            currentGoods = currentGoods.Where(p =>
           p.Item_Name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            // сортировка
            if (ComboSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0)
                    currentGoods = currentGoods.OrderBy(p => p.evaluation_cost).ToList();
                // сортировка по убыванию цены
                if (ComboSort.SelectedIndex == 1)
                    currentGoods = currentGoods.OrderByDescending(p =>
                   p.evaluation_cost).ToList();
            }
            // В качестве источника данных присваиваем список данных
            ListBoxProducts.ItemsSource = currentGoods;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {currentGoods.Count} записей из {_itemcount}";


        }


        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {

                LombardEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p =>
                p.Reload());
                ListBoxProducts.ItemsSource =
               LombardEntities.GetContext().Items.OrderBy(p => p.Item_Name).ToList();
            }
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtnBasket_Click(object sender, RoutedEventArgs e)
        {
            NewOrderWindow newOrderWindow = new NewOrderWindow();
            newOrderWindow.ShowDialog();
            if (BasketClass.GetCount > 0)
            {
                BtnBasket.Visibility = Visibility.Visible;

                TextBlockBasketInfo.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBasket.Visibility = Visibility.Collapsed;
                TextBlockBasketInfo.Visibility = Visibility.Collapsed;
            }
        }

        private void ListBoxProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //получаем всех выделенный товар
            _selectedProduct = null;
            var selected = ListBoxProducts.SelectedItems.Cast<Item>().ToList();
            if (selected.Count == 0) return;
            _selectedProduct = selected[0];
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // контекстное меню по нажатию правой кнопки мыши
            // если товар не выбран, завершаем работу
            if (_selectedProduct == null)
                return;
            // добавляем товар в корзину
            BasketClass.AddProductInBasket(_selectedProduct);
            // отображаем кнопку и текстовое поле
            if (BasketClass.GetCount > 0)
            {
                BtnBasket.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Text = $"В корзине {BasketClass.GetCount} товаров";
            }
        }
    }
}
