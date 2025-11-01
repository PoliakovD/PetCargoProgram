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
    private List<ValueTableHydrostatic> Table { get; set; }

    public ServiceHydrostatic(TablesHydrostatic hydrostatic)
    {
        Table= hydrostatic.Tables[1].Table;
    }

    public ValueTableHydrostatic GetValue(double displacement)
    {
        CheckDisplacement(displacement);
        // Получаем ближайшие значения
        var closest = GetClosestTableValuesByDisplacement(displacement);
        var interKoef = (displacement - closest.First().Displacement)
                             / (closest.Last().Displacement - closest.First().Displacement);
        return GetInterpolatedFullValue(closest[0],closest[1],interKoef,displacement);

    }

    public double GetDisplacement(double draft)
    {
        // Получаем ближайшие значения
        var closest = GetClosestTableValuesByDraft(draft);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Draft,closest[1].Draft,draft,
            closest[0].Displacement,closest[1].Displacement);
    }
    public double GetDraft(double displacement)
    {
        CheckDisplacement(displacement);
        // Получаем ближайшие значения
        var closest = GetClosestTableValuesByDisplacement(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Displacement,closest[1].Displacement,displacement,
            closest[0].Draft,closest[1].Draft);
    }
    public double GetTPC(double displacement)
    {
        CheckDisplacement(displacement);
        // Получаем ближайшие значения
        var closest = GetClosestTableValuesByDisplacement(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Displacement,closest[1].Displacement,displacement,
            closest[0].TPC,closest[1].TPC);
    }
    public double GetKM(double displacement)
    {
        CheckDisplacement(displacement);
        // Получаем ближайшие значения
        var closest = GetClosestTableValuesByDisplacement(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Displacement,closest[1].Displacement,displacement,
            closest[0].MetacentrKM,closest[1].MetacentrKM);
    }
    public double GetLCF(double draft)
    {
        // Получаем ближайшие значения
        var closest = GetClosestTableValuesByDraft(draft);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Draft,closest[1].Draft,draft,
            closest[0].FloatationCenterLCF,closest[1].FloatationCenterLCF);
    }
    public double GetMCTC(double displacement)
    {
        CheckDisplacement(displacement);
        // Получаем ближайшие значения
        var closest = GetClosestTableValuesByDisplacement(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Displacement,closest[1].Displacement,displacement,
            closest[0].MCTC,closest[1].MCTC);
    }
    public double GetLCB(double displacement)
    {
        CheckDisplacement(displacement);
        // Получаем ближайшие значения
        var closest = GetClosestTableValuesByDisplacement(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Displacement,closest[1].Displacement,displacement,
            closest[0].LCB,closest[1].LCB);
    }
    public double GetCM(double displacement)
    {
        CheckDisplacement(displacement);
        // Получаем ближайшие значения
        var closest = GetClosestTableValuesByDisplacement(displacement);
        // Возвращаем интерполированное значение
        return GetInterpolatedValue(closest[0].Displacement,closest[1].Displacement,displacement,
            closest[0].CM,closest[1].CM);
    }
    private List<ValueTableHydrostatic> GetClosestTableValuesByDisplacement(double displacement)
    {
        // Находим два значения в таблице, ближайшие к volume
        return Table.OrderBy(n => Math.Abs(n.Displacement - displacement)).Take(2).ToList();
    }
    private List<ValueTableHydrostatic> GetClosestTableValuesByDraft(double draft)
    {
        // Находим два значения в таблице, ближайшие к volume
        return Table.OrderBy(n => Math.Abs(n.Draft - draft)).Take(2).ToList();
    }

    private void CheckDisplacement(double displacement)
    {
        //Проверка входных значений
        if (displacement < 0) throw new Exception($"Дисплейсмент {displacement} меньше нуля");
        var maxdisplacement =Table.Max(x => x.Displacement)+double.Epsilon;
        if (displacement > maxdisplacement)
            throw new Exception($"Дисплейсмент {displacement} больше максимального {maxdisplacement}");
    }

    private ValueTableHydrostatic GetInterpolatedFullValue(ValueTableHydrostatic valueFirst,
        ValueTableHydrostatic valueSecond, double koef, double displacement)
    {

        return new ValueTableHydrostatic
        (displacement,
            GetInterpolatedValueByKoef(koef, valueFirst.Draft, valueSecond.Draft),
            GetInterpolatedValueByKoef(koef, valueFirst.TPC, valueSecond.TPC),
            GetInterpolatedValueByKoef(koef, valueFirst.MetacentrKM, valueSecond.MetacentrKM),
            GetInterpolatedValueByKoef(koef, valueFirst.FloatationCenterLCF, valueSecond.FloatationCenterLCF),
            GetInterpolatedValueByKoef(koef, valueFirst.MCTC, valueSecond.MCTC),
            GetInterpolatedValueByKoef(koef, valueFirst.LCB, valueSecond.LCB),
            GetInterpolatedValueByKoef(koef, valueFirst.CM, valueSecond.CM));
    }
}
