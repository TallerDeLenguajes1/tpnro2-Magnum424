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
        //Defino un curso 
        Curso cursito;
        //Y una lista de cursos
        BindingList<Curso> cursitos;
        //Asi como un bool y un entero, para guardar los datos que entran y asi poder modificarlos
        bool mod2;
        int pos;
        //Creo una lista de alumnos para pasar la lista que entra otra ventana
        BindingList<Alumno> lista;
        public VentanaCursos(BindingList<Curso> cursos, BindingList<Personal> empleados, BindingList<Alumno> alumnos,int i, bool mod)
        {
            InitializeComponent();
            //Asigno el source de la lbx
            lbxpersonal.ItemsSource = empleados;
            //Le asigno a las listas que yo tengo las listas que entran
            lista = alumnos;
            cursitos = cursos;
            //Tomo el bool que entra y lo asigno para poder usarlo
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
        //Armo un getter de lista de cursos
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
            //Al agregar el curso verifico si estoy agregando o modificando utilizando el bool mod2
            if (mod2 == true)
            {
                //Reviso que no esten vacios
                if (!string.IsNullOrEmpty(txbtema.Text) && !string.IsNullOrEmpty(txbcuota.Text) && !string.IsNullOrEmpty(txbinscripcion.Text) && !string.IsNullOrEmpty(cbbturno.Text) && empleado != null)
                {
                    //Creo el curso y lo agrego a la lista que voy a devolver
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
                //Verifico que nada este en null
                if (!string.IsNullOrEmpty(txbtema.Text) && !string.IsNullOrEmpty(txbcuota.Text) && !string.IsNullOrEmpty(txbinscripcion.Text) && !string.IsNullOrEmpty(cbbturno.Text) && empleado != null)
                {
                    //Modifico el elemento en la posisicion pos con los nuevos datos que se cargaron
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
        //El constructor para modificar los cursos
        public VentanaCursos(BindingList<Curso> cursos, Curso curso, BindingList<Personal> empleados, BindingList<Alumno> alumnos, int i, bool mod, int index)
        {
            InitializeComponent();
            //Coloco todos los datos que entran en sus respectivos lugares
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
