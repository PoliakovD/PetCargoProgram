using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using static PetCargoProgram.Services.CargoTables.ServiceFindAndCalcHelper;
using System.Linq;


namespace PetCargoProgram.Services.CargoTables;

public class ServiceCargoTankUllageTrim
{
    private List<Table_CargoTankUllageTrim> Tables { get; set; }

    public ServiceCargoTankUllageTrim(Tables_CargoTankUllageTrim cargoTankUllageTrim)
    {
        Tables= cargoTankUllageTrim.Tables;
    }

    public double GetVolumeWithTrim(string name, double ullage, double trim)
    {
        // Выбираем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == name);

        // Проверка на наличие таблицы
        if (table == null) throw new Exception($"Не найдена таблица для танка {name}");

        //Проверка входных значений
        if(ullage<0.0) throw new Exception("Пустота не может быть меньше нуля");
        if (trim>8.0) throw new Exception("Trim не может быть больше 8");
        if(trim<-4.0) throw new Exception("Trim не может быть меньше -4");

        // Проверяем ullage
        var maxUllage = table.Table.MaxBy(x => x.Ullage).Ullage+double.Epsilon;
        if(ullage > maxUllage)
            throw new Exception($"Пустота {ullage} больше максимальной {maxUllage}");

        // Находим два значения в таблице, ближайшие к ullage
        var closest = table.Table
            .OrderBy(n => Math.Abs(n.Ullage - ullage))
            .Take(2);

        var closestFirst = closest.First();
        var closestLast = closest.Last();

        //расчет коэффициента для интерполяции по пустоте
        var koef = 0.0;
        var ullageFirst = closestFirst.Ullage;
        var ullageLast = closestLast.Ullage;
        if (ullageFirst != ullage) koef = (ullageLast-ullageFirst)/(ullage-ullageFirst);

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
            trim);

        // код ниже оказалося не обязательным

        //Проверяем значение на границы от 0 до максVolume
        // var MaxVolume = table.Table[0].CargoVolumeTrim0; // тут всегда хранится максимальное значение
        //
        // if (result < 0.0) result = 0.0;
        // if (result > MaxVolume) result = MaxVolume;

        return result;
    }



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
            // Экстраполируем
            var extraKoef = (SearchValue - closest.First().Key) / (closest.First().Key - closest.Last().Key);
            return GetExtrapoladedValueByKoef(extraKoef,closest.First().Value,closest.Last().Value);

        }
    }
}
