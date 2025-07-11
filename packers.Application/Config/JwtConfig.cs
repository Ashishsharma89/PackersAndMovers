namespace Packer.Application.Config
{
    public class JwtConfig
    {
        public string Secret { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int DurationInMinutes { get; set; }
        public int ExpirationInMinutes { get; set; } = 60;
    }
} 