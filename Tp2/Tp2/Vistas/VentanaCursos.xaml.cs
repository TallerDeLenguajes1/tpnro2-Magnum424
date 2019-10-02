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
        Personal empleado = new Personal();
        BindingList<Alumno> inscriptos = new BindingList<Alumno>();
        Curso cursito;
        BindingList<Curso> cursitos;
        bool mod2;
        int pos;
        //Creo una lista de alumnos para pasar la lista que entra otra ventana
        BindingList<Alumno> lista;
        public VentanaCursos(BindingList<Curso> cursos, BindingList<Personal> empleados, BindingList<Alumno> alumnos,int i, bool mod)
        {
            InitializeComponent();
            lbxpersonal.ItemsSource = empleados;
            lista = alumnos;
            cursitos = cursos;
            mod2 = mod;
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
            }
        }
        //Armo un getter del curso
        public BindingList<Curso> GetListaNueva()
        {
            return cursitos;
        }
        //Selecciono el docente del curso y lo asigno a empleado
        private void Btndocente_Click(object sender, RoutedEventArgs e)
        {
            if (lbxpersonal.SelectedItem != null)
            {
                empleado = (Personal)lbxpersonal.SelectedItem;
                MessageBox.Show("Empleado cargado");
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
            if (mod2 == true)
            {
                if (!string.IsNullOrEmpty(txbtema.Text) && !string.IsNullOrEmpty(txbcuota.Text) && !string.IsNullOrEmpty(txbinscripcion.Text) && !string.IsNullOrEmpty(cbbturno.Text) && empleado != null)
                {
                    cursito.CrearCurso(txbtema.Text, empleado, cbbturno.Text, inscriptos, Convert.ToSingle(txbcuota.Text), Convert.ToSingle(txbinscripcion.Text));
                    cursitos.Add(cursito);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Revise que esté colocando los valores correctamente");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txbtema.Text) && !string.IsNullOrEmpty(txbcuota.Text) && !string.IsNullOrEmpty(txbinscripcion.Text) && !string.IsNullOrEmpty(cbbturno.Text) && empleado != null)
                {
                    cursitos.ElementAt(pos).Tema = txbtema.Text;
                    cursitos.ElementAt(pos).Cuota = Convert.ToSingle(txbcuota.Text);
                    cursitos.ElementAt(pos).Inscripcion = Convert.ToSingle(txbinscripcion.Text);
                    cursitos.ElementAt(pos).ListaDeAlumnos = inscriptos;
                    cursitos.ElementAt(pos).Docente = empleado;
                    cursitos.ElementAt(pos).Turno = cbbturno.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Revise que esté colocando los valores correctamente");
                }
            }
        }
        public VentanaCursos(BindingList<Curso> cursos, Curso curso, BindingList<Personal> empleados, BindingList<Alumno> alumnos, int i, bool mod, int index)
        {
            InitializeComponent();
            lbxpersonal.ItemsSource = empleados;
            lista = alumnos;
            cursitos = cursos;
            mod2 = mod;
            pos = index;
            txbtema.Text = curso.Tema;
            txbcuota.Text = curso.Cuota.ToString();
            txbinscripcion.Text = curso.Inscripcion.ToString();
            cbbturno.Text = curso.Turno;
            inscriptos = curso.ListaDeAlumnos;
        }
    }
}
