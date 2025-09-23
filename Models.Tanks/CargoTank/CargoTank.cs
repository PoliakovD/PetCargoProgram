using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.LoadingCondition;
using PetCargoProgram.Services.CargoTables;
using PetCargoProgram.ViewModels.Base;

namespace PetCargoProgram.Models.Tanks;


public partial class CargoTank : ViewModelBase, ILoadingConditionItem, IEquatable<CargoTank>
{
    //TODO написать методы для расчета показаний в грузовом танке, узнать у преподавателя про интерфейс InotifiedProperty

    // From ILoadingConditionItem
    private string _name;
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

    //Cargo Tables инициализируемая статическим методом, до создания любого экземпляра класса
    private static AllCargoTables _CTables;
    private static ServiceVolume _sVolume;

    public static void InitCargoTables(AllCargoTables cargoTables)
    {
        _CTables = cargoTables;
        _sVolume=new ServiceVolume(_CTables.TablesVolume);
    }

    public CargoTank(string name)
    {
        Name = name;
        MaxVolume = _sVolume.GetMaxVolume(name);
    }


    // TODO Добавить свойства для грузового танка (вес груза в вакууме, обьем в баррелях и тд)
    public double TempCelsius{ get; set; }
    public double TempFaringates{ get; set; }
    public double API { get; set; }
    public double VolumeCorrectionFactorBBLS { get; set; }
    public double VolumeCorrectionFactor { get; set; }

    public double ObservedVolume{ get; set; }
    public double GrossVolume{ get; set; }


    public string Name
    {
        get => _name;
        init => SetField(ref _name, value);
    }

    public double MaxVolume
    {
        get => _maxVolume;
        init => SetField(ref _maxVolume, value);
    }

    public double Sound
    {
        get => _sound;
        set => SetField(ref _sound, value);
    }

    public double Ullage
    {
        get => _ullage;
        set => _ullage = value;
    }

    public double Volume
    {
        get => _volume;
        set
        {
            SetField(ref _volume, value);
            var tableValue = _sVolume.GetValue(_name, _volume);
            DistributeVolumeTableValue(tableValue);
            SetField(ref _volumePercent, _sVolume.GetPercentsVolume(_name, _volume));
        }
    }

    public double VolumePercent
    {
        get => _volumePercent;
        set
        {
            if (value<0.0||value>100.0) throw new ArgumentOutOfRangeException("VolumePercent is out of range 0.0-100.0");
            SetField(ref _volumePercent, value);
            SetField(ref _volume, _maxVolume*value/100.0);
            var tableValue = _sVolume.GetValue(_name, _volume);
            DistributeVolumeTableValue(tableValue);
        }
    }

    public double Density
    {
        get => _density;
        set
        {
            SetField(ref _density, value);
            SetField(ref _weight, Volume * Density);
        }
    }

    public double Weight
    {
        get => _weight;
        set
        {
            var volume=value/Density;
            if (volume < 0||volume>_maxVolume)
                throw new ArgumentOutOfRangeException($"Weight is out of range 0.0-{_maxVolume/Density}");
            var tableValue = _sVolume.GetValue(_name, volume);
            DistributeVolumeTableValue(tableValue);
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

    private void DistributeVolumeTableValue(Value_Table_Volume tableValue)
    {
        SetField(ref _lcg, tableValue.LCG);
        SetField(ref _tcg, tableValue.TCG);
        SetField(ref _vcg, tableValue.VCG);
        SetField(ref _iy, tableValue.IY);
        SetField(ref _weight, tableValue.Volume*Density);
    }


}

