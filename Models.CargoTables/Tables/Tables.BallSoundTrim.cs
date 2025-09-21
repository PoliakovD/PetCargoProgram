using System.Collections.Generic;
using PetCargoProgram.Models.CargoTables.Values;
using PetCargoProgram.Models.CargoTables.Table;

namespace PetCargoProgram.Models.CargoTables.Tables;

public class Tables_BallSoundTrim
{
    public List<Table_BallSoundTrim> Tables { get; set; } = [];
    public void Add(Table_BallSoundTrim table) => Tables.Add(table);

    // public FileStream WriteTables(FileStream fs, BinaryWriter bw)
    // {
    //     // записываем  Tables_BallastTanksSounding
    //     bw.Write(Tables.Count);// кол-во таблиц
    //     foreach (var tableBTST in Tables)
    //     {
    //         bw.Write(tableBTST.Name); // имя таблицы
    //         bw.Write(tableBTST.Table.Count); // кол-во записей в таблице
    //         foreach (var valueBTST in tableBTST.Table)
    //         {
    //             // запись данных в файл
    //             bw.Write(valueBTST.VolumeTrim5);
    //             bw.Write(valueBTST.VolumeTrim4);
    //             bw.Write(valueBTST.VolumeTrim3);
    //             bw.Write(valueBTST.VolumeTrim2);
    //             bw.Write(valueBTST.VolumeTrim1);
    //             bw.Write(valueBTST.VolumeTrim0);
    //             bw.Write(valueBTST.Sound);
    //         }
    //     }
    //     return fs;
    // }
    //
    // public FileStream ReadTables(FileStream fs, BinaryReader br)
    // {
    //     Tables.Clear(); // Очищаем список
    //     // считываем кол-во Tables_BallastTanksSounding
    //     int countTablesBTST = br.ReadInt32();
    //
    //     for (int i = 0; i < countTablesBTST; ++i)
    //     {
    //         var TempName = br.ReadString(); // записываем имя таблицы
    //         var TempTable = new List<Value_Table_BallSoundTrim> { };
    //
    //         // считываем кол-во значений в Table_BallastTankSoundingTrim
    //         int count_TableValues = br.ReadInt32();
    //         for (int j = 0; j < count_TableValues; ++j)
    //         {
    //             TempTable.Add(new Value_Table_BallSoundTrim(br.ReadDouble(), br.ReadDouble(),
    //                 br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
    //         }
    //         // Добавляем таблицу в список таблиц
    //         Tables.Add(new Table_BallSoundTrim(TempName, TempTable));
    //     }
    //     return fs;
    // }
}
