using System.Windows.Media;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.LoadingCondition;
using PetCargoProgram.Services.CargoTables;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.Models.Tanks;


public class OtherTank : NotifyPropertyChanged,ILoadingConditionItem
{
    private string _itemName;
    private double _maxVolume;
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
    private double _maxUllage;
    private SolidColorBrush _color;
    private TypeOfLoadingConditionItem _typeOfItem;

    // Tables инициализируется статическим методом, до создания любого экземпляра класса
    private static ServiceVolume _sVolume = CargoTablesProvider.Volume;
    private static ServiceOtherSound _sOtherTanks = CargoTablesProvider.ServiceOtherSound;

    // TODO Добавить свойства для грузового танка (вес груза в вакууме, обьем в баррелях и тд)
    public string ItemName
    {
        get => _itemName;
        set
        {
            SetField(ref _itemName, value);

            MaxVolume = _sVolume.GetMaxVolume(_itemName);
            // MaxUllage = _sOtherTanks.GetMaxSound(_itemName)+double.Epsilon;
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
            // if (value < 0.0) value = 0.0;
            // if (value >_maxUllage)  value = _maxUllage;
            // // throw new ArgumentOutOfRangeException($"Sound is out of range 0.0-{_maxUllage}");
            // SetField(ref _sound, value);
            //
            // _ullage = _maxUllage-_sound;
            // OnPropertyChanged(nameof(Ullage));
            //
            // _volume = _sOtherTanks.GetVolumeWithSound(_itemName,_sound);
            // OnPropertyChanged(nameof(Volume));
            //
            // _volumePercent= _volume / _maxVolume;
            // OnPropertyChanged(nameof(VolumePercent));
            //
            // var tableValue = _sVolume.GetValue(_itemName, _volume);
            // DistributeVolumeTableValue(tableValue);

        }
    }

    public double Ullage
    {
        get => _ullage;
        set
        {
            // if (value < 0.0) value = 0.0;
            // if (value >_maxUllage)  value = _maxUllage;
            // // throw new ArgumentOutOfRangeException($"Ullage is out of range 0.0-{_maxUllage}");
            // SetField(ref _ullage, value);
            //
            //
            // _sound=_maxUllage-value;
            // OnPropertyChanged(nameof(Sound));
            //
            // _volume = _sOtherTanks.GetVolumeWithSound(_itemName,_sound);
            // OnPropertyChanged(nameof(Volume));
            //
            // _volumePercent= _volume / _maxVolume;
            // OnPropertyChanged(nameof(VolumePercent));
            //
            // var tableValue = _sVolume.GetValue(_itemName, _volume);
            // DistributeVolumeTableValue(tableValue);


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

            _volumePercent= _volume / _maxVolume;
            OnPropertyChanged(nameof(VolumePercent));

            // _sound = _maxUllage;
            // _sound = _sOtherTanks.GetSoundWithVolume(_itemName, _volume);
            // if(_sound<0) _sound=0;
            // if(_sound>_maxUllage) _sound=_maxUllage;
            // OnPropertyChanged(nameof(Sound));
            //
            // _ullage=_maxUllage-_sound;
            // OnPropertyChanged(nameof(Ullage));
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


            _volume = _maxVolume * value;
            OnPropertyChanged(nameof(Volume));

            var tableValue = _sVolume.GetValue(_itemName, _volume);
            DistributeVolumeTableValue(tableValue);

            // _sound = _sOtherTanks.GetSoundWithVolume(_itemName, _volume);
            // if (_sound < 0.0) _sound = 0.0;
            // if (_sound > _maxUllage - 0.0001) _sound = _maxUllage;
            // OnPropertyChanged(nameof(Sound));
            //
            // _ullage = _maxUllage - _sound;
            // OnPropertyChanged(nameof(Ullage));

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

            _volumePercent= _volume / _maxVolume;
            OnPropertyChanged(nameof(VolumePercent));

            //_sound = _sOtherTanks.GetSoundWithVolume(_itemName, _volume);
            //if(_sound<0) _sound=0;
            //if(_sound>_maxUllage) _sound=_maxUllage;
            //OnPropertyChanged(nameof(Sound));

            //_ullage=_maxUllage-_sound;
            //OnPropertyChanged(nameof(Ullage));
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

    public SolidColorBrush Color
    {
        get => _color;
        set => SetField(ref _color, value);
    }

    public TypeOfLoadingConditionItem TypeOfItem
    {
        get => _typeOfItem;
        set => _typeOfItem = value;
    }

    public OtherTank(string name,
        TypeOfLoadingConditionItem type = TypeOfLoadingConditionItem.Other,
        SolidColorBrush color = null)
    {
        ItemName = name;
        MaxVolume = _sVolume.GetMaxVolume(name);
        //MaxUllage = _sOtherTanks.GetMaxSound(name);
        DistributeVolumeTableValue(_sVolume.GetValue(name,0.0));
        _density = 1.000;
        Color = color;
        TypeOfItem = type;

    }
    private void DistributeVolumeTableValue(ValueTableVolume tableValue)
    {
        _lcg= tableValue.LCG;
        _tcg= tableValue.TCG;
        _vcg= tableValue.VCG;
        _iy= tableValue.IY;
        _weight= tableValue.Volume*Density;
        OnPropertyChanged(nameof(LCG));
        OnPropertyChanged(nameof(TCG));
        OnPropertyChanged(nameof(VCG));
        OnPropertyChanged(nameof(IY));
        OnPropertyChanged(nameof(Weight));
    }
}
