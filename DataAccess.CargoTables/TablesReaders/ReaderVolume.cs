using System.Collections.Generic;
using System.IO;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.DataAccess.CargoTables.TablesReaders;

/// <summary>
/// This static class for reading Tables_Volume
/// Contain method  <see cref="Read"/>
/// </summary>
public static class ReaderVolume
{
    /// <summary>
    /// Read Tables_Volume in AllCargoTables object
    /// <param name="fs">Input  <see cref="FileStream"/></param>
    /// <param name="br">Input  <see cref="BinaryReader"/> for reading all required rows from bin file</param>
    /// <param name="allCargoTables">reference on <see cref="AllCargoTables"/> to which object to save <see cref="TablesVolume"/></param>
    /// <returns><see cref="FileStream"/> to continue read other Tables</returns>
    /// </summary>
    public static FileStream Read(FileStream fs, BinaryReader br, ref AllCargoTables allCargoTables)
    {
        allCargoTables.TablesVolume.Tables.Clear(); // Очищаем список
        // считываем кол-во Tables_Volume
        int count_Vol = br.ReadInt32();

        for (int i = 0; i < count_Vol; ++i)
        {
            var Temp_Name = br.ReadString(); // записываем имя таблицы
            var Temp_Table = new List<ValueTableVolume> { };

            // считываем кол-во значений в Table_OtherSounding
            int count_TableValues = br.ReadInt32();
            for (int j = 0; j < count_TableValues; ++j)
            {
                Temp_Table.Add(new ValueTableVolume(br.ReadDouble(), br.ReadDouble(),
                    br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
            }

            // Добавляем таблицу в список таблиц
            allCargoTables.TablesVolume.Tables.Add(new TableVolume(Temp_Name, Temp_Table));
        }

        return fs;
    }
}
