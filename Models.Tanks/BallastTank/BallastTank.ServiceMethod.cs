using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.Tanks;

public partial class BallastTank
{
    private void DistributeVolumeTableValue(ValueTableVolume tableValue)
    {
        _lcg= tableValue.LCG;
        _tcg= tableValue.TCG;
        _vcg= tableValue.VCG;
        _iy= tableValue.IY;
        _weight= tableValue.Volume*Density;
        OnPropertyChanged(nameof(LCG));
        OnPropertyChanged(nameof(TCG));
        OnPropertyChanged(nameof(VCG));
        OnPropertyChanged(nameof(IY));
        OnPropertyChanged(nameof(Weight));
    }
}
