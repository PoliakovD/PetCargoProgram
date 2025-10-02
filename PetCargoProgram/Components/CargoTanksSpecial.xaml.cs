using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using PetCargoProgram.Models.Tanks;

namespace PetCargoProgram.Components;

public partial class CargoTanksSpecial : UserControl
{
    // CargoTanks
    public static readonly DependencyProperty CargoTanksProperty =
        DependencyProperty.Register(nameof(CargoTanks), typeof(ObservableCollection<CargoTank>), typeof(CargoTanksSpecial));
    public ObservableCollection<CargoTank> CargoTanks
    {
        get => (ObservableCollection<CargoTank>)GetValue(CargoTanksProperty);
        set => SetValue(CargoTanksProperty, value);
    }
    public CargoTanksSpecial()
    {
        InitializeComponent();
    }
}

