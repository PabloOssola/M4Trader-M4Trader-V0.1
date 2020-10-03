namespace M4Trader.TwoFAGateway.VU.NetFramework
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class TwoFAGatewayException : Exception
    {
        public TwoFAGatewayException()
        {
        }

        public TwoFAGatewayException(string message, string resultText)
            : base($"{message}: {resultText}")
        {
        }
    }
}