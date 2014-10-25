using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileLoader.Data.Commands;
using FileLoader.Data.Context;
using FileLoader.Data.Queries;

namespace FileLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new FileLoaderDbSession();
            var queries = new FileLoaderQueries(db);
            var commands = new FileLoaderComands(db, queries);
            var filePath = ConfigurationManager.AppSettings["FilePath"];
            var exportTextFile = ConfigurationManager.AppSettings["ExportFile"] + ".txt";
            var exportZipFile = ConfigurationManager.AppSettings["ExportFile"] + ".zip";

            var startTime = DateTime.Now;
            Console.WriteLine("Start time: " + startTime);
            Console.WriteLine("Loading Files....");

            // Get files to load
            var filesToLoad = queries.GetFilesToLoad(filePath);

            // Load files to database
            var recordsLoaded = commands.LoadFilesToDatabase(filesToLoad);
            var loadTime = DateTime.Now;
            Console.WriteLine("Total Records Loaded: " + recordsLoaded + " Time: " + (loadTime - startTime));

            // Export data back out to file
            var recordsExported = commands.ExportDataToFile(filePath, exportTextFile, exportZipFile);
            Console.WriteLine("Total Records Exported: " + recordsExported);

            var endTime = DateTime.Now;
            Console.WriteLine("End time: " + endTime);
            var totalTime = endTime - startTime;
            Console.WriteLine("Total time: " + totalTime);
            Console.ReadKey();

        }
    }
}
