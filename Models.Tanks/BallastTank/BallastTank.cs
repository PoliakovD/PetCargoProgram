using System;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.LoadingCondition;
using PetCargoProgram.Services.CargoTables;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.Models.Tanks;


public partial class BallastTank : NotifyPropertyChanged, ILoadingConditionItem
{
    // From ILoadingConditionItem
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

    private double _trim = 0.0;
    // Tables инициализируется статическим методом, до создания любого экземпляра класса
    private static ServiceVolume _sVolume = CargoTablesProvider.Volume;
    private static ServiceBallastSoundTrim _soundTrim=CargoTablesProvider.BallastSoundTrim;

    // TODO Добавить свойства для балластного танка
    // TODO +возможно добавить функционал для учета седиментов
    public BallastTank(string name)
    {
        ItemName = name;
        MaxVolume = _sVolume.GetMaxVolume(name);
        MaxUllage = _soundTrim.GetMaxSound(name);
        _density = 1.0;
    }
    public BallastTank()
    {
        _itemName = "";
        _maxVolume = 0;
        _maxUllage = 0;
        _sound = 0;
        _ullage = 0;
        _volume = 2000;
        _volumePercent = 50;
        _density = 1.0;
        _weight = 0;
        _lcg = 0;
        _vcg = 0;
        _tcg = 0;
        _iy = 0;
    }
   public string ItemName
    {
        get => _itemName;
        set
        {
            SetField(ref _itemName, value);

            MaxVolume = _sVolume.GetMaxVolume(_itemName);
            MaxUllage = _soundTrim.GetMaxSound(_itemName)+double.Epsilon;
            _density = 1.0;
        }
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
        set
        {
            if (value < 0.0) value = 0.0;
            if (value >_maxUllage)  value = _maxUllage;
                // throw new ArgumentOutOfRangeException($"Sound is out of range 0.0-{_maxUllage}");
            SetField(ref _sound, value);

            _ullage = _maxUllage-_sound;
            OnPropertyChanged(nameof(Ullage));

            _volume = _soundTrim.GetVolumeWithTrim(_itemName,_sound);
            OnPropertyChanged(nameof(Volume));

            _volumePercent=_sVolume.GetPercentsVolume(_itemName, _volume);
            OnPropertyChanged(nameof(VolumePercent));

            var tableValue = _sVolume.GetValue(_itemName, _volume);
            DistributeVolumeTableValue(tableValue);

        }
    }

    public double Ullage
    {
        get => _ullage;
        set
        {
            if (value < 0.0) value = 0.0;
            if (value >_maxUllage)  value = _maxUllage;
                // throw new ArgumentOutOfRangeException($"Ullage is out of range 0.0-{_maxUllage}");
            SetField(ref _ullage, value);


            _sound=_maxUllage-value;
            OnPropertyChanged(nameof(Sound));

            _volume = _soundTrim.GetVolumeWithTrim(_itemName,_ullage);
            OnPropertyChanged(nameof(Volume));

            _volumePercent=_sVolume.GetPercentsVolume(_itemName, _volume);
            OnPropertyChanged(nameof(VolumePercent));

            var tableValue = _sVolume.GetValue(_itemName, _volume);
            DistributeVolumeTableValue(tableValue);


        }
    }

    public double Volume
    {
        get => _volume;
        set
        {

            if (value < 0.0) value = 0.0;
            if(value > _maxVolume) value = _maxVolume;
                // throw new ArgumentOutOfRangeException($"Volume is out of range 0.0-{_maxVolume}");
            SetField(ref _volume, value);

            var tableValue = _sVolume.GetValue(_itemName, _volume);
            DistributeVolumeTableValue(tableValue);

            _volumePercent=_sVolume.GetPercentsVolume(_itemName, _volume);
            OnPropertyChanged(nameof(VolumePercent));

            _sound = _maxUllage;
            _sound = _soundTrim.GetSoundWithTrim(_itemName, _volume);
            if(_sound<0) _sound=0;
            if(_sound>_maxUllage) _sound=_maxUllage;
            OnPropertyChanged(nameof(Sound));

            _ullage=_maxUllage-_sound;
            OnPropertyChanged(nameof(Ullage));
        }
    }

    public double VolumePercent
    {
        get => _volumePercent;
        set
        {
            if (value < 0.0) value = 0.0;
            if (value > 1.0) value = 1.0;
            SetField(ref _volumePercent, value);


            _volume=_maxVolume*value;
            OnPropertyChanged(nameof(Volume));

            var tableValue = _sVolume.GetValue(_itemName, _volume);
            DistributeVolumeTableValue(tableValue);

            _sound = _soundTrim.GetSoundWithTrim(_itemName, _volume,_trim);
            if(_sound<0.0) _sound=0.0;
            if(_sound>_maxUllage-0.0001) _sound=_maxUllage;
            OnPropertyChanged(nameof(Sound));

            _ullage=_maxUllage-_sound;
            OnPropertyChanged(nameof(Ullage));
        }
    }

    public double Density
    {
        get => _density;
        set
        {
            SetField(ref _density, value);

            _weight=Volume * Density;
            OnPropertyChanged(nameof(Weight));
        }
    }

    public double Weight
    {
        get => _weight;
        set
        {
            var volume=value/Density;
            if (volume < 0)
            {
                value = 0;
                volume = 0;
            }

            if (volume > _maxVolume)
            {
                value=MaxVolume*Density;
                volume=_maxVolume;
            }
                // throw new ArgumentOutOfRangeException($"Weight is out of range 0.0-{_maxVolume*Density}");
            SetField(ref _weight, value);

            _volume=volume;
            OnPropertyChanged(nameof(Volume));

            var tableValue = _sVolume.GetValue(_itemName, volume);
            DistributeVolumeTableValue(tableValue);

            _volumePercent=_sVolume.GetPercentsVolume(_itemName, _volume);
            OnPropertyChanged(nameof(VolumePercent));

            _sound = _soundTrim.GetSoundWithTrim(_itemName, _volume);
            if(_sound<0) _sound=0;
            if(_sound>_maxUllage) _sound=_maxUllage;
            OnPropertyChanged(nameof(Sound));

            _ullage=_maxUllage-_sound;
            OnPropertyChanged(nameof(Ullage));
        }
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

}
