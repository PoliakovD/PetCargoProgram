
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.Tanks;

public partial class CargoTank

{
    private void DistributeVolumeTableValue(Value_Table_Volume tableValue)
    {
        SetField(ref _lcg, tableValue.LCG);
        SetField(ref _tcg, tableValue.TCG);
        SetField(ref _vcg, tableValue.VCG);
        SetField(ref _iy, tableValue.IY);
        SetField(ref _weight, tableValue.Volume*Density);
    }
}
