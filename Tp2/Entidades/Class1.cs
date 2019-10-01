using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Entidades
{
    //Creo las clases necesarias para poder elaborar el proyecto
    public class Institucion
    {
        string Nombre { get; set; }
        string MatriculaMinisterio { get; set; }
        BindingList<Curso> ListaCursos { get; set; }
    }
    public abstract class Curso
    {
        public string Tema { get; set; }
        public Personal Docente { get; set; }
        public string Turno { get; set; }
        public BindingList<Alumno> ListaDeAlumnos { get; set; }
        public float Cuota { get; set; }
        public float Inscripcion { get; set; }
        public void CrearCurso(string tema, Personal docente, string turno, BindingList<Alumno> listaDeAlumnos, float cuota, float inscripcion)
        {
            this.Tema = tema;
            this.Docente = docente;
            this.Turno = turno;
            this.ListaDeAlumnos = listaDeAlumnos;
            this.Cuota = cuota;
            this.Inscripcion = inscripcion;
        }
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
        //Constructor vacio
        public Alumno()
        {
        }
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
        //Constructor vacio
        public Personal()
        {
        }
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
        //Genero un constructor para la clase curso
        public Presencial()
        {
        }
        public override string ToString()
        {
            return Tema + " - " + Docente + " - Turno  " + Turno;
        }
    }
    public class SemiPresencial : Curso
    {
        //Genero un constructor para la clase curso
        public SemiPresencial()
        {
        }
        public override string ToString()
        {
            return Tema + " - " + Docente + " - Turno  " + Turno;
        }
    }
    public class NoPresencial : Curso
    {
        //Genero un constructor para la clase curso
        public NoPresencial()
        {
        }
        public override string ToString()
        {
            return Tema + " - " + Docente + " - Turno  " + Turno;
        }
    }
}
