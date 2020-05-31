using Microsoft.EntityFrameworkCore;

namespace SecondTask.Models.Implemntation
{
    public class BankTransaction
    {
        private readonly ApplicationContext db;
        public BankTransaction(ApplicationContext db)
        {
            this.db = db;
        }

        public TransactionResult Send(BankUser from, BankUser to, int amount)
        {
            if (from == null | to == null)
                return TransactionResult.UserNotExist;
            else if (from.Amount < amount || amount == 0)
                return TransactionResult.NotValidAmount;

            from.Amount -= amount;
            to.Amount += amount;

            this.db.Entry(from).State = EntityState.Modified;
            this.db.Entry(to).State = EntityState.Modified;


            this.db.BankUserTransactions.Add(new BankUserTransaction()
            {
                CreditorId = from.Id,
                DebitorId = to.Id,
                Amount = amount
            });
            // must save all records  or exception
            this.db.SaveChanges();
            return TransactionResult.Done;

        }
    }

    public enum TransactionResult
    {
        UserNotExist, NotValidAmount, Done
    }
}
