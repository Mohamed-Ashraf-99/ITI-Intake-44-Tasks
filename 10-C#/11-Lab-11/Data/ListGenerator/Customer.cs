namespace L2O___D09;

public class Customer
{
    public Customer(string customerId, string companyName)
    {
        CustomerId = customerId;
        CompanyName = companyName;
        Orders = new Order[10];
    }

    public Customer()
    {
    }

    public string CustomerId;
    public string CompanyName;
    public string Address;
    public string City;
    public string Region;
    public string PostalCode;
    public string Country;
    public string Phone;
    public string Fax;
    public Order[] Orders;


    public override string ToString()
    {
        return
            $"{CustomerId}, {CompanyName}, {Address}, {City}, {Region}, {PostalCode}, {Country}, {Phone}, {Fax}";
    }
}