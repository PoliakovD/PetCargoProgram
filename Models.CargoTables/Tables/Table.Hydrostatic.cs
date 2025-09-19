using System.Text;
using Model.CargoTables;
using PetCargoProgram.CargoTables.Values;

namespace PetCargoProgram.CargoTables.Tables;

// TODO Перенести в сервис сурвисную часть
public class Table_Hydrostatic : ICargoTable
{
    public string Name { get; set; }
        public List<Value_Table_Hydrostatic> Table{ get; set; }
        public Table_Hydrostatic(string name, List<Value_Table_Hydrostatic> table)
        {
            Name = name;
            Table = table;
        }
        static public void Save_to_file(string initialPath, string finalPath)
        {
            List<Value_Table_Hydrostatic> cot = new List<Value_Table_Hydrostatic> { };

            string temp = File.ReadAllText(initialPath);
            temp = temp.Replace(',', '.');
            string[] temparr = temp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temparr.Length; ++i)
            {
                string[] tempUllage = temparr[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                cot.Add(new Value_Table_Hydrostatic(Convert.ToDouble(tempUllage[0]), Convert.ToDouble(tempUllage[1]), Convert.ToDouble(tempUllage[2]),
                    Convert.ToDouble(tempUllage[3]), Convert.ToDouble(tempUllage[4]), Convert.ToDouble(tempUllage[5]), Convert.ToDouble(tempUllage[6]), Convert.ToDouble(tempUllage[7])));

            }

            using (FileStream fs = new FileStream(finalPath,
            FileMode.Create))
            {
                using (BinaryWriter bw =
                new BinaryWriter(fs,
                Encoding.Unicode))
                {
                    bw.Write(cot.Count);
                    foreach (var item in cot)
                    {
                        // запись данных в файл
                        bw.Write(item.displacement);
                        bw.Write(item.draft);
                        bw.Write(item.tpc);
                        bw.Write(item.metacentrKM);
                        bw.Write(item.FloatationCenterLCF);
                        bw.Write(item.MCTC);
                        bw.Write(item.LCB);
                        bw.Write(item.CM);
                    }

                }
            }


        }
        static public List<Value_Table_Hydrostatic> Read_from_file(string Path)
        {
            List<Value_Table_Hydrostatic> cot1 = new List<Value_Table_Hydrostatic> { };

            using (FileStream fs = new FileStream(Path,
            FileMode.Open))
            {
                using (BinaryReader br =
                new BinaryReader(fs,
                Encoding.Unicode))
                {
                    int count = br.ReadInt32();
                    for (int i = 0; i < count; ++i)
                    {
                        cot1.Add(new Value_Table_Hydrostatic(br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));

                    }

                    // получаем данные из файла

                }
            }
            return cot1;
        }
        static public void TempSaveAll()
        {
            string[] input = { "HydrostaticTableTrim1.txt","HydrostaticTableTrim0.txt",  "HydrostaticTableTrim-1.txt", "HydrostaticTableTrim-2.txt"
                    , "HydrostaticTableTrim-3.txt", "HydrostaticTableTrim-4.txt" };
            string[] output = { "HydrostaticTableTrim1.bin","HydrostaticTableTrim0.bin",  "HydrostaticTableTrim-1.bin", "HydrostaticTableTrim-2.bin"
                    , "HydrostaticTableTrim-3.bin", "HydrostaticTableTrim-4.bin" };

            for (int i = 0; i < input.Length; ++i)
            {
                Table_Hydrostatic.Save_to_file(input[i], output[i]);
                List<Value_Table_Hydrostatic> cot1 = Table_Hydrostatic.Read_from_file(output[i]);

            }

        }
        static public List<Table_Hydrostatic> ReadAllTables()
        {
            var result = new List<Table_Hydrostatic> { };

            string[] output = { "Trim1.bin","Trim0.bin",  "Trim-1.bin", "Trim-2.bin"
                    , "Trim-3.bin", "Trim-4.bin" };

            foreach (var item in output)
            {
                result.Add(new Table_Hydrostatic(item.Replace(".bin", ""), Table_Hydrostatic.Read_from_file(item)));
            }


            return result;
        }
}
