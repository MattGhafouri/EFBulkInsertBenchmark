using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkInsertLoadTest.BulkInsertproviders.EFCore
{ 
    public static class EFCoreAddRange
    {
        public static TimeSpan Insert(List<Temporary_LoadTestForTransactionBulkInsert> trx)
        {
            var timer = new Stopwatch();
            using var context = new YourContext();

            timer.Start();
            context.ChangeTracker.AutoDetectChangesEnabled = false;
            context.Temporary_LoadTestForTransactionBulkInsert.AddRangeAsync(trx);
            context.SaveChangesAsync().Wait();
            context.ChangeTracker.AutoDetectChangesEnabled = true;
            timer.Stop();
            return timer.Elapsed;

        }
    }
}
