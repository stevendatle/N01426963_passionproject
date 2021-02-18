using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace N01426963_passionproject.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }

        public string Role { get; set; }

        [ForeignKey]
      
    }
}