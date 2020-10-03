using Mae.Ordenes.Framework;

namespace M4Trader.ordenes.server.CQRSFramework.Cryptography
{
    public class NonEncryptor : IEncryptable
    {
        public string Desencriptar(string encrypted)
        {
            return encrypted;
        }

        public string Desencriptar(string encrypted, bool isCryptoBox = false)
        {
            return encrypted;
        }

        public string DesencriptarQuery(string encrypted, string key)
        {
            return encrypted;
        }

        public string DynamicEncryption(string plainText)
        {
            return plainText;
        }

        public string Encriptar(string plainText)
        {
            return plainText;
        }

        public string Encriptar(string plainText, bool isCryptoBox = false)
        {
            return plainText;
        }

        public string EncriptarQuery(string plainText)
        {
            return plainText;
        }

        public string GetUniqueKey()
        {
            return string.Empty;
        }
    }

}
