using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.Services.CargoTables;

public static class CargoTablesProvider
{
    public static AllCargoTables AllTables = BinaryCTService.Load();
    public static ServiceHydrostatic Hydrostatic = new ServiceHydrostatic(AllTables.TablesHydrostatic);
    public static ServiceHydrostaticTrim HydrostaticTrim = new ServiceHydrostaticTrim(AllTables.TablesHydrostatic);
    public static ServiceVolume Volume= new ServiceVolume(AllTables.TablesVolume);
    public static ServiceBallastSoundTrim BallastSoundTrim= new ServiceBallastSoundTrim(AllTables.TablesBallSoundTrim);
    public static ServiceCargoTankUllageTrim ServiceCargoTankUllageTrim= new ServiceCargoTankUllageTrim(AllTables.TablesCargoTankUllage);
}

