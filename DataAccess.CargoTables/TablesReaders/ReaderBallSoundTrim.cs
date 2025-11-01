using System.Collections.Generic;
using System.IO;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.CargoTables.Table;
using PetCargoProgram.Models.CargoTables.Tables;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.DataAccess.CargoTables.TablesReaders;

/// <summary>
/// This static class for reading Tables_BallastTanksSounding
/// Contain method  <see cref="Read"/>
/// </summary>
public static class ReaderBallSoundTrim
{
    /// <summary>
    /// Read Tables_BallastTanksSounding in AllCargoTables object
    /// <param name="fs">Input  <see cref="FileStream"/></param>
    /// <param name="br">Input  <see cref="BinaryReader"/> for reading all required rows from bin file</param>
    /// <param name="allCargoTables">reference on <see cref="AllCargoTables"/> to which object to save <see cref="TablesBallSoundTrim"/></param>
    /// <returns><see cref="FileStream"/> to continue read other Tables</returns>
    /// </summary>
    public static FileStream Read(FileStream fs, BinaryReader br, ref AllCargoTables allCargoTables)
    {
        if (allCargoTables.TablesBallSoundTrim.Tables is not null)
            allCargoTables.TablesBallSoundTrim.Tables.Clear(); // Очищаем список


        // считываем кол-во Tables_BallastTanksSounding
        int count_tablesBTST = br.ReadInt32();

        for (int i = 0; i < count_tablesBTST; ++i)
        {
            var Temp_Name = br.ReadString(); // записываем имя таблицы
            var Temp_Table = new List<ValueTableBallSoundTrim> { };

            // считываем кол-во значений в Table_BallastTankSoundingTrim
            int count_TableValues = br.ReadInt32();
            for (int j = 0; j < count_TableValues; ++j)
            {
                Temp_Table.Add(new ValueTableBallSoundTrim(br.ReadDouble(), br.ReadDouble(),
                    br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
            }

            // Добавляем таблицу в список таблиц
            allCargoTables.TablesBallSoundTrim.Tables?.Add(new TableBallSoundTrim(Temp_Name, Temp_Table));
        }

        return fs;
    }
}
