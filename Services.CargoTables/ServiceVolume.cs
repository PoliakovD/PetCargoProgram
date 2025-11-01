using System;
using System.Collections.Generic;
using System.Linq;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using static PetCargoProgram.Services.CargoTables.ServiceFindAndCalcHelper;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Services.CargoTables;
public class ServiceVolume
{
    public List<TableVolume> Tables { get; set; }

    public ServiceVolume(TablesVolume volume)
    {
        Tables= volume.Tables;
    }
    public double GetMaxVolume(string name)
        =>Tables.FirstOrDefault(x=>x.Name==name)!.Table.Last().Volume;

    public double GetPercentsVolume(string name, double volume) => volume / GetMaxVolume(name);
    public ValueTableVolume GetValue(string name, double volume)
    {
        // Получаем ближайшие значения
        var closest = GetClosestTableValues(name,volume);
        if (Math.Abs(closest[0].Volume - volume) > 0.25)
        {
            var interKoef = (volume - closest.First().Volume) / (closest.Last().Volume - closest.First().Volume);
            return GetInterpolatedFullValue(closest[0],closest[1],interKoef,volume);
        }
        return closest[0];

    }


    public double GetLCG(string name, double volume)
    {

        // Находим два значения в таблице, ближайшие к volume
        var closest = GetClosestTableValues(name, volume);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Volume,closest[1].Volume,volume,
                        closest[0].LCG,closest[1].LCG);
    }
    public double GetTCG(string name, double volume)
    {
        // Находим два значения в таблице, ближайшие к volume
        var closest = GetClosestTableValues(name, volume);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Volume,closest[1].Volume,volume,
            closest[0].TCG,closest[1].TCG);
    }

    public double GetVCG(string name, double volume)
    {
        // Находим два значения в таблице, ближайшие к volume
        var closest = GetClosestTableValues(name, volume);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Volume,closest[1].Volume,volume,
            closest[0].VCG,closest[1].VCG);
    }

    public double GetIY(string name, double volume)
    {
        // Находим два значения в таблице, ближайшие к volume
        var closest = GetClosestTableValues(name, volume);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Volume,closest[1].Volume,volume,
            closest[0].IY,closest[1].IY);
    }

    private List<ValueTableVolume> GetClosestTableValues(string name, double volume)
    {
        // Выбираем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == name);
        // Проверка на наличие таблицы
        if (table == null) throw new Exception($"Не найдена таблица для танка {name}");

        //Проверка входных значений
        if (volume < 0 ) throw new Exception("Объем не может быть отрицательным");
        var maxVolume = table.Table.MaxBy(x => x.Volume)!.Volume + double.Epsilon;
        if (volume > maxVolume)
            throw new Exception($"Объем {volume} больше, чем наибольший объем {maxVolume} для танка {name}");
        // TODO - Проверка на выход за границы и обработка

        // Находим два значения в таблице, ближайшие к volume
        return table.Table.OrderBy(n => Math.Abs(n.Volume - volume)).Take(2).ToList();
    }

    private ValueTableVolume GetInterpolatedFullValue(ValueTableVolume valueFirst, ValueTableVolume valueSecond,
        double interKoef, double volume)
    {
        return new ValueTableVolume
        (volume,
            GetInterpolatedValueByKoef(interKoef, valueFirst.LCG, valueSecond.LCG),
            GetInterpolatedValueByKoef(interKoef, valueFirst.TCG, valueSecond.TCG),
            GetInterpolatedValueByKoef(interKoef, valueFirst.VCG, valueSecond.VCG),
            GetInterpolatedValueByKoef(interKoef, valueFirst.IY, valueSecond.IY));
    }
}
