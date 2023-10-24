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

        }
        //Объявляем несколько переменных
        private bool isMouse = false; // Объявили приватную переменную isMouse для проверки зажата-ли левая кнопка мыши (когда рисуем линию мышкой, рисуем зажатой кнопкой мыши)

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) // Обработчик события нажатия левой кнопки мыши на pictureBox1
        {
            isMouse = true; // При нажатии левой кнопки мышки переменная isMouse приобретает значение true
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) // Обработчик события отпускания левой кнопки мыши на pictureBox1
        {
            isMouse = false; // При отпускании левой кнопки мышки переменная isMouse приобретает значение false
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) // Обработчик события движения мыши на pictureBox1
        {

        }
    }
}
