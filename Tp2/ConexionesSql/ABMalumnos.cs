using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using System.ComponentModel;

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
                SqlCommand command = new SqlCommand(query,connection);
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
        Alumno GetAlumno(int idAlumno)
        {
            try
            {
                SqlConnection connection = Conexiones.Conectar();
                string query = "SELECT * FROM Alumnos WHERE Id = idAlumno";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Alumno alumno = new Alumno();
                alumno.Nombre = reader.GetString(1);
                alumno.Apellido = reader.GetString(2);
                alumno.FechaDeNacimiento = reader.GetDateTime(3);
                alumno.DNI = reader.GetString(4);
                Conexiones.Desconectar(connection);
                return alumno;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public BindingList<Alumno> GetListaAlumnos()
        {
            BindingList<Alumno> alumnosBd = new BindingList<Alumno>();
            Alumno alumno = new Alumno();
            try
            {
                SqlConnection connection = Conexiones.Conectar();
                string query = "SELECT * FROM Alumnos";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    alumno.Nombre = reader.GetString(1);
                    alumno.Apellido = reader.GetString(2);
                    alumno.FechaDeNacimiento = reader.GetDateTime(3);
                    alumno.DNI = reader.GetString(4);
                    alumnosBd.Add(alumno);
                }
                Conexiones.Desconectar(connection);
                return alumnosBd;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
