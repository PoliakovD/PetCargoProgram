using System.Collections.Generic;
using System.IO;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.DataAccess.CargoTables.TablesReaders;

/// <summary>
/// This static class for reading Tables_OtherSounding
/// Contain method  <see cref="Read"/>
/// </summary>
public static class ReaderOtherSounding
{
    /// <summary>
    /// Read Tables_OtherSounding in AllCargoTables object
    /// <param name="fs">Input  <see cref="FileStream"/></param>
    /// <param name="br">Input  <see cref="BinaryReader"/> for reading all required rows from bin file</param>
    /// <param name="allCargoTables">reference on <see cref="AllCargoTables"/> to which object to save <see cref="TablesOtherSounding"/></param>
    /// <returns><see cref="FileStream"/> to continue read other Tables</returns>
    /// </summary>
    public static FileStream Read(FileStream fs, BinaryReader br, ref AllCargoTables allCargoTables)
    {
        allCargoTables.TablesOtherSounding.Tables.Clear(); // Очищаем список
        // считываем кол-во Tables_OtherSounding
        int count_OS = br.ReadInt32();

        for (int i = 0; i < count_OS; ++i)
        {
            var Temp_Name = br.ReadString(); // записываем имя таблицы
            var Temp_Table = new List<ValueTableOtherSounding> { };

            // считываем кол-во значений в Table_OtherSounding
            int count_TableValues = br.ReadInt32();
            for (int j = 0; j < count_TableValues; ++j)
            {
                Temp_Table.Add(new ValueTableOtherSounding(br.ReadDouble(), br.ReadDouble()));
            }

            // Добавляем таблицу в список таблиц
            allCargoTables.TablesOtherSounding.Tables.Add(new TableOtherSounding(Temp_Name, Temp_Table));
        }

        return fs;
    }
}
