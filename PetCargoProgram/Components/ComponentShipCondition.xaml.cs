using System.Windows;
using System.Windows.Controls;

namespace PetCargoProgram.Components;

public partial class ComponentShipCondition : UserControl
{
    // LightWeight
    public static readonly DependencyProperty LightWeightProperty =
        DependencyProperty.Register(nameof(LightWeight), typeof(double), typeof(ComponentShipCondition));
    public double LightWeight
    {
        get => (double)GetValue(LightWeightProperty);
        set => SetValue(LightWeightProperty, value);
    }

    // DeadWeight
    public static readonly DependencyProperty DeadWeightProperty =
        DependencyProperty.Register(nameof(DeadWeight), typeof(double), typeof(ComponentShipCondition));
    public double DeadWeight
    {
        get => (double)GetValue(DeadWeightProperty);
        set => SetValue(DeadWeightProperty, value);
    }

    // Displacement
    public static readonly DependencyProperty DisplacementProperty =
        DependencyProperty.Register(nameof(Displacement), typeof(double), typeof(ComponentShipCondition));
    public double Displacement
    {
        get => (double)GetValue(DisplacementProperty);
        set => SetValue(DisplacementProperty, value);
    }

    // DeadWeightRegistred
    public static readonly DependencyProperty DeadWeightRegistredProperty =
        DependencyProperty.Register(nameof(DeadWeightRegistred), typeof(double), typeof(ComponentShipCondition));
    public double DeadWeightRegistred
    {
        get => (double)GetValue(DeadWeightRegistredProperty);
        set => SetValue(DeadWeightRegistredProperty, value);
    }

    // CargoOnBoard
    public static readonly DependencyProperty CargoOnBoardProperty =
        DependencyProperty.Register(nameof(CargoOnBoard), typeof(double), typeof(ComponentShipCondition));
    public double CargoOnBoard
    {
        get => (double)GetValue(CargoOnBoardProperty);
        set => SetValue(CargoOnBoardProperty, value);
    }

    // BallastOnBoard
    public static readonly DependencyProperty BallastOnBoardProperty =
        DependencyProperty.Register(nameof(BallastOnBoard), typeof(double), typeof(ComponentShipCondition));
    public double BallastOnBoard
    {
        get => (double)GetValue(BallastOnBoardProperty);
        set => SetValue(BallastOnBoardProperty, value);
    }

    // FuelOilOnBoard
    public static readonly DependencyProperty FuelOilOnBoardProperty =
        DependencyProperty.Register(nameof(FuelOilOnBoard), typeof(double), typeof(ComponentShipCondition));
    public double FuelOilOnBoard
    {
        get => (double)GetValue(FuelOilOnBoardProperty);
        set => SetValue(FuelOilOnBoardProperty, value);
    }

    // DieselOilOnBoard
    public static readonly DependencyProperty DieselOilOnBoardProperty =
        DependencyProperty.Register(nameof(DieselOilOnBoard), typeof(double), typeof(ComponentShipCondition));
    public double DieselOilOnBoard
    {
        get => (double)GetValue(DieselOilOnBoardProperty);
        set => SetValue(DieselOilOnBoardProperty, value);
    }

    // FreshWaterOnBoard
    public static readonly DependencyProperty FreshWaterOnBoardProperty =
        DependencyProperty.Register(nameof(FreshWaterOnBoard), typeof(double), typeof(ComponentShipCondition));
    public double FreshWaterOnBoard
    {
        get => (double)GetValue(FreshWaterOnBoardProperty);
        set => SetValue(FreshWaterOnBoardProperty, value);
    }

    // LubeOilOnBoard
    public static readonly DependencyProperty LubeOilOnBoardProperty =
        DependencyProperty.Register(nameof(LubeOilOnBoard), typeof(double), typeof(ComponentShipCondition));
    public double LubeOilOnBoard
    {
        get => (double)GetValue(LubeOilOnBoardProperty);
        set => SetValue(LubeOilOnBoardProperty, value);
    }

    // OtherStoresOnBoard
    public static readonly DependencyProperty OtherStoresOnBoardProperty =
        DependencyProperty.Register(nameof(OtherStoresOnBoard), typeof(double), typeof(ComponentShipCondition));
    public double OtherStoresOnBoard
    {
        get => (double)GetValue(OtherStoresOnBoardProperty);
        set => SetValue(OtherStoresOnBoardProperty, value);
    }

    // Drafts & Lists

    // DraftEquiv
    public static readonly DependencyProperty DraftEquivProperty =
        DependencyProperty.Register(nameof(DraftEquiv), typeof(double), typeof(ComponentShipCondition));
    public double DraftEquiv
    {
        get => (double)GetValue(DraftEquivProperty);
        set => SetValue(DraftEquivProperty, value);
    }

    // DraftFore
    public static readonly DependencyProperty DraftForeProperty =
        DependencyProperty.Register(nameof(DraftFore), typeof(double), typeof(ComponentShipCondition));
    public double DraftFore
    {
        get => (double)GetValue(DraftForeProperty);
        set => SetValue(DraftForeProperty, value);
    }

    // DraftMean
    public static readonly DependencyProperty DraftMeanProperty =
        DependencyProperty.Register(nameof(DraftMean), typeof(double), typeof(ComponentShipCondition));
    public double DraftMean
    {
        get => (double)GetValue(DraftMeanProperty);
        set => SetValue(DraftMeanProperty, value);
    }

    // DraftAft
    public static readonly DependencyProperty DraftAftProperty =
        DependencyProperty.Register(nameof(DraftAft), typeof(double), typeof(ComponentShipCondition));
    public double DraftAft
    {
        get => (double)GetValue(DraftAftProperty);
        set => SetValue(DraftAftProperty, value);
    }

    // Trim
    public static readonly DependencyProperty TrimProperty =
        DependencyProperty.Register(nameof(Trim), typeof(double), typeof(ComponentShipCondition));
    public double Trim
    {
        get => (double)GetValue(TrimProperty);
        set => SetValue(TrimProperty, value);
    }

    // List
    public static readonly DependencyProperty ListProperty =
        DependencyProperty.Register(nameof(List), typeof(double), typeof(ComponentShipCondition));
    public double List
    {
        get => (double)GetValue(ListProperty);
        set => SetValue(ListProperty, value);
    }

    public ComponentShipCondition()
    {
        InitializeComponent();
    }
}

