using System.ComponentModel;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.Models.ShipCondition;

public class ShipCondition : NotifyPropertyChanged
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
    private double _draftAftPependicular;
    private double _draftFwd;
    private double _draftFwdPependicular;
    private double _draftMean;

    private double _tcg;
    private double _lcg;
    private double _vcg;
    private double _gm;
    private double _gom;
    private double _shearingForce;
    private double _bendingMoment;
    private double _tpc;
    private double _mctc;
    private double _lcb;
    private double _cm;

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

    public double DraftAftPependicular
    {
        get => _draftAftPependicular;
        set => SetField(ref _draftAftPependicular, value);
    }

    public double DraftFwd
    {
        get => _draftFwd;
        set => SetField(ref _draftFwd, value);
    }

    public double DraftFwdPependicular
    {
        get => _draftFwdPependicular;
        set => SetField(ref _draftFwdPependicular, value);
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

    public double LCG
    {
        get => _lcg;
        set => SetField(ref _lcg, value);
    }

    public double VCG
    {
        get => _vcg;
        set => SetField(ref _vcg, value);
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
    public ShipCondition()
    {
        LightWeight = 17475.9;
        DeadWeightRegistred = 1054999;
    }
}
