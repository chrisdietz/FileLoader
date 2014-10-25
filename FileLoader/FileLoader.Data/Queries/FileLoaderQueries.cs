using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper;
using FileLoader.Data.Context;
using FileLoader.Domain.Entities;

namespace FileLoader.Data.Queries
{
    public class FileLoaderQueries
    {
        private readonly FileLoaderDbSession db;

        public FileLoaderQueries(FileLoaderDbSession db)
        {
            this.db = db;
        }

        /// <summary>
        /// Read file path and get a list of files to load
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> GetFilesToLoad(string filePath)
        {
            var filesToLoad = new List<string>(Directory.GetFiles(filePath));
            return filesToLoad;
        }

        /// <summary>
        /// Read datbase counties table and bring back a list of counties
        /// </summary>
        /// <returns></returns>
        public List<County> GetCounties()
        {
            var query = @"SELECT CountyCode as CountyCode, CountyDesc as Name from Counties ORDER BY CountyCode";

            return db.Connection.Query<County>(query).ToList<County>();

        }

        /// <summary>
        /// Read database voters table and bring back a list of voters for a given county
        /// </summary>
        /// <param name="countyCode"></param>
        /// <returns></returns>
        public List<Voter> GetVotersForExport(string countyCode)
        {
            var query = @"SELECT * from Voters WHERE CountyCode = @CountyCode";

            return db.Connection.Query<Voter>(query, new { CountyCode = countyCode }).ToList<Voter>();

        }

    }
}
