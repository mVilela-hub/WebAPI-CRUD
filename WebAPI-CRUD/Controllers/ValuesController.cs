using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebAPI_CRUD.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection connectionString = new SqlConnection(@"Data Source=.;Initial Catalog=ClienteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        // GET api/values
        public string Get()
        {
            
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM ClienteTable", connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                
                 return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "não foi encontrado o banco dados";
            }

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
