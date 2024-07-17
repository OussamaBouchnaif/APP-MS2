namespace Admin.Flags
{
    [Flags]
    public enum SourceInformation
    {
        OMDH = 1,
        PCDC = 2,
        EGLISE = 4,
        AutresONGs = 8,
        Communautes = 16,
        Autres = 32
    }
}