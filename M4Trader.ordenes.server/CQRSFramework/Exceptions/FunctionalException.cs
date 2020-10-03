using M4Trader.ordenes.server.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Trader.ordenes.server.CQRSFramework.Exceptions
{
    public class FunctionalException : Exception
    {
        public FunctionalException()
            : base()
        {
            Code = 0;
            DataValidations = new List<KeyArray>();
        }

        public FunctionalException(int code)
            : base()
        {
            Code = code;
            DataValidations = new List<KeyArray>();
        }

        public int Code { get;  set; }

        public List<KeyArray> DataValidations { get; set; }

        public override string Message
        {
            get
            {
                var msg = new StringBuilder();
                foreach (var dataval in DataValidations)
                {
                    if(TraductorLiterales.ExistMessage(dataval.Codigo))
                    {
                        var s1 = TraductorLiterales.GetTranslatedMessage(dataval.Codigo);
                        var s2 = string.Format(s1, dataval.Parametros.ToArray());
                        msg.Append("||" + s2 + Environment.NewLine);
                    }
                }

                if (msg.Length > 0)
                    return msg.ToString();
                else
                    return base.Message;
            }
        }
    }
}
