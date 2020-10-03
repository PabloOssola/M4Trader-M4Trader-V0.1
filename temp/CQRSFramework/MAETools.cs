using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace M4Trader.ordenes.server.CQRSFramework
{

    public class MAETools
    {
        public static bool IsSymbol(char chr)
        {
            string regex = "^([A-Za-z0-9]+)$";
            RegexOptions options = RegexOptions.None;
            Regex reg = new Regex(regex, options);

            Match match = reg.Match(chr.ToString());

            return (match.Length == 0);
        }

        private const string PASSWORD_DE_CIFRADO = "P2MarT33VtLsIxWz";

        #region Cifrado/Descifrado
        public static string Descifrar(string Textocifrado)
        {
            return Desencriptar(Textocifrado, PASSWORD_DE_CIFRADO);
        }

        public static string Cifrar(string TextACifrar)
        {
            return Encriptar(TextACifrar, PASSWORD_DE_CIFRADO);
        }

        private static byte[] CreateKeyFromPassword(string password, bool UTF8oDefault)
        {
            MD5CryptoServiceProvider hasher = new MD5CryptoServiceProvider();
            byte[] pwdBytes = null;

            if (UTF8oDefault)
                pwdBytes = Encoding.UTF8.GetBytes(password);
            else
                pwdBytes = Encoding.Default.GetBytes(password);
            return hasher.ComputeHash(pwdBytes);
        }

        private static string Desencriptar(string Texto, string Pass)
        {
            Byte[] textoADesencriptarEnBytes = Convert.FromBase64String(Texto);
            MemoryStream memStream = new System.IO.MemoryStream();
            string result = null;
            try
            {
                SymmetricAlgorithm crypto = SymmetricAlgorithm.Create("Rijndael");
                try
                {
                    //Generate a key from password and assign it to algorithem.
                    crypto.Key = CreateKeyFromPassword(Pass, false);
                    crypto.BlockSize = 128; // This is 128 in this particular case
                    crypto.Mode = CipherMode.ECB;
                    crypto.Padding = PaddingMode.Zeros;

                    CryptoStream decryptionStream = new CryptoStream(memStream, crypto.CreateDecryptor(),
                        CryptoStreamMode.Write);
                    decryptionStream.Write(textoADesencriptarEnBytes, 0, textoADesencriptarEnBytes.Length);
                    decryptionStream.FlushFinalBlock();
                    decryptionStream.Close();

                    result = Encoding.Default.GetString(memStream.ToArray());

                    if (result.IndexOf('\0') >= 0)
                        result = result.Substring(0, result.IndexOf('\0'));

                    return result;

                }
                finally
                {
                    crypto.Clear();
                }
            }
            finally
            {
                if (memStream != null)
                    memStream.Close();
            }
        }

        private static string Encriptar(string Texto, string Pass)
        {
            Byte[] TextoAEncriptarEnBytes = Encoding.Default.GetBytes(Texto);

            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            //RijndaelCipher.KeySize = 128;
            RijndaelCipher.BlockSize = 128;
            RijndaelCipher.Mode = CipherMode.ECB;
            RijndaelCipher.Padding = PaddingMode.Zeros;
            RijndaelCipher.Key = CreateKeyFromPassword(Pass, false);

            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor();
            MemoryStream memoryStream = new MemoryStream();

            // Create a CryptoStream.
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);

            // Start the encryption process.
            cryptoStream.Write(TextoAEncriptarEnBytes, 0, TextoAEncriptarEnBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memoryStream into a byte array.
            byte[] CipherBytes = memoryStream.ToArray();
            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert encrypted data into a base64-encoded string.
            string EncryptedData = System.Convert.ToBase64String(CipherBytes);

            return EncryptedData;
        }

        #endregion

        #region HashMD5
        public static string HashMD5(string toHash)
        {

            byte[] toHashInBytes =
                Encoding.UTF8.GetBytes((toHash));

            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] HashResult = md5.ComputeHash(toHashInBytes);

            int hashLength = HashResult.Length;

            // We need to convert the MD5 byte array to an 
            // hexadecimal (32 chars fixed) string expression
            string strMD5Result = ByteArrayToString(HashResult);
            //string strMD5Result = System.Convert.ToBase64String(HashResult);

            return strMD5Result;

        }

        static string ByteArrayToString(byte[] value)
        {
            StringBuilder inValue = new StringBuilder(value.Length * 2);

            for (int lc = 0; lc < value.Length; lc++)
            {
                inValue.AppendFormat(string.Format("{0:X2}", value[lc]));
            }
            return inValue.ToString();
        }

        #endregion


    }
}
