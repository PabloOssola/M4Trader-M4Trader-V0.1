using System;
using System.Collections.Generic;

namespace M4Trader.ordenes.services.Exceptions
{
    public class MAECommunicationException : ApplicationException
    {
        private string _codigo;

        public MAECommunicationException()
            : base()
        {
        }

        public MAECommunicationException(string message)
            : base(message)
        {
        }

        public MAECommunicationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public MAECommunicationException(string codigo, string message)
            : base(message)
        {
            this.Codigo = codigo;
        }

        public MAECommunicationException(string codigo, string message, Exception inner)
            : base(message, inner)
        {
            this.Codigo = codigo;
        }

        public MAECommunicationException(string message, List<string> errores, List<string> oks)
            : base(message)
        {
            this.Errores = errores;
            this.Oks = oks;
        }

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public List<string> Errores { get; set; }

        public List<string> Oks { get; set; }
    }
}
