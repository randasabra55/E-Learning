namespace E_Learning_Data.Helper
{
    public class JwtSettings
    {
        public string secret { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }
        public bool validateAudience { get; set; }
        public bool validateIssuer { get; set; }
        public bool validateLifetime { get; set; }
        public bool validateIssuerSigningKey { get; set; }
        public int AccessTokenExpireDate { get; set; }
        public int RefreshTokenExpireDate { get; set; }

    }
}
