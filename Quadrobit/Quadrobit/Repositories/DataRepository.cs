#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using System.Collections.Generic;
using System.Threading.Tasks;
using Quadrobit.Abstractions;
using Quadrobit.Models;
using SQLite;

#endregion

namespace Quadrobit.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        public DataRepository(ISqliteConnectionService sqliteConnectionService)
        {
            _connection = sqliteConnectionService.GetAsyncConnection();
            Task.Run(async () => await _connection.CreateTableAsync<DataEntry>());
        }

        public async Task AddEntry(DataEntry entry)
        {
            await _connection.InsertAsync(entry);
        }

        public async Task RemoveEntry(int key)
        {
            await _connection.DeleteAsync<DataEntry>(key);
        }

        public async Task<List<DataEntry>> GetAllEntries()
        {
            return await _connection.Table<DataEntry>().ToListAsync();
        }
    }
}