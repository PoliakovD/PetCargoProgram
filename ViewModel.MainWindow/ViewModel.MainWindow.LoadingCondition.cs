﻿using PetCargoProgram.Models.LoadingCondition;
using PetCargoProgram.Services.LoadingCondition;

namespace PetCargoProgram.ViewModels.MainWindow;

public partial class ViewModelMainWindow
{
    public ServiceLoadingCondition? LoadingCondition { get; set; }


    void InitLoadingCondition()
    {
        LoadingCondition = new ServiceLoadingCondition();
        LoadingCondition.AddCargoTanks(CargoTanks.Values);
        LoadingCondition.AddRange(BallastTanks.Values);
        LoadingCondition.AddRange(OtherTanks.Values);
        LoadingCondition.Add( new LightWeight());
    }
}
