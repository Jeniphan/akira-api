using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akira_api.models;

namespace akira_api.Data
{
    public interface IAuthRepository
    {
       Task<ServiceReponse<int>> Register(User user,string password);

        Task<ServiceReponse<string>> Login(string username , string password);

        Task<bool> UserExists(string username);
    }
}