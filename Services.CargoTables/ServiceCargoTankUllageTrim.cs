using System;
using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using static PetCargoProgram.Services.CargoTables.ServiceFindAndCalcHelper;
using System.Linq;
using PetCargoProgram.Models.CargoTables.Values;


namespace PetCargoProgram.Services.CargoTables;

public class ServiceCargoTankUllageTrim
{
    private List<Table_CargoTankUllageTrim> Tables { get; set; }

    public ServiceCargoTankUllageTrim(Tables_CargoTankUllageTrim cargoTankUllageTrim)
    {
        Tables= cargoTankUllageTrim.Tables;
    }
    public double GetMaxUllage(string name)
        => Tables.FirstOrDefault(x => x.Name == name)!.Table.Last().Ullage;
    public double GetVolumeWithTrim(string name, double ullage, double trim=0.0)
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
        var maxUllage = GetMaxUllage(name)+double.Epsilon;
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
        if (ullageFirst != ullage) koef = (ullage-ullageFirst)/(ullageLast-ullageFirst);

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

        return result;
    }

    public double GetUllageWithTrim(string name, double volume, double trim=0.0)
    {
        // Выбираем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == name);

        // Проверка на наличие таблицы
        if (table == null) throw new Exception($"Не найдена таблица для танка {name}");

        //Проверка входных значений
        if(volume<0.0) throw new Exception("Обьем не может быть меньше нуля");
        if (trim>8.0) throw new Exception("Trim не может быть больше 8");
        if(trim<-4.0) throw new Exception("Trim не может быть меньше -4");

        // Проверяем volume
        var maxVolume = table.Table[0].CargoVolumeTrim0 + double.Epsilon;
        if(volume > maxVolume)
            throw new Exception($"Объем {volume} больше максимального {maxVolume}");

        // ищем ближайшие значения для диферентов
        int[] indexedTrims = new int[]{-1,0,1,2,3,4};
        var closestTrims = indexedTrims.OrderBy(n => Math.Abs((double)n - trim)).Take(2).ToList();

        // в ближайших дифферентах идем по столбцам и находим ближайшее значения обьемов
        var firstVolume = new Dictionary<double, double>();
        var secondVolume = new Dictionary<double, double>();

        switch (closestTrims[0])
        {
            case -1:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim_1 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim_1);
                firstVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim_1);
                break;
            }
            case 0:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim0 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim0);
                firstVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim0);
                break;
            }
            case 1:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim1 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim1);
                firstVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim1);
                break;
            }
            case 2:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim2 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim2);
                firstVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim2);
                break;
            }
            case 3:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim3 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim3);
                firstVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim3);
                break;
            }
            case 4:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim4 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim4);
                firstVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim4);
                break;
            }
        }

        switch (closestTrims[1])
        {
            case -1:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim_1 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim_1);
                secondVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim_1);
                break;
            }
            case 0:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim0 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim0);
                secondVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim0);
                break;
            }
            case 1:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim1 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim1);
                secondVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim1);
                break;
            }
            case 2:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim2 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim2);
                secondVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim2);
                break;
            }
            case 3:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim3 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim3);
                secondVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim3);
                break;
            }
            case 4:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.CargoVolumeTrim4 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Ullage, searchedValue.First().CargoVolumeTrim4);
                secondVolume.Add(searchedValue.Last().Ullage, searchedValue.Last().CargoVolumeTrim4);
                break;
            }
        }

        // интерполируем значения по обьему и получаем два ullages
        // которые потом интреполируем/экстраполируем по дифференту

        //подготовка для первых расчетов:
        var firstUllageForCalc = firstVolume.Keys.First();
        var secondUllageForCalc = firstVolume.Keys.Last();

        var firstVolumeForCalc = firstVolume.Values.First();
        var secondVolumeForCalc = firstVolume.Values.Last();

        var firstUllage = GetInterpolatedValue(firstVolumeForCalc, secondVolumeForCalc, volume,
            firstUllageForCalc, secondUllageForCalc);

        //подготовка для вторых расчетов:
        firstUllageForCalc = secondVolume.Keys.First();
        secondUllageForCalc = secondVolume.Keys.Last();

        firstVolumeForCalc = secondVolume.Values.First();
        secondVolumeForCalc = secondVolume.Values.Last();

        var secondUllage = GetInterpolatedValue(firstVolumeForCalc, secondVolumeForCalc, volume,
            firstUllageForCalc, secondUllageForCalc);

        if (trim >= -1 && trim <= 4)
        {
            // интерполируем
            var interKoef = (trim - closestTrims[0]) / (closestTrims[1] - closestTrims[0]);
            return GetInterpolatedValueByKoef(interKoef,firstUllage,secondUllage);
        }
        else
        {
            // экстраполируем
            var extraKoef = (trim - closestTrims[0]) / (closestTrims[0] - closestTrims[1]);
            return GetExtrapoladedValueByKoef(extraKoef,firstUllage,secondUllage);
        }
    }

    // private Value_Table_CargoTankUllageTrim GetInterpolatedFullValue(Value_Table_CargoTankUllageTrim valueFirst,
    //     Value_Table_CargoTankUllageTrim valueSecond, double koef)
    // {
    //     return new Value_Table_CargoTankUllageTrim
    //     (
    //         GetInterpolatedValueByKoef(koef, valueFirst.Ullage, valueSecond.Ullage),
    //         GetInterpolatedValueByKoef(koef, valueFirst.CargoVolumeTrim4, valueSecond.CargoVolumeTrim4),
    //         GetInterpolatedValueByKoef(koef, valueFirst.CargoVolumeTrim3, valueSecond.CargoVolumeTrim3),
    //         GetInterpolatedValueByKoef(koef, valueFirst.CargoVolumeTrim2, valueSecond.CargoVolumeTrim2),
    //         GetInterpolatedValueByKoef(koef, valueFirst.CargoVolumeTrim1, valueSecond.CargoVolumeTrim1),
    //         GetInterpolatedValueByKoef(koef, valueFirst.CargoVolumeTrim0, valueSecond.CargoVolumeTrim0),
    //         GetInterpolatedValueByKoef(koef, valueFirst.CargoVolumeTrim_1, valueSecond.CargoVolumeTrim_1));
    // }

}
