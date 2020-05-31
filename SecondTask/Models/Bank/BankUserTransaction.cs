using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecondTask.Models
{

    public class BankUserTransaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0,Int32.MaxValue)]
        public int Amount { get; set; } 

        public DateTime Time { get; set; } = DateTime.Now;

        [ForeignKey("BankUser")]
        [Required]
        public string CreditorId { get; set; }

        [ForeignKey("BankUser")]
        [Required]
        public string DebitorId { get; set; }


        //Not used  credit BankUser and Debitor BankUser get problem cycling  cascade update and delete 
        //public BankUser Creditor { get; set; }
        //public BankUser Debitore { get; set; }

       

    }

   
}
