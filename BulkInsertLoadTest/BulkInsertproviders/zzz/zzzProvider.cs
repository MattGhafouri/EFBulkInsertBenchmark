using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Z.BulkOperations;

namespace BulkInsertLoadTest.BulkInsertproviders.zzz
{
    public static class zzzProvider
    {
        public static TimeSpan Insert(List<Temporary_LoadTestForTransactionBulkInsert> trx)
        {
            var timer = new Stopwatch();
            using var context = new RGSContext();



            var bulk = new BulkOperation<Temporary_LoadTestForTransactionBulkInsert>(context.Database.GetDbConnection());

            if (bulk.Connection.State != System.Data.ConnectionState.Open)
                bulk.Connection.Open();
 
            timer.Start();
            bulk.ColumnInputExpression = c => new
            {
                c.Amount,
                c.BonusId,
                c.CreationTime,
                c.CurrencyId,
                c.DeviceType,
                c.GameId,
                c.OperationType,
                c.OriginalTxId,
                c.Rake,
                c.RoundId,
                c.WinType,
                c.SessionId,
                c.ProviderTransactionId,
                c.PlayerId
            };
           
            bulk.ColumnOutputExpression = c => c.Id; 

            bulk.BulkMerge(trx); 

            timer.Stop();

            return timer.Elapsed;

        }
    }
}
