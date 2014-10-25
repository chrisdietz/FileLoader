using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using Dapper;
using FileLoader.Data.Context;
using FileLoader.Data.Queries;
using Ionic.Zip;
using LumenWorks.Framework.IO.Csv;
using CsvReader = LumenWorks.Framework.IO.Csv.CsvReader;

namespace FileLoader.Data.Commands
{
    public class FileLoaderComands
    {
        private readonly FileLoaderDbSession db;
        private readonly FileLoaderQueries queries;

        public FileLoaderComands(FileLoaderDbSession db, FileLoaderQueries queries)
        {
            this.db = db;
            this.queries = queries;
        }

        /// <summary>
        /// Load all files from list to database
        /// </summary>
        /// <param name="filesToLoad">List of files to load</param>
        public int LoadFilesToDatabase(List<string> filesToLoad)
        {
            var totalRecordsLoaded = 0;

            foreach (var fileToLoad in filesToLoad)
            {
                var pos = (fileToLoad.LastIndexOf("\\", StringComparison.Ordinal) + 1);
                var countyCode = fileToLoad.Substring(pos, 3);

                var startTime2 = DateTime.Now;
                Console.WriteLine("File: " + fileToLoad);

                var recordsLoaded = LoadCountyFile(fileToLoad, countyCode);
                totalRecordsLoaded += recordsLoaded;

                var endTime2 = DateTime.Now;
                Console.WriteLine(" - Time: " + (endTime2 - startTime2) + " Records: " + recordsLoaded);
            }
            return totalRecordsLoaded;
        }

        /// <summary>
        /// Load a file one county at a time
        /// </summary>
        /// <param name="fileToLoad">File to read and load</param>
        /// <param name="countyCode">County</param>
        /// <returns></returns>
        public int LoadCountyFile(string fileToLoad, string countyCode)
        {
            var stagingTableName = "VotersStage";
            var tableName = "Voters";
            var truncateStatement = @"TRUNCATE TABLE " + stagingTableName;
            var deleteStatement = @"DELETE FROM " + tableName + " WHERE CountyCode=@countyCode";
            var insertStatement = @"INSERT INTO " + tableName + " SELECT DISTINCT * FROM " + stagingTableName + "; SELECT @@ROWCOUNT";
            var dataTable = new DataTable();
            var recordsLoaded = 0;

            try
            {
                // 1. Read file and load contents to dataTable in memory.
                using (var textFile = new CsvReader(new StreamReader(fileToLoad), false, '\t', '\0', '\0', '#', ValueTrimmingOptions.All, 4096))
                {
                    dataTable.Load(textFile);
                }

                // 2. Truncate target staging table
                db.Connection.Execute(truncateStatement);

                // 3. Use SQL Bulk Copy to insert into staging table from dataTable.
                using (var bulkCopy = new SqlBulkCopy(db.connectionString))
                {
                    bulkCopy.DestinationTableName = stagingTableName;
                    bulkCopy.BulkCopyTimeout = 180;
                    bulkCopy.BatchSize = 100000;
                    bulkCopy.WriteToServer(dataTable);
                }

                // 4. Remove all records from fact table.
                db.Connection.Execute(deleteStatement, new { countyCode }, null, 180);

                // 5. Insert all records from staging table into fact table.
                recordsLoaded = db.Connection.Execute(insertStatement, null, null, 180);

            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return recordsLoaded;

        }

        /// <summary>
        /// Export data out of database, copy to file then zip
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <param name="exportTextFileName">Export file name for text file</param>
        /// <param name="exportZipFileName">Export file name for zip file</param>
        public int ExportDataToFile(string filePath, string exportTextFileName, string exportZipFileName)
        {
            var recordsExported = 0;

            try
            {
                // 1 Get all the Counties so we can loop through them.
                var counties = queries.GetCounties();

                // 2. Fetch all records from SQL Server and write to a tab delimited text file.
                using (var textWriter = File.CreateText(filePath + exportTextFileName))
                using (var writer = new CsvWriter(textWriter))
                {
                    writer.Configuration.Delimiter = "\t";
                    writer.Configuration.HasHeaderRecord = true;
                    foreach (var county in counties)
                    {
                        var voters = queries.GetVotersForExport(county.CountyCode);
                        if (voters != null)
                        {
                            recordsExported += voters.Count();
                            writer.WriteRecords(voters);
                        }
                    }
                }

                // 3. Zip the text file just created.
                using (var zipFile = new ZipFile())
                {
                    zipFile.AddFile(filePath + exportTextFileName, string.Empty);
                    zipFile.Save(filePath + exportZipFileName);
                }

                // 4. Delete the text file.
                if (File.Exists(filePath + exportTextFileName))
                    File.Delete(filePath + exportTextFileName);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return recordsExported;

        }

    }
}
