using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N01426963_passionproject.Models
{
    //This class will be used to describe a "class" in World of Warcraft.
    public class Class
    {
        [Key]
        public int ClassID { get; set; }

        public string ClassName { get; set; }


    

    }
}