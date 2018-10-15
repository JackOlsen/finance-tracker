using System;
using System.ComponentModel.DataAnnotations;

namespace MintImporter.Models
{
    public class AccountSnapshot
    {
        [Key]
        public int AccountSnapshotId { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Balance { get; set; }
    }
}
