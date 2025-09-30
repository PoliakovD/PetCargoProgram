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
        // public static readonly DependencyProperty AngleProperty =
        //     DependencyProperty.Register(nameof(Angle), typeof(double), typeof(ChartStablility));
        // public double Angle
        // {
        //     get => (double)GetValue(AngleProperty);
        //     set
        //     {
        //         SetValue(AngleProperty, value);
        //     }
        // }

        public static readonly DependencyProperty DraftProperty =
            DependencyProperty.Register(nameof(Draft), typeof(double), typeof(ChartStablility));
        public double Draft
        {
            get => (double)GetValue(DraftProperty);
            set
            {
                SetValue(DraftProperty, value);
            }
        }
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


        // public Binding RotationBinding = new Binding("Angle");
        // public Binding DraftBinding = new Binding("Draft");
        // public RotateTransform Rotate { get; set; }
        //
        // public TranslateTransform Down { get; set; }
        // public TransformGroup RotateAndDown { get; set; }
        //
        // Поля
        //
        // Список для хранения данных
        List<double[]> dataList = new List<double[]>();
        // Или можно DoubleCollection data = new DoubleCollection();
        // Контейнер слоев рисунков
        DrawingGroup drawingGroup = new DrawingGroup();
        //
        //
        // public GeometryDrawing Ship = new GeometryDrawing();
        // public RotateTransform Rotate = new RotateTransform();
        // public TranslateTransform Down = new TranslateTransform();
        // public TransformGroup RotateAndDown = new TransformGroup();
        //


        public ChartStablility()
        {
            InitializeComponent();
            //
            // RotationBinding.ElementName = "ChartStablility"; // элемент-источник
            // RotationBinding.Path = new PropertyPath("Angle"); // свойство элемента-источника
            // RotationBinding.SetBinding(TextBlock.TextProperty, binding); // установка привязки для элемента-приемника
            //
            //
            // Rotate = new RotateTransform(0.0);
            // Rotate.CenterX = 120.0;
            // Rotate.CenterY = DraftBinding;


            DataFill();// Заполнение списка данными
            Execute(); // Заполнение слоев

            // Down = new TranslateTransform();
            // Rotate = new RotateTransform();
            // Rotate.CenterX = 120.0;
            //
            // Binding RotationBinding = new Binding();
            //
            // RotationBinding.ElementName = "Component"; // элемент-источник
            // RotationBinding.Path = new PropertyPath("AngleProperty"); // свойство элемента-источника
            // RotationBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            // RotationBinding.Mode = BindingMode.OneWay;
            //
            // Binding DownBinding = new Binding();
            //
            // DownBinding.ElementName = "Component"; // элемент-источник
            // DownBinding.Path = new PropertyPath("DraftProperty"); // свойство элемента-источника
            // DownBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            // DownBinding.Mode = BindingMode.OneWay;
            //
            //
            // BindingOperations.SetBinding(Component, RotateTransform.AngleProperty, RotationBinding);
            //
            // BindingOperations.SetBinding(Component, RotateTransform.CenterYProperty, DownBinding);
            //
            // BindingOperations.SetBinding(Component, TranslateTransform.YProperty, DownBinding);
            //
            // RotateAndDown.Children.Add(Rotate);
            // RotateAndDown.Children.Add(Down);
            //
            // Ship.Geometry.Transform = RotateAndDown;


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
            geometryDrawing.Pen = new Pen(Brushes.Red, 0.015);// Перо рамки

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
            var Ship = new GeometryDrawing();
            Ship.Geometry = lineGroup;

            // Настраиваем перо
            Ship.Pen = new Pen(Brushes.Black, 0.8);

            //добавление вращения

            //
            // geometryDrawing.Geometry.Transform = RotateAndDown;

            // Добавляем готовый слой в контейнер отображения
            drawingGroup.Children.Add(Ship);

        }


 }

}



