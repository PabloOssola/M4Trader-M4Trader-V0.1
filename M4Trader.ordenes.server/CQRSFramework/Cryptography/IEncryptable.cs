namespace Mae.Ordenes.Framework
{
    public interface IEncryptable
    {
        string Desencriptar(string encrypted);
        string Encriptar(string plainText);
        string DynamicEncryption(string textToHash);
    }
}