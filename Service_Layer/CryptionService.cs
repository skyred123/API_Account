using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Service_Layer
{
	public class CryptionService
	{
		private readonly IConfiguration _configuration;
		private readonly byte[] key;
		private readonly byte[] iv;
		public CryptionService(IConfiguration configuration)
		{
			_configuration = configuration;
			key = Encoding.UTF8.GetBytes(configuration["Cryption:Key"]);
			iv = Encoding.UTF8.GetBytes(configuration["Cryption:IV"]);
		}

		public string Encrypt(string plaintext)
		{
			using(Aes aes = Aes.Create())
			{
				aes.Key = key;
				aes.IV = iv;
				aes.Mode = CipherMode.CBC;
				aes.Padding = PaddingMode.PKCS7;

				ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

				using (MemoryStream msEncrypt = new MemoryStream())
				using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
				{
					using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
					{
						swEncrypt.Write(plaintext);
					}
					return Convert.ToBase64String(msEncrypt.ToArray());
				}
			}
		}

		public string Decrypt(string ciphertext)
		{
			using (Aes aes = Aes.Create())
			{
				aes.Key = key;
				aes.IV = iv;
				aes.Mode = CipherMode.CBC;
				aes.Padding = PaddingMode.PKCS7;

				ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

				using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(ciphertext)))
				using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
				using (StreamReader srDecrypt = new StreamReader(csDecrypt))
				{
					return srDecrypt.ReadToEnd();
				}
			}
		}
	}
}
