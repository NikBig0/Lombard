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
using Lombard.Moduls;

namespace Lombard.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        User _currentUser;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }


        void LoadData()
        {
            _currentUser = AdminClass.CurrentUser;
            if (_currentUser != null)
            {
                TextBlockName.Text = $"Вы вошли как: {_currentUser.FIO}";
            }
            MainFrame.Navigate(new Pages.CatalogPage());
            AdminClass.MainFrame = MainFrame;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            //if (_currentUser == null || _currentUser.Role_ID == 2) // клиент или гость
            //{

            //    if (MainFrame.CanGoBack)
            //    {
            //        BtnBack.Visibility = Visibility.Visible;
            //        BtnEditGoods.Visibility = Visibility.Collapsed;
            //        BtnEditOrders.Visibility = Visibility.Collapsed;
            //    }
            //    else
            //    {
            //        BtnBack.Visibility = Visibility.Collapsed;
            //        BtnEditGoods.Visibility = Visibility.Collapsed;
            //        BtnEditOrders.Visibility = Visibility.Collapsed;
            //    }
            //    return;
            //}
            if (_currentUser.Role_ID == 2) // менеджер
            {
                if (MainFrame.CanGoBack)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    BtnEditGoods.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnEditGoods.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Visible;
                }
                return;
            }
            if (_currentUser.Role_ID == 1) // админ
            {
                if (MainFrame.CanGoBack)
                {
                    BtnBack.Visibility = Visibility.Visible;
                    BtnEditGoods.Visibility = Visibility.Collapsed;
                    BtnEditOrders.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnEditGoods.Visibility = Visibility.Visible;
                    BtnEditOrders.Visibility = Visibility.Visible;
                }
                return;
            }
        }

        private void BtnEditGoods_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.ItemPage());
        }

        private void BtnEditOrders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.OrderPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.GoBack();
        }

        private void BtnAvtoriz_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
        }
    }
}
