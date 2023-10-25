using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetSize(); // при запуске формы инициализируем метод SetSize();
        }
        private class ArrayPoints // Создаем приватный класс Массив Точек ArrayPoints
        {
            private int index = 0; // Объявили целочисленную переменную index которая содержит номер текущей точки в массиве
            private Point[] points; // Объявили массив points в котором будут хранится наши точки

            public ArrayPoints(int size) // Конструктор класса в котором изначально задаем размер ArrayPoints который принимает размер массива
            {
                if (size <= 0) { size = 2;} // Проверка на ошибки если size <=0 то задаем size = 2
                points = new Point[size]; // инициализируем наш массив 
            }

            public void SetPoint(int x, int y) //Метод который помогает установить точку он будет принимать координаты int x, int y
            {
                if(index >= points.Length)       // Проверка на выход за пределы массива
                {
                    index = 0;                   // Если выходим за пределы массива то index обнуляем
                }
                points[index] = new Point(x, y); // Иначе присваиваем новые координаты points
                index++;                         // Увеличиваем индекс на единицу
            }

            public void ResetPoints()  // Метод который сбрасывает рисование точек если кнопка мыши не нажата.
            {
                index = 0;
            }

            public int GetCountPoits() //Публичная функция
            {
                return index; //Которая возвращает индекс
            }

            public Point[] GetPoints() // Метод который возвращает наш массив он нужен для отрисовки рисунка или другой графики
            {
                return points;
            }
        }
        
        //Объявляем несколько переменных
        private bool isMouse = false; // Объявили приватную переменную isMouse для проверки зажата-ли левая кнопка мыши (когда рисуем линию мышкой, рисуем зажатой кнопкой мыши)

        private ArrayPoints arrayPoints = new ArrayPoints(2); // Создаем экземпляр класса ArrayPoints

        Bitmap map = new Bitmap(100, 100); // Создаем переменную map для хранения изображения 100 на 100 

        Graphics graphics;

        Pen pen = new Pen(Color.Black, 3f); //Создаем обьект для рисования pen, инициализируем его new Pen Цвет Color черный Black толщина 3f

        private void SetSize() // Устанавливаем размер для нашего Bitmap
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds; //Определяем при каком разрешении работает нашь пользователь
            map = new Bitmap(rectangle.Width, rectangle.Height); // И такое - же разрешение выставляем для Bitmap
            graphics = Graphics.FromImage(map);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round; // Добавляем эту строку что-бы линии были более сглаженные
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;   // Добавляем эту строку что-бы линии были более сглаженные
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) // Обработчик события нажатия левой кнопки мыши на pictureBox1
        {
            isMouse = true; // При нажатии левой кнопки мышки переменная isMouse приобретает значение true
            arrayPoints.ResetPoints(); // Когда отпускаем кнопку мыши не будем ничего сохранять.
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) // Обработчик события отпускания левой кнопки мыши на pictureBox1
        {
            isMouse = false; // При отпускании левой кнопки мышки переменная isMouse приобретает значение false
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) // Обработчик события движения мыши на pictureBox1
        {
             if (!isMouse) {return; } // Если кнопка мыши не зажата if (!isMouse) то просто выходим {return;} из метода
             arrayPoints.SetPoint(e.X, e.Y); //Задаем новую точку по координатам (e.X, e.Y)
             if(arrayPoints.GetCountPoits() >= 2) 
            {
                graphics.DrawLines(pen,arrayPoints.GetPoints()); // Сделали отрисовку линии
                pictureBox1.Image = map;
                arrayPoints.SetPoint(e.X, e.Y);
            }
        }

        private void button3_Click(object sender, EventArgs e) // Универсальная кнопка для смены цвета карандаша.
        {
            pen.Color = ((Button)sender).BackColor;
        }
    }
}
