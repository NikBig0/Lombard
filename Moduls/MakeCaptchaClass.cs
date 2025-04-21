using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lombard.Moduls
{
    public class MakeCaptchaClass
    {

        /// <summary>
        /// Генерирует картинку, содержащую текст капчи
        /// </summary>
        /// <param name="width">ширина изображения</param>
        /// <param name="height">высота изображения</param>
        /// <param name="symbolCount">длина капчи</param>
        /// <returns>возвращает картинку и текст капчи</returns>
        public static (BitmapImage image, string captcha) CreateImage(int width, int
       height, int symbolCount)
        {
            Random rnd = new Random();
            //Создадим изображение
            Bitmap result = new Bitmap(width, height);
            //Добавим различные цвета
            Brush[] colors = { Brushes.Black,
            Brushes.Red,
            Brushes.RoyalBlue,
            Brushes.Green };
            //Укажем где рисовать
            Graphics g = Graphics.FromImage((System.Drawing.Image)result);
            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);
            //Сгенерируем текст
            char symbol;
            // нбор допустимых символов
            string alphabet = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            // текст капчи
            string captcha = "";
            // размер поля для одного символа
            int h = width / symbolCount;

            for (int i = 0; i < symbolCount; ++i)
            {
                // генерируем размер буквы
                int size = rnd.Next(20, h);
                // выбираем любой символ из допустимого набора
                symbol = alphabet[rnd.Next(alphabet.Length)];
                // текст капчи
                captcha += symbol;
                // генерируем позиции рисования символа
                int Ypos = rnd.Next(height - size - 20);
                int Xpos = rnd.Next(i * h, (i + 1) * h - size);
                //Нарисуем сгенерированный символ
                g.DrawString(symbol.ToString(),
                new Font("Arial", size),
                colors[rnd.Next(colors.Length)],
               new PointF(Xpos, Ypos));
                //Добавим немного помех
                ///////Линии из углов
                //Устанавливаем цвет линии
                Pen skyBluePen = new Pen(colors[rnd.Next(colors.Length)]);
                // Устанавливаем толщину линии
                skyBluePen.Width = rnd.Next(2, 5);
                g.DrawLine(skyBluePen,
                new Point(Xpos + 5, Ypos + 5),
               new Point(Xpos + size + 5, Ypos + size + 5));
            }

            ////Белые точки
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);
            return (BitmapToImageSource(result), captcha);

        }

        private static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {

            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }

        }

    }
}
