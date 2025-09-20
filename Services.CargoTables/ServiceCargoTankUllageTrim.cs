using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using System.Linq;

namespace PetCargoProgram.Services.CargoTables;

public class ServiceCargoTankUllageTrim
{
    private List<Table_CargoTankUllageTrim> Tables { get; set; }

    public ServiceCargoTankUllageTrim(Tables_CargoTankUllageTrim cargoTankUllageTrim)
    {
        Tables= cargoTankUllageTrim.Tables;
    }

    public double GetVolume(string Name, double Ullage, double Trim)
    {
        double result = 0;

        // Выбераем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == Name);

        // Находим два значения в таблице, ближайшие к ullage
        var closest = table.Table
            .OrderBy(n => Math.Abs(n.Ullage - Ullage))
            .Take(2);

        //расчет коэффициента для интерполяции по пустоте
        var koef = 1.0;
        var ullageFirst = closest.First().Ullage;
        var ullageLast = closest.Last().Ullage;
        if (closest.First().Ullage != Ullage) koef = (ullageLast-ullageFirst)/(Ullage-ullageFirst);

        //Расчет объема по дифференту
//TODO Доделать!!!


        return result;
    }
}
