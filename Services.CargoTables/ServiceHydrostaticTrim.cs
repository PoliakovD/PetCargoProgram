using System;
using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using static PetCargoProgram.Services.CargoTables.ServiceFindAndCalcHelper;
using System.Linq;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Services.CargoTables;
// гидростатические таблицы при деференте trim
public partial class ServiceHydrostaticTrim
{
    private List<Table_Hydrostatic> Tables { get; set; }

    public ServiceHydrostaticTrim(Tables_Hydrostatic hydrostatic)
    {
        Tables= hydrostatic.Tables;
    }

    public Value_Table_Hydrostatic GetValue(double displacement, double trim)
    {
        // Получаем ближайшие таблицы
        var closest = GetClosestTables(trim);

        // Получаем ближайшие значения
        var closestFirstValues = GetClosestTableValues(displacement,closest[0]);
        var closestSecondValues = GetClosestTableValues(displacement,closest[1]);

        // Вычисляем интерполированное значения для первого значения
        var interKoef = (displacement - closestFirstValues.First().Displacement)
                        / (closestFirstValues.Last().Displacement - closestFirstValues.First().Displacement);
        var closestFirstInterpolatedValue = GetInterpolatedFullValue(
            closestFirstValues.First(),
            closestFirstValues.Last(),
            interKoef, displacement, true);

        // Вычисляем интерполированное значения для второго значения
        interKoef = (displacement - closestSecondValues.First().Displacement)
                    / (closestSecondValues.Last().Displacement - closestSecondValues.First().Displacement);
        var closestSecondInterpolatedValue = GetInterpolatedFullValue(
            closestSecondValues.First(),
            closestSecondValues.Last(),
            interKoef, displacement, true);

        // Вычисляем полное значениe
        if (trim >= -1 && trim <= 4)
        {
            // интерполируем
            interKoef = (trim - closest.Keys.First()) / (closest.Keys.Last() - closest.Keys.First());
            return GetInterpolatedFullValue(closestFirstInterpolatedValue,closestSecondInterpolatedValue,interKoef,
                displacement, true);
        }
        else
        {
            // экстраполируем
            var extraKoef = (trim - closest.Keys.First()) / (closest.Keys.First() - closest.Keys.Last());
            return GetInterpolatedFullValue(closestFirstInterpolatedValue,closestSecondInterpolatedValue,extraKoef,
                displacement, false);
        }

    }
    // Возможно Useless, поэтому пока в комментах, может потом пригодится

    // public double GetDraft(double displacement, double trim)
    // {
    //     // Получаем ближайшие таблицы
    //     var closest = GetClosestTables(trim);
    //
    //     // Получаем ближайшие значения
    //     var closestFirstValues = GetClosestTableValues(displacement,closest[0]);
    //     var closestSecondValues = GetClosestTableValues(displacement,closest[1]);
    //
    //     // Вычисляем интерполированное значения для первого значения
    //     var closestFirstInterpolatedValue = GetInterpolatedValue(
    //         closestFirstValues.First().Displacement,
    //         closestFirstValues.Last().Displacement,
    //         displacement,
    //         closestFirstValues.First().Draft,
    //         closestFirstValues.Last().Draft);
    //
    //     // Вычисляем интерполированное значения для второго значения
    //     var closestSecondInterpolatedValue = GetInterpolatedValue(
    //         closestSecondValues.First().Displacement,
    //         closestSecondValues.Last().Displacement,
    //         displacement,
    //         closestSecondValues.First().Draft,
    //         closestSecondValues.Last().Draft);
    //
    //     // Вычисляем интерполированные значения
    //     var trimFirstClosest = closest.Keys.First();
    //     var trimSecondClosest = closest.Keys.Last();
    //
    //     return GetInterpolatedValueByTwoValues(trimFirstClosest, trimSecondClosest,trim,
    //         closestFirstInterpolatedValue,closestSecondInterpolatedValue);
    // }
    // public double GetTPC(double displacement, double trim)
    // {
    //     // Получаем ближайшие таблицы
    //     var closest = GetClosestTables(trim);
    //
    //     // Получаем ближайшие значения
    //     var closestFirstValues = GetClosestTableValues(displacement,closest[0]);
    //     var closestSecondValues = GetClosestTableValues(displacement,closest[1]);
    //
    //     // Вычисляем интерполированное значения для первого значения
    //     var closestFirstInterpolatedValue = GetInterpolatedValue(
    //         closestFirstValues.First().Displacement,
    //         closestFirstValues.Last().Displacement,
    //         displacement,
    //         closestFirstValues.First().TPC,
    //         closestFirstValues.Last().TPC);
    //
    //     // Вычисляем интерполированное значения для второго значения
    //     var closestSecondInterpolatedValue = GetInterpolatedValue(
    //         closestSecondValues.First().Displacement,
    //         closestSecondValues.Last().Displacement,
    //         displacement,
    //         closestSecondValues.First().TPC,
    //         closestSecondValues.Last().TPC);
    //
    //     // Вычисляем интерполированные значения
    //     var trimFirstClosest = closest.Keys.First();
    //     var trimSecondClosest = closest.Keys.Last();
    //
    //     return GetInterpolatedValueByTwoValues(trimFirstClosest, trimSecondClosest,trim,
    //         closestFirstInterpolatedValue,closestSecondInterpolatedValue);
    // }
    // public double GetKM(double displacement, double trim)
    // {
    //     // Получаем ближайшие таблицы
    //     var closest = GetClosestTables(trim);
    //
    //     // Получаем ближайшие значения
    //     var closestFirstValues = GetClosestTableValues(displacement,closest[0]);
    //     var closestSecondValues = GetClosestTableValues(displacement,closest[1]);
    //
    //     // Вычисляем интерполированное значения для первого значения
    //     var closestFirstInterpolatedValue = GetInterpolatedValue(
    //         closestFirstValues.First().Displacement,
    //         closestFirstValues.Last().Displacement,
    //         displacement,
    //         closestFirstValues.First().MetacentrKM,
    //         closestFirstValues.Last().MetacentrKM);
    //
    //     // Вычисляем интерполированное значения для второго значения
    //     var closestSecondInterpolatedValue = GetInterpolatedValue(
    //         closestSecondValues.First().Displacement,
    //         closestSecondValues.Last().Displacement,
    //         displacement,
    //         closestSecondValues.First().MetacentrKM,
    //         closestSecondValues.Last().MetacentrKM);
    //
    //     // Вычисляем интерполированные значения
    //     var trimFirstClosest = closest.Keys.First();
    //     var trimSecondClosest = closest.Keys.Last();
    //
    //     return GetInterpolatedValueByTwoValues(trimFirstClosest, trimSecondClosest,trim,
    //         closestFirstInterpolatedValue,closestSecondInterpolatedValue);
    // }
    // public double GetLCF(double displacement, double trim)
    // {
    //     // Получаем ближайшие таблицы
    //     var closest = GetClosestTables(trim);
    //
    //     // Получаем ближайшие значения
    //     var closestFirstValues = GetClosestTableValues(displacement,closest[0]);
    //     var closestSecondValues = GetClosestTableValues(displacement,closest[1]);
    //
    //     // Вычисляем интерполированное значения для первого значения
    //     var closestFirstInterpolatedValue = GetInterpolatedValue(
    //         closestFirstValues.First().Displacement,
    //         closestFirstValues.Last().Displacement,
    //         displacement,
    //         closestFirstValues.First().FloatationCenterLCF,
    //         closestFirstValues.Last().FloatationCenterLCF);
    //
    //     // Вычисляем интерполированное значения для второго значения
    //     var closestSecondInterpolatedValue = GetInterpolatedValue(
    //         closestSecondValues.First().Displacement,
    //         closestSecondValues.Last().Displacement,
    //         displacement,
    //         closestSecondValues.First().FloatationCenterLCF,
    //         closestSecondValues.Last().FloatationCenterLCF);
    //
    //     // Вычисляем интерполированные значения
    //     var trimFirstClosest = closest.Keys.First();
    //     var trimSecondClosest = closest.Keys.Last();
    //
    //     return GetInterpolatedValueByTwoValues(trimFirstClosest, trimSecondClosest,trim,
    //         closestFirstInterpolatedValue,closestSecondInterpolatedValue);
    // }
    // public double GetMCTC(double displacement, double trim)
    // {
    //     // Получаем ближайшие таблицы
    //     var closest = GetClosestTables(trim);
    //
    //     // Получаем ближайшие значения
    //     var closestFirstValues = GetClosestTableValues(displacement,closest[0]);
    //     var closestSecondValues = GetClosestTableValues(displacement,closest[1]);
    //
    //     // Вычисляем интерполированное значения для первого значения
    //     var closestFirstInterpolatedValue = GetInterpolatedValue(
    //         closestFirstValues.First().Displacement,
    //         closestFirstValues.Last().Displacement,
    //         displacement,
    //         closestFirstValues.First().MCTC,
    //         closestFirstValues.Last().MCTC);
    //
    //     // Вычисляем интерполированное значения для второго значения
    //     var closestSecondInterpolatedValue = GetInterpolatedValue(
    //         closestSecondValues.First().Displacement,
    //         closestSecondValues.Last().Displacement,
    //         displacement,
    //         closestSecondValues.First().MCTC,
    //         closestSecondValues.Last().MCTC);
    //
    //     // Вычисляем интерполированные значения
    //     var trimFirstClosest = closest.Keys.First();
    //     var trimSecondClosest = closest.Keys.Last();
    //
    //     return GetInterpolatedValueByTwoValues(trimFirstClosest, trimSecondClosest,trim,
    //         closestFirstInterpolatedValue,closestSecondInterpolatedValue);
    // }
    // public double GetLCB(double displacement, double trim)
    // {
    //     // Получаем ближайшие таблицы
    //     var closest = GetClosestTables(trim);
    //
    //     // Получаем ближайшие значения
    //     var closestFirstValues = GetClosestTableValues(displacement,closest[0]);
    //     var closestSecondValues = GetClosestTableValues(displacement,closest[1]);
    //
    //     // Вычисляем интерполированное значения для первого значения
    //     var closestFirstInterpolatedValue = GetInterpolatedValue(
    //         closestFirstValues.First().Displacement,
    //         closestFirstValues.Last().Displacement,
    //         displacement,
    //         closestFirstValues.First().LCB,
    //         closestFirstValues.Last().LCB);
    //
    //     // Вычисляем интерполированное значения для второго значения
    //     var closestSecondInterpolatedValue = GetInterpolatedValue(
    //         closestSecondValues.First().Displacement,
    //         closestSecondValues.Last().Displacement,
    //         displacement,
    //         closestSecondValues.First().LCB,
    //         closestSecondValues.Last().LCB);
    //
    //     // Вычисляем интерполированные значения
    //     var trimFirstClosest = closest.Keys.First();
    //     var trimSecondClosest = closest.Keys.Last();
    //
    //     return GetInterpolatedValueByTwoValues(trimFirstClosest, trimSecondClosest,trim,
    //         closestFirstInterpolatedValue,closestSecondInterpolatedValue);
    // }
    // public double GetCM(double displacement, double trim)
    // {
    //     // Получаем ближайшие таблицы
    //     var closest = GetClosestTables(trim);
    //
    //     // Получаем ближайшие значения
    //     var closestFirstValues = GetClosestTableValues(displacement,closest[0]);
    //     var closestSecondValues = GetClosestTableValues(displacement,closest[1]);
    //
    //     // Вычисляем интерполированное значения для первого значения
    //     var closestFirstInterpolatedValue = GetInterpolatedValue(
    //         closestFirstValues.First().Displacement,
    //         closestFirstValues.Last().Displacement,
    //         displacement,
    //         closestFirstValues.First().CM,
    //         closestFirstValues.Last().CM);
    //
    //     // Вычисляем интерполированное значения для второго значения
    //     var closestSecondInterpolatedValue = GetInterpolatedValue(
    //         closestSecondValues.First().Displacement,
    //         closestSecondValues.Last().Displacement,
    //         displacement,
    //         closestSecondValues.First().CM,
    //         closestSecondValues.Last().CM);
    //
    //     // Вычисляем интерполированные значения
    //     var trimFirstClosest = closest.Keys.First();
    //     var trimSecondClosest = closest.Keys.Last();
    //
    //     return GetInterpolatedValueByTwoValues(trimFirstClosest, trimSecondClosest,trim,
    //         closestFirstInterpolatedValue,closestSecondInterpolatedValue);
    // }
}
