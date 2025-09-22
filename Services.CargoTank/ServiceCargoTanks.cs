using System.Collections.Generic;
using PetCargoProgram.Models.Tanks;
using PetCargoProgram.Services.CargoTables;

namespace PetCargoProgram.Services.CargoTank;

// Нужно иметь список имен всех танков для инициализации сервиса,
// TODO Возможно потом добавить инициализацию через файл сохранения состояния
// TODO Добавить DataAccess для сохранения состояния
// TODO Поправить названия класса CargoTank после рефакторинга компонентов
public class ServiceCargoTanks
{
    // private ServiceVolume _serviceVolume;
    private Dictionary<string, PetCargoProgram.Models.Tanks.CargoTank> _cargoTanks = [];
    public bool Add(PetCargoProgram.Models.Tanks.CargoTank cargoTank) =>
        _cargoTanks.TryAdd(cargoTank.Name, cargoTank);
    public PetCargoProgram.Models.Tanks.CargoTank? GetByName(string name) =>
        _cargoTanks.GetValueOrDefault(name);
    public bool Delete(string name) =>
        _cargoTanks.Remove(name);
    public bool Update(PetCargoProgram.Models.Tanks.CargoTank сargoTank)
    {
        var _сargoTank = GetByName(сargoTank.Name);
        if (_сargoTank is null) return false;

        _cargoTanks[_сargoTank.Name] = сargoTank;
        return true;
    }
}
