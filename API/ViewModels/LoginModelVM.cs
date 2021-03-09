using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class LoginModelVM
    {
        public string FullName { get; }
        public string Email { get; set; }
        public string RoleName { get; }

        public string Password { get; set; }
    }
}
