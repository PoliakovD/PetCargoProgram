using PetCargoProgram.Models.LoadingCondition;
using PetCargoProgram.Services.LoadingCondition;

namespace PetCargoProgram.ViewModels.MainWindow;

public partial class ViewModelMainWindow
{
    public ServiceLoadingCondition LoadingCondition
        { get; set; }

    void InitLoadingCondition()
    {
        LoadingCondition = new ServiceLoadingCondition();
        LoadingCondition.AddRange(CargoTanks.Values);
        LoadingCondition.AddRange(BallastTanks.Values);
        LoadingCondition.Add( new LightWeight());
    }

}
