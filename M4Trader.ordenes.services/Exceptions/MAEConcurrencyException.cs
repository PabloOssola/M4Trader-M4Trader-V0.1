using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.services.Exceptions
{
    public class MAEConcurrencyException : ApplicationException
    {
        private string _codigo;

        public MAEConcurrencyException()
            : base()
        {
        }

        public MAEConcurrencyException(string message)
            : base(message)
        {
        }

        public MAEConcurrencyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public MAEConcurrencyException(string codigo, string message)
            : base(message)
        {
            this.Codigo = codigo;
        }

        public MAEConcurrencyException(string codigo, string message, Exception inner)
            : base(message, inner)
        {
            this.Codigo = codigo;
        }

        public MAEConcurrencyException(string message, List<string> errores, List<string> oks)
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
