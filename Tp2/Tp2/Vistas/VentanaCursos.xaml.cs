using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using Entidades;

namespace Tp2
{
    /// <summary>
    /// Interaction logic for VentanaCursos.xaml
    /// </summary>
    public partial class VentanaCursos : Window
    {
        //Defino un objeto personal, una lista de alumnos y un curso vacios
        Personal empleado;
        BindingList<Alumno> inscriptos;
        Curso cursito;
        //
        BindingList<Alumno> lista;
        public VentanaCursos(BindingList<Personal> empleados, BindingList<Alumno> alumnos)
        {
            InitializeComponent();
            lbxpersonal.ItemsSource = empleados;
            lista = alumnos;
        }
        //Armo un getter del curso
        public Curso GetCurso()
        {
            return cursito;
        }
        //Selecciono el docente del curso y lo asigno a empleado
        private void Btndocente_Click(object sender, RoutedEventArgs e)
        {
            empleado = (Personal)lbxpersonal.SelectedItem;
        }
        //El boton revisar lista me manda a otra ventana en la cual voy agregando alumnos a la lista de la ventana de cursos
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Listados revList = new Listados(lista);

        }
    }
}
