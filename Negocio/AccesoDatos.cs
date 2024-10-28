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

        public void read()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void executeQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void closeConnection()
        {
            if(reader != null)     
                reader.Close();
            connection.Close();
        }
        public void setQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;    
        }
        public void setParameter(string nombre, object valor)
        {
            command.Parameters.AddWithValue(nombre, valor);
        }
        public int executeQueryScalar()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                return int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void setProcedure(string procedure)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = procedure;
        }
    }
}

