namespace generate_hash.Models.Home
{
    public class HomeIocPageModel
    {
        public String HashVerificationCode { get; set; } = null!;
        public String HashFileName { get; set; } = null!;
        public String KdfCryptoSalt { get; set; } = null!;
    }
}
