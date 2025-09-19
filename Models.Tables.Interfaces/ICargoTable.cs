namespace Model.CargoTables;

public interface ICargoTable
{
    public string Name { get; }
    public List<ICargoTableValue> Table { get; }
}
