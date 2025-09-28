using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Services.CargoTables;



var tableService = CargoTablesProvider.Volume;

string Name = "COT 1P";
double Volume = 2000.0;


var LCG = tableService.GetLCG(Name, Volume);
var TCG = tableService.GetTCG(Name, Volume);
var VCG = tableService.GetVCG(Name, Volume);
var IY = tableService.GetIY(Name, Volume);

Console.WriteLine("LCG: " + LCG);
Console.WriteLine("TCG: " + TCG);
Console.WriteLine("VCG: " + VCG);
Console.WriteLine("IY: " + IY);
Console.WriteLine("Volume: " + Volume);
Console.WriteLine("Searched to FullValue: "+tableService.GetValue(Name, Volume));

var sb = new StringBuilder();
sb.Append("{");
foreach (var item in CargoTablesProvider.Volume.Tables)
{
    sb.Append("\"");
    sb.Append(item.Name);
    sb.Append("\"");
    sb.Append(",");
}
sb.Append("}");
File.WriteAllText("Cargossssss.txt", sb.ToString());
Console.ReadKey();
