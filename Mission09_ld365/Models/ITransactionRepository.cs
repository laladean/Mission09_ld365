using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_ld365.Models
{
    public interface ITransactionRepository
    {
        IQueryable<Transaction> Transactions { get; }

        void SaveTransaction(Transaction trans)
        {

        }
    }
}
