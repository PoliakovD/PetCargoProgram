using System;
using System.Windows.Media;
using PetCargoProgram.Models.LoadingCondition;
using PetCargoProgram.Services.CargoTables;
using static PetCargoProgram.Services.ASTM.ServiceASTM;
using ViewModel.ASTM;

namespace PetCargoProgram.Models.Tanks;


public partial class CargoTank : ViewModelASTM, ILoadingConditionItem, IEquatable<CargoTank>
{
    //TODO написать методы для расчета показаний в грузовом танке, узнать у преподавателя про интерфейс InotifiedProperty

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
    private SolidColorBrush _color;
    private TypeOfLoadingConditionItem _typeOfItem;

    // Tables инициализируется статическим классом, до создания любого экземпляра класса
    private static ServiceVolume _sVolume = CargoTablesProvider.Volume;
    private static ServiceCargoTankUllageTrim _UllageTrim =CargoTablesProvider.ServiceCargoTankUllageTrim;


    private double _grossVolume;

    public double GrossVolume
    {
        get => _grossVolume;
        set
        {

            var volume = value / _volumeCorrection;

            if (volume < 0.0)
            {
                value = 0.0;
                volume = 0.0;
            }

            if (volume > _maxVolume)
            {
                value = _maxVolume/_volumeCorrection;
                volume = _maxVolume;
            }

            SetField(ref _grossVolume, value);

            SetField(ref _volume, volume);
            OnPropertyChanged(nameof(Volume));

            _volumePercent= _volume / _maxVolume;
            OnPropertyChanged(nameof(VolumePercent));

            _ullage = _UllageTrim.GetUllageWithTrim(_itemName, _volume);
            OnPropertyChanged(nameof(Ullage));

            _sound=_maxUllage-_ullage;
            OnPropertyChanged(nameof(Sound));

            _weight = _grossVolume * _density15 * _weightVacToAir;
            OnPropertyChanged(nameof(Weight));

            var tableValue = _sVolume.GetValue(_itemName, _volume);
            DistributeVolumeTableValue(tableValue);
        }
    }

    public CargoTank(string name)
    {
        ItemName = name;
        MaxVolume = _sVolume.GetMaxVolume(name);
        MaxUllage = _UllageTrim.GetMaxUllage(name);
        DistributeVolumeTableValue(_sVolume.GetValue(name,0.0));
        CurrentTemperatureCelsius = 30.0;
        _density15 = 0.988;
        base.Density15=_density15;
        Color = new SolidColorBrush(System.Windows.Media.Color.FromArgb(137, 129, 225, 13));
        TypeOfItem = TypeOfLoadingConditionItem.CargoTank;

    }
    public CargoTank()
    {
        _itemName = "";
        _maxVolume = 0;
        _maxUllage = 0;
        _sound = 0;
        _ullage = 0;
        _volume = 2000;
        _volumePercent = 50;
        _weight = 0;
        _lcg = 0;
        _vcg = 0;
        _tcg = 0;
        _iy = 0;
        TypeOfItem = TypeOfLoadingConditionItem.CargoTank;

    }

    public string ItemName
    {
        get => _itemName;
        set
        {
            SetField(ref _itemName, value);

            MaxVolume = _sVolume.GetMaxVolume(_itemName);
            MaxUllage = _UllageTrim.GetMaxUllage(_itemName);
            _density15 = 1.0;
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
            if (value<0.0) value = 0.0;
            if (value>_maxUllage)  value = _maxUllage;
            // if(value<0.0||value>_maxUllage)
            //     throw new ArgumentOutOfRangeException($"Sound is out of range 0.0-{_maxUllage}");
            SetField(ref _sound, value);

            _ullage = _maxUllage-_sound;
            OnPropertyChanged(nameof(Ullage));

            _volume = _UllageTrim.GetVolumeWithTrim(_itemName,_ullage);
            OnPropertyChanged(nameof(Volume));

            _grossVolume = _volume*_volumeCorrection;
            OnPropertyChanged(nameof(GrossVolume));

            _weight = _grossVolume * base._density15 * _weightVacToAir;
            OnPropertyChanged(nameof(Weight));

            _volumePercent= _volume / _maxVolume;
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
            if (value<0.0) value = 0.0;
            if(value>_maxUllage)  value = _maxUllage;
                // throw new ArgumentOutOfRangeException($"Ullage is out of range 0.0-{_maxUllage}");
            SetField(ref _ullage, value);


            _sound=_maxUllage-_ullage;
            OnPropertyChanged(nameof(Sound));

            _volume = _UllageTrim.GetVolumeWithTrim(_itemName,_ullage);
            OnPropertyChanged(nameof(Volume));

            _volumePercent= _volume / _maxVolume;
            OnPropertyChanged(nameof(VolumePercent));

            _grossVolume = _volume*_volumeCorrection;
            OnPropertyChanged(nameof(GrossVolume));

            _weight = _grossVolume * base._density15 * _weightVacToAir;
            OnPropertyChanged(nameof(Weight));

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

            _volumePercent= _volume / _maxVolume;
            OnPropertyChanged(nameof(VolumePercent));

            _ullage = _UllageTrim.GetUllageWithTrim(_itemName, _volume);
            OnPropertyChanged(nameof(Ullage));

            _sound=_maxUllage-_ullage;
            OnPropertyChanged(nameof(Sound));

            _grossVolume = _volume*_volumeCorrection;
            OnPropertyChanged(nameof(GrossVolume));

            _weight = _grossVolume * base._density15 * _weightVacToAir;
            OnPropertyChanged(nameof(Weight));

            var tableValue = _sVolume.GetValue(_itemName, _volume);
            DistributeVolumeTableValue(tableValue);
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

            _ullage = _UllageTrim.GetUllageWithTrim(_itemName, _volume);
            OnPropertyChanged(nameof(Ullage));

            _grossVolume = _volume*_volumeCorrection;
            OnPropertyChanged(nameof(GrossVolume));

            _weight = _grossVolume * _density15 * _weightVacToAir;
            OnPropertyChanged(nameof(Weight));

            _sound=_maxUllage-_ullage;
            OnPropertyChanged(nameof(Sound));
        }
    }

