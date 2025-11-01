using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.IO;
using System.Linq;

namespace PetCargoProgram.Components;

public partial class ChartStabilityList : UserControl
{
    private const double widthForDrawing = 80.0;
    private const double heightForDrawing = 50.0;
    private const double shiftingForDrawing = widthForDrawing/2;


    public static readonly DependencyProperty DraftProperty =
        DependencyProperty.Register(nameof(Draft), typeof(double), typeof(ChartStabilityList));

    public double Draft
    {
        get => (double)GetValue(DraftProperty);
        set { SetValue(DraftProperty, value); }
    }

    public static readonly DependencyProperty KGroperty =
        DependencyProperty.Register(nameof(KG), typeof(double), typeof(ChartStabilityList));

    public double KG
    {
        get => (double)GetValue(KGroperty);
        set
        {
            // так как LCF приходит со значением от миделя мы смещаем его на величину
            // LBP/2 для данного судна LBP/2 = 119.5
            SetValue(KGroperty, value);
        }
    }

    public static readonly DependencyProperty AngleProperty =
        DependencyProperty.Register(nameof(Angle), typeof(double), typeof(ChartStabilityList));

    public double Angle
    {
        get => (double)GetValue(AngleProperty);
        set { SetValue(AngleProperty, value); }
    }
    //
    // Поля
    //

    // Контейнер слоев рисунков
    DrawingGroup drawingGroup = new DrawingGroup();

    //
    //
    public GeometryDrawing Ship = new GeometryDrawing();

    //
    public RotateTransform Rotate = new RotateTransform();
    public TranslateTransform Down = new TranslateTransform();
    public TransformGroup RotateAndDown = new TransformGroup();
    //


    public ChartStabilityList()
    {
        InitializeComponent();
        Execute(); // Заполнение слоев
        // Отображение на экране
        DrawingImage.Source = new DrawingImage(drawingGroup);
    }

    // Послойное формирование рисунка
    void Execute()
    {
        ShipFun();
        BackgroundFun(); // Фон
    }

    // Фон
    private void BackgroundFun()
    {
        // Создаем объект для описания геометрической фигуры
        GeometryDrawing geometryDrawing = new GeometryDrawing();

        // Описываем и сохраняем геометрию квадрата
        RectangleGeometry rectGeometry = new RectangleGeometry();
        rectGeometry.Rect = new Rect(0, 0, widthForDrawing, heightForDrawing);
        geometryDrawing.Geometry = rectGeometry;

        // Настраиваем перо и кисть
        geometryDrawing.Pen = new Pen(Brushes.Black, 0.015); // Перо рамки

        // Настраиваем кисть
        var fillBrush = new LinearGradientBrush();

        var seaColor = Colors.Blue;
        seaColor.A = 100;


        fillBrush.GradientStops.Add(new GradientStop(seaColor, 0.0));
        fillBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1.0));
        fillBrush.StartPoint = new Point(0.0, 0.0);
        fillBrush.EndPoint = new Point(0, 1);

        geometryDrawing.Brush = fillBrush; // Кисть закраски

        // Добавляем готовый слой в контейнер отображения
        drawingGroup.Children.Add(geometryDrawing);
    }


    private double[] GetShipPoints(string path = "shipList.txt")
    {
        var stringPoints = File.ReadAllText(path);
        var points = stringPoints.Replace('\t', ' ').Replace("\r\n", " ").Split(' ');

        List<double> result = new List<double>();
        for (int i = 0; i < points.Length - 2; i++)
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

        double[] ship = GetShipPoints();

        GeometryGroup lineGroup = new GeometryGroup();
        LineGeometry line;

        for (int i = 0; i < ship.Length - 3; i += 2)
        {
            line = new LineGeometry(
                new Point(ship[i] + shiftingForDrawing, -ship[i + 1]),
                new Point(ship[i + 2] + shiftingForDrawing, -ship[i + 3]));
            lineGroup.Children.Add(line);
        }

        // Сохраняем описание геометрии
        var Ship = new GeometryDrawing();
        Ship.Geometry = lineGroup;

        // Настраиваем перо
        Ship.Pen = new Pen(Brushes.Black, 0.8);

        //добавление вращения
        RotateAndDown = new TransformGroup();

        Down = new TranslateTransform();
        Rotate = new RotateTransform() {CenterX = shiftingForDrawing};


        Binding RotationBinding = new Binding();

        RotationBinding.ElementName = "Component"; // элемент-источник
        RotationBinding.Path = new PropertyPath("Angle"); // свойство элемента-источника
        RotationBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        RotationBinding.Mode = BindingMode.OneWay;

        Binding DownBinding = new Binding();

        DownBinding.ElementName = "Component"; // элемент-источник
        DownBinding.Path = new PropertyPath("Draft"); // свойство элемента-источника
        DownBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        DownBinding.Mode = BindingMode.OneWay;

        Binding KGBinding = new Binding();
        KGBinding.ElementName = "Component"; // элемент-источник
        KGBinding.Path = new PropertyPath("KG"); // свойство элемента-источника
        KGBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        KGBinding.Mode = BindingMode.OneWay;


        BindingOperations.SetBinding(Rotate, RotateTransform.AngleProperty, RotationBinding);
        BindingOperations.SetBinding(Rotate, RotateTransform.CenterYProperty, KGBinding);



        BindingOperations.SetBinding(Down, TranslateTransform.YProperty, DownBinding);


        RotateAndDown.Children.Add(Rotate);
        RotateAndDown.Children.Add(Down);

        Ship.Geometry.Transform = RotateAndDown;

        // Добавляем готовый слой в контейнер отображения
        drawingGroup.Children.Add(Ship);
    }
}
