using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Globalization;
using System.IO;
using System.Linq;

namespace PetCargoProgram.Components
{
    public partial class ChartStablility : UserControl
    {
        //TODO Исправить правильно отображение графика
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register(nameof(Angle), typeof(double), typeof(ChartStablility));
        public double Angle
        {
            get => (double)GetValue(AngleProperty);
            set
            {
                SetValue(AngleProperty, value);
            }
        }

        public static readonly DependencyProperty DraftProperty =
            DependencyProperty.Register(nameof(Draft), typeof(double), typeof(ChartStablility));
        public double Draft
        {
            get => (double)GetValue(DraftProperty);
            set
            {
                SetValue(DraftProperty, -value);
            }
        }

        //
        // Поля
        //
        private int countDot = 0;// Количество отрезков
        // Список для хранения данных
        List<double[]> dataList = new List<double[]>();
        // Или можно DoubleCollection data = new DoubleCollection();
        // Контейнер слоев рисунков
        DrawingGroup drawingGroup = new DrawingGroup();

        public ChartStablility()
        {
            InitializeComponent();

                ;
            DataFill();// Заполнение списка данными
            Execute(); // Заполнение слоев

            // Отображение на экране
            image1.Source = new DrawingImage(drawingGroup);
        }

        // Генерация точек графиков
        void DataFill()
        {
            double[] ship = GetShipPoints();

            dataList.Add(ship);
        }

        // Послойное формирование рисунка в Z-последовательности
        void Execute()
        {
            ShipFun();
            //BackgroundFun();    // Фон
            //GridFun();          // Мелкая сетка
            //SinFun();           // Строим синус линией
            //CosFun();           // Строим косинус точками
            //MarkerFun();        // Надписи

        }


        private double[] GetShipPoints(string path = "ship.txt")
        {
            var stringPoints = File.ReadAllText(path);
            var points = stringPoints.Replace('\t', ' ').Replace("\r\n", " ").Split(' ');

            List<double> result=new List<double>();
            for(int i =0;i<points.Length-2;i++)
            {
                result.Add(Convert.ToDouble(points[i]));
            }
            result.Add(0.0);
            return result.ToArray<double>();
        }
        // Рисуем кораблик
        private void ShipFun()
        {
            // Строим описание судна
            GeometryGroup lineGroup = new GeometryGroup();
            LineGeometry line;
            int i = 0;
            for (i = 0; i < dataList[0].Length - 3; i+=2)
            {
                line = new LineGeometry(
                    new Point(dataList[0][i]+25.0, -dataList[0][i+1]),
                    new Point(dataList[0][i+2]+25.0, -dataList[0][i+3]));
                lineGroup.Children.Add(line);
            }
            // Сохраняем описание геометрии
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = lineGroup;

            // Настраиваем перо
            geometryDrawing.Pen = new Pen(Brushes.Black, 1.0);


            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);

        }
 }

}