    public double Density
    {
        get { return _density; }
        set { SetField(ref _density, value); }
    }

    public override double Density15
    {
        get => _density15;
        set
        {
            if (value < 0.5) value = 0.5;
            if (value > 1.1) value = 1.1;
            SetField(ref _density15, value);

            _api = GetAPIbyDensity15(_density15);
            OnPropertyChanged(nameof(API));

            _density60 = GetRelativeDensity6060byDensity15(_density15);
            OnPropertyChanged(nameof(Density60));

            VolumeCorrection = GetVCFbyDensity15(_currentTemperatureCelsius, _density15);

            WeightVacToAir = GetWeightVacToAirByDensity15(_density15);

            WeightAirToVac= GetWeightAirToVacByDensity15(_density15);

            _grossVolume = _volume*_volumeCorrection;
            OnPropertyChanged(nameof(GrossVolume));

            _weight = _grossVolume * _density15 * _weightVacToAir;
            OnPropertyChanged(nameof(Weight));

            _density=_density15*_volumeCorrection*_weightVacToAir;
            OnPropertyChanged(nameof(Density));

        }
    }

    public override double Density60
    {
        get => _density60;
        set
        {
            if (value < 0.5) value = 0.5;
            if (value > 1.1) value = 1.1;
            SetField(ref _density60, value);

            _density15=GetDensity15byRelativeDensity6060(_density60);
            OnPropertyChanged(nameof(Density));

            _api = GetAPIbyDensity15(_density15);
            OnPropertyChanged(nameof(API));

            VolumeCorrection = GetVCFbyDensity15(_currentTemperatureCelsius, _density15);

            WeightVacToAir = GetWeightVacToAirByDensity15(_density15);

            WeightAirToVac= GetWeightAirToVacByDensity15(_density15);

            _grossVolume = _volume*_volumeCorrection;
            OnPropertyChanged(nameof(GrossVolume));

            _weight = _grossVolume * _density15 * _weightVacToAir;
            OnPropertyChanged(nameof(Weight));

            _density=_density15*_volumeCorrection*_weightVacToAir;
            OnPropertyChanged(nameof(Density));
        }
    }

    public override double CurrentTemperatureCelsius
    {
        get => _currentTemperatureCelsius;
        set
        {
            SetField(ref _currentTemperatureCelsius, value);

            _volumeCorrection = GetVCFbyDensity15(_currentTemperatureCelsius, _density15);
            OnPropertyChanged(nameof(VolumeCorrection));

            _grossVolume = _volume*_volumeCorrection;
            OnPropertyChanged(nameof(GrossVolume));

            _weight = _grossVolume * _density15 * _weightVacToAir;
            OnPropertyChanged(nameof(Weight));

            _density=_density15*_volumeCorrection*_weightVacToAir;
            OnPropertyChanged(nameof(Density));
        }
    }

    public override double API
    {
        get => _api;
        set
        {
            SetField(ref _api, value);

            _density15=GetDensity15byAPI(_api);
            OnPropertyChanged(nameof(Density15));

            _density60 = GetRelativeDensity6060byDensity15(_density15);
            OnPropertyChanged(nameof(Density60));

            VolumeCorrection = GetVCFbyDensity15(_currentTemperatureCelsius, _density15);

            WeightVacToAir = GetWeightVacToAirByDensity15(_density15);

            WeightAirToVac= GetWeightAirToVacByDensity15(_density15);

            _grossVolume = _volume*_volumeCorrection;
            OnPropertyChanged(nameof(GrossVolume));

            _weight = _grossVolume * _density15 * _weightVacToAir;
            OnPropertyChanged(nameof(Weight));

            _density=_density15*_volumeCorrection*_weightVacToAir;
            OnPropertyChanged(nameof(Density));

        }
    }

    public double Weight
    {
        get => _weight;
        set
        {
            var volume=value/Density;

            if(volume<0) value = 0;
            if(volume>_maxVolume) value=MaxVolume*Density;

            SetField(ref _weight, value);

            _volume=volume;
            OnPropertyChanged(nameof(Volume));

            _grossVolume = _volume*_volumeCorrection;
            OnPropertyChanged(nameof(GrossVolume));

            var tableValue = _sVolume.GetValue(_itemName, volume);
            DistributeVolumeTableValue(tableValue);

            _volumePercent= _volume / _maxVolume;
            OnPropertyChanged(nameof(VolumePercent));

            _ullage = _UllageTrim.GetUllageWithTrim(_itemName, _volume);
            OnPropertyChanged(nameof(Ullage));

            _sound=_maxUllage-_ullage;
            OnPropertyChanged(nameof(Sound));
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
}

