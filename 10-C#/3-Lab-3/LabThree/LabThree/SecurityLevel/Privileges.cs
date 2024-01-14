namespace SecurityLevel
{
    [Flags]
    public enum Privileges : byte
    {
        Guest = 8, Developer = 4, Secretary = 2, DBA = 1
    }
}

