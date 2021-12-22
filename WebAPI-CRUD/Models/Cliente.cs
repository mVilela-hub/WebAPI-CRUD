using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebAPI_CRUD.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

    }

    public class criarCliente: Cliente
    {
    }

    public class lerCliente: Cliente
    {
        public lerCliente (DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            Nome = row["Nome"].ToString();
            Sobrenome = row["Sobrenome"].ToString();
        }

        public int id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
} 