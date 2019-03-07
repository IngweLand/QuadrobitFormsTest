#region Author

// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 04 03 2019

#endregion

#region

using System.Threading.Tasks;

#endregion

namespace Quadrobit.Abstractions
{
    public interface IApiService
    {
        Task<bool> Login(string username, string password);
        Task Logout();
    }
}