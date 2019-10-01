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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Entidades;

namespace Tp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ///Creo las listas que voy a necesitar, utilizo binding lists porque estan chidas
        BindingList<Alumno> alumnos;
        BindingList<Personal> personal;
        BindingList<Curso> cursos;
        Random rn;

        public MainWindow()
        {
            InitializeComponent();
            //Al inicializar la ventana, creo una instancia de cada lista
            alumnos = new BindingList<Alumno>();
            personal = new BindingList<Personal>();
            cursos = new BindingList<Curso>();
            rn = new Random();
            //Hago que las listbox muestren los elementos de mis listas
            lbxalumnosM.ItemsSource = alumnos;
            lbxpersonalM.ItemsSource = personal;
            lbxcursoM.ItemsSource = cursos;
        }
        //Creo todos los eventos para agregar objetos a las listas
        ///Agrego alumnos
        private void BtnagregAM_Click(object sender, RoutedEventArgs e)
        {
            //Creo una instancia de la ventana de alumnos para poder trabajar en la misma
            VentanaAlumnos agAlumnos = new VentanaAlumnos(alumnos);
            //ShowDialog abre la ventana
            agAlumnos.ShowDialog();
            //Tomo el objeto alumno creado en la ventana alumnos y lo cargo a la lista en la ventana principal
            alumnos.Add(agAlumnos.GetAlumno());
        }
        //Agrego personal
        private void BtnagregPM_Click(object sender, RoutedEventArgs e)
        {
            //Creo una instancia de la ventana de personal 
            VentanaPersonal agPersonal = new VentanaPersonal(personal);
            //Se abre la ventana
            agPersonal.ShowDialog();
            //Tomo el objeto empleado que viene de la ventana de personal y lo agrego a la lista 
            personal.Add(agPersonal.GetPersonal());
        }
        //Agrego curso
        private void BtnagregCM_Click(object sender, RoutedEventArgs e)
        {
            //Creo una instancia de la ventana de curso
            VentanaCursos agCurso = new VentanaCursos(personal,alumnos,rn.Next(1,3));
            //Abro la ventana
            agCurso.ShowDialog();
            //Tomo el curso y lo guardo en la lista
            cursos.Add(agCurso.GetCurso());
        }
        //Modifico alumnos
        private void Btnmodal_Click(object sender, RoutedEventArgs e)
        {
            if (lbxalumnosM.SelectedItem != null)
            {
                VentanaAlumnos modAlumnos = new VentanaAlumnos(alumnos, (Alumno)lbxalumnosM.SelectedItem, lbxalumnosM.SelectedIndex);
                modAlumnos.ShowDialog();
                alumnos.ElementAt(lbxalumnosM.SelectedIndex).Nombre = modAlumnos.GetAlumno().Nombre;
                alumnos.ElementAt(lbxalumnosM.SelectedIndex).Apellido = modAlumnos.GetAlumno().Apellido;
                alumnos.ElementAt(lbxalumnosM.SelectedIndex).DNI = modAlumnos.GetAlumno().DNI;
                alumnos.ElementAt(lbxalumnosM.SelectedIndex).FechaDeNacimiento = modAlumnos.GetAlumno().FechaDeNacimiento;
            }
            else
            {
                MessageBox.Show("Por favor seleccione un alumno a modificar");
            }
        }
        



    }
}
