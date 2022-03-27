namespace UsefulArticles.Service
{
    public class Config
    {
        public static string? ConnectionString { get; set; } = "Data Source=localhost\\SQLEXPRESS; Database=UsefulArticles; Persist Security Info=false; User ID='giocatory'; Password='IPSequence*351'; MultipleActiveResultSets=True; Trusted_Connection=False;";
        public static string CompanyName { get; set; } = "Giocatory - Useful Articles";
        public static string CompanyPhone { get; set; } = "+7 (914) 050-34-17";
        public static string CompanyPhoneShort { get; set; } = "+79140503417";
        public static string CompanyEmail { get; set; } = "giocatory@yandex.ru";
    }
}