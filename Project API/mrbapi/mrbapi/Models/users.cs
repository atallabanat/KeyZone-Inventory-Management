using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace mrbapi.Models
{
    public class Users
    {

        public string Username { get; set; }
        public string Password { get; set; }

        public DataTable GetUsers(string Username, string Password)
        {
            string cnnString = System.Configuration.ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            //string TrainingPlan_ref = WebConfigurationManager.AppSettings["TrainingPlan_ref"];
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_GetByUsrPwd";
            //add any parameters the stored procedure might require
            cmd.Parameters.AddWithValue("@Username", Username); //mm
            cmd.Parameters.AddWithValue("@Password", Password); //123

            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("users");
            da.Fill(dt);

            return dt;
        }
    }
}