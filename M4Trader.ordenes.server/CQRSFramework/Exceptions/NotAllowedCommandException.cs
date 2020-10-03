using M4Trader.ordenes.server.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Trader.ordenes.server.CQRSFramework.Exceptions
{
    public class NotAllowedCommandException : Exception
    {
        public NotAllowedCommandException()
            : base()
        {
            Code = "";
            DataValidations = new List<KeyArray>();
        }

        public NotAllowedCommandException(string code)
            : base()
        {
            Code = code;
            DataValidations = new List<KeyArray>();
        }

        public NotAllowedCommandException(string code, string description) : base(code)
        {
            this.Code = code;
            this.description = description;
        }
        public const string ERR_EXPIRO_SESION = "E100015";

        public string ErrorCode
        {
            get
            {
                return ERR_EXPIRO_SESION;
            }
        }

        public string Code { get;  set; }

        public static string LoginFailed = "Session_LoginFailed";

        public static string SessionExpired = "Session_SessionExpired";

        public static string InvalidSecurityCode = "Session_InvalidSecurityCode";
        private string description;

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
