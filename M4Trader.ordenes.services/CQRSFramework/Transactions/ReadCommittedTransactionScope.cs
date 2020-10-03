using System;
using System.Transactions;

namespace M4Trader.ordenes.services.CQRSFramework.Transactions
{
    public class ReadCommittedTransactionScope : IDisposable
    {
        private TransactionScope transactionScope;

        public ReadCommittedTransactionScope()
        {
            TransactionOptions opciones = new TransactionOptions();
            opciones.IsolationLevel = IsolationLevel.ReadCommitted;
            transactionScope = new TransactionScope(TransactionScopeOption.Required, opciones);
        }

        public ReadCommittedTransactionScope(TransactionScopeOption option)
        {
            TransactionOptions opciones = new TransactionOptions();
            opciones.IsolationLevel = IsolationLevel.ReadCommitted;
            transactionScope = new TransactionScope(option, opciones);
        }

        public void Dispose()
        {
            this.transactionScope.Dispose();
        }

        public void Complete()
        {
            this.transactionScope.Complete();
        }
    }
}
