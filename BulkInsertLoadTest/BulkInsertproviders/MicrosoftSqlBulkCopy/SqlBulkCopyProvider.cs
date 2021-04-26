//using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BulkInsertLoadTest.BulkInsertproviders.MicrosoftSqlBulkCopy
{
    public class SqlBulkCopyProvider
    {
        private string _connectionString = @"yourConnectionString";
        public async Task<TimeSpan> Insert(IEnumerable<Temporary_LoadTestForTransactionBulkInsert> items)  
        {
            var timer = new Stopwatch();
            using var connection = new  SqlConnection(_connectionString);

            timer.Start();
            using var bulk = new SqlBulkCopy(_connectionString);


            await connection.OpenAsync();

            var table = ConvertToDataTable(items.ToArray());
            bulk.DestinationTableName = "Temporary_LoadTestForTransactionBulkInsert";
            await bulk.WriteToServerAsync(table);

            await connection.CloseAsync();

            timer.Stop();
            return timer.Elapsed;
        }


        private DataTable ConvertToDataTable(Object[] array)
        {
            PropertyInfo[] properties = array.GetType().GetElementType().GetProperties();
            DataTable dt = CreateDataTable(properties);
            if (array.Length != 0)
            {
                foreach (object o in array)
                    FillData(properties, dt, o);
            }
            return dt;
        }

        private DataTable CreateDataTable(PropertyInfo[] properties)

        {
            DataTable dt = new DataTable();
            DataColumn dc = null;
            foreach (PropertyInfo pi in properties)
            {
                dc = new DataColumn();
                dc.ColumnName = pi.Name;
                dc.DataType = pi.PropertyType;
                dt.Columns.Add(dc);
            }
            return dt;
        }

        private void FillData(PropertyInfo[] properties, DataTable dt, Object o)
        {
            DataRow dr = dt.NewRow();
            foreach (PropertyInfo pi in properties)
            {
                dr[pi.Name] = pi.GetValue(o, null);
            }
            dt.Rows.Add(dr);
        }

    }

     
}
