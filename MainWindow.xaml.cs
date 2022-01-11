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

namespace painter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush Color; //объект для цвета
        bool IsDraw; //нажата ли кнопка мыши
        double R; //толщина линии

        public MainWindow()
        {
            InitializeComponent();
            IsDraw = false; //изначально перо не опущено на холст
            R = 1;//размер линии = 1 пиксель
            Color = Brushes.Red;//по умолчанию цвет пера красный

        }

        //обработчик нажатия на радиокнопки
        private void cmRed(object sender, RoutedEventArgs e)//выбор красног8о цвета
        {
            Color = Brushes.Red;
            rectColor.Fill = Color;
        }

        private void cmBlue(object sender, RoutedEventArgs e)//выбор синего цвета пера
        {
            Color = Brushes.Blue;
            rectColor.Fill = Color;
        }

        private void cmGreen(object sender, RoutedEventArgs e)//выбор зеленого цвета пера
        {
            Color = Brushes.Green;
            rectColor.Fill = Color;
        }

        private void cmClear(object sender, RoutedEventArgs e)//очистить холст
        {
            g.Children.Clear();
        }

        private void cmSize(object sender, RoutedPropertyChangedEventArgs<double> e)//изменение размера линии
        {
            R = slSize.Value;
        }

        private void cmDown(object sender, MouseButtonEventArgs e)//если кнопка мыши нажата
        {
            IsDraw = true;//опустить перо
        }

        private void cmUp(object sender, MouseButtonEventArgs e)//если кнопка мыши не нажата
        {
            IsDraw = false;//поднять перо
        }

        private void cmMove(object sender, MouseEventArgs e)//рисование
        {
            if (IsDraw)//если перо опущено
            {
                //если указатель мыши находится вне холста
                if((e.GetPosition(g).X < 0) || (e.GetPosition(g).X > g.Width))
                {
                    return;
                }
                if ((e.GetPosition(g).Y < 0) || (e.GetPosition(g).Y > g.Height))
                {
                    return;
                }

                //если указатель находится в пределах холста
                Ellipse o = new Ellipse();//создаем объект круг
                o.Width = R;//ширина
                o.Height = R;//высота
                o.Fill = Color;//цвет
                o.Margin = new Thickness(e.GetPosition(g).X - R / 2, e.GetPosition(g).Y - R / 2, 0, 0);//положение объекта под указателем мыши
                g.Children.Add(o);//добавить объект на холст
            }
        }
    }
}
