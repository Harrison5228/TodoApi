using System.Security.Cryptography;
using System.Text;

namespace TodoApi.Helpers;

public static class EncryptHelper
{
    private const string Key = "0123456789ABCDEF";
    private const string Iv = "ABCDEF0123456789";
    
    public static string Encrypt(string origin)
    {
        if (string.IsNullOrEmpty(origin))
            throw new ArgumentNullException(nameof(origin));
        if (string.IsNullOrEmpty(Key))
            throw new ArgumentNullException(nameof(Key));

        using var aesAlg = Aes.Create();
        
        aesAlg.Key = Encoding.UTF8.GetBytes(Key);
        aesAlg.IV = Encoding.UTF8.GetBytes(Iv);

        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using var msEncrypt = new MemoryStream();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        using (var swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(origin);
        }

        return Convert.ToBase64String(msEncrypt.ToArray());
    }
}