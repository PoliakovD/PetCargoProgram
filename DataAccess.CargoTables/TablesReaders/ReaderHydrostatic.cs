using System.Collections.Generic;
using System.IO;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.DataAccess.CargoTables.TablesReaders;

/// <summary>
/// This static class for reading Tables_Hydrostatic
/// Contain method  <see cref="Read"/>
/// </summary>
public static class ReaderHydrostatic
{
    /// <summary>
    /// Read Tables_Hydrostatic in AllCargoTables object
    /// <param name="fs">Input  <see cref="FileStream"/></param>
    /// <param name="br">Input  <see cref="BinaryReader"/> for reading all required rows from bin file</param>
    /// <param name="allCargoTables">reference on <see cref="AllCargoTables"/> to which object to save <see cref="TablesHydrostatic"/></param>
    /// <returns><see cref="FileStream"/> to continue read other Tables</returns>
    /// </summary>
    public static FileStream Read(FileStream fs, BinaryReader br, ref AllCargoTables allCargoTables)
    {
        allCargoTables.TablesHydrostatic.Tables.Clear(); // Очищаем список

        // считываем кол-во Tables_Hydrostatic
        int count_tablesHydro = br.ReadInt32();

        for (int i = 0; i < count_tablesHydro; ++i)
        {
            var Temp_Name = br.ReadString(); // записываем имя таблицы
            var Temp_Table = new List<ValueTableHydrostatic> { };

            // считываем кол-во значений в Table_Hydrostatic
            int count_TableValues = br.ReadInt32();
            for (int j = 0; j < count_TableValues; ++j)
            {
                Temp_Table.Add(new ValueTableHydrostatic(br.ReadDouble(), br.ReadDouble(), br.ReadDouble(),
                    br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
            }

            // Добавляем таблицу в список таблиц
            allCargoTables.TablesHydrostatic.Tables.Add(new TableHydrostatic(Temp_Name, Temp_Table));
        }

        return fs;
    }
}
