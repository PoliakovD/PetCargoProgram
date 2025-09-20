using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using PetCargoProgram.CargoTables.Tables;
using PetCargoProgram.CargoTables.Values;

namespace PetCargoProgram.DataAccess;

public static class WriterAllTables
{
    // public List<Table_BallSoundTrim> TablesBallSoundTrim { get; set; }= [];
    public Tables_BallSoundTrim TablesBallSoundTrim { get; set; }
    // public List<Table_CargoTankUllageTrim> TablesCargoTankUllage { get; set; } = [];
    public Tables_CargoTankUllageTrim TablesCargoTankUllage { get; set; }
    // public List<Table_Hydrostatic> TablesHydrostatic{ get; set; }= [];
    public Tables_Hydrostatic TablesHydrostatic { get; set; }
    // public List<Table_OtherSounding> TablesOtherSounding{ get; set; }= [];
    public Tables_OtherSounding TablesOtherSounding { get; set; }
    // public List<Table_Volume> TablesVolume{ get; set; }= [];
    public Tables_Volume TablesVolume { get; set; }

    public WriterAllTables()
    {
        //Tables_BallastTanksSounding = Table_BallastTankSoundingTrim.ReadAllTables();
        //Tables_CargoTanksUllage = Table_CargoTankUllageTrim.ReadAllTables();
        //Tables_Hydrostatic = Table_Hydrostatic.ReadAllTables();
        //Tables_OtherSounding = Table_OtherSounding.ReadAllTables();
        //Tables_Volume = Table_Volume.ReadAllTables();


        TablesBallSoundTrim = new Tables_BallSoundTrim { };
        TablesCargoTankUllage = new Tables_CargoTankUllageTrim { };
        TablesHydrostatic = new Tables_Hydrostatic { };
        TablesOtherSounding = new Tables_OtherSounding { };
        TablesVolume = new Tables_Volume { };


    }
    // Сохранение таблиц
        public void BinarySave(string path = "CargoTables.bin")
        {

            using (FileStream fs = new FileStream(path,
            FileMode.Create))
            {
                using (BinaryWriter bw =
                new BinaryWriter(fs,
                Encoding.Unicode))
                {
                    TablesBallSoundTrim.WriteTables(fs, bw);
                    TablesCargoTankUllage.WriteTables(fs, bw);
                    TablesHydrostatic.WriteTables(fs, bw);
                    TablesOtherSounding.WriteTables(fs, bw);
                    TablesVolume.WriteTables(fs, bw);
                }
            }
        }
        public void BinaryLoad(string path = "CargoTables.bin")
        {
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
                    {
                        TablesBallSoundTrim.ReadTables(fs, br);
                        TablesCargoTankUllage.ReadTables(fs, br);
                        TablesHydrostatic.ReadTables(fs, br);
                        TablesOtherSounding.ReadTables(fs, br);
                        TablesVolume.ReadTables(fs, br);
                    }
                }
            }
        }
        // Выгрузка в файл json
        public static void UnLoadToJson(WriterAllTables cargoTables, string path = "CargoTables.json")
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
                IncludeFields = true,
                MaxDepth = 2000000
            };

            var json = JsonSerializer.Serialize<WriterAllTables>(cargoTables, options);
            File.WriteAllText(path, json);
        }
        // Загрузка из json
        //public static CargoTables? Load(string path = "CargoTables.json")
        //{
        //    var json = File.ReadAllText(path);
        //    return JsonSerializer.Deserialize<CargoTables>(json);
        //}
        //public static void BinarySerialize(CargoTables cargoTables)
        //{
        //    BinaryFormatter binFormat = new BinaryFormatter();
        //    try
        //    {
        //        using (Stream fStream =
        //        File.Create("test.bin"))
        //        {
        //            binFormat.Serialize(fStream, cargoTables);
        //        }

        //        //CargoTables p = null;
        //        //using (Stream fStream =
        //        //File.OpenRead("test.bin"))
        //        //{
        //        //    p = (CargoTables)binFormat.
        //        //    Deserialize(fStream);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.MessageBox.Show(ex.Message);
        //    }
        //}


}
