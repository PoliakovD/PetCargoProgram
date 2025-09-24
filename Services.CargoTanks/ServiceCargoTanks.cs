using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PetCargoProgram.Models.Tanks;

namespace PetCargoProgram.Services;

// Нужно иметь список имен всех танков для инициализации сервиса,
// TODO Возможно потом добавить инициализацию через файл сохранения состояния
// TODO Добавить DataAccess для сохранения состояния
// TODO Поправить названия класса CargoTank после рефакторинга компонентов
public class ServiceCargoTanks
{
    // private ServiceVolume _serviceVolume;
    private ObservableCollection<CargoTank> _cargoTanks = [];

    public void Add(CargoTank cargoTank) =>
        _cargoTanks.Add(cargoTank);

    public CargoTank? GetByName(string name) =>
        _cargoTanks.FirstOrDefault(x=>x.ItemName==name);

    public IEnumerable<CargoTank> GetAll() => _cargoTanks;


    private static string[] _cargoTankNames =
    ["COT 1P", "COT 2P", "COT 3P","COT 4P","COT 5P","COT 6P","SLOPP",
    "COT 1S", "COT 2S", "COT 3S","COT 4S","COT 5S","COT 6S","SLOPS"];
    private void Init()
    {
        foreach (var t in _cargoTankNames)
        {
            _cargoTanks.Add(new CargoTank(t));
        }
    }
}
