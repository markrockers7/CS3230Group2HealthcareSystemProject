using System;

namespace HealthcareSystemProjectCS3230.DAL { 
    /// <summary>
    /// Holds the connection information
    /// </summary>
    public static class Connection
    {

        private static string databaseName = "cs3230f26_g2";
        private static string userName = "cs3230f26_g2";
        private static string password = "[qBJ@N2IO%W}w47}HP+Q";
        private static int port = 3307;
        private static string address = "localhost";

        /// <summary>
        /// The connection string for the database
        /// </summary>
        public static readonly string ConnectionString = 
            $"server={address}; port={port}; " +
            $"uid={userName}; pwd={password}; " +
            $"database={databaseName};";
    }

}
