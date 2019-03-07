#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 07 03 2019

#endregion

#region

using SQLite;

#endregion

namespace Quadrobit.Abstractions
{
    public interface ISqliteConnectionService
    {
        SQLiteAsyncConnection GetAsyncConnection();
    }
}