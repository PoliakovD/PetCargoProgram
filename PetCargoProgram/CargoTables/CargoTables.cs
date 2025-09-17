using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using static PetCargoProgram.CargoTables.Table_BallastTankSoundingTrim;
using static PetCargoProgram.CargoTables.Table_CargoTankUllageTrim;
using static PetCargoProgram.CargoTables.Table_Hydrostatic;
using static PetCargoProgram.CargoTables.Table_OtherSounding;
using static PetCargoProgram.CargoTables.Table_Volume;

namespace PetCargoProgram.CargoTables
{
    class CargoTables
    {

        public List<Table_BallastTankSoundingTrim> Tables_BallastTanksSounding;
        public List<Table_CargoTankUllageTrim> Tables_CargoTanksUllage;
        public List<Table_Hydrostatic> Tables_Hydrostatic;
        public List<Table_OtherSounding> Tables_OtherSounding;
        public List<Table_Volume> Tables_Volume;

        public CargoTables()
        {
            //Tables_BallastTanksSounding = Table_BallastTankSoundingTrim.ReadAllTables();
            //Tables_CargoTanksUllage = Table_CargoTankUllageTrim.ReadAllTables();
            //Tables_Hydrostatic = Table_Hydrostatic.ReadAllTables();
            //Tables_OtherSounding = Table_OtherSounding.ReadAllTables();
            //Tables_Volume = Table_Volume.ReadAllTables();


            Tables_BallastTanksSounding = new List<Table_BallastTankSoundingTrim> { };
            Tables_CargoTanksUllage = new List<Table_CargoTankUllageTrim> { };
            Tables_Hydrostatic = new List<Table_Hydrostatic> { };
            Tables_OtherSounding = new List<Table_OtherSounding> { };
            Tables_Volume = new List<Table_Volume> { };
        }

        // Сохранение таблиц
        public void Save(string path = "CargoTables.bin")
        {
            if (this is null) throw new NullReferenceException("CargoTable can`t be saved if it`s null");

            using (FileStream fs = new FileStream(path,
            FileMode.Create))
            {
                using (BinaryWriter bw =
                new BinaryWriter(fs,
                Encoding.Unicode))
                {
                    // записываем  Tables_BallastTanksSounding
                    bw.Write(this.Tables_BallastTanksSounding.Count);// кол-во таблиц
                    foreach (var table_BTST in this.Tables_BallastTanksSounding)
                    {
                        bw.Write(table_BTST.Name); // имя таблицы
                        bw.Write(table_BTST.Table.Count); // кол-во записей в таблице
                        foreach (var value_BTST in table_BTST.Table)
                        {
                            // запись данных в файл
                            bw.Write(value_BTST.VolumeTrim5);
                            bw.Write(value_BTST.VolumeTrim4);
                            bw.Write(value_BTST.VolumeTrim3);
                            bw.Write(value_BTST.VolumeTrim2);
                            bw.Write(value_BTST.VolumeTrim1);
                            bw.Write(value_BTST.VolumeTrim0);
                            bw.Write(value_BTST.sound);
                        }
                    }

                    // записываем  Tables_CargoTanksUllage
                    bw.Write(this.Tables_CargoTanksUllage.Count);// кол-во таблиц
                    foreach (var table_CTU in this.Tables_CargoTanksUllage)
                    {
                        bw.Write(table_CTU.Name); // имя таблицы
                        bw.Write(table_CTU.Table.Count); // кол-во записей в таблице
                        foreach (var value_CTU in table_CTU.Table)
                        {
                            // запись данных в файл
                            bw.Write(value_CTU.ullage);
                            bw.Write(value_CTU.CargoVolumeTrim4);
                            bw.Write(value_CTU.CargoVolumeTrim3);
                            bw.Write(value_CTU.CargoVolumeTrim2);
                            bw.Write(value_CTU.CargoVolumeTrim1);
                            bw.Write(value_CTU.CargoVolumeTrim0);
                            bw.Write(value_CTU.CargoVolumeTrim_1);
                        }
                    }

                    // записываем  Tables_Hydrostatic
                    bw.Write(this.Tables_Hydrostatic.Count);// кол-во таблиц
                    foreach (var table_Hydro in this.Tables_Hydrostatic)
                    {
                        bw.Write(table_Hydro.Name); // имя таблицы
                        bw.Write(table_Hydro.Table.Count); // кол-во записей в таблице
                        foreach (var value_Hydro in table_Hydro.Table)
                        {
                            // запись данных в файл
                            bw.Write(value_Hydro.displacement);
                            bw.Write(value_Hydro.draft);
                            bw.Write(value_Hydro.tpc);
                            bw.Write(value_Hydro.metacentrKM);
                            bw.Write(value_Hydro.FloatationCenterLCF);
                            bw.Write(value_Hydro.MCTC);
                            bw.Write(value_Hydro.LCB);
                            bw.Write(value_Hydro.CM);
                        }
                    }

                    // записываем  Tables_OtherSounding
                    bw.Write(this.Tables_OtherSounding.Count);// кол-во таблиц
                    foreach (var table_OS in this.Tables_OtherSounding)
                    {
                        bw.Write(table_OS.Name); // имя таблицы
                        bw.Write(table_OS.Table.Count); // кол-во записей в таблице
                        foreach (var value_OS in table_OS.Table)
                        {
                            // запись данных в файл
                            bw.Write(value_OS.volume);
                            bw.Write(value_OS.sound);
                        }
                    }

                    // записываем  Tables_Volume
                    bw.Write(this.Tables_Volume.Count);// кол-во таблиц
                    foreach (var table_Vol in this.Tables_Volume)
                    {
                        bw.Write(table_Vol.Name); // имя таблицы
                        bw.Write(table_Vol.Table.Count); // кол-во записей в таблице
                        foreach (var value_Vol in table_Vol.Table)
                        {
                            // запись данных в файл
                            bw.Write(value_Vol.Volume);
                            bw.Write(value_Vol.LCG);
                            bw.Write(value_Vol.TCG);
                            bw.Write(value_Vol.VCG);
                            bw.Write(value_Vol.IY);
                        }
                    }

                }
            }
        }
        public static CargoTables? Load(string path = "CargoTables.bin")
        {
            if (File.Exists(path))
            {

                CargoTables ResultCargoTables = new CargoTables();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
                    {
                        // считываем кол-во Tables_BallastTanksSounding
                        int count_tablesBTST = br.ReadInt32();

                        for (int i = 0; i < count_tablesBTST; ++i)
                        {
                            var Temp_Name = br.ReadString(); // записываем имя таблицы
                            var Temp_Table = new List<Table_BallastTankSoundingTrim.Value_Table_BallastSoundingTrim> { };

                            // считываем кол-во значений в Table_BallastTankSoundingTrim
                            int count_TableValues = br.ReadInt32();
                            for (int j = 0; j < count_TableValues; ++j)
                            {
                                Temp_Table.Add(new Table_BallastTankSoundingTrim.Value_Table_BallastSoundingTrim(br.ReadDouble(), br.ReadDouble(),
                                br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                            }
                            // Добавляем таблицу в список таблиц
                            ResultCargoTables.Tables_BallastTanksSounding.Add(new Table_BallastTankSoundingTrim(Temp_Name, Temp_Table));
                        }

                        // считываем кол-во Tables_CargoTanksUllage
                        int count_tablesCTU = br.ReadInt32();

                        for (int i = 0; i < count_tablesCTU; ++i)
                        {
                            var Temp_Name = br.ReadString(); // записываем имя таблицы
                            var Temp_Table = new List<Table_CargoTankUllageTrim.Value_Table_CargoTankUllageTrim> { };

                            // считываем кол-во значений в Table_CargoTankUllageTrim
                            int count_TableValues = br.ReadInt32();
                            for (int j = 0; j < count_TableValues; ++j)
                            {
                                Temp_Table.Add(new Table_CargoTankUllageTrim.Value_Table_CargoTankUllageTrim(br.ReadDouble(), br.ReadDouble(),
                            br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                            }
                            // Добавляем таблицу в список таблиц
                            ResultCargoTables.Tables_CargoTanksUllage.Add(new Table_CargoTankUllageTrim(Temp_Name, Temp_Table));
                        }

                        // считываем кол-во Tables_Hydrostatic
                        int count_tablesHydro = br.ReadInt32();

                        for (int i = 0; i < count_tablesHydro; ++i)
                        {
                            var Temp_Name = br.ReadString(); // записываем имя таблицы
                            var Temp_Table = new List<Table_Hydrostatic.Value_Table_Hydrostatic> { };

                            // считываем кол-во значений в Table_Hydrostatic
                            int count_TableValues = br.ReadInt32();
                            for (int j = 0; j < count_TableValues; ++j)
                            {
                                Temp_Table.Add(new Table_Hydrostatic.Value_Table_Hydrostatic(br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                            }
                            // Добавляем таблицу в список таблиц
                            ResultCargoTables.Tables_Hydrostatic.Add(new Table_Hydrostatic(Temp_Name, Temp_Table));
                        }

                        // считываем кол-во Tables_OtherSounding
                        int count_OS = br.ReadInt32();

                        for (int i = 0; i < count_OS; ++i)
                        {
                            var Temp_Name = br.ReadString(); // записываем имя таблицы
                            var Temp_Table = new List<Table_OtherSounding.Value_Table_OtherSounding> { };

                            // считываем кол-во значений в Table_OtherSounding
                            int count_TableValues = br.ReadInt32();
                            for (int j = 0; j < count_TableValues; ++j)
                            {
                                Temp_Table.Add(new Table_OtherSounding.Value_Table_OtherSounding(br.ReadDouble(), br.ReadDouble()));
                            }
                            // Добавляем таблицу в список таблиц
                            ResultCargoTables.Tables_OtherSounding.Add(new Table_OtherSounding(Temp_Name, Temp_Table));
                        }

                        // считываем кол-во Tables_Volume
                        int count_Vol = br.ReadInt32();

                        for (int i = 0; i < count_Vol; ++i)
                        {
                            var Temp_Name = br.ReadString(); // записываем имя таблицы
                            var Temp_Table = new List<Table_Volume.Value_Table_Volume> { };

                            // считываем кол-во значений в Table_OtherSounding
                            int count_TableValues = br.ReadInt32();
                            for (int j = 0; j < count_TableValues; ++j)
                            {
                                Temp_Table.Add(new Table_Volume.Value_Table_Volume(br.ReadDouble(), br.ReadDouble(),
                            br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                            }
                            // Добавляем таблицу в список таблиц
                            ResultCargoTables.Tables_Volume.Add(new Table_Volume(Temp_Name, Temp_Table));
                        }
                    }
                }
                return ResultCargoTables;
            }
            else return null;
        }
        // Выгрузка в файл json
        public static void UnLoad(CargoTables cargoTables, string path = "CargoTables.json")
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true,
                IncludeFields = true,
                MaxDepth = 2000000
            };

            var json = JsonSerializer.Serialize<CargoTables>(cargoTables, options);
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
}
