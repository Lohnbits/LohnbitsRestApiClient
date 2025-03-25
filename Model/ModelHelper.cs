using System.Security.Cryptography;
using System.Text;

namespace LohnbitsRestApiClient.Model;

public class ModelHelper
{
    public static string DecryptStringAES(string encryptedText, byte[] keyBytes)
    {
        byte[] combinedBytes = Convert.FromBase64String(encryptedText);

        byte[] iv = new byte[16];
        byte[] encryptedBytes = new byte[combinedBytes.Length - iv.Length];

        Buffer.BlockCopy(combinedBytes, 0, iv, 0, iv.Length);
        Buffer.BlockCopy(combinedBytes, iv.Length, encryptedBytes, 0, encryptedBytes.Length);

        using (var aes = Aes.Create())
        {
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Set the key and IV for decryption
            aes.Key = keyBytes;
            aes.IV = iv;

            // Create a decryptor to perform the stream transform
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            // Create a MemoryStream to hold the decrypted data
            using (var ms = new MemoryStream())
            {
                // Create a CryptoStream through which we can write the decrypted data
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                {
                    // Write the encrypted data to the CryptoStream
                    cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                    cs.FlushFinalBlock();
                }

                // Get the decrypted bytes from the MemoryStream
                byte[] decryptedBytes = ms.ToArray();

                // Convert the decrypted bytes to a string
                string decryptedString = Encoding.UTF8.GetString(decryptedBytes);

                return decryptedString;
            }
        }
    }
}
