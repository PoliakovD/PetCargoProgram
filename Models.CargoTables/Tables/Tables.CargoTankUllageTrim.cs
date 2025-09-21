using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;

public class Tables_CargoTankUllageTrim
{

    public  List<Table_CargoTankUllageTrim> Tables { get; set; } = [];

        public void Add(Table_CargoTankUllageTrim table) => Tables.Add(table);
        // public FileStream WriteTables(FileStream fs, BinaryWriter bw)
        // {
        //     // записываем  Table_CargoTankUllageTrim
        //     bw.Write(_tables.Count); // кол-во таблиц
        //     foreach (var table_BTST in _tables)
        //     {
        //         bw.Write(_tables.Count); // кол-во таблиц
        //         foreach (var table_CTU in _tables)
        //         {
        //             bw.Write(table_CTU.Name); // имя таблицы
        //             bw.Write(table_CTU.Table.Count); // кол-во записей в таблице
        //             foreach (var value_CTU in table_CTU.Table)
        //             {
        //                 // запись данных в файл
        //                 bw.Write(value_CTU.Ullage);
        //                 bw.Write(value_CTU.CargoVolumeTrim4);
        //                 bw.Write(value_CTU.CargoVolumeTrim3);
        //                 bw.Write(value_CTU.CargoVolumeTrim2);
        //                 bw.Write(value_CTU.CargoVolumeTrim1);
        //                 bw.Write(value_CTU.CargoVolumeTrim0);
        //                 bw.Write(value_CTU.CargoVolumeTrim_1);
        //             }
        //         }
        //     }
        //     return fs;
        // }
        // public FileStream ReadTables(FileStream fs, BinaryReader br)
        // {
        //     _tables.Clear(); // Очищаем список
        //
        //     // считываем кол-во Tables_CargoTanksUllage
        //     int count_tablesCTU = br.ReadInt32();
        //
        //     for (int i = 0; i < count_tablesCTU; ++i)
        //     {
        //         var Temp_Name = br.ReadString(); // записываем имя таблицы
        //         var Temp_Table = new List<Value_Table_CargoTankUllageTrim> { };
        //
        //         // считываем кол-во значений в Table_CargoTankUllageTrim
        //         int count_TableValues = br.ReadInt32();
        //         for (int j = 0; j < count_TableValues; ++j)
        //         {
        //             Temp_Table.Add(new Value_Table_CargoTankUllageTrim(br.ReadDouble(), br.ReadDouble(),
        //                 br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
        //         }
        //         // Добавляем таблицу в список таблиц
        //         _tables.Add(new Table_CargoTankUllageTrim(Temp_Name, Temp_Table));
        //     }
        //     return fs;
        // }
}
