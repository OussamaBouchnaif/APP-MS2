namespace Admin.Flags
{
    [Flags]
    public enum Nationalites
    {
        Soudan = 1,
        SudSoudan = 2,
        Guinee = 4,
        Cameroun = 8,
        CoteDIvoire = 16,
        Mali = 32,
        Nigeria = 64,
        Senegal = 128,
        RDC = 256,
        Autres = 512
    }
}