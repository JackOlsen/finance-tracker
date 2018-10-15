using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MintImporter.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Index(IsUnique = true )]
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public virtual ICollection<AccountSnapshot> AccountSnapshots { get; set; }
    }
}
