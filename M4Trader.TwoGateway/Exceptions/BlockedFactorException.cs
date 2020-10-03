namespace M4Trader.TwoFAGateway.VU.NetFramework
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class BlockedFactorException : TwoFAGatewayException
    {
        public BlockedFactorException()
        {
        }

        public BlockedFactorException(string message, string resultText)
            : base(message, resultText)
        {
        }
    }
}