using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTRA.Domain.Entity
{
    public class Statements
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public double Expense { get; set; }
        public byte[] ExpenceType { get; set; }
        public string TransactionType1 { get; set; }
        public string TransactionType2 { get; set; }
        public string Name { get; set; }
        public string BankType { get; set; }
        public int CategoryID { get; set; }
    }
}
