#region Author
// Author ILYA GOLOVACH (aka IngweLand)
// http://ingweland.com
// ingweland@gmail.com
// Created: 04 03 2019
#endregion

using System.Threading.Tasks;
using Quadrobit.Abstractions;

namespace Quadrobit.Services
{
    public class ApiService:IApiService
    {
        public async Task<bool> Login(string username, string password)
        {
            return await Task.Run(() =>
            {
                if (username == "demo" && password == "demo")
                {
                    return true;
                }
                
                return false;
            });
        }

        public async Task Logout()
        {
            
        }
    }
}