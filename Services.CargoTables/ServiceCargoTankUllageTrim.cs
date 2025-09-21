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
        if(Ullage<0.0) throw new Exception("Пустота не может быть меньше нуля");
        if (Trim>8.0) throw new Exception("Trim не может быть больше 8");
        if(Trim<-4.0) throw new Exception("Trim не может быть меньше -4");
        // Выбераем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == Name);

        if (table == null) throw new Exception($"Не найдена таблица для танка {Name}");

        // Проверяем ullage
        var maxUllage = table.Table.MaxBy(x => x.Ullage).Ullage+double.Epsilon;
        if(Ullage > maxUllage)
            throw new Exception($"Пустота {Ullage} больше максимальной {maxUllage}");

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

        // получаем значение по trim
        var result =GetValueInDictionary(trimsVolumes,
            Trim);

        // код ниже оказалося не обязательным

        //Проверяем значение на границы от 0 до максVolume
        // var MaxVolume = table.Table[0].CargoVolumeTrim0; // тут всегда хранится максимальное значение
        //
        // if (result < 0.0) result = 0.0;
        // if (result > MaxVolume) result = MaxVolume;

        return result;
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
    private static double GetUpExtrapoladedValueByKoef(double koef,
        double SearchValue1, double SearchValue2)
        =>koef * (SearchValue1 - SearchValue2) + SearchValue1;
    private static double GetDownExtrapoladedValueByKoef(double koef,
        double SearchValue1, double SearchValue2)
        => SearchValue1 - koef * (SearchValue1 - SearchValue2);

    private static double GetValueInDictionary(Dictionary<int,double> dictionary, double SearchValue)
    {
        // Min - всегда -1
        // Max - всегда +4

        // находим два ближайших значения
        var closest = dictionary.OrderBy(x => Math.Abs(x.Key - SearchValue)).Take(2);
        if (SearchValue >= -1 && SearchValue <= 4)
        {
            //Интерполируем
            var interKoef = (closest.First().Key-SearchValue)/(closest.First().Key - closest.Last().Key);
            return GetInterpolatedValueByKoef(interKoef,closest.First().Value,closest.Last().Value);
        }
        else
        {
            var extraKoef = (SearchValue - closest.First().Key) / (closest.First().Key - closest.Last().Key);
            // Экстраполируем вверх
            if (SearchValue > 4)
            {
                return GetUpExtrapoladedValueByKoef(extraKoef,closest.First().Value,closest.Last().Value);
            }
            else
            // Экстраполируем вниз
            {
                return GetUpExtrapoladedValueByKoef(extraKoef,closest.First().Value,closest.Last().Value);
            }
        }
    }
}
