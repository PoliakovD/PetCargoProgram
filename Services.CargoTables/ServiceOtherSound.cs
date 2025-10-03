using System;
using System.Collections.Generic;
using System.Linq;
using PetCargoProgram.Models.CargoTables.Table;
using static PetCargoProgram.Services.CargoTables.ServiceFindAndCalcHelper;
using PetCargoProgram.Models.CargoTables.Tables;

namespace PetCargoProgram.Services.CargoTables;

public class ServiceOtherSound
{
    private List<Table_OtherSounding> Tables { get; set; }

    public ServiceOtherSound(Tables_OtherSounding tables)
    {
        Tables = tables.Tables;
    }
    public double GetMaxSound(string name)
        => Tables.FirstOrDefault(x => x.Name == name)!.Table.Last().Sound;
    public double GetMaxVolume(string name)
        => Tables.FirstOrDefault(x => x.Name == name)!.Table.Last().Volume;

    public double GetVolumeWithSound(string name, double sound)
    {
        // Выбираем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == name);

        // Проверка на наличие таблицы
        if (table == null) throw new Exception($"Не найдена таблица для танка {name}");

        //Проверка входных значений
        if(sound<0.0) throw new Exception("Пустота не может быть меньше нуля");

        // Проверяем sound
        var maxSound = GetMaxSound(name)+double.Epsilon;
        if(sound > maxSound)
            throw new Exception($"Взлив {sound} больше максимального {maxSound}");

        // Находим два значения в таблице, ближайшие к sound
        var closest = table.Table
            .OrderBy(n => Math.Abs(n.Sound - sound))
            .Take(2);

        var closestFirst = closest.First();
        var closestLast = closest.Last();

        //расчет коэффициента для интерполяции по пустоте
        var koef = 0.0;
        var soundFirst = closestFirst.Sound;
        var soundLast = closestLast.Sound;
        if (soundFirst != sound) koef = (sound-soundFirst)/(soundLast-soundFirst);

        //Расчет объема

        return GetInterpolatedValueByKoef(koef, closestFirst.Volume, closestLast.Volume);
    }
    public double GetSoundWithVolume(string name, double volume)
    {
        // Выбираем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == name);

        // Проверка на наличие таблицы
        if (table == null) throw new Exception($"Не найдена таблица для танка {name}");

        //Проверка входных значений
        if(volume<0.0) throw new Exception("Объем не может быть меньше нуля");

        // Проверяем sound
        var maxVolume = GetMaxVolume(name)+double.Epsilon;
        if(volume > maxVolume)
            throw new Exception($"Объем {volume} больше максимального {maxVolume}");

        // Находим два значения в таблице, ближайшие к sound
        var closest = table.Table
            .OrderBy(n => Math.Abs(n.Volume - volume))
            .Take(2);

        var closestFirst = closest.First();
        var closestLast = closest.Last();

        //расчет коэффициента для интерполяции по пустоте
        var koef = 0.0;
        var volumeFirst = closestFirst.Sound;
        var volumeLast = closestLast.Sound;
        if (volumeFirst != volume) koef = (volume-volumeFirst)/(volumeLast-volumeFirst);

        //Расчет взлива по дифференту
        return GetInterpolatedValueByKoef(koef, closestFirst.Sound, closestLast.Sound);
    }
}
