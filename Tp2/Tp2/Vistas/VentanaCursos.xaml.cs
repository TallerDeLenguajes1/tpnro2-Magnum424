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
        //Creo una lista de alumnos para pasar la lista que entra otra ventana
        BindingList<Alumno> lista;
        public VentanaCursos(BindingList<Personal> empleados, BindingList<Alumno> alumnos,int i)
        {
            InitializeComponent();
            lbxpersonal.ItemsSource = empleados;
            lista = alumnos;
            empleado = new Personal();
            inscriptos = new BindingList<Alumno>();
            //Reviso que curso voy a crear
            switch (i)
            {
                case 1:
                    cursito = new Presencial();
                    break;
                case 2:
                    cursito = new SemiPresencial();
                    break;
                case 3:
                    cursito = new NoPresencial();
                    break;
                default:
                    break;
            }

        }
        //Armo un getter del curso
        public Curso GetCurso()
        {
            return cursito;
        }
        //Selecciono el docente del curso y lo asigno a empleado
        private void Btndocente_Click(object sender, RoutedEventArgs e)
        {
            if (lbxpersonal.SelectedItem != null)
            {
                empleado = (Personal)lbxpersonal.SelectedItem;
            }
            else
            {
                MessageBox.Show("Seleccione un empleado");
            }
        }
        //El boton revisar lista me manda a otra ventana en la cual voy agregando alumnos a la lista de la ventana de cursos
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Creo una instancia de la ventana  
            Listados revList = new Listados(lista);
            //Abro la ventana
            revList.ShowDialog();
            //Tomo el alumno que viene y lo agrego a la lista
            inscriptos.Add(revList.GetAlumno());
        }

        private void Btnagregarcurso_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txbtema.Text) && !string.IsNullOrEmpty(txbcuota.Text) && !string.IsNullOrEmpty(txbinscripcion.Text) && !string.IsNullOrEmpty(cbbturno.Text) && empleado != null)
            {
                cursito.CrearCurso(txbtema.Text,empleado,cbbturno.Text,inscriptos,Convert.ToSingle(txbcuota.Text),Convert.ToSingle(txbinscripcion.Text));
                this.Close();
            }
            else
            {
                MessageBox.Show("Revise que esté colocando los valores correctamente");
            }
        }
    }
}
