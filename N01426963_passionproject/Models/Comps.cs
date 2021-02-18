using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N01426963_passionproject.Models
{
    public class Comps
    {

        [Key]
        public int CompID { get; set; }

        public string CompName { get; set; }

        public string CompClass1 { get; set; }

        public string CompClass2 { get; set; }

        public string CompClass3 { get; set; }





    }
}