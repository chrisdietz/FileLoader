using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoader.Data.Context
{
    public class FileLoaderDbSession
    {
        private static readonly object @lock = new object();
        public readonly string connectionString;
        private IDbConnection cn;

        public FileLoaderDbSession(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public FileLoaderDbSession()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["FileLoaderDb"].ConnectionString;
        }


        /// <summary>
        /// Gets the IDbConnection object.
        /// </summary>
        /// <value>The connection.</value>
        public IDbConnection Connection { get { return GetConnection(); } }

        /// <summary>
        /// Gets the connection and creates it if this
        /// is the first call on the property.
        /// </summary>
        /// <returns>IDbConnection.</returns>
        private IDbConnection GetConnection()
        {
            if (cn == null)
            {
                lock (@lock)
                {
                    if (cn == null)
                    {
                        cn = new SqlConnection(connectionString);
                        cn.Open();
                    }
                }
            }

            return cn;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (cn != null)
            {
                cn.Dispose();
            }
        }

    }
}
