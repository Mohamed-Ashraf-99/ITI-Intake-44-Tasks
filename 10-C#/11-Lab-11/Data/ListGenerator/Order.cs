namespace L2O___D09;

public class Order
{
    public Order(int orderId, DateTime orderDate, decimal total)
    {
        OrderId = orderId;
        OrderDate = orderDate;
        Total = total;
    }

    public Order()
    {
    }

    public int OrderId;
    public DateTime OrderDate;
    public decimal Total;

    public override string ToString()
    {
        return $"Order Id: {OrderId},Date: {OrderDate.ToShortTimeString()},Total: {Total}";
    }
}