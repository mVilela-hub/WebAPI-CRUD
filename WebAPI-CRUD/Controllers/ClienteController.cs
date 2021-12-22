using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CRUD.Models;

namespace WebAPI_CRUD.Controllers
{
    public class ClienteController : ApiController
    {
        // GET: api/Cliente
        private SqlDataAdapter adapterDB;
        SqlConnection connectionString = new SqlConnection(@"Data Source =.; Initial Catalog = ClienteDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public IEnumerable<Cliente> Get()
        {
            DataTable dt = new DataTable();
            string querry = "SELECT * FROM [ClienteTable]";
            adapterDB = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(querry, connectionString)
            };
            adapterDB.Fill(dt);
            List<Cliente> Cliente = new List<Models.Cliente>(dt.Rows.Count);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow gravarCliente in dt.Rows)
                {
                    Cliente.Add(new lerCliente(gravarCliente));
                }
            }
            return Cliente;
        }

        // GET: api/Cliente/5
        public IEnumerable<Cliente> Get(int id)
        {
            //string querry = "SELECT * FROM [ClienteTable] WHERE id= @Id";
            //var connectstring = @"Data Source =.; Initial Catalog = ClienteDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //using (SqlConnection con = new SqlConnection(connectstring))
            //{

            //    con.Open();
            //    var o = con.Query<Cliente>(querry, new { Id });
            //    return o;

            //} UTILIZANDO O DAPPER
            DataTable dt = new DataTable();
            string querry = "SELECT * FROM [ClienteTable] WHERE id=" + id;
            adapterDB = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(querry, connectionString)
            };
            adapterDB.Fill(dt);
            List<Cliente> clienteList = new List<Models.Cliente>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow gravarCliente in dt.Rows)
                {
                    clienteList.Add(new lerCliente(gravarCliente));
                }
            }
            return clienteList;
        }

        // POST: api/Cliente
        public string Post([FromBody]criarCliente value)
        {
            string querry = "INSERT INTO [ClienteTable] (Nome, Sobrenome) VALUES (@Nome,@Sobrenome)";
            SqlCommand comandoInsert = new SqlCommand(querry, connectionString);
            comandoInsert.Parameters.AddWithValue("@Nome", value.Nome);
            comandoInsert.Parameters.AddWithValue("@Sobrenome", value.Sobrenome);
            connectionString.Open();
            int i = comandoInsert.ExecuteNonQuery();
            if (i > 0)
            {
                return "Dados inserido com sucesso";
            }
            else
            {
                return "Dados não foram inseridos";
            }

        }

        // PUT: api/Cliente/5
        public string Put(int id, [FromBody]criarCliente value)
        {
            string querry = "UPDATE [ClienteTable] SET Nome=@Nome, Sobrenome=@Sobrenome WHERE id=" + id;
            SqlCommand comandoUpdate = new SqlCommand(querry, connectionString);
            comandoUpdate.Parameters.AddWithValue("@Nome", value.Nome);
            comandoUpdate.Parameters.AddWithValue("@Sobrenome", value.Sobrenome);
            connectionString.Open();
            int i = comandoUpdate.ExecuteNonQuery();
            if (i > 0)
            {
                return "Dados atualizados com sucesso";
            }
            else
            {
                return "Dados não foram atualizados";
            }



        }

        // DELETE: api/Cliente/5
        public string Delete(int id)
        {
            string querry = "DELETE FROM [ClienteTable] WHERE id=" + id;
            connectionString.Open();
            SqlCommand comandoDelete = new SqlCommand(querry, connectionString);
            int i = comandoDelete.ExecuteNonQuery();
            if (i > 0)
            {
                return "Os dados foram deletados com Sucesso !!!";
            }
            else
            {
                return "Os dados não foram deletados";
            }
        }
    }
}
