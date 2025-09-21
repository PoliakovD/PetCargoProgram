
using System;
using System.Collections.Generic;
using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Services.CargoTables;

AllCargoTables _cargoTables = new AllCargoTables();
BinaryCTService.Load(ref _cargoTables);


// test values
string Name = "COT 1P";
double trim = 3.2;
double ullage = 5.5;

var tableService = new ServiceCargoTankUllageTrim(_cargoTables.TablesCargoTankUllage);

double Volume = tableService.GetVolumeWithTrim(Name, ullage, trim);
Console.WriteLine("Volume: " + Volume+ "// 6334.68 - OK"); // 6334.68 - OK

// test values 2
Name = "COT 1P";
trim = 3.0;
ullage = 5.5;

Volume = tableService.GetVolumeWithTrim(Name, ullage, trim);
Console.WriteLine("Volume: " + Volume+ "// 6333.5 - OK"); // 6333.5 - OK

// test values 3
Name = "COT 1P";
trim = 4.0;
ullage = 5.5;

Volume = tableService.GetVolumeWithTrim(Name, ullage, trim);
Console.WriteLine("Volume: " + Volume+ "// 6339.4 - OK"); // 6339.4 - OK

// test values 4
Name = "COT 1P";
trim = 0.0;
ullage = 5.5;

Volume = tableService.GetVolumeWithTrim(Name, ullage, trim);
Console.WriteLine("Volume: " + Volume+ "");

// test values 5 Экстраполяция вверх
Name = "COT 1P";
trim = 4.5;
ullage = 5.5;

Volume = tableService.GetVolumeWithTrim(Name, ullage, trim);
Console.WriteLine("Экстраполяция вверх Volume: " + Volume+ "//6342.35 - ОК");//6342.35 - ОК

// test values 6 Экстраполяция вниз
Name = "COT 1P";
trim = -1.5;
ullage = 5.5;

Volume = tableService.GetVolumeWithTrim(Name, ullage, trim);
Console.WriteLine("Экстраполяция вниз Volume: " + Volume+ "//6306.15 - ОК");//6306.15 - ОК

try
{
// test values  поимка исключений
    Name = "COT 1S";
    ullage = 20.33;
    trim = 7.5;
    Volume = tableService.GetVolumeWithTrim(Name, ullage, trim);
    Console.WriteLine("Максималная пустота Volume: " + Volume+ "");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
try
{
// test values  поимка исключений
    trim = -3.5;
    Volume = tableService.GetVolumeWithTrim(Name, ullage, trim);

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


Console.ReadKey();
