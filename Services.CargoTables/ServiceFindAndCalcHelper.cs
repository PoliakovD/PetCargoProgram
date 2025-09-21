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
    public static double GetUpExtrapoladedValueByKoef(double koef,
        double searchValue1, double searchValue2)
        =>koef * (searchValue1 - searchValue2) + searchValue1;
    public static double GetDownExtrapoladedValueByKoef(double koef,
        double searchValue1, double searchValue2)
        => searchValue1 - koef * (searchValue1 - searchValue2);
}
