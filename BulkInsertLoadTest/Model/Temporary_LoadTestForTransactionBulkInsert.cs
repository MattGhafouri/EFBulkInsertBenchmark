using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkInsertLoadTest
{
    public class Temporary_LoadTestForTransactionBulkInsert
    { 
        public long Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public string RoundId { get; set; }
        public string ProviderTransactionId { get; set; }
        public short OperationType { get; set; }        
        public decimal Amount { get; set; }
        public string CurrencyId { get; set; }
        public long SessionId { get; set; } 
        public int DeviceType { get; set; }
        public DateTime CreationTime { get; set; }
        public string OriginalTxId { get; set; }
        public string BonusId { get; set; }
        public short WinType { get; set; }
        public decimal Rake { get; set; }
    }
}
