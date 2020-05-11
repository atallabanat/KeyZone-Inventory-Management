using mrbapi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mrbapi.Controllers
{



    public class UsersController : ApiController
    {
        // GET: api/Users
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Users/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        public DataTable Get(string Username, string Password)
        {
            Users u = new Users();
            DataTable dt = new DataTable();

            dt = u.GetUsers(Username, Password);

            return dt;
        }

        // POST: api/Users
        //public IHttpActionResult Post(string username, string password)

        public IHttpActionResult Post([FromBody]Users u)
        {
            if (u.Username == null || u.Password == null)
            {
                return Ok("Username and password are mandatory ");
            }

            //Users users = new Users();
            //users.Username = username;
            //users.Password = password;

            if (u.Username.Trim().Length == 0 || u.Password.Trim().Length == 0)
            {
                return Ok("Username and password are mandatory ");
            }

            DataTable dt = new DataTable();

            dt = u.GetUsers(u.Username, u.Password);
            

            if(dt.Rows.Count == 0)
            {
                dt.Columns.Add("Result", typeof(String));
                //dt.Rows.Add ("failure");
                dt.Rows.Add();
                dt.Rows[0]["Result"] = "failure";
            }
            else
            {
                dt.Columns.Add("Result", typeof(String));
                //dt.Rows.Add ("failure");
                
                dt.Rows[0]["Result"] = "تم الدخول بنجاح"+u.Username;
            }

            //return dt;
            return Ok(dt);
        }

        //public DataTable Post(Users users)
        //{
        //    Users u = new Users();
        //    DataTable dt = new DataTable();

        //    dt = u.GetUsers(users.Username, users.Password);

        //    return dt;
        //}

        //[HttpPost]
        //public IHttpActionResult PostUser(string username, string password)
        //{
        //    if(username == null || password == null)
        //    {
        //        return Ok("Username and password are mandatory ");
        //    }

        //    Users users = new Users();
        //    users.Username = username;
        //    users.Password = password;

        //    if (username.Trim().Length == 0 || password.Trim().Length == 0 )
        //    {
        //        return Ok("Username and password are mandatory ");
        //    }

        //    DataTable dt = new DataTable();

        //    dt = users.GetUsers(username, password);

        //    //return dt;
        //    return Ok(dt);
        //}


        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
