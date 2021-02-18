using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using N01426963_passionproject.Models;
using MySql.Data.MySqlClient;

namespace N01426963_passionproject.Controllers
{
    public class CompDataController : ApiController
    {
        private WoWDBContext WoW = new WoWDBContext();

        [HttpGet]
        [Route("api/CompData/ListComps")]
        public IEnumerable<Comp> ListComps()
        {

            //Allowing access into my MySQL Database
            MySqlConnection Conn = WoW.AccessDatabase();

            //opening the connection to DB
            Conn.Open();

            //Establishing new command query for our DB
            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from comp";
            cmd.Prepare();

            //Gathering results into variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Creating empty list of comps
            List<Comp> Comps = new List<Comp> { };

            //Loop thorugh each row of the result set

            while (ResultSet.Read())
            {
                //Accessing column information 
                int CompId = (int)ResultSet["compid"];
                string CompName = (string)ResultSet["comp_name"];
                string Class1 = (string)ResultSet["class1"];
                string Class2 = (string)ResultSet["class2"];
                string Class3 = (string)ResultSet["class3"];

                Comps NewComp = new Comps();
                NewComp.CompID = CompId;
                NewComp.CompName = CompName;
                NewComp.CompClass1 = Class1;
                NewComp.CompClass2 = Class2;
                NewComp.CompClass3 = Class3;



                Comps.Add(NewComp);
            }
            Conn.Close;
            return Comps;


        }


    }
}
