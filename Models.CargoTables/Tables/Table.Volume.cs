using System.Text;
using Model.CargoTables;
using PetCargoProgram.CargoTables.Values;

// TODO Перенести в сервис сурвисную часть
public class Table_Volume:ICargoTable
{
     public string Name { get; set; }
        public List<Value_Table_Volume> Table;
        public Table_Volume(string name, List<Value_Table_Volume> table)
        {
            Name = name;
            Table = table;
        }
        static public void Save_to_file(string initialPath, string finalPath)
        {
            List<Value_Table_Volume> cot = new List<Value_Table_Volume> { };

            string temp = File.ReadAllText(initialPath);
            string[] temparr = temp.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temparr.Length; ++i)
            {
                string[] tempUllage = temparr[i].Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                cot.Add(new Value_Table_Volume(Convert.ToDouble(tempUllage[0]), Convert.ToDouble(tempUllage[1]), Convert.ToDouble(tempUllage[2]),
                    Convert.ToDouble(tempUllage[3]), Convert.ToDouble(tempUllage[4])));

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
                        bw.Write(item.Volume);
                        bw.Write(item.LCG);
                        bw.Write(item.TCG);
                        bw.Write(item.VCG);
                        bw.Write(item.IY);
                    }
                }
            }
        }
        static public List<Value_Table_Volume> Read_from_file(string Path)
        {
            List<Value_Table_Volume> cot1 = new List<Value_Table_Volume> { };

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
                        cot1.Add(new Value_Table_Volume(br.ReadDouble(), br.ReadDouble(),
                            br.ReadDouble(), br.ReadDouble(), br.ReadDouble()));
                    }
                    // получаем данные из файла
                }
            }
            return cot1;
        }
        static public void savealltemp()
        {
            string[] input = { "COT1P.txt","COT2P.txt", "COT3P.txt", "COT4P.txt", "COT5P.txt", "COT6P.txt", "SLOPP.txt"
                             , "COT1S.txt","COT2S.txt", "COT3S.txt", "COT4S.txt", "COT5S.txt", "COT6S.txt", "SLOPS.txt"
                             ,"BWT1P.txt","BWT2P.txt","BWT3P.txt","BWT4P.txt","BWT5P.txt","BWT6P.txt"
                             ,"BWT1S.txt","BWT2S.txt","BWT3S.txt","BWT4S.txt","BWT5S.txt","BWT6S.txt","FPT.txt","APT.txt"
                             ,"1HFOStor_P.txt","1HFOStor_S.txt","2HFOStor_S.txt","HFOSett_S.txt","HFOServ_S.txt"
                             ,"LSHFOSett_S.txt","LSHFOServ_S.txt","DOStorS.txt","DOStervS.txt","2HFOStor_P.txt"
                             ,"MainLOSettS.txt","MainLOStorS.txt","1CylOilStorS.txt","2CylOilStorP.txt","GELOStorS.txt"
                             ,"TurLOStorS.txt","MainLOSumpC.txt","FWTP.txt","FWTS.txt","CWTC.txt","STLODrainS.txt"
                             ,"SepBilgeOilP.txt","BilgeHoldingP.txt","FOoverflowC.txt","PurifSludgeS.txt"
                             ,"BW_ER_AFT_P.txt","BW_ER_FWD_P.txt","BW_ER_FWD_S.txt"};

            string[] output = { "COT1P.bin","COT2P.bin", "COT3P.bin", "COT4P.bin", "COT5P.bin", "COT6P.bin", "SLOPP.bin"
                             , "COT1S.bin","COT2S.bin", "COT3S.bin", "COT4S.bin", "COT5S.bin", "COT6S.bin", "SLOPS.bin"
                             ,"BWT1P.bin","BWT2P.bin","BWT3P.bin","BWT4P.bin","BWT5P.bin","BWT6P.bin"
                             ,"BWT1S.bin","BWT2S.bin","BWT3S.bin","BWT4S.bin","BWT5S.bin","BWT6S.bin","FPT.bin","APT.bin"
                             ,"1HFOStor_P.bin","1HFOStor_S.bin","2HFOStor_S.bin","HFOSett_S.bin","HFOServ_S.bin"
                             ,"LSHFOSett_S.bin","LSHFOServ_S.bin","DOStorS.bin","DOStervS.bin","2HFOStor_P.bin"
                             ,"MainLOSettS.bin","MainLOStorS.bin","1CylOilStorS.bin","2CylOilStorP.bin","GELOStorS.bin"
                             ,"TurLOStorS.bin","MainLOSumpC.bin","FWTP.bin","FWTS.bin","CWTC.bin","STLODrainS.bin"
                             ,"SepBilgeOilP.bin","BilgeHoldingP.bin","FOoverflowC.bin","PurifSludgeS.bin"
                             ,"BW_ER_AFT_P.bin","BW_ER_FWD_P.bin","BW_ER_FWD_S.bin"};

            for (int i = 0; i < input.Length; ++i)
            {
                Table_Volume.Save_to_file(input[i], output[i]);
                List<Value_Table_Volume> cot1 = Table_Volume.Read_from_file(output[i]);

            }
        }
        static public List<Table_Volume> ReadAllTables()
        {
            var result = new List<Table_Volume> { };

            string[] output = { "COT 1P.bin","COT 2P.bin", "COT 3P.bin", "COT 4P.bin", "COT 5P.bin", "COT 6P.bin", "SLOP P.bin"
                             , "COT 1S.bin","COT 2S.bin", "COT 3S.bin", "COT 4S.bin", "COT 5S.bin", "COT 6S.bin", "SLOP S.bin"
                             ,"BWT 1P.bin","BWT 2P.bin","BWT 3P.bin","BWT 4P.bin","BWT 5P.bin","BWT 6P.bin"
                             ,"BWT 1S.bin","BWT 2S.bin","BWT 3S.bin","BWT 4S.bin","BWT 5S.bin","BWT 6S.bin","FPT.bin","APT.bin"
                             ,"NO.1 HFO.STOR.T. (P).bin","NO.1 HFO.STOR.T. (S).bin","NO.2 HFO.STOR.T. (S).bin","HFO SETT.T. (S).bin","HFO SERV.T. (S).bin"
                             ,"L.S. HFO.SETT.T. (S).bin","L.S. HFO.SERV.T. (S).bin","D.O STOR.T (S).bin","D.O SERV.T (S).bin","NO.2 HFO.STOR.T. (P).bin"
                             ,"MAIN L.O SETT.T. (S).bin","MAIN L.O.STOR.T. (S).bin","NO.1 CYL.OIL.STOR.T. (S).bin","NO.2 CYL.OIL.STOR.T. (P).bin","GE L.O STOR.T. (S).bin"
                             ,"TUR.L.O.STOR.T. (S).bin","MAIN L.O SUMP T. (C).bin","FWT P.bin","FWT S.bin","C.W.T. (С).bin","ST L.O.DRAIN T. (S).bin"
                             ,"SEP. BILGE OIL T. (P).bin","BILGE HOLDING T. (P).bin","F.O. OVERFLOW T. (C).bin","PURIF. SLUDGE T. (S).bin"
                             ,"BW (ER AFT,P).bin","BW (ER FWD,P).bin","BW (ER FWD,S).bin"};

            foreach (var item in output)
            {
                result.Add(new Table_Volume(item.Replace(".bin", ""), Table_Volume.Read_from_file("VolumeTables\\" + item)));
            }


            return result;
        }
}
