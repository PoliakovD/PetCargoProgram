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

    public double GetVolumeWithTrim(string Name, double Ullage, double Trim)
    {
        if(Ullage<0) throw new Exception("Пустота не может быть меньше нуля");
        if (Trim>8) throw new Exception("Trim не может быть больше 8");
        if(Trim<-3 throw new Exception("Trim не может быть меньше -3");
        // Выбераем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == Name);

        // Находим два значения в таблице, ближайшие к ullage
        var closest = table.Table
            .OrderBy(n => Math.Abs(n.Ullage - Ullage))
            .Take(2);

        var closestFirst = closest.First();
        var closestLast = closest.Last();

        //расчет коэффициента для интерполяции по пустоте
        var koef = 0.0;
        var ullageFirst = closestFirst.Ullage;
        var ullageLast = closestLast.Ullage;
        if (ullageFirst != Ullage) koef = (ullageLast-ullageFirst)/(Ullage-ullageFirst);

        //Расчет объема по дифференту
        Dictionary<int, double> trimsVolumes = [];

        trimsVolumes.Add(-1, GetInterpolatedValueByKoef(koef,
            closestFirst.CargoVolumeTrim_1,
            closestLast.CargoVolumeTrim_1));
        trimsVolumes.Add(0, GetInterpolatedValueByKoef(koef,
            closestFirst.CargoVolumeTrim0,
            closestLast.CargoVolumeTrim0));
        trimsVolumes.Add(1, GetInterpolatedValueByKoef(koef,
            closestFirst.CargoVolumeTrim1,
            closestLast.CargoVolumeTrim1));
        trimsVolumes.Add(2, GetInterpolatedValueByKoef(koef,
            closestFirst.CargoVolumeTrim2,
            closestLast.CargoVolumeTrim2));
        trimsVolumes.Add(3, GetInterpolatedValueByKoef(koef,
            closestFirst.CargoVolumeTrim3,
            closestLast.CargoVolumeTrim3));
        trimsVolumes.Add(4, GetInterpolatedValueByKoef(koef,
            closestFirst.CargoVolumeTrim4,
            closestLast.CargoVolumeTrim4));

        return GetIterpolatedValueInDictionary(trimsVolumes,
            Trim);
    }

    private static double GetInterpolatedValue(
        double calcValue1, double calcValue2,
        double currentValue,
        double SearchValue1, double SearchValue2)
    {
        double koef = (calcValue1 - currentValue) / (calcValue2 - calcValue1);
        return koef * (SearchValue2 - SearchValue1) + SearchValue1;
    }
    private static double GetInterpolatedValueByKoef(double koef,
        double SearchValue1, double SearchValue2)
    =>koef * (SearchValue2 - SearchValue1) + SearchValue1;

    private static double GetIterpolatedValueInDictionary(Dictionary<int,double> dictionary, double SearchValue)
    {
        // находим два ближайших значения
        var closest = dictionary.OrderBy(x => Math.Abs(x.Key - SearchValue)).Take(2);
        var koef = (closest.First().Key-SearchValue)/(closest.First().Key - closest.Last().Key);
        //Интерполируем
        return GetInterpolatedValueByKoef(koef,closest.First().Value,closest.Last().Value);
    }
}
