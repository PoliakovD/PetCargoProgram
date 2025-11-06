using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PetCargoProgram.Models.CargoTables.Values;

namespace PetCargoProgram.Models.CargoTables.Tables;

public class TableKN
    {
        public List<ValueTableKN> Table { get; set; }

        public static void Save_to_file(string initialPath, string finalPath)
        {
            List<ValueTableKN> cot = new List<ValueTableKN> { };

            string temp = File.ReadAllText(initialPath);
            string[] temparr = temp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temparr.Length; ++i)
            {
                string[] split = temparr[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                cot.Add(new ValueTableKN(Convert.ToDouble(split[0]), Convert.ToDouble(split[1]),
                    Convert.ToDouble(split[2]),
                    Convert.ToDouble(split[3]), Convert.ToDouble(split[4]), Convert.ToDouble(split[5]),
                    Convert.ToDouble(split[6]), Convert.ToDouble(split[7]), Convert.ToDouble(split[8]),
                    Convert.ToDouble(split[9]), Convert.ToDouble(split[10]), Convert.ToDouble(split[11]),
                    Convert.ToDouble(split[12])));
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
                        bw.Write(item.Draft);
                        bw.Write(item.KNonHeelingAngle0_1);
                        bw.Write(item.KNonHeelingAngle5);
                        bw.Write(item.KNonHeelingAngle10);
                        bw.Write(item.KNonHeelingAngle15);
                        bw.Write(item.KNonHeelingAngle20);
                        bw.Write(item.KNonHeelingAngle30);
                        bw.Write(item.KNonHeelingAngle40);
                        bw.Write(item.KNonHeelingAngle50);
                        bw.Write(item.KNonHeelingAngle60);
                        bw.Write(item.KNonHeelingAngle70);
                        bw.Write(item.KNonHeelingAngle80);
                        bw.Write(item.KNonHeelingAngle90);
                    }
                }
            }
        }

        static public List<ValueTableKN> Read_from_file(string Path)
        {
            List<ValueTableKN> table = new List<ValueTableKN> { };

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
                        table.Add(new ValueTableKN(br.ReadDouble(), br.ReadDouble(),
                            br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()
                            , br.ReadDouble(), br.ReadDouble(), br.ReadDouble(), br.ReadDouble()
                            , br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                    }
                    // получаем данные из файла
                }
            }
            return table;
        }
    }
