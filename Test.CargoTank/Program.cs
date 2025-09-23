using System;
using System.Collections.Generic;
using PetCargoProgram.DataAccess;
using PetCargoProgram.Models.CargoTables;
using PetCargoProgram.Models.Tanks;
using PetCargoProgram.Services.CargoTables;

AllCargoTables _cargoTables = new AllCargoTables();
BinaryCTService.Load(ref _cargoTables);

CargoTank.InitCargoTables(_cargoTables);

string Name = "COT 1P";
CargoTank COT1P = new CargoTank(Name);
COT1P.Density = 0.9887;
COT1P.VolumePercent = 98.0;

Console.WriteLine(COT1P);

Console.ReadKey();
