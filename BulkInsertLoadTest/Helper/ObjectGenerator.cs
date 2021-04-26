using System;
using System.Collections.Generic;
using System.Text;

namespace BulkInsertLoadTest.Helper
{
    public static class ObjectGenerator
    {

        public static List<Temporary_LoadTestForTransactionBulkInsert> GenerateTempTransaction(int count)
        {
            var result = new List<Temporary_LoadTestForTransactionBulkInsert>();
            for (int i = 0; i < count; i++)
            {
                result.Add(new Temporary_LoadTestForTransactionBulkInsert
                {
                    Amount = RandomGenerator.RandomNumber(10, 1000),
                    BonusId = RandomGenerator.RandomString(5),
                    CurrencyId = RandomGenerator.RandomString(3),
                    DeviceType = RandomGenerator.RandomNumber(1, 2),
                    GameId = RandomGenerator.RandomNumber(1000, 4000),
                    OperationType = (short)RandomGenerator.RandomNumber(1, 4),
                    PlayerId = RandomGenerator.RandomNumber(4000, 16000),
                    ProviderTransactionId = RandomGenerator.RandomString(6),
                    Rake = RandomGenerator.RandomNumber(100, 1000),
                    RoundId = RandomGenerator.RandomString(7),
                    SessionId = RandomGenerator.RandomNumber(10000, 30000),
                    WinType = (short)RandomGenerator.RandomNumber(1, 4),
                    CreationTime = DateTime.Now,
                    OriginalTxId = RandomGenerator.RandomString(6)
                }) ;
            }


            return result;
        }
         
    }
}
