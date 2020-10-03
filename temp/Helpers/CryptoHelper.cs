using M4Trader.ordenes.services.Entities;
using Sodium;
using System;
using System.Text;

namespace M4Trader.ordenes.server.Helpers 
{
    public class CryptoHelper
    {

        #region Singleton

        private static CryptoHelper _instance;
        public static CryptoHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CryptoHelper();
                }
                return _instance;
            }
        }
        #endregion

        public string Encrypt(string text, MAEUserSession user)
        {
            var encrypted = string.Empty;

            var bytes = Encoding.UTF8.GetBytes(text);
            var eBytes = PublicKeyBox.Create(bytes, Convert.FromBase64String(user.Nonce), Convert.FromBase64String(user.ClientSecret), Convert.FromBase64String(user.ServerPublic));
            encrypted = Convert.ToBase64String(eBytes);

            return encrypted;
        }

        public string Decrypt(string datos, MAEUserSession user)
        {
            // Revisa si el parametro esta encriptado (si la cadena es base64)
            try
            {
                var isEncrypted = Convert.FromBase64String(datos);
            }
            catch (Exception)
            {
                return datos;
            }

            var bytes = Convert.FromBase64String(datos);
            var eBytes = PublicKeyBox.Open(bytes, Convert.FromBase64String(user.Nonce), Convert.FromBase64String(user.ServerPublic), Convert.FromBase64String(user.ClientSecret));
            var txt = Encoding.UTF8.GetString(eBytes);

            return txt;
        }


    }
}