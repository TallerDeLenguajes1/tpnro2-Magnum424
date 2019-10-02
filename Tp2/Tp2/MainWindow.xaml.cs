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
using System.IO;

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
        bool xd = true;

        public MainWindow()
        {
            InitializeComponent();
            //Al inicializar la ventana, creo una instancia de cada lista
            alumnos = new BindingList<Alumno>();
            personal = new BindingList<Personal>();
            cursos = new BindingList<Curso>();
            rn = new Random();
            //Hago que las listbox muestren los elementos de mis listas
            ListUpdate();
        }
        //Creo todos los eventos para agregar objetos a las listas
        ///Agrego alumnos
        private void BtnagregAM_Click(object sender, RoutedEventArgs e)
        {
            xd = true;
            //Creo una instancia de la ventana de alumnos para poder trabajar en la misma
            VentanaAlumnos agAlumnos = new VentanaAlumnos(alumnos,xd);
            //ShowDialog abre la ventana
            agAlumnos.ShowDialog();
            //Tomo el objeto alumno creado en la ventana alumnos y lo cargo a la lista en la ventana principal
            alumnos = agAlumnos.GetListaNueva();
        }
        //Agrego personal
        private void BtnagregPM_Click(object sender, RoutedEventArgs e)
        {
            //Creo una instancia de la ventana de personal 
            VentanaPersonal agPersonal = new VentanaPersonal(personal,xd);
            //Se abre la ventana
            agPersonal.ShowDialog();
            //Tomo el objeto empleado que viene de la ventana de personal y lo agrego a la lista 
            personal = agPersonal.GetListaNueva();
        }
        //Agrego curso
        private void BtnagregCM_Click(object sender, RoutedEventArgs e)
        {
            //Creo una instancia de la ventana de curso
            VentanaCursos agCurso = new VentanaCursos(cursos, personal, alumnos, rn.Next(1,3), xd);
            //Abro la ventana
            agCurso.ShowDialog();
            //Tomo el curso y lo guardo en la lista
            cursos = agCurso.GetListaNueva();
            ListUpdate();

        }
        //Modifico alumnos
        private void Btnmodal_Click(object sender, RoutedEventArgs e)
        {
            if (lbxalumnosM.SelectedItem != null)
            {
                xd = false;
                VentanaAlumnos modAlumnos = new VentanaAlumnos(alumnos, (Alumno)lbxalumnosM.SelectedItem, lbxalumnosM.SelectedIndex, xd);
                modAlumnos.ShowDialog();
                alumnos = modAlumnos.GetListaNueva();
                ListUpdate();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un alumno a modificar");
            }
        }
        private void ListUpdate()
        {
            lbxalumnosM.ItemsSource = alumnos;
            lbxcursoM.ItemsSource = cursos;
            lbxpersonalM.ItemsSource = personal;
            lbxalumnosM.Items.Refresh();
            lbxpersonalM.Items.Refresh();
            lbxcursoM.Items.Refresh();
        }

        private void Btnmodper_Click(object sender, RoutedEventArgs e)
        {
            if (lbxpersonalM.SelectedItem != null)
            {
                xd = false;
                VentanaPersonal modPersonal = new VentanaPersonal(personal, (Personal)lbxpersonalM.SelectedItem, lbxpersonalM.SelectedIndex, xd);
                modPersonal.ShowDialog();
                personal = modPersonal.GetListaNueva();
                ListUpdate();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un alumno a modificar");
            }
        }

        private void Btnmodcur_Click(object sender, RoutedEventArgs e)
        {
            if (lbxcursoM.SelectedItem != null)
            {
                xd = false;
                VentanaCursos modCurso = new VentanaCursos(cursos, (Curso)lbxcursoM.SelectedItem, personal, alumnos, rn.Next(1, 3), xd, lbxcursoM.SelectedIndex);
                modCurso.ShowDialog();
                cursos = modCurso.GetListaNueva();
                ListUpdate();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un alumno a modificar");
            }
        }

        private void Btnimprimir_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(File.Open(@"Cursos.csv",FileMode.OpenOrCreate));
            //foreach (Curso x in cursos)
            //{
            //    sw.Write($"{x.Tema};");
            //    sw.Write($"{x.Turno};");
            //    sw.Write($"{x.Cuota};");
            //    sw.Write($"{x.Inscripcion};\n");
            //    sw.Write($"Docente: ;{x.Docente.Nombre};{x.Docente.Apellido};\n");
            //    foreach (Alumno a in x.ListaDeAlumnos)
            //    {
            //        sw.Write($"Alumno: ;{a.Nombre};{a.Apellido};\n");
            //    }
            //}
            //sw.Close();

            sw.Write($"{cursos.ElementAt(lbxcursoM.SelectedIndex).Tema};");
            sw.Write($"{cursos.ElementAt(lbxcursoM.SelectedIndex).Turno};");
            sw.Write($"{cursos.ElementAt(lbxcursoM.SelectedIndex).Cuota};");
            sw.Write($"{cursos.ElementAt(lbxcursoM.SelectedIndex).Inscripcion};\n");
            sw.Write($"Docente: ;{cursos.ElementAt(lbxcursoM.SelectedIndex).Docente.Nombre};{cursos.ElementAt(lbxcursoM.SelectedIndex).Docente.Apellido};\n");
            foreach (Alumno a in cursos.ElementAt(lbxcursoM.SelectedIndex).ListaDeAlumnos)
            {
                sw.Write($"Alumno: ;{a.Nombre};{a.Apellido};\n");
            }
            sw.Close();
        }
    }
}
