using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using static PetCargoProgram.Services.CargoTables.ServiceFindAndCalcHelper;
using System.Linq;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Services.CargoTables;
public class ServiceVolume
{
    private List<Table_Volume> Tables { get; set; }

    public ServiceVolume(Tables_Volume volume)
    {
        Tables= volume.Tables;
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

    private List<Value_Table_Volume> GetClosestTableValues(string name, double volume)
    {
        // Выбираем таблицу для нужного танка
        var table = Tables.FirstOrDefault(x => x.Name == name);
        // Проверка на наличие таблицы
        if (table == null) throw new Exception($"Не найдена таблица для танка {name}");

        //Проверка входных значений
        if (volume < 0 ) throw new Exception("Объем не может быть отрицательным");
        var maxVolume = table.Table.MaxBy(x => x.Volume).Volume + double.Epsilon;
        if (volume > maxVolume)
            throw new Exception($"Объем {volume} больше, чем наибольший объем {maxVolume} для танка {name}");

        // Находим два значения в таблице, ближайшие к volume
        return table.Table.OrderBy(n => Math.Abs(n.Volume - volume)).Take(2).ToList();
    }
}
