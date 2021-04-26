using BulkInsertLoadTest.BulkInsertproviders.borisdj;
using BulkInsertLoadTest.BulkInsertproviders.EFCore;
using BulkInsertLoadTest.BulkInsertproviders.zzz;
using BulkInsertLoadTest.Helper;
using System;
using System.Collections.Generic;

namespace BulkInsertLoadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var trx = new List<Temporary_LoadTestForTransactionBulkInsert>();
            var objectCount = ReadCount();

            while (objectCount > 0)
            {
                //Trial-1Month
                trx = ObjectGenerator.GenerateTempTransaction(objectCount);
                var zzzProviderResult = zzzProvider.Insert(trx);
                PrintResult("zzz -Trial(1 Month)", objectCount, zzzProviderResult);


                trx = ObjectGenerator.GenerateTempTransaction(objectCount);
                var borisDjProviderResult = borisdjProvider.Insert(trx);
                PrintResult("borisdj", objectCount, borisDjProviderResult);

                trx = ObjectGenerator.GenerateTempTransaction(objectCount);
                var addRangeResult = EFCoreAddRange.Insert(trx);
                PrintResult("EF Add Range", objectCount, addRangeResult);

                objectCount = ReadCount();
            }
        }

        private static void PrintResult(string provider, int objectCount, TimeSpan borisDjProviderResult)
        {
            Console.WriteLine();

            Console.WriteLine($"-----------------------{ provider }-------------------------");

            Console.WriteLine($" Object Count : {objectCount} ---- " +
                $" Time taken: " + borisDjProviderResult.ToString(@"\:ss\.fff"));
            Console.WriteLine("------------------------------------------------");

            Console.WriteLine(); 
        }

        private static int ReadCount()
        {
            Console.WriteLine("=====================================================================");
            Console.Write("Enter Object count : ");
            return int.Parse(Console.ReadLine());
        }
    }
}
