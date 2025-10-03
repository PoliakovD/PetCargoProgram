using System;
using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using static PetCargoProgram.Services.CargoTables.ServiceFindAndCalcHelper;
using System.Linq;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Services.CargoTables;

public class ServiceBallastSoundTrim
{
    private List<Table_BallSoundTrim> Tables { get; set; }

    public ServiceBallastSoundTrim(Tables_BallSoundTrim tablesBallSoundTrim)
    {
        Tables= tablesBallSoundTrim.Tables;
    }
    public double GetMaxSound(string name)
        => Tables.FirstOrDefault(x => x.Name == name)!.Table.Last().Sound;

    public double GetVolumeWithTrim(string name, double sound, double trim=0.0)
    {
        // Выбираем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == name);

        // Проверка на наличие таблицы
        if (table == null) throw new Exception($"Не найдена таблица для танка {name}");

        //Проверка входных значений
        if(sound<0.0) throw new Exception("Пустота не может быть меньше нуля");
        if (trim>8.0) throw new Exception("Trim не может быть больше 8");
        if(trim<-4.0) throw new Exception("Trim не может быть меньше -4");

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

        //Расчет объема по дифференту
        Dictionary<int, double> trimsVolumes = [];

        trimsVolumes.Add(0, GetInterpolatedValueByKoef(koef,
            closestFirst.VolumeTrim0,
            closestLast.VolumeTrim0));
        trimsVolumes.Add(1, GetInterpolatedValueByKoef(koef,
            closestFirst.VolumeTrim1,
            closestLast.VolumeTrim1));
        trimsVolumes.Add(2, GetInterpolatedValueByKoef(koef,
            closestFirst.VolumeTrim2,
            closestLast.VolumeTrim2));
        trimsVolumes.Add(3, GetInterpolatedValueByKoef(koef,
            closestFirst.VolumeTrim3,
            closestLast.VolumeTrim3));
        trimsVolumes.Add(4, GetInterpolatedValueByKoef(koef,
            closestFirst.VolumeTrim4,
            closestLast.VolumeTrim4));
        trimsVolumes.Add(5, GetInterpolatedValueByKoef(koef,
            closestFirst.VolumeTrim5,
            closestLast.VolumeTrim5));

        // получаем значение по trim
        var result =GetValueInDictionary(trimsVolumes,
            trim,0,5);
        return result;
    }

    public double GetSoundWithTrim(string name, double volume, double trim=0.0)
    {
        // Выбираем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == name);

        // Проверка на наличие таблицы
        if (table == null) throw new Exception($"Не найдена таблица для танка {name}");

        //Проверка входных значений
        if(volume<0.0) throw new Exception("Объем не может быть меньше нуля");
        if (trim>8.0) throw new Exception("Trim не может быть больше 8");
        if(trim<-4.0) throw new Exception("Trim не может быть меньше -4");

        // Проверяем volume
        var maxVolume = table.Table.Last().VolumeTrim0 + double.Epsilon;
        if(volume > maxVolume)
            throw new Exception($"Объем {volume} больше максимального {maxVolume}");

        // ищем ближайшие значения для диферентов
        int[] indexedTrims = new int[]{0,1,2,3,4,5};
        var closestTrims = indexedTrims.OrderBy(n => Math.Abs(n - trim)).Take(2).ToList();

        // в ближайших дифферентах идем по столбцам и находим ближайшее значения обьемов
        var firstVolume = new Dictionary<double, double>();
        var secondVolume = new Dictionary<double, double>();

        var maxSound = GetMaxSound(name);

        switch (closestTrims[0])
        {
            case 0:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim0 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim0);
                firstVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim0);
                break;
            }
            case 1:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim1 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim1);
                firstVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim1);
                break;
            }
            case 2:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim2 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim2);
                firstVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim2);
                break;
            }
            case 3:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim3 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim3);
                firstVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim3);
                break;
            }
            case 4:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim4 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim4);
                firstVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim4);
                break;
            }
            case 5:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim5 - volume)).Take(2);
                firstVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim5);
                firstVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim5);
                break;
            }
        }

        switch (closestTrims[1])
        {
            case 0:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim0 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim0);
                secondVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim0);
                break;
            }
            case 1:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim1 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim1);
                secondVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim1);
                break;
            }
            case 2:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim2 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim2);
                secondVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim2);
                break;
            }
            case 3:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim3 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim3);
                secondVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim3);
                break;
            }
            case 4:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim4 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim4);
                secondVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim4);
                break;
            }
            case 5:
            {
                var searchedValue = table.Table.OrderBy(n =>
                    Math.Abs(n.VolumeTrim5 - volume)).Take(2);
                secondVolume.Add(searchedValue.First().Sound, searchedValue.First().VolumeTrim5);
                secondVolume.Add(searchedValue.Last().Sound, searchedValue.Last().VolumeTrim5);
                break;
            }
        }

        // интерполируем значения по обьему и получаем два sounds
        // которые потом интреполируем/экстраполируем по дифференту

        //подготовка для первых расчетов:
        var firstSoundForCalc = firstVolume.Keys.First();
        var secondSoundForCalc = firstVolume.Keys.Last();

        var firstVolumeForCalc = firstVolume.Values.First();
        var secondVolumeForCalc = firstVolume.Values.Last();

        var firstUllage = GetInterpolatedValue(firstVolumeForCalc, secondVolumeForCalc, volume,
            firstSoundForCalc, secondSoundForCalc);
        if(firstUllage < 0.0) firstUllage=0.0;
        if(firstUllage > maxSound) firstUllage=maxSound;

        //подготовка для вторых расчетов:
        firstSoundForCalc = secondVolume.Keys.First();
        secondSoundForCalc = secondVolume.Keys.Last();

        firstVolumeForCalc = secondVolume.Values.First();
        secondVolumeForCalc = secondVolume.Values.Last();

        var secondUllage = GetInterpolatedValue(firstVolumeForCalc, secondVolumeForCalc, volume,
            firstSoundForCalc, secondSoundForCalc);
        if(secondUllage < 0.0) secondUllage=0.0;
        if(secondUllage > maxSound) secondUllage=maxSound;


        double result=maxSound;
        if (trim >= 0 && trim <= 5)
        {
            // интерполируем
            if (Math.Abs(trim - closestTrims[0]) > 0.0001)
            {
                var interKoef = (trim - closestTrims[0]) / (closestTrims[1] - closestTrims[0]);
                result = GetInterpolatedValueByKoef(interKoef,firstUllage,secondUllage);
            }
            else result = firstUllage;

        }
        else
        {
            // экстраполируем
            if (Math.Abs(trim - closestTrims[0]) > 0.0001)
            {
                var extraKoef = (trim - closestTrims[0]) / (closestTrims[0] - closestTrims[1]);
                result = GetExtrapoladedValueByKoef(extraKoef,firstUllage,secondUllage);
            }
            else result = firstUllage;

        }
        return result;

    }
}
