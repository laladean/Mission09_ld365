using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_ld365.Models
{
    public class EFTransactionRepository : ITransactionRepository
    {
        public BookstoreContext context;

        public EFTransactionRepository(BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Transaction> Transactions => context.Transactions.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveTransaction(Transaction tran)
        {
            context.AttachRange(tran.Lines.Select(x => x.Book));

            if (tran.TransactionId == 0)
            {
                context.Transactions.Add(tran);
            }

            context.SaveChanges();

        }
            
     }

}
