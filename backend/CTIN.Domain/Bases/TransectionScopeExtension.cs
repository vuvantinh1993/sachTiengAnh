using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace CTIN.Domain.Bases
{
    public static class TransectionScopeExtension
    {
        public static TransactionScope Create()
        {
            return new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                TransactionScopeAsyncFlowOption.Enabled
                );
        }
    }
}
