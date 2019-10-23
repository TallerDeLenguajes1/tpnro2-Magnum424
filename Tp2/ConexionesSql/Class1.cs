using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConexionesSql
{
    public class Conexiones
    {
        public static SqlConnection Conectar()
        {
            try
            {
                string ConLine = @"server=DESKTOP-1822RQS;database=Instituto;integrated security=true";
                SqlConnection connection = new SqlConnection(ConLine);
                connection.Open();
                return connection;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Desconectar(SqlConnection connection)
        {
            connection.Close();
        }
    }
}
