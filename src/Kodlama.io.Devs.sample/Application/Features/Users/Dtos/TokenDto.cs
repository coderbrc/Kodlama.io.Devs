using corePackages.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Dtos
{
    public class TokenDto
    {
        public User Id { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
