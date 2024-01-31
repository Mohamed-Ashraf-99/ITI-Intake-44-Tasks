namespace L2O___D09;

public class Product
{
    public Int64 ProductId { get; set; }
    public String ProductName { get; set; }
    public String Category { get; set; }
    public Decimal UnitPrice { get; set; }
    public Int32 UnitsInStock { get; set; }

    public override string ToString()
    {
        return $"ProductID: {ProductId}, ProductName: {ProductName}, Category: {Category}, UnitPrice: ${UnitPrice}, UnitsInStock: {UnitsInStock}";
    }
}