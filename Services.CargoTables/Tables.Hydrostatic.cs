using System.Text;
using PetCargoProgram.CargoTables.Tables;
using PetCargoProgram.CargoTables.Values;

namespace Services.CargoTables;

public class Tables_Hydrostatic
{
    private List<Table_Hydrostatic> _tables = [];
    public FileStream WriteTables(FileStream fs, BinaryWriter bw)
    {
        // записываем  Tables_Hydrostatic
        bw.Write(_tables.Count);// кол-во таблиц
        foreach (var table_Hydro in _tables)
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
        return fs;
    }
}
