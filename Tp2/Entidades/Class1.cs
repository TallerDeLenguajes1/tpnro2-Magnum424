using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Creo las clases necesarias para poder elaborar el proyecto
    public class Institucion
    {
        string Nombre { get; set; }
        string MatriculaMinisterio { get; set; }
        List<Curso> ListaCursos { get; set; }
    }
    public class Curso
    {
        string Tema { get; set; }
        Personal Docente { get; set; }
        string Turno { get; set; }
        List<Alumno> ListaDeAlumnos { get; set; }
        float Cuota { get; set; }
        float Inscripcion { get; set; }
        void GuardarDatosEnArchivo()
        {

        }
        float ValorCuota()
        {
            return 0;
        }
    }
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string DNI { get; set; }

        int CalcularEdad(DateTime fechaNacimiento)
        {
            return 0;
        }
    }
    //Herencias de Persona
    public class Alumno : Persona
    {
        //Genero un constructor para la clase alumno
        public Alumno(string nombre, string apellido, DateTime fechanacimiento, string dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaDeNacimiento = fechanacimiento;
            this.DNI = dni;
        }
        //Hago un override del metodo to string para mostrar bien en las listboxes
        public override string ToString()
        {
            return Apellido + ", " + Nombre + " - " + DNI;
        }
    }
    public class Personal : Persona
    {
        DateTime FechaDeAlta { get; set; }
        float Sueldo { get; set; }
        //Genero un constructor de personals
        public Personal(string nombre, string apellido, DateTime fechanacimiento, string dni, DateTime fechaalta, float sueldo)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaDeNacimiento = fechanacimiento;
            this.DNI = dni;
            this.FechaDeAlta = fechaalta;
            this.Sueldo = sueldo;
        }
        //Hago un override del metodo to string para mostrar bien en las listboxes
        public override string ToString()
        {
            return Apellido + ", " + Nombre + " - " + DNI;
        }
        int CalcularAntiguedad(DateTime fechaDeAlta)
        {
            return 0;
        }
    }
    //Herencias de Curso
    public class Presencial : Curso
    {
    }
    public class SemiPresencial : Curso
    {
    }
    public class NoPresencial : Curso
    {
    }
}
