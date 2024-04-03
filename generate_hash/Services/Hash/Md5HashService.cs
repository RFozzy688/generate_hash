namespace generate_hash.Services.Hash
{
    public class Md5HashService : IHashService
    {
        public string Digest(int input) => Convert.ToHexString(
            System.Security.Cryptography.MD5.HashData(BitConverter.GetBytes(input)));
    }
}
