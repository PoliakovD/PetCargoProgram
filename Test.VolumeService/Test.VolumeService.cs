using System;
using System.IO;
using System.Text;
using PetCargoProgram.Services.CargoTables;



var tableService = CargoTablesProvider.Volume;

string name = "COT 1P";
double volume = 2000.0;



var lcg = tableService.GetLCG(name, volume);
var tcg = tableService.GetTCG(name, volume);
var vcg = tableService.GetVCG(name, volume);
var iy = tableService.GetIY(name, volume);

Console.WriteLine("LCG: " + lcg);
Console.WriteLine("TCG: " + tcg);
Console.WriteLine("VCG: " + vcg);
Console.WriteLine("IY: " + iy);
Console.WriteLine("Volume: " + volume);
Console.WriteLine("Searched to FullValue: "+tableService.GetValue(name, volume));

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
File.WriteAllText("Cargoes.txt", sb.ToString());
Console.ReadKey();
