using System;


namespace PetCargoProgram.Services.ASTM;

public static class ServiceASTM
{
    // диапазон расчетов плотностей: 0.5-1.0
    public enum Table54VCF
    {
        CrudeOil54B,
        OilProduct54A,
        LubeOil54D
    };

    public static double GetVCFbyDensity15(double currentTemperature, double density15,
        Table54VCF table54VCF = Table54VCF.CrudeOil54B)
    {
        var temperatureDifference = currentTemperature - 15.0;
        density15 *= 1000.0;
        switch (table54VCF)
        {
            case Table54VCF.OilProduct54A:
            {
                var k0 = 613.97226;
                var k1 = 0.0;
                var a = (k0 + (k1 * density15)) / (density15 * density15);
                var b = -a * temperatureDifference * (1.0 + (0.8 * a * temperatureDifference));
                return Math.Exp(b);

            }
            case Table54VCF.CrudeOil54B:
            {
                if (density15 < 0.770)
                {
                    var k0 = 346.42278;
                    var k1 = 0.43884;
                    var a = (k0 + (k1 * density15)) / (density15 * density15);
                    var b = -a * temperatureDifference * (1.0 + (0.8 * a * temperatureDifference));
                    return Math.Exp(b);
                }
                else if (density15 is >= 0.770 and <= 0.778)
                {
                    var c = -0.0033612 + 2680.32 / (density15 * density15);
                    var d = -c * temperatureDifference * (1.0 + (0.8 * c * temperatureDifference));
                    return Math.Exp(d);
                }
                else if (density15 is > 0.778 and < 0.839)
                {
                    var k0 = 594.54180;
                    var k1 = 0.0;
                    var a = (k0 + (k1 * density15)) / (density15 * density15);
                    var b = -a * temperatureDifference * (1.0 + (0.8 * a * temperatureDifference));
                    return Math.Exp(b);
                }
                else // Density15 >= 0.839
                {
                    var k0 = 186.9696;
                    var k1 = 0.48618;
                    var a = (k0 + (k1 * density15)) / (density15 * density15);
                    var b = -a * temperatureDifference * (1.0 + (0.8 * a * temperatureDifference));
                    var result = Math.Exp(b);
                    return result;
                }
            }
            case Table54VCF.LubeOil54D:
            {
                var k0 = 0.0;
                var k1 = 0.6278;
                var a = (k0 + (k1 * density15)) / (density15 * density15);
                var b = -a * temperatureDifference * (1.0 + (0.8 * a * temperatureDifference));
                return Math.Exp(b);
            }
        }

        return 0.0;
    }

    public static double GetVCFbyAPI(double api, double currentTemperature)
    {
        var density15 = GetDensity15byAPI(api);
        return GetVCFbyDensity15(currentTemperature, density15);
    }

    public static double GetAPIbyRelativeDensity6060(double relativeDensity6060) =>
        (141.5 / relativeDensity6060) - 131.5;

    public static double GetAPIbyDensity15(double density15) =>
        GetAPIbyRelativeDensity6060(GetRelativeDensity6060byDensity15(density15));

    public static double GetDensity15byRelativeDensity6060(double density6060)
    {
        double correction;
        if (density6060 < 0.5) correction = 0.0001;
        else if (density6060 is >= 0.6836 and < 0.7576) correction = 0.0002;
        else if (density6060 is >= 0.7576 and < 0.7866) correction = 0.0003;
        else if (density6060 is >= 0.7866 and < 0.8526) correction = 0.0004;
        else if (density6060 is >= 0.8526 and < 0.9416) correction = 0.0005;
        else if (density6060 is >= 0.9416 and < 1.0336) correction = 0.0006;
        else if (density6060 is >= 1.0336 and < 1.0750) correction = 0.0007;
        else correction = 0.0008;
        return density6060 - correction;
    }

