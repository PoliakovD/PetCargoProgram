using System;

namespace PetCargoProgram.Models.ShipCondition;

public partial class ShipConditionClass : IEquatable<ShipConditionClass>
{
    public bool Equals(ShipConditionClass? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return _lightWeight.Equals(other._lightWeight) && _deadWeight.Equals(other._deadWeight) && _displacement.Equals(other._displacement) && _deadWeightRegistred.Equals(other._deadWeightRegistred) && _cargoOnBoard.Equals(other._cargoOnBoard) && _ballastOnBoard.Equals(other._ballastOnBoard) && _fuelOilOnBoard.Equals(other._fuelOilOnBoard) && _dieselOnBoard.Equals(other._dieselOnBoard) && _freshWaterOnBoard.Equals(other._freshWaterOnBoard) && _lubeOilOnBoard.Equals(other._lubeOilOnBoard) && _draftAft.Equals(other._draftAft)  && _draftFwd.Equals(other._draftFwd) && _draftMean.Equals(other._draftMean) && _tcg.Equals(other._tcg) && _lcf.Equals(other._lcf) && _vcg.Equals(other._vcg) && _km.Equals(other._km) && _gom.Equals(other._gom) && _shearingForce.Equals(other._shearingForce) && _bendingMoment.Equals(other._bendingMoment) && _tpc.Equals(other._tpc) && _mctc.Equals(other._mctc) && _lcb.Equals(other._lcb) && _cm.Equals(other._cm) && _draftActual.Equals(other._draftActual) && _dieselOilOnBoard.Equals(other._dieselOilOnBoard) && _otherStoresOnBoard.Equals(other._otherStoresOnBoard) && _draftFore.Equals(other._draftFore) && _trim.Equals(other._trim) && _list.Equals(other._list);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((ShipConditionClass)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(_lightWeight);
        hashCode.Add(_deadWeight);
        hashCode.Add(_displacement);
        hashCode.Add(_deadWeightRegistred);
        hashCode.Add(_cargoOnBoard);
        hashCode.Add(_ballastOnBoard);
        hashCode.Add(_fuelOilOnBoard);
        hashCode.Add(_dieselOnBoard);
        hashCode.Add(_freshWaterOnBoard);
        hashCode.Add(_lubeOilOnBoard);
        hashCode.Add(_draftAft);
        hashCode.Add(_draftFwd);
        hashCode.Add(_draftMean);
        hashCode.Add(_tcg);
        hashCode.Add(_lcf);
        hashCode.Add(_vcg);
        hashCode.Add(_km);
        hashCode.Add(_gom);
        hashCode.Add(_shearingForce);
        hashCode.Add(_bendingMoment);
        hashCode.Add(_tpc);
        hashCode.Add(_mctc);
        hashCode.Add(_lcb);
        hashCode.Add(_cm);
        hashCode.Add(_draftActual);
        hashCode.Add(_dieselOilOnBoard);
        hashCode.Add(_otherStoresOnBoard);
        hashCode.Add(_draftFore);
        hashCode.Add(_trim);
        hashCode.Add(_list);
        return hashCode.ToHashCode();
    }
}
