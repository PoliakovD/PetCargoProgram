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

        // Фон
        private void BackgroundFun()
        {
            // Создаем объект для описания геометрической фигуры
            GeometryDrawing geometryDrawing = new GeometryDrawing();

            // Описываем и сохраняем геометрию квадрата
            RectangleGeometry rectGeometry = new RectangleGeometry();
            rectGeometry.Rect = new Rect(0, 0, 300, 50);
            geometryDrawing.Geometry = rectGeometry;

            // Настраиваем перо и кисть
            geometryDrawing.Pen = new Pen(Brushes.Red, 0.005);// Перо рамки

            // Настраиваем кисть
            var fillBrush = new LinearGradientBrush();

            var seaColor = Colors.Blue;
            seaColor.A = 100;


            fillBrush.GradientStops.Add(new GradientStop(seaColor, 0.0));
            fillBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1.0));
            fillBrush.StartPoint = new Point(0.0, 0.0);
            fillBrush.EndPoint = new Point(0, 1);

            geometryDrawing.Brush = fillBrush;// Кисть закраски

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
        }

        // Горизонтальная сетка
        private void GridFun()
        {
            // Создаем коллекцию для описания геометрических фигур
            GeometryGroup lineGroup = new GeometryGroup();

            // Создаем и добавляем в коллекцию десять параллельных линий
            for (int i = 1; i < 10; i++)
            {
                LineGeometry line = new LineGeometry(new Point(1.0, i * 0.1),
                    new Point(-0.1, i * 0.1));
                lineGroup.Children.Add(line);
            }

            // Сохраняем описание геометрии
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = lineGroup;

            // Настраиваем перо
            geometryDrawing.Pen = new Pen(Brushes.Gray, 0.003);
            double[] dashes = { 1, 1, 1, 1, 1 };// Образец штриха
            geometryDrawing.Pen.DashStyle = new DashStyle(dashes, -.1);

            // Настраиваем кисть
            geometryDrawing.Brush = Brushes.Beige;

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
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
            geometryDrawing.Pen = new Pen(Brushes.Black, 0.5);


            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);

        }

        private void ShipRotate()
        {
            var rotate = new RotateTransform(Angle);
            ((drawingGroup.Children[0] as GeometryDrawing)!).Geometry.Transform = rotate;
        }


        // Строим косинус точками
        private void CosFun()
        {
            // Строим описание косинусоиды
            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 0; i < dataList[1].Length; i++)
            {
                EllipseGeometry ellips = new EllipseGeometry(
                    new Point((double)i / (double)countDot,
                    .5 - (dataList[1][i] / 2.0)), 0.01, 0.01);
                geometryGroup.Children.Add(ellips);
            }

            // Сохраняем описание геометрии
            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            // Настраиваем перо
            geometryDrawing.Pen = new Pen(Brushes.Green, 0.005);

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(geometryDrawing);
        }

        // Надписи
        private void MarkerFun()
        {
            GeometryGroup geometryGroup = new GeometryGroup();
            for (int i = 0; i <= 10; i++)
            {
                FormattedText formattedText = new FormattedText(
                String.Format("{0,7:F}", 1 - i * 0.2),
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Verdana"),
                0.05,
                Brushes.Black);

                formattedText.SetFontWeight(FontWeights.Bold);

                Geometry geometry = formattedText.BuildGeometry(new Point(-0.2, i * 0.1 - 0.03));
                geometryGroup.Children.Add(geometry);
            }

            GeometryDrawing geometryDrawing = new GeometryDrawing();
            geometryDrawing.Geometry = geometryGroup;

            geometryDrawing.Brush = Brushes.LightGray;
            geometryDrawing.Pen = new Pen(Brushes.Gray, 0.003);

            drawingGroup.Children.Add(geometryDrawing);
        }
 }

}



