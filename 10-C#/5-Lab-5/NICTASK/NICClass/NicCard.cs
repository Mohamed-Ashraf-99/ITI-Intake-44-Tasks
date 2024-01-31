using NICTASK.NITEnum;

namespace NICTASK.NICClass;

public class NicCard
{
    public string Manufacture { get; private set; }
    public string MacAddress { get; private set; }
    public NicType Type { get; private set; }
    
    private static NicCard? _singleObject;
    private NicCard(string manufacture, string macAddress, NicType type)
    {
        Manufacture = manufacture;
        MacAddress = macAddress;
        Type = type;
    }
    public static NicCard? GetNic(string manufacture, string macAddress, NicType type)
    {
        if (_singleObject == null)
            _singleObject = new NicCard(manufacture, macAddress, type);
        return _singleObject;
    }
}