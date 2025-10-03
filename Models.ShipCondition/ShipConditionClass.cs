using System.ComponentModel;
using PetCargoProgram.Services.CargoTables;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.Models.ShipCondition;

public partial class ShipConditionClass : NotifyPropertyChanged
{
    private double _lightWeight;
    private double _deadWeight;
    private double _displacement;
    private double _deadWeightRegistred;

    private double _cargoOnBoard;
    private double _ballastOnBoard;
    private double _fuelOilOnBoard;
    private double _dieselOnBoard;
    private double _freshWaterOnBoard;
    private double _lubeOilOnBoard;

    private double _draftAft;
    private double _draftFwd;
    private double _draftMean;

    private double _tcg;
    private double _lcf;
    private double _vcg;
    private double _km;
    private double _gm;
    private double _gom;
    private double _shearingForce;
    private double _bendingMoment;
    private double _tpc;
    private double _mctc;
    private double _lcb;
    private double _cm;
    private double _dieselOilOnBoard;
    private double _otherStoresOnBoard;
    private double _draftFore;
    private double _trim;
    private double _list;
    private double _trimAngle;

    public double LightWeight
    {
        get => _lightWeight;
        set => SetField(ref _lightWeight, value);
    }

    public double DeadWeight
    {
        get => _deadWeight;
        set => SetField(ref _deadWeight, value);
    }

    public double Displacement
    {
        get => _displacement;
        set => SetField(ref _displacement, value);
    }

    public double DeadWeightRegistred
    {
        get => _deadWeightRegistred;
        set => SetField(ref _deadWeightRegistred, value);
    }

    public double CargoOnBoard
    {
        get => _cargoOnBoard;
        set => SetField(ref _cargoOnBoard, value);
    }

    public double BallastOnBoard
    {
        get => _ballastOnBoard;
        set => SetField(ref _ballastOnBoard, value);
    }

    public double FuelOilOnBoard
    {
        get => _fuelOilOnBoard;
        set => SetField(ref _fuelOilOnBoard, value);
    }

    public double DieselOnBoard
    {
        get => _dieselOnBoard;
        set => SetField(ref _dieselOnBoard, value);
    }

    public double FreshWaterOnBoard
    {
        get => _freshWaterOnBoard;
        set => SetField(ref _freshWaterOnBoard, value);
    }

    public double LubeOilOnBoard
    {
        get => _lubeOilOnBoard;
        set => SetField(ref _lubeOilOnBoard, value);
    }

    public double DraftAft
    {
        get => _draftAft;
        set => SetField(ref _draftAft, value);
    }

    public double DraftMean
    {
        get => _draftMean;
        set => SetField(ref _draftMean, value);
    }

    public double TCG
    {
        get => _tcg;
        set => SetField(ref _tcg, value);
    }

    public double LCF
    {
        get => _lcf;
        set => SetField(ref _lcf, value);
    }

    public double VCG
    {
        get => _vcg;
        set => SetField(ref _vcg, value);
    }

    public double KM
    {
        get => _km;
        set => SetField(ref _km, value);
    }

    public double Gm
    {
        get => _gm;
        set => SetField(ref _gm, value);
    }

    public double Gom
    {
        get => _gom;
        set => SetField(ref _gom, value);
    }

    public double ShearingForce
    {
        get => _shearingForce;
        set => SetField(ref _shearingForce, value);
    }

    public double BendingMoment
    {
        get => _bendingMoment;
        set => SetField(ref _bendingMoment, value);
    }
    public double TPC
    {
        get => _tpc;
        set => SetField(ref _tpc, value);
    }

    public double MCTC
    {
        get => _mctc;
        set => SetField(ref _mctc, value);
    }

    public double LCB
    {
        get => _lcb;
        set => SetField(ref _lcb, value);
    }

    public double CM
    {
        get => _cm;
        set => SetField(ref _cm, value);
    }

    public double DraftActual
    {
        get => _draftActual;
        set => SetField(ref _draftActual, value);
    }

    public double DieselOilOnBoard
    {
        get => _dieselOilOnBoard;
        set { SetField(ref _dieselOilOnBoard, value); }
    }

    public double OtherStoresOnBoard
    {
        get => _otherStoresOnBoard;
        set => SetField(ref _otherStoresOnBoard, value);
    }

    public double DraftFore
    {
        get =>  _draftFore;
        set => SetField(ref _draftFore, value);
    }

    public double Trim
    {
        get =>  _trim;
        set => SetField(ref _trim, value);
    }

    public double List
    {
        get => _list;
        set => SetField(ref _list, value);
    }

    public double TrimAngle
    {
        get => _trimAngle;
        set => SetField(ref _trimAngle, value);
    }

    public ShipConditionClass()
    {
        LightWeight = 17475.9;
        Displacement = 17475.9;
        DeadWeightRegistred = 1054999;
        SeaWaterDensity = 1.025;

        var value = CargoTablesProvider.Hydrostatic.GetValue(Displacement);
        DraftMean = value.Draft;
        TPC = value.TPC;
        KM = value.MetacentrKM;
        LCF = value.FloatationCenterLCF;
        MCTC= value.MCTC;
        LCB= value.LCB;
        CM = value.CM;

        DraftEquivalent = DraftMean;
        CalcDrafts();
        MomentX = -188442.63;
        MomentY = 0.0;
        MomentZ = 203646.66;

    }
}
