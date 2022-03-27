namespace UsefulArticles.Service
{
    public class Config
    {
        public static string? ConnectionString { get; set; } = "Data Source=(local)\\SQLSERVER; Database=UsefulArticles; Persist Security Info=false; User ID='giocatory'; Password='IPSequence*351'; MultipleActiveResultSets=True; Trusted_Connection=False;";
        public static string CompanyName { get; set; } = "Giocatory - Useful Articles";
        public static string CompanyPhone { get; set; } = "";
        public static string CompanyPhoneShort { get; set; } = "";
        public static string CompanyEmail { get; set; } = "";
    }
}