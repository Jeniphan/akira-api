using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akira_api.models;

namespace akira_api.Data
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;
    public AuthRepository(DataContext context)
    {
        _context = context;
    }
    public Task<ServiceReponse<string>> Login(string username, string password)
    {
      throw new NotImplementedException();
    }

    public Task<ServiceReponse<int>> Register(User user, string password)
    {
      throw new NotImplementedException();
    }

    public Task<bool> UserExists(string username)
    {
      throw new NotImplementedException();
    }
  }
}