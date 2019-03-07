#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using System;
using System.IO;
using Quadrobit.Abstractions;
using SQLite;

#endregion

namespace Quadrobit.iOS.Services
{
    public class IosSqliteConnectionService : ISqliteConnectionService
    {
        private const string FileName = "IngwelandQuadrobit.sqlite3";
        private SQLiteAsyncConnection _connection;

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            if (_connection == null)
            {
                var databaseFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var databaseFilePath = Path.Combine(databaseFolder, FileName);
                _connection = new SQLiteAsyncConnection(databaseFilePath);
            }

            return _connection;
        }
    }
}