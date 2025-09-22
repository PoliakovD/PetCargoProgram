using System;
using PetCargoProgram.Models.LoadingCondition;

namespace PetCargoProgram.Models.Tanks;

public partial class CargoTank : ILoadingConditionItem, IEquatable<CargoTank>
{
    public bool Equals(CargoTank? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name
               && MaxVolume.Equals(other.MaxVolume)
               && Level.Equals(other.Level)
               && Ullage.Equals(other.Ullage)
               && Volume.Equals(other.Volume)
               && VolumePercent.Equals(other.VolumePercent)
               && Density.Equals(other.Density)
               && Weight.Equals(other.Weight)
               && LCG.Equals(other.LCG)
               && VCG.Equals(other.VCG)
               && TCG.Equals(other.TCG)
               && TempCelsius.Equals(other.TempCelsius)
               && TempFaringates.Equals(other.TempFaringates)
               && API.Equals(other.API)
               && VolumeCorrectionFactorBBLS.Equals(other.VolumeCorrectionFactorBBLS)
               && VolumeCorrectionFactor.Equals(other.VolumeCorrectionFactor)
               && ObservedVolume.Equals(other.ObservedVolume)
               && GrossVolume.Equals(other.GrossVolume);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((CargoTank)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Name);
        hashCode.Add(MaxVolume);
        hashCode.Add(Level);
        hashCode.Add(Ullage);
        hashCode.Add(Volume);
        hashCode.Add(VolumePercent);
        hashCode.Add(Density);
        hashCode.Add(Weight);
        hashCode.Add(LCG);
        hashCode.Add(VCG);
        hashCode.Add(TCG);
        hashCode.Add(TempCelsius);
        hashCode.Add(TempFaringates);
        hashCode.Add(API);
        hashCode.Add(VolumeCorrectionFactorBBLS);
        hashCode.Add(VolumeCorrectionFactor);
        hashCode.Add(ObservedVolume);
        hashCode.Add(GrossVolume);
        return hashCode.ToHashCode();
    }
    public static bool operator ==(CargoTank? left, CargoTank? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(CargoTank? left, CargoTank? right)
    {
        return !Equals(left, right);
    }
}
