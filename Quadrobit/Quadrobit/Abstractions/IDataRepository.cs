#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using System.Collections.Generic;
using System.Threading.Tasks;
using Quadrobit.Models;

#endregion

namespace Quadrobit.Abstractions
{
    public interface IDataRepository
    {
        Task AddEntry(DataEntry entry);
        Task<List<DataEntry>> GetAllEntries();
        Task RemoveEntry(int key);
    }
}