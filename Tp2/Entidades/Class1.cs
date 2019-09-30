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
        void CrearCurso()
        {

        }
    }
    public class Curso
    {
        Personal Docente { get; set; }
        DateTime Turno { get; set; }
        List<Alumno> ListaDeAlumnos { get; set; }
        float Cuota { get; set; }
        float Inscripcion { get; set; }

        void CargarAlumno(Alumno alumno)
        {

        }
        void GuardarDatosEnArchivo()
        {

        }
        float ValorCuota()
        {
            return 0;
        }
    }
    public class Persona
    {
        string Nombre { get; set; }
        string Apellido { get; set; }
        DateTime FechaDeNacimiento { get; set; }
        string DNI { get; set; }

        int CalcularEdad(DateTime fechaNacimiento)
        {
            return 0;
        }
    }
    //Herencias de Persona
    public class Alumno : Persona
    {
    }
    public class Personal : Persona
    {
        DateTime FechaDeAlta { get; set; }
        float Sueldo { get; set; }

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
