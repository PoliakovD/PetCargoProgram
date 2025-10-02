using PetCargoProgram.ViewModels.Base;
using  PetCargoProgram.Services.ASTM;
using static PetCargoProgram.Services.ASTM.ServiceASTM;


namespace ViewModel.ASTM;

public class ViewModelASTM : NotifyPropertyChanged
{
    private double _density15;
    private double _density60;
    private double _api;
    private double _currentTemperature;
    private double _volumeCorrection;
    private double _weightVacToAir;
    private double _weightAirToVac;


    public double Density15
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

            VolumeCorrection = GetVCFbyDensity15(_currentTemperature, _density15);

            WeightVacToAir = GetWeightVacToAirByDensity15(_density15);

            WeightAirToVac= GetWeightAirToVacByDensity15(_density15);

        }
    }

    public double Density60
    {
        get => _density60;
        set
        {
            if (value < 0.5) value = 0.5;
            if (value > 1.1) value = 1.1;
            SetField(ref _density60, value);

            _density15=GetDensity15byRelativeDensity6060(_density60);
            OnPropertyChanged(nameof(Density15));

            _api = GetAPIbyDensity15(_density15);
            OnPropertyChanged(nameof(API));

            VolumeCorrection = GetVCFbyDensity15(_currentTemperature, _density15);

            WeightVacToAir = GetWeightVacToAirByDensity15(_density15);

            WeightAirToVac= GetWeightAirToVacByDensity15(_density15);
        }
    }

    public double API
    {
        get => _api;
        set
        {
            SetField(ref _api, value);

            _density15=GetDensity15byAPI(_api);
            OnPropertyChanged(nameof(Density15));

            _density60 = GetRelativeDensity6060byDensity15(_density15);
            OnPropertyChanged(nameof(Density60));

            VolumeCorrection = GetVCFbyDensity15(_currentTemperature, _density15);

            WeightVacToAir = GetWeightVacToAirByDensity15(_density15);

            WeightAirToVac= GetWeightAirToVacByDensity15(_density15);


        }
    }

    public double CurrentTemperature
    {
        get => _currentTemperature;
        set
        {
            SetField(ref _currentTemperature, value);
            VolumeCorrection = GetVCFbyDensity15(_currentTemperature, _density15);
        }
    }
    public double VolumeCorrection
    {
        get => _volumeCorrection;
        set => SetField(ref _volumeCorrection, value);
    }
    public double WeightVacToAir
    {
        get => _weightVacToAir;
        set => SetField(ref _weightVacToAir, value);
    }
    public double WeightAirToVac
    {
        get => _weightAirToVac;
        set => SetField(ref _weightAirToVac, value);
    }

    public ViewModelASTM()
    {
        CurrentTemperature = 30.0;
        OnPropertyChanged(nameof(CurrentTemperature));

        _density15 = 0.0;
        _density60= 0.0;
        _api= 0.0;
        _volumeCorrection= 0.0;
        _weightVacToAir= 0.0;
        _weightAirToVac= 0.0;
        Density15 = 0.976;
    }
}
