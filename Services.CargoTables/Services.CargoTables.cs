using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.Services.CargoTables;

public class Services_CargoTables
{
    private  AllCargoTables _allTables;

    public Services_CargoTables()
    {
        Init();
    }
    private void Init()
    {
        _allTables = new AllCargoTables();
        BinaryCTService.Load(ref _allTables);
    }
    public Tables_BallSoundTrim GetBallSoundTrimTables() => _allTables.TablesBallSoundTrim;
    public Tables_CargoTankUllageTrim GetCargoTankUllageTables() => _allTables.TablesCargoTankUllage;
    public Tables_Hydrostatic GetHydrostaticTables() => _allTables.TablesHydrostatic;
    public Tables_OtherSounding GetOtherSoundingTables() => _allTables.TablesOtherSounding;
    public Tables_Volume GetVolumeTables() => _allTables.TablesVolume;
}

