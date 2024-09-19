using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.DTOs.User
{
    public class ListUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        //public string NameSurname { get; set; }
        //public bool TwoFactoredEnabled { get; set; }
    }
}