    public static double GetRelativeDensity6060byDensity15(double density15)
    {
        double correction;
        if (density15 < 0.5) correction = 0.0001;
        else if (density15 is >= 0.6834 and < 0.7573) correction = 0.0002;
        else if (density15 is >= 0.7573 and < 0.7862) correction = 0.0003;
        else if (density15 is >= 0.7862 and < 0.8521) correction = 0.0004;
        else if (density15 is >= 0.8521 and < 0.9410) correction = 0.0005;
        else if (density15 is >= 0.9410 and < 1.0329) correction = 0.0006;
        else if (density15 is >= 1.0329 and < 1.0750) correction = 0.0007;
        else correction = 0.0008;
        return density15 + correction;
    }

    public static double GetRelativeDensity6060byAPI(double api) => 141.5 / (api + 131.5);

    public static double GetDensity15byAPI(double api)
    {
        var density6060 = GetRelativeDensity6060byAPI(api);
        double correction;
        if (density6060 < 0.5) correction = 0.0001;
        else if (density6060 is >= 0.6836 and < 0.7576) correction = 0.0002;
        else if (density6060 is >= 0.7576 and < 0.7866) correction = 0.0003;
        else if (density6060 is >= 0.7866 and < 0.8526) correction = 0.0004;
        else if (density6060 is >= 0.8526 and < 0.9416) correction = 0.0005;
        else if (density6060 is >= 0.9416 and < 1.0336) correction = 0.0006;
        else if (density6060 is >= 1.0336 and < 1.0750) correction = 0.0007;
        else correction = 0.0008;
        return density6060 - correction;
    }

    public static double GetWeightVacToAirByDensity15(double density15)
    {
        if (density15 is >= 0.5 and <= 0.5191) return 0.99775;
        else if (density15 is > 0.5191 and <= 0.5421) return 0.99785;
        else if (density15 is > 0.5421 and <= 0.5673) return 0.99795;
        else if (density15 is > 0.5673 and <= 0.5950) return 0.99805;
        else if (density15 is > 0.5950 and <= 0.6255) return 0.99815;
        else if (density15 is > 0.6255 and <= 0.6593) return 0.99825;
        else if (density15 is > 0.6593 and <= 0.6970) return 0.99835;
        else if (density15 is > 0.6970 and <= 0.7392) return 0.99845;
        else if (density15 is > 0.7392 and <= 0.7892) return 0.99855;
        else if (density15 is > 0.7892 and <= 0.8411) return 0.99865;
        else if (density15 is > 0.8411 and <= 0.9034) return 0.99875;
        else if (density15 is > 0.9034 and <= 0.9756) return 0.99885;
        else if (density15 is > 0.9756 and <= 1.0604) return 0.99895;
        else if (density15 is > 1.0604 and <= 1.1000) return 0.99905;
        else return 0.0;
    }

    public static double GetWeightAirToVacByDensity15(double density15)
    {
        if (density15 is >= 0.5 and <= 0.5201) return 0.00225;
        else if (density15 is > 0.5201 and <= 0.5432) return 1.00215;
        else if (density15 is > 0.5432 and <= 0.5684) return 1.00205;
        else if (density15 is > 0.5684 and <= 0.5960) return 1.00195;
        else if (density15 is > 0.5960 and <= 0.6265) return 1.00185;
        else if (density15 is > 0.6265 and <= 0.6603) return 1.00175;
        else if (density15 is > 0.6603 and <= 0.6980) return 1.00165;
        else if (density15 is > 0.6980 and <= 0.7402) return 1.00155;
        else if (density15 is > 0.7402 and <= 0.7879) return 1.00145;
        else if (density15 is > 0.7879 and <= 0.8421) return 1.00135;
        else if (density15 is > 0.8421 and <= 0.9044) return 1.00125;
        else if (density15 is > 0.9044 and <= 0.9766) return 1.00115;
        else if (density15 is > 0.9766 and <= 1.0614) return 1.00105;
        else if (density15 is > 1.0614 and <= 1.1000) return 1.00095;
        else return 0.0;
    }
}
