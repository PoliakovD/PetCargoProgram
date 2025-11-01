
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using PetCargoProgram.Models.Tanks;


namespace PetCargoProgram.DataAccess;
// TODO Проверка загруженных значений грузового танка
//TODO Добавить Json Сериализацию и Десериализацию
public static class JsonService
{
    public static void Save(IEnumerable<CargoTank> cargoTanks, string path = "CargoTanks.json")
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(cargoTanks, options);
            File.WriteAllText(path, json);
        }
        catch (Exception e)
        {
            throw new SaveToJsonException(path, e);
        }
    }

    public static IEnumerable<CargoTank> Load(string path = "CargoTanks.json")
    {
        try
        {
            var json = File.ReadAllText(path);
            var cargoTanks =  JsonSerializer.Deserialize<IEnumerable<CargoTank>>(json);

            if (cargoTanks is null) throw new LoadFromJsonException(path);

            return cargoTanks;
        }
        catch (Exception e)
        {
            throw new LoadFromJsonException(path, e);
        }
    }
}
