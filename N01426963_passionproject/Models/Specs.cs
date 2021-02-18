using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations
using System.ComponentModel.DataAnnotations.Schema;

namespace N01426963_passionproject.Models
{
    public class Specs
    {
        [Key]
        public int SpecID { get; set; }

        public string SpecName { get; set; }

        [ForeignKey("Roles")]
        public int RoleID { get; set; }
        public string Role { get; set; }
    }
}