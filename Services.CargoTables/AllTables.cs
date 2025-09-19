using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using PetCargoProgram.CargoTables.Tables;
using PetCargoProgram.CargoTables.Values;

namespace Services.CargoTables;

public class AllTables
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

    public AllTables()
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
        public void Save(string path = "CargoTables.bin")
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
        public static AllTables? Load(string path = "CargoTables.bin")
        {
            if (File.Exists(path))
            {

                AllTables ResultCargoTables = new AllTables();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
                    {
                        // считываем кол-во Tables_BallastTanksSounding
                        int count_tablesBTST = br.ReadInt32();

                        for (int i = 0; i < count_tablesBTST; ++i)
                        {
                            var Temp_Name = br.ReadString(); // записываем имя таблицы
                            var Temp_Table = new List<Value_Table_BallSoundTrim> { };

                            // считываем кол-во значений в Table_BallastTankSoundingTrim
                            int count_TableValues = br.ReadInt32();
                            for (int j = 0; j < count_TableValues; ++j)
                            {
                                Temp_Table.Add(new Value_Table_BallSoundTrim(br.ReadDouble(), br.ReadDouble(),
                                br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                            }
                            // Добавляем таблицу в список таблиц
                            ResultCargoTables.TablesBallSoundTrim.Add(new Table_BallSoundTrim(Temp_Name, Temp_Table));
                        }

                        // считываем кол-во Tables_CargoTanksUllage
                        int count_tablesCTU = br.ReadInt32();

                        for (int i = 0; i < count_tablesCTU; ++i)
                        {
                            var Temp_Name = br.ReadString(); // записываем имя таблицы
                            var Temp_Table = new List<Value_Table_CargoTankUllageTrim> { };

                            // считываем кол-во значений в Table_CargoTankUllageTrim
                            int count_TableValues = br.ReadInt32();
                            for (int j = 0; j < count_TableValues; ++j)
                            {
                                Temp_Table.Add(new Value_Table_CargoTankUllageTrim(br.ReadDouble(), br.ReadDouble(),
                            br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                            }
                            // Добавляем таблицу в список таблиц
                            ResultCargoTables.TablesCargoTankUllage.Add(new Table_CargoTankUllageTrim(Temp_Name, Temp_Table));
                        }

                        // считываем кол-во Tables_Hydrostatic
                        int count_tablesHydro = br.ReadInt32();

                        for (int i = 0; i < count_tablesHydro; ++i)
                        {
                            var Temp_Name = br.ReadString(); // записываем имя таблицы
                            var Temp_Table = new List<Value_Table_Hydrostatic> { };

                            // считываем кол-во значений в Table_Hydrostatic
                            int count_TableValues = br.ReadInt32();
                            for (int j = 0; j < count_TableValues; ++j)
                            {
                                Temp_Table.Add(new Value_Table_Hydrostatic(br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                            }
                            // Добавляем таблицу в список таблиц
                            ResultCargoTables.TablesHydrostatic.Add(new Table_Hydrostatic(Temp_Name, Temp_Table));
                        }

                        // считываем кол-во Tables_OtherSounding
                        int count_OS = br.ReadInt32();

                        for (int i = 0; i < count_OS; ++i)
                        {
                            var Temp_Name = br.ReadString(); // записываем имя таблицы
                            var Temp_Table = new List<Value_Table_OtherSounding> { };

                            // считываем кол-во значений в Table_OtherSounding
                            int count_TableValues = br.ReadInt32();
                            for (int j = 0; j < count_TableValues; ++j)
                            {
                                Temp_Table.Add(new Value_Table_OtherSounding(br.ReadDouble(), br.ReadDouble()));
                            }
                            // Добавляем таблицу в список таблиц
                            ResultCargoTables.TablesOtherSounding.Add(new Table_OtherSounding(Temp_Name, Temp_Table));
                        }

                        // считываем кол-во Tables_Volume
                        int count_Vol = br.ReadInt32();

                        for (int i = 0; i < count_Vol; ++i)
                        {
                            var Temp_Name = br.ReadString(); // записываем имя таблицы
                            var Temp_Table = new List<Value_Table_Volume> { };

                            // считываем кол-во значений в Table_OtherSounding
                            int count_TableValues = br.ReadInt32();
                            for (int j = 0; j < count_TableValues; ++j)
                            {
                                Temp_Table.Add(new Value_Table_Volume(br.ReadDouble(), br.ReadDouble(),
                            br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                            }
                            // Добавляем таблицу в список таблиц
                            ResultCargoTables.TablesVolume.Add(new Table_Volume(Temp_Name, Temp_Table));
                        }
                    }
                }
                return ResultCargoTables;
            }
            else return null;
        }
        // Выгрузка в файл json
        public static void UnLoadToJson(AllTables cargoTables, string path = "CargoTables.json")
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
                IncludeFields = true,
                MaxDepth = 2000000
            };

            var json = JsonSerializer.Serialize<AllTables>(cargoTables, options);
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
