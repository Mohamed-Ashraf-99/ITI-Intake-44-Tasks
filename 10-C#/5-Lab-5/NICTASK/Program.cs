using NICTASK.NICClass;
using NICTASK.NITEnum;

namespace NICTASK;

class Program
{
    static void Main(string[] args)
    {
        var nic = NicCard.GetNic("Intel", "00-1A-2B-3C-4D-5E", NicType.Ethernet);
        
        var anotherNic = NicCard.GetNic("Broadcom", "11-22-33-44-55-66", NicType.TokenRing);

        Console.WriteLine($"NIC Manufacturer: {nic?.Manufacture}, MAC Address: {nic?.MacAddress}, Type: {nic?.Type}");
       
        Console.WriteLine($"Another NIC Manufacturer: {anotherNic?.Manufacture}, MAC Address: {anotherNic?.MacAddress}, Type: {anotherNic?.Type}");
        
        Console.WriteLine($"nic and anotherNic are the same object? {ReferenceEquals(nic, anotherNic)}");
    }
}