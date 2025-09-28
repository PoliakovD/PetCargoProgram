using System.Windows.Media;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.Models.LoadingCondition;

public class LightWeight: NotifyPropertyChanged, ILoadingConditionItem
{
    private string _itemName;
    private double _maxVolume;
    private double _maxUllage;
    private double _sound;
    private double _ullage;
    private double _volume;
    private double _volumePercent;
    private double _density;
    private double _weight;
    private double _lcg;
    private double _vcg;
    private double _tcg;
    private double _iy;
    private SolidColorBrush _color;
    private TypeOfLoadingConditionItem _typeOfTank;

    public string ItemName
    {
        get => _itemName;
        set => SetField(ref _itemName, value);
    }

    public double MaxVolume
    {
        get => _maxVolume;
        set => SetField(ref _maxVolume, value);
    }

    public double MaxUllage
    {
        get => _maxUllage;
        set => SetField(ref _maxUllage, value);
    }

    public double Sound
    {
        get => _sound;
        set => SetField(ref _sound, value);
    }

    public double Ullage
    {
        get => _ullage;
        set => SetField(ref _ullage, value);
    }

    public double Volume
    {
        get => _volume;
        set => SetField(ref _volume, value);
    }

    public double VolumePercent
    {
        get => _volumePercent;
        set => SetField(ref _volumePercent, value);
    }

    public double Density
    {
        get => _density;
        set => SetField(ref _density, value);
    }

    public double Weight
    {
        get => _weight;
        set => SetField(ref _weight, value);
    }

    public double LCG
    {
        get => _lcg;
        set => SetField(ref _lcg, value);
    }

    public double VCG
    {
        get => _vcg;
        set => SetField(ref _vcg, value);
    }

    public double TCG
    {
        get => _tcg;
        set => SetField(ref _tcg, value);
    }

    public double IY
    {
        get => _iy;
        set => SetField(ref _iy, value);
    }

    public SolidColorBrush Color
    {
        get => _color;
        set => SetField(ref _color, value);
    }

    public TypeOfLoadingConditionItem TypeOfItem
    {
        get => _typeOfTank;
        set => _typeOfTank = value;
    }

    public LightWeight()
    {
        ItemName = "Light Weight";
        Weight = 17475.9;
        Volume = 0;
        VolumePercent = 0;
        Density = 0;
        LCG = 108.72;
        VCG = 11.65;
        TCG = -10.78;
        IY = 0;
        VolumePercent = 0;
        Density = 0;
        MaxVolume = 0;
        MaxUllage = 0;
        Sound = 0;
        Ullage = 0;
        Color = new SolidColorBrush(Colors.LightGray);
        TypeOfItem=TypeOfLoadingConditionItem.Other;
    }
}
