using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Lombard.Moduls;
using Brushes = System.Drawing.Brushes;

namespace Lombard.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        // Переменная флаг, меняет свое значение, 
        // если пользователь не смог ввести с первого раза пароль и логин
        // если b == true, то отобразим капчу
        bool b = false;
        // таймер
        DispatcherTimer timer = new DispatcherTimer();
        int seconds = 0; // секунды
        string captcha = ""; // текст капчи


        public LoginWindow()
        {
            InitializeComponent();
            LoadAndInitData();
        }


        void LoadAndInitData()
        {
            this.Height = 200; // задаем высоту окна
            timer.Tick += timer_Tick;
            // скрываем строки с капчой
            RowCaptcha1.Height = new GridLength(0);
            RowCaptcha2.Height = new GridLength(0);
            TbLogin.Text = "Login1";
            TbPass.Password = "Pass1";
        }
        // обаботчик события срабатывает через каждые т секунд
        void timer_Tick(object sender, EventArgs e)
        {
            seconds -= 1;
            TextBlockTime.Text = $"Осталось {seconds} секунд до разблокировки";
            if (seconds == 0) // оставливаем таймер, разблокировываем кнопку
            {

                BtnOk.IsEnabled = true;
                TextBlockTime.Text = "";
                timer.Stop();
            }

        }

        void ShowCaptcha()
        {
            // из класса MakeCaptcha вызываем метод CreateImage
            var tuple = MakeCaptchaClass.CreateImage(300, 100, 5);
            // получаем ImageSource
            ImageCaptcha.Source = tuple.image;
            // получаем текст капчи
            captcha = tuple.captcha;
        }

        private void BtnRenewCaptcha_Click(object sender, RoutedEventArgs e)
        {
            ShowCaptcha();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            { //загрузка всех пользователей из БД в список
                List<User> users = LombardEntities.GetContext().Users.ToList();
                //попытка найти пользователя с указанным паролем и логином

                User user = users.FirstOrDefault(p => p.UserPassword == TbPass.Password && p.UserLogin == TbLogin.Text);
                // удачный вход после ввода пароля и логина или пароля, логина и капчи
                if ((user != null && !b) || (user != null && b && TbCaptcha.Text == captcha))
                {

                    AdminClass.CurrentUser = user;
                    // логин и пароль корректные запускаем главную форму приложения
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Owner = this;
                    this.Hide();// скрываем форму авторизации
                    mainWindow.Show();

                }
                else
                {
                    MessageBox.Show("Не верный логин или пароль");
                    // меняем высоту формы
                    this.Height = 350;
                    // вызываем метод отображения капчи
                    ShowCaptcha();
                    if (b) // если неправильно ввели логин, пароль и капчу 
                    {

                        timer.Interval = TimeSpan.FromSeconds(1);
                        // блокируем кнопку
                        BtnOk.IsEnabled = false;
                        // на 10 секунд
                        seconds = 10;
                        // отображает сколько секунд осталось до разблокировки
                        TextBlockTime.Text = $"Осталось {seconds} секунд до разблокировки";
                        // включаем таймер
                        timer.Start();
                    }
                    b = true;
                    RowCaptcha1.Height = new GridLength(34);
                    RowCaptcha2.Height = new GridLength(1, GridUnitType.Star);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
