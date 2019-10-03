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
    /// Interaction logic for VentanaAlumnos.xaml
    /// </summary>
    public partial class VentanaAlumnos : Window
    {
        //Creo un alumno en el cual voy a cargar los datos de entrada y una lista para guardar la lista entrante
        Alumno alumno;
        BindingList<Alumno> alum;
        //Asi tambien un bool y un int para guardar el resto de los datos
        bool mod2;
        int pos;
        public VentanaAlumnos(BindingList<Alumno> alumnos, bool mod)
        {
            InitializeComponent();
            //Como ingresa la lista la utilizo para mostrar la carga de alumnos en un listbox
            lbxalumnos.ItemsSource = alumnos;
            alum = alumnos;
            mod2 = mod;
        }
        //Hago un getter de la lista de alumnos
        public BindingList<Alumno> GetListaNueva()
        {
            return alum;
        }
        //Creo el evento que va a llenar al alumno previamente creado
        private void BtnagregarA_Click(object sender, RoutedEventArgs e)
        {
            if (mod2 == true)
            {
                //Controlo vagamente que los campos no sean nulos o espacios en blanco
                if (!string.IsNullOrWhiteSpace(txbnombreA.Text) && !string.IsNullOrWhiteSpace(txbapellidoA.Text) && !string.IsNullOrWhiteSpace(txbdniA.Text) && !string.IsNullOrWhiteSpace(dtpfechanacA.Text))
                {
                    //Armo el alumno con el constructor de la clase y lo cargo a la lista que voy a devolver
                    alumno = new Alumno(txbnombreA.Text, txbapellidoA.Text, dtpfechanacA.DisplayDate, txbdniA.Text);
                    alum.Add(alumno);
                    //Cierro la ventana
                    this.Close();
                }
                else
                {
                    //En caso de ser nulo o vacio me salta una alerta
                    MessageBox.Show("Ingrese los datos correspondientes");
                }
            }
            else
            {
                //Controlo vagamente que los campos no sean nulos o espacios en blanco
                if (!string.IsNullOrWhiteSpace(txbnombreA.Text) && !string.IsNullOrWhiteSpace(txbapellidoA.Text) && !string.IsNullOrWhiteSpace(txbdniA.Text) && !string.IsNullOrWhiteSpace(dtpfechanacA.Text))
                {
                    //Reemplazo los datos existentes en la posicion indicada por los nuevos datos
                    alum.ElementAt(pos).Nombre = txbnombreA.Text;
                    alum.ElementAt(pos).Apellido = txbapellidoA.Text;
                    alum.ElementAt(pos).DNI = txbdniA.Text;
                    alum.ElementAt(pos).FechaDeNacimiento = dtpfechanacA.DisplayDate;
                    //Cierro la ventana
                    this.Close();
                }
                else
                {
                    //En caso de ser nulo o vacio me salta una alerta
                    MessageBox.Show("Ingrese los datos correspondientes");
                }
            }
            
        }
        //Genero un constructor nuevo para la modificacion de los alumnos, tomo la lista para mostrarla y un alumno para modificar
        public VentanaAlumnos(BindingList<Alumno> alumnos, Alumno alumno, int ind, bool mod)
        {
            InitializeComponent();
            alum = alumnos;
            lbxalumnos.ItemsSource = alumnos;
            txbnombreA.Text = alumno.Nombre;
            txbapellidoA.Text = alumno.Apellido;
            txbdniA.Text = alumno.DNI;
            dtpfechanacA.DisplayDate = alumno.FechaDeNacimiento;
            dtpfechanacA.SelectedDate = alumno.FechaDeNacimiento;
            pos = ind;
        }
    }
}
