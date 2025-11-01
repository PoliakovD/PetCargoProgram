using System.Windows;
using System.Windows.Controls;

namespace PetCargoProgram.Components;

public partial class ComponentShipCondition : UserControl
{
    public static readonly DependencyProperty GomProperty = DependencyProperty.Register(nameof(Gom), typeof(double),
        typeof(ComponentShipCondition), new PropertyMetadata(default(double)));

    public static readonly DependencyProperty GmProperty = DependencyProperty.Register(nameof(Gm), typeof(double),
        typeof(ComponentShipCondition), new PropertyMetadata(default(double)));

    // LightWeight
    public static readonly DependencyProperty LightWeightProperty =
        DependencyProperty.Register(nameof(LightWeight), typeof(double), typeof(ComponentShipCondition));

    public double LightWeight
    {
        get => (double)GetValue(LightWeightProperty);
        set => SetValue(LightWeightProperty, value);
    }

    // TrimAngle
    public static readonly DependencyProperty TrimAngleProperty =
        DependencyProperty.Register(nameof(TrimAngle), typeof(double), typeof(ComponentShipCondition));

    public double TrimAngle
    {
        get => (double)GetValue(TrimAngleProperty);
        set => SetValue(TrimAngleProperty, value);
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

    // DraftActual
    public static readonly DependencyProperty DraftActualProperty =
        DependencyProperty.Register(nameof(DraftActual), typeof(double), typeof(ComponentShipCondition));

    public double DraftActual
    {
        get => (double)GetValue(DraftActualProperty);
        set => SetValue(DraftActualProperty, value);
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

    public double Gm
    {
        get => (double)GetValue(GmProperty);
        set => SetValue(GmProperty, value);
    }

    public double Gom
    {
        get => (double)GetValue(GomProperty);
        set => SetValue(GomProperty, value);
    }
    // DraftMean = value.Draft;
    // TPC = value.TPC;
    // KM = value.MetacentrKM;
    // LCF = value.FloatationCenterLCF;
    // MCTC= value.MCTC;
    // LCB= value.LCB;
    // CM = value.CM;

    // TPC
    public static readonly DependencyProperty TPCroperty =
        DependencyProperty.Register(nameof(TPC), typeof(double), typeof(ComponentShipCondition));

    public double TPC
    {
        get => (double)GetValue(TPCroperty);
        set => SetValue(TPCroperty, value);
    }
    // KM
    public static readonly DependencyProperty KMroperty =
        DependencyProperty.Register(nameof(KM), typeof(double), typeof(ComponentShipCondition));

    public double KM
    {
        get => (double)GetValue(KMroperty);
        set => SetValue(KMroperty, value);
    }

    // LCF
    public static readonly DependencyProperty LCFroperty =
        DependencyProperty.Register(nameof(LCF), typeof(double), typeof(ComponentShipCondition));

    public double LCF
    {
        get => (double)GetValue(LCFroperty);
        set => SetValue(LCFroperty, value);
    }
    // MCTC
    public static readonly DependencyProperty MCTCroperty =
        DependencyProperty.Register(nameof(MCTC), typeof(double), typeof(ComponentShipCondition));

    public double MCTC
    {
        get => (double)GetValue(MCTCroperty);
        set => SetValue(MCTCroperty, value);
    }
    // LCB
    public static readonly DependencyProperty LCBroperty =
        DependencyProperty.Register(nameof(LCB), typeof(double), typeof(ComponentShipCondition));

    public double LCB
    {
        get => (double)GetValue(LCBroperty);
        set => SetValue(LCBroperty, value);
    }
    // CM
    public static readonly DependencyProperty CMroperty =
        DependencyProperty.Register(nameof(CM), typeof(double), typeof(ComponentShipCondition));

    public double CM
    {
        get => (double)GetValue(CMroperty);
        set => SetValue(CMroperty, value);
    }
    public ComponentShipCondition()
    {
        InitializeComponent();
    }
}
