using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using N01426963_passionproject.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace N01426963_passionproject.Controllers
{
    public class CompDataController : ApiController
    {
        private WoWDBContext WoW = new WoWDBContext();


        ///<summary>
        ///Returning a list of comps in the system
        ///</summary>

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

                Comp NewComp = new Comp();
                NewComp.CompID = CompId;
                NewComp.CompName = CompName;
                NewComp.CompClass1 = Class1;
                NewComp.CompClass2 = Class2;
                NewComp.CompClass3 = Class3;


                //Add new comp to the list
                Comps.Add(NewComp);
            }
           



            //return new list
            return Comps;


        }//End of List Comps

        //Finding a certain comp utilizing ID
        [HttpGet]
        public Comp FindComp(int id)
        {
            Comp NewComp = new Comp();

            //Allowing access into my MySQL Database
            MySqlConnection Conn = WoW.AccessDatabase();

            //opening the connection to DB
            Conn.Open();

            //Establishing new command query for our DB
            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from comp where compid = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            

            //Gathering results into variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Accessing column information 
                int CompId = (int)ResultSet["compid"];
                string CompName = (string)ResultSet["comp_name"];
                string Class1 = (string)ResultSet["class1"];
                string Class2 = (string)ResultSet["class2"];
                string Class3 = (string)ResultSet["class3"];


                NewComp.CompID = CompId;
                NewComp.CompName = CompName;
                NewComp.CompClass1 = Class1;
                NewComp.CompClass2 = Class2;
                NewComp.CompClass3 = Class3;
            }

            return NewComp;
        }

        /// <summary>
        /// To delete a composition
        /// </summary>
        /// <param name="id"></param>
        /// <example>POST: /api/CompData/DeleteComp/2</example>
  
        [HttpPost]
        public void DeleteComp(int id)
        {
            //Creating a connection
            MySqlConnection Conn = WoW.AccessDatabase();

            //Opening connection
            Conn.Open();

            //Establishing new command for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "delete from comp where compid=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            //after executing query, can close connection
            Conn.Close();

        }



        //AddComps will give the user the ability to add their own composition.
        [HttpPost]
        [Route("api/CompData/AddComp")]
        public void AddComp([FromBody]Comp NewComp)
        {
            //Connections
            MySqlConnection Conn = WoW.AccessDatabase();

            try
            {
                //Opening Connection
                Conn.Open();

                //Establishing new command query
                MySqlCommand cmd = Conn.CreateCommand();

                //SQL Query
                cmd.CommandText = "insert into comp (comp_name, class1, class2, class3) values (@CompName, @CompClass1, @CompClass2, @CompClass3)";
                cmd.Parameters.AddWithValue("@CompName", NewComp.CompName);
                cmd.Parameters.AddWithValue("@CompClass1", NewComp.CompClass1);
                cmd.Parameters.AddWithValue("@CompClass2", NewComp.CompClass2);
                cmd.Parameters.AddWithValue("@CompClass3", NewComp.CompClass3);
                cmd.Prepare();

                cmd.ExecuteNonQuery();

                Conn.Close();
            }
            catch (MySqlException ex)
            {
                //Catches issues with MySQL.
                Debug.WriteLine(ex);
                throw new ApplicationException("Issue was a database issue.", ex);
            }
            catch (Exception ex)
            {
                //Catches generic issues
                Debug.Write(ex);
                throw new ApplicationException("There was a server issue.", ex);
            }
            finally
            {
                //Close the connection between the MySQL Database and the WebServer
                Conn.Close();

            }





        }


    }
}
