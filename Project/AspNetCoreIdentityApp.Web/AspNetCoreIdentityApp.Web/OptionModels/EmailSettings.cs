namespace AspNetCoreIdentityApp.Web.OptionModels
{
    public class EmailSettings
    {
        public string Host { get; set; } = null!; // buradaki null olamaz ifadesi ile ? ifadesi aynı anlama geliyor.
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
