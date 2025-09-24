using System;

namespace PetCargoProgram.Models.Tanks;

public partial class BallastTank:IEquatable<BallastTank>
{
    public bool Equals(BallastTank? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _name == other._name
               && _maxVolume.Equals(other._maxVolume)
               && _sound.Equals(other._sound)
               && _ullage.Equals(other._ullage)
               && _volume.Equals(other._volume)
               && _volumePercent.Equals(other._volumePercent)
               && _density.Equals(other._density)
               && _weight.Equals(other._weight)
               && _lcg.Equals(other._lcg)
               && _vcg.Equals(other._vcg)
               && _tcg.Equals(other._tcg)
               && _iy.Equals(other._iy)
               && _maxUllage.Equals(other._maxUllage);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((BallastTank)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(_name);
        hashCode.Add(_maxVolume);
        hashCode.Add(_sound);
        hashCode.Add(_ullage);
        hashCode.Add(_volume);
        hashCode.Add(_volumePercent);
        hashCode.Add(_density);
        hashCode.Add(_weight);
        hashCode.Add(_lcg);
        hashCode.Add(_vcg);
        hashCode.Add(_tcg);
        hashCode.Add(_iy);
        hashCode.Add(_maxUllage);
        return hashCode.ToHashCode();
    }
    public static bool operator ==(BallastTank? left, BallastTank? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(BallastTank? left, BallastTank? right)
    {
        return !Equals(left, right);
    }
}
