using System;
using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using static PetCargoProgram.Services.CargoTables.ServiceFindAndCalcHelper;
using System.Linq;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Services.CargoTables;
// гидростатические таблицы при деференте 0
public class ServiceHydrostatic
{
    private List<Value_Table_Hydrostatic> Table { get; set; }

    public ServiceHydrostatic(Tables_Hydrostatic hydrostatic)
    {
        Table= hydrostatic.Tables[0].Table;
    }

    public double GetDraft(double displacement)
    {
        // Получаем ближайшие значения
        var closest = GetClosestTableValues(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].displacement,closest[1].displacement,displacement,
            closest[0].draft,closest[1].draft);
    }
    public double GetTPC(double displacement)
    {
        // Получаем ближайшие значения
        var closest = GetClosestTableValues(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].displacement,closest[1].displacement,displacement,
            closest[0].tpc,closest[1].tpc);
    }
    public double GetKM(double displacement)
    {
        // Получаем ближайшие значения
        var closest = GetClosestTableValues(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].displacement,closest[1].displacement,displacement,
            closest[0].metacentrKM,closest[1].metacentrKM);
    }
    public double GetLCF(double displacement)
    {
        // Получаем ближайшие значения
        var closest = GetClosestTableValues(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].displacement,closest[1].displacement,displacement,
            closest[0].FloatationCenterLCF,closest[1].FloatationCenterLCF);
    }
    public double GetMCTC(double displacement)
    {
        // Получаем ближайшие значения
        var closest = GetClosestTableValues(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].displacement,closest[1].displacement,displacement,
            closest[0].MCTC,closest[1].MCTC);
    }
    public double GetLCB(double displacement)
    {
        // Получаем ближайшие значения
        var closest = GetClosestTableValues(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].displacement,closest[1].displacement,displacement,
            closest[0].LCB,closest[1].LCB);
    }
    public double GetCM(double displacement)
    {
        // Получаем ближайшие значения
        var closest = GetClosestTableValues(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].displacement,closest[1].displacement,displacement,
            closest[0].CM,closest[1].CM);
    }
    private List<Value_Table_Hydrostatic> GetClosestTableValues(double displacement)
    {
        //Проверка входных значений
        if (displacement < 0) throw new Exception($"Дисплейсмент {displacement} меньше нуля");
        var maxdisplacement =Table.Max(x => x.displacement)+double.Epsilon;
        if (displacement > maxdisplacement)
            throw new Exception($"Дисплейсмент {displacement} больше максимального {maxdisplacement}");

        // Находим два значения в таблице, ближайшие к volume
        return Table.OrderBy(n => Math.Abs(n.displacement - displacement)).Take(2).ToList();
    }
}
