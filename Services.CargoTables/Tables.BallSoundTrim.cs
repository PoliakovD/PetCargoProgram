using System.Text;
using PetCargoProgram.CargoTables.Tables;
using PetCargoProgram.CargoTables.Values;

namespace Services.CargoTables;

public class Tables_BallSoundTrim
{
    private List<Table_BallSoundTrim> _tables = [];

    public FileStream WriteTables(FileStream fs, BinaryWriter bw)
    {
        // записываем  Tables_BallastTanksSounding
        bw.Write(_tables.Count);// кол-во таблиц
        foreach (var table_BTST in _tables)
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
                bw.Write(value_BTST.Sound);
            }
        }
        return fs;
    }
}
