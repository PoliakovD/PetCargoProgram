using System.Text;
using PetCargoProgram.CargoTables.Tables;
using PetCargoProgram.CargoTables.Values;

namespace Services.CargoTables;

public class Tables_CargoTankUllageTrim
{

        private List<Table_CargoTankUllageTrim> _tables = [];

        public FileStream WriteTables(FileStream fs, BinaryWriter bw)
        {
            // записываем  Table_CargoTankUllageTrim
            bw.Write(_tables.Count); // кол-во таблиц
            foreach (var table_BTST in _tables)
            {
                bw.Write(_tables.Count); // кол-во таблиц
                foreach (var table_CTU in _tables)
                {
                    bw.Write(table_CTU.Name); // имя таблицы
                    bw.Write(table_CTU.Table.Count); // кол-во записей в таблице
                    foreach (var value_CTU in table_CTU.Table)
                    {
                        // запись данных в файл
                        bw.Write(value_CTU.Ullage);
                        bw.Write(value_CTU.CargoVolumeTrim4);
                        bw.Write(value_CTU.CargoVolumeTrim3);
                        bw.Write(value_CTU.CargoVolumeTrim2);
                        bw.Write(value_CTU.CargoVolumeTrim1);
                        bw.Write(value_CTU.CargoVolumeTrim0);
                        bw.Write(value_CTU.CargoVolumeTrim_1);
                    }
                }
            }
            return fs;
        }
}
