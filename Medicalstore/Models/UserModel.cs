using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Medicalstore.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}