using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;
public class Tables_Volume
{
    public  List<Table_Volume> Tables { get; set; } = [];

    public void Add(Table_Volume table) => Tables.Add(table);
    // public FileStream WriteTables(FileStream fs, BinaryWriter bw)
    // {
    //     // записываем  Tables_Volume
    //     bw.Write(this._tables.Count);// кол-во таблиц
    //     foreach (var table_Vol in this._tables)
    //     {
    //         bw.Write(table_Vol.Name); // имя таблицы
    //         bw.Write(table_Vol.Table.Count); // кол-во записей в таблице
    //         foreach (var value_Vol in table_Vol.Table)
    //         {
    //             // запись данных в файл
    //             bw.Write(value_Vol.Volume);
    //             bw.Write(value_Vol.LCG);
    //             bw.Write(value_Vol.TCG);
    //             bw.Write(value_Vol.VCG);
    //             bw.Write(value_Vol.IY);
    //         }
    //     }
    //     return fs;
    // }
    // public FileStream ReadTables(FileStream fs, BinaryReader br)
    // {
    //     _tables.Clear(); // Очищаем список
    //
    //     // считываем кол-во Tables_Volume
    //     int count_Vol = br.ReadInt32();
    //
    //     for (int i = 0; i < count_Vol; ++i)
    //     {
    //         var Temp_Name = br.ReadString(); // записываем имя таблицы
    //         var Temp_Table = new List<Value_Table_Volume> { };
    //
    //         // считываем кол-во значений в Table_OtherSounding
    //         int count_TableValues = br.ReadInt32();
    //         for (int j = 0; j < count_TableValues; ++j)
    //         {
    //             Temp_Table.Add(new Value_Table_Volume(br.ReadDouble(), br.ReadDouble(),
    //                 br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
    //         }
    //         // Добавляем таблицу в список таблиц
    //         _tables.Add(new Table_Volume(Temp_Name, Temp_Table));
    //     }
    //     return fs;
    // }

}
