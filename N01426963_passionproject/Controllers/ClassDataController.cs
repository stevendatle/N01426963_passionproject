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
    public class ClassDataController : ApiController
    {
        private WoWDBContext WoW = new WoWDBContext();


        //This controller will access the classes table of our WoWDB.
        /// <summary>
        /// Return a list of classes in the system
        /// </summary>
        /// <returns>
        /// List of class objects with fields mapped to the database columns (class_name)
        /// </returns>
        
        [HttpGet]
        [Route("api/ClassData/ListClasses")]
        public IEnumerable<Class> ListClasses()
        {
            //Allowing access into my MySQL Database
            MySqlConnection Conn = WoW.AccessDatabase();

            //opening the connection to DB
            Conn.Open();

            //Establishing new command query for our DB
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL Query
            cmd.CommandText = "Select * from classes";

            cmd.Prepare();

            //Gather results into a variable

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Creating an empty list of classes
            List<Class> Classes = new List<Class> { };

            //Loop through each row of result set
            while (ResultSet.Read())
            {
                //Accessing column information 
                int ClassId = (int)ResultSet["classid"];
                string ClassName = (string)ResultSet["class_name"];

                Class NewClass = new Class();
                NewClass.ClassID = ClassId;
                NewClass.ClassName = ClassName;

                Classes.Add(NewClass);
            }

                Conn.Close();

                return Classes;

            } // END OF LIST CLASSES



            
        }
    }

