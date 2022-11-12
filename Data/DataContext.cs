using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using akira_api.models;
using Microsoft.EntityFrameworkCore;

namespace akira_api.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<User> Users {get; set;}

  }
}