using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace akira_api.models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public byte[] Passwordhash  { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}