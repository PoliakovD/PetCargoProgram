using System;
using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using static PetCargoProgram.Services.CargoTables.ServiceFindAndCalcHelper;
using System.Linq;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Services.CargoTables;

public partial class ServiceHydrostaticTrim
{

    private List<Value_Table_Hydrostatic> GetClosestTableValues(double displacement, Table_Hydrostatic table)
    {
        //Проверка входных значений
        if (displacement < 0) throw new Exception($"Дисплейсмент {displacement} меньше нуля");
        var maxdisplacement =table.Table.Max(x => x.Displacement)+double.Epsilon;
        if (displacement > maxdisplacement)
            throw new Exception($"Дисплейсмент {displacement} больше максимального {maxdisplacement}");

        // Находим два значения в таблице, ближайшие к volume
        return table.Table.OrderBy(n => Math.Abs(n.Displacement - displacement)).Take(2).ToList();

    }
    private Dictionary<int,Table_Hydrostatic> GetClosestTables(double trim)
    {
        int[] indexedTrims = new int[]{-1,0,1,2,3,4};
        var searchedIndexes = indexedTrims.OrderBy(n => Math.Abs((double)n - trim)).Take(2).ToList();
        return new Dictionary<int,Table_Hydrostatic>
        {
            {searchedIndexes[0],Tables[searchedIndexes[0]+1]},
            {searchedIndexes[1],Tables[searchedIndexes[1]+1]}
        };
    }

    private double GetInterpolatedValueByTwoValues(double trimFirst, double trimSecond, double trim, double valueFirst,
        double valueSecond)
    {
        if (trim >= -1 && trim <= 4)
        {
            // интерполируем
            var interKoef = (trim - trimFirst) / (trimSecond - trimFirst);
            return GetInterpolatedValueByKoef(interKoef,valueFirst,valueSecond);
        }
        else
        {
            // экстраполируем
            var extraKoef = (trim - trimFirst) / (trimFirst - trimSecond);
            return GetExtrapoladedValueByKoef(extraKoef,valueFirst,valueSecond);
        }
    }

    private Value_Table_Hydrostatic GetInterpolatedFullValue(Value_Table_Hydrostatic valueFirst,
        Value_Table_Hydrostatic valueSecond, double koef, double displacement, bool IsInterpolated=true)
    {
        if (IsInterpolated)
        {
            return new Value_Table_Hydrostatic
            (displacement,
                GetInterpolatedValueByKoef(koef, valueFirst.Draft, valueSecond.Draft),
                GetInterpolatedValueByKoef(koef, valueFirst.TPC, valueSecond.TPC),
                GetInterpolatedValueByKoef(koef, valueFirst.MetacentrKM, valueSecond.MetacentrKM),
                GetInterpolatedValueByKoef(koef, valueFirst.FloatationCenterLCF, valueSecond.FloatationCenterLCF),
                GetInterpolatedValueByKoef(koef, valueFirst.MCTC, valueSecond.MCTC),
                GetInterpolatedValueByKoef(koef, valueFirst.LCB, valueSecond.LCB),
                GetInterpolatedValueByKoef(koef, valueFirst.CM, valueSecond.CM));
        }
        else
        {
            return new Value_Table_Hydrostatic
            (displacement,
                GetExtrapoladedValueByKoef(koef, valueFirst.Draft, valueSecond.Draft),
                GetExtrapoladedValueByKoef(koef, valueFirst.TPC, valueSecond.TPC),
                GetExtrapoladedValueByKoef(koef, valueFirst.MetacentrKM, valueSecond.MetacentrKM),
                GetExtrapoladedValueByKoef(koef, valueFirst.FloatationCenterLCF, valueSecond.FloatationCenterLCF),
                GetExtrapoladedValueByKoef(koef, valueFirst.MCTC, valueSecond.MCTC),
                GetExtrapoladedValueByKoef(koef, valueFirst.LCB, valueSecond.LCB),
                GetExtrapoladedValueByKoef(koef, valueFirst.CM, valueSecond.CM));
        }


    }
}
