using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }
        public AccesoDatos()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=Ecommerce_Equipo20A; integrated security=true");
            command = new SqlCommand();
        }
    }
}

