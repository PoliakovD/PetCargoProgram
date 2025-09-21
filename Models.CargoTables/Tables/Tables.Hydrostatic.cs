using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;

public class Tables_Hydrostatic
{
    public  List<Table_Hydrostatic> Tables { get; set; } = [];

    public void Add(Table_Hydrostatic table) => Tables.Add(table);
    // public FileStream WriteTables(FileStream fs, BinaryWriter bw)
    // {
    //     // записываем  Tables_Hydrostatic
    //     bw.Write(_tables.Count);// кол-во таблиц
    //     foreach (var table_Hydro in _tables)
    //     {
    //         bw.Write(table_Hydro.Name); // имя таблицы
    //         bw.Write(table_Hydro.Table.Count); // кол-во записей в таблице
    //         foreach (var value_Hydro in table_Hydro.Table)
    //         {
    //             // запись данных в файл
    //             bw.Write(value_Hydro.displacement);
    //             bw.Write(value_Hydro.draft);
    //             bw.Write(value_Hydro.tpc);
    //             bw.Write(value_Hydro.metacentrKM);
    //             bw.Write(value_Hydro.FloatationCenterLCF);
    //             bw.Write(value_Hydro.MCTC);
    //             bw.Write(value_Hydro.LCB);
    //             bw.Write(value_Hydro.CM);
    //         }
    //     }
    //     return fs;
    // }
    // public FileStream ReadTables(FileStream fs, BinaryReader br)
    // {
    //     _tables.Clear(); // Очищаем список
    //
    //     // считываем кол-во Tables_Hydrostatic
    //     int count_tablesHydro = br.ReadInt32();
    //
    //     for (int i = 0; i < count_tablesHydro; ++i)
    //     {
    //         var Temp_Name = br.ReadString(); // записываем имя таблицы
    //         var Temp_Table = new List<Value_Table_Hydrostatic> { };
    //
    //         // считываем кол-во значений в Table_Hydrostatic
    //         int count_TableValues = br.ReadInt32();
    //         for (int j = 0; j < count_TableValues; ++j)
    //         {
    //             Temp_Table.Add(new Value_Table_Hydrostatic(br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
    //         }
    //         // Добавляем таблицу в список таблиц
    //         _tables.Add(new Table_Hydrostatic(Temp_Name, Temp_Table));
    //     }
    //     return fs;
    // }
}
