using M4Trader.ordenes.server.ApplicationServices;
using M4Trader.ordenes.server.Helpers;
using M4Trader.ordenes.services.Entities;
using Sodium;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Mae.Ordenes.Framework
{
    public  class SodiumEncryptor : IEncryptable
    {
        
        public SodiumEncryptor()
        {
        }

        public  string Encriptar(string plainText)
        {
            return plainText;    
        }


        public  string Desencriptar(string encrypted)
        {
            if (string.IsNullOrEmpty(encrypted) || encrypted.Length % 4 != 0
                || encrypted.Contains(" ") || encrypted.Contains("\t") || encrypted.Contains("\r") || encrypted.Contains("\n"))
                return encrypted;
            try
            {
                Guid guidId = OrdenesApplication.Instance.GetSecurityTokenIdFromHeader();
                SessionHelper.GetSesionExistente(guidId);
                var user = MAEUserSession.Instancia;
                var bytes = Convert.FromBase64String(encrypted);

                var eBytes = PublicKeyBox.Open(bytes, Convert.FromBase64String(user.Nonce), Convert.FromBase64String(user.ClientSecret), Convert.FromBase64String(user.ServerPublic));
                var txt = Encoding.UTF8.GetString(eBytes);

                return txt;
            }
            catch (Exception)
            {
                return encrypted;
            }
        }
         

        public string DynamicEncryption(string plainText)
        {
            return plainText;
        }
    }
}