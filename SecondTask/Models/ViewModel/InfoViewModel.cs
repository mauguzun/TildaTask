using System.Linq;

namespace SecondTask.Models.ViewModel
{
    public class InfoViewModel
    {
        public IQueryable<DisplayTransaction> Creditor { get; set; }
        public IQueryable<DisplayTransaction> Debitor { get; set; }
        public long Total { get; set; }
        public long Debit { get; set; }
        public long Credit { get; set; }

    }
}
