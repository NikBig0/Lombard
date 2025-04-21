using System;
using System.Collections.Generic;
using System.IO;
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
using Lombard.Moduls;
using Microsoft.Win32;

namespace Lombard.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddItemPage.xaml
    /// </summary>
    public partial class AddItemPage : Page
    {

        private Item _currentProduct = new Item();
        // путь к файлу
        private string _filePath = null;
        // название текущей главной фотографии
        private string _photoName = null;
        // флаг меняется, если фото товара поменялось
        private bool _photoChanged = false;
        // текущая папка приложения
        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\Images\";

        public AddItemPage( Item selectedProduct)
        {
            InitializeComponent();
            LoadAndInitData(selectedProduct);
        }


        void LoadAndInitData(Item selectedProduct)
        { // если передано null, то мы добавляем новый товар
            if (selectedProduct != null)
            {
                _currentProduct = selectedProduct;
                _filePath = _currentDirectory + _currentProduct.Photo;
            }
            // контекст данных текущий товар
            DataContext = _currentProduct;
            _photoName = _currentProduct.Photo;
            //загрузка в выпалдающие списки
            // категории товаров
            ComboCategory.ItemsSource = LombardEntities.GetContext().Categories.ToList();
            // производители товаров
            ComboManufacturer.ItemsSource =
           LombardEntities.GetContext().Clients.ToList();
            CmbStatus.ItemsSource = LombardEntities.GetContext().ItemStatus.ToList();
        }


        string ChangePhotoName()
        {
            string x = _currentDirectory + _photoName;
            string photoname = _photoName;
            int i = 0;
            if (File.Exists(x))
            {
                while (File.Exists(x))
                {
                    i++;
                    x = _currentDirectory + i.ToString() + photoname;
                }
                photoname = i.ToString() + photoname;
            }
            return photoname;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            // если товар новый, то его ID == 0
            if (_currentProduct.Item_id == 0)
            {
                // добавление нового товара, 
                // формируем новое название файла картинки,
                // так как в папке может быть файл с тем же именем
                if (_filePath != null)
                {
                    string photo = ChangePhotoName();
                    // путь куда нужно скопировать файл
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentProduct.Photo = photo;
                }
                // добавляем товар в БД
                LombardEntities.GetContext().Items.Add(_currentProduct);
            }
            try
            { // если изменилось изображение
                if (_photoChanged)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentProduct.Photo = photo;
                }
                LombardEntities.GetContext().SaveChanges(); // Сохраняем изменения в БД
                MessageBox.Show("Запись Изменена");
                AdminClass.MainFrame.GoBack(); // Возвращаемся на предыдущую форму
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //Диалог открытия файла
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg) | *.jpg | GIF Files(*.gif) | *.gif";
                // диалог вернет true, если файл был открыт
                if (op.ShowDialog() == true)
                {
                    // проверка размера файла
                    // по условию файл дожен быть не более 2Мб.
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (1024 * 1024 * 2))
                    {

                        // размер файла меньше 2Мб. Поэтому выбрасывается новое исключение
                        throw new Exception("Размер файла должен быть меньше 2Мб");
                    }
                    ImagePhoto.Source = new BitmapImage(new Uri(op.FileName));
                    _photoName = op.SafeFileName;
                    _filePath = op.FileName;
                    _photoChanged = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                _filePath = null;
            }

        }
    }
}
