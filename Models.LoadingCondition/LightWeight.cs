namespace PetCargoProgram.Models.LoadingCondition;

public class LightWeight: ILoadingConditionItem
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

    public string ItemName
    {
        get => _itemName;
        set => _itemName = value;
    }

    public double MaxVolume
    {
        get => _maxVolume;
        set => _maxVolume = value;
    }

    public double MaxUllage
    {
        get => _maxUllage;
        set => _maxUllage = value;
    }

    public double Sound
    {
        get => _sound;
        set => _sound = value;
    }

    public double Ullage
    {
        get => _ullage;
        set => _ullage = value;
    }

    public double Volume
    {
        get => _volume;
        set => _volume = value;
    }

    public double VolumePercent
    {
        get => _volumePercent;
        set => _volumePercent = value;
    }

    public double Density
    {
        get => _density;
        set => _density = value;
    }

    public double Weight
    {
        get => _weight;
        set => _weight = value;
    }

    public double LCG
    {
        get => _lcg;
        set => _lcg = value;
    }

    public double VCG
    {
        get => _vcg;
        set => _vcg = value;
    }

    public double TCG
    {
        get => _tcg;
        set => _tcg = value;
    }

    public double IY
    {
        get => _iy;
        set => _iy = value;
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
    }
}
