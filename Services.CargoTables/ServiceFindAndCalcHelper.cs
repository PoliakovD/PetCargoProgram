using System;
using System.Collections.Generic;
using System.Linq;

namespace PetCargoProgram.Services.CargoTables;

public static class ServiceFindAndCalcHelper
{
    public static double GetInterpolatedValue(
        double calcValue1, double calcValue2,
        double currentValue,
        double searchValue1, double searchValue2)
    {
        double koef = (calcValue1 - currentValue) / (calcValue1 - calcValue2);
        return koef * (searchValue2 - searchValue1) + searchValue1;
    }
    public static double GetInterpolatedValueByKoef(double koef,
        double searchValue1, double searchValue2)
        =>koef * (searchValue2 - searchValue1) + searchValue1;
    public static double GetExtrapoladedValueByKoef(double koef,
        double searchValue1, double searchValue2)
        =>koef * (searchValue1 - searchValue2) + searchValue1;
    public static double GetValueInDictionary(Dictionary<int,double> dictionary, double SearchValue, int min=-1,int max=4)
    {
        // Min - всегда -1
        // Max - всегда +4

        // находим два ближайших значения
        var closest = dictionary.OrderBy(x => Math.Abs(x.Key - SearchValue)).Take(2);
        if (SearchValue >= min && SearchValue <= max)
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
