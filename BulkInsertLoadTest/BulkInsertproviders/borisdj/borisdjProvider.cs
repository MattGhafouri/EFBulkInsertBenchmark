using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BulkInsertLoadTest.BulkInsertproviders.borisdj
{
    public static class borisdjProvider
    {
        public static TimeSpan Insert(List<Temporary_LoadTestForTransactionBulkInsert> trx)
        {
            var timer = new Stopwatch();
            using var context = new YourContext();
             
            var config = new BulkConfig()
            {
                BatchSize = 2000,
                TrackingEntities = false,
                SetOutputIdentity = true,
            };

            timer.Start();
            context.BulkInsertAsync(trx, config).Wait();
            timer.Stop();

            return timer.Elapsed;           

        }
    }
}
