using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace ConexionesSql
{
    public class ABMalumnos
    {
        void CargarAlumno(Alumno alumno)
        {

            try
            {
                SqlConnection connection = Conexiones.Conectar();
                string query = @"INSERT INTO Alumnos(Nombre,Apellido,FechaNac,DNI) VALUES(@nombre,@apellido,@fechaNac,@dni)";
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("@nombre", alumno.Nombre);
                command.Parameters.AddWithValue("@apellido", alumno.Apellido);
                command.Parameters.AddWithValue("@fechaNac", alumno.FechaDeNacimiento);
                command.Parameters.AddWithValue("@dni", alumno.DNI);
                command.ExecuteNonQuery();
                Conexiones.Desconectar(connection);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
