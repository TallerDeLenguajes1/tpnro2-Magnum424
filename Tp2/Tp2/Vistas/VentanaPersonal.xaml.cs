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
    /// Interaction logic for VentanaPersonal.xaml
    /// </summary>
    public partial class VentanaPersonal : Window
    {
        //Creo un empleado para llenarlo con los datos de entrada y una lista para guardar y modificar
        Personal empleado;
        BindingList<Personal> empleados;
        bool mod2;
        int pos;
        public VentanaPersonal(BindingList<Personal> personal, bool mod)
        {
            InitializeComponent();
            //Tomo como fuente del listbox la lista que entra
            lbxempleados.ItemsSource = personal;
            empleados = personal;
            mod2 = mod;
        }
        //Armo un getter de la lista de empleados
        public BindingList<Personal> GetListaNueva()
        {
            return empleados;
        }
        //Creo el evento para agregar los datos al empleado
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (mod2 == true)
            {
                //Controlo vagamente que los campos no sean nulos o espacios en blanco
                if (!string.IsNullOrWhiteSpace(txbnombre.Text) && !string.IsNullOrWhiteSpace(txbapellido.Text) && !string.IsNullOrWhiteSpace(txbdni.Text) && !string.IsNullOrWhiteSpace(dtpfecnac.Text) && !string.IsNullOrWhiteSpace(dtpfecalta.Text) && !string.IsNullOrWhiteSpace(txbsueldo.Text))
                {
                    //Armo el alumno con el constructor de la clase
                    empleado = new Personal(txbnombre.Text, txbapellido.Text, dtpfecnac.DisplayDate, txbdni.Text, dtpfecalta.DisplayDate, Convert.ToSingle(txbsueldo.Text));
                    empleados.Add(empleado);
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
                if (!string.IsNullOrWhiteSpace(txbnombre.Text) && !string.IsNullOrWhiteSpace(txbapellido.Text) && !string.IsNullOrWhiteSpace(txbdni.Text) && !string.IsNullOrWhiteSpace(dtpfecnac.Text) && !string.IsNullOrWhiteSpace(dtpfecalta.Text) && !string.IsNullOrWhiteSpace(txbsueldo.Text))
                {
                    empleados.ElementAt(pos).Nombre = txbnombre.Text;
                    empleados.ElementAt(pos).Apellido = txbapellido.Text;
                    empleados.ElementAt(pos).DNI = txbdni.Text;
                    empleados.ElementAt(pos).FechaDeNacimiento = dtpfecnac.DisplayDate;
                    empleados.ElementAt(pos).FechaDeAlta = dtpfecalta.DisplayDate;
                    empleados.ElementAt(pos).Sueldo = Convert.ToSingle(txbsueldo.Text);
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
        //Armo el constructor para modificar personal
        public VentanaPersonal(BindingList<Personal> personal, Personal empleado, int index, bool mod)
        {
            InitializeComponent();
            //Coloco todos los datos donde corresponden
            empleados = personal;
            lbxempleados.ItemsSource = personal;
            txbnombre.Text = empleado.Nombre;
            txbapellido.Text = empleado.Apellido;
            txbdni.Text = empleado.DNI;
            dtpfecnac.DisplayDate = empleado.FechaDeNacimiento;
            dtpfecnac.SelectedDate = empleado.FechaDeNacimiento;
            dtpfecalta.DisplayDate = empleado.FechaDeAlta;
            dtpfecalta.SelectedDate = empleado.FechaDeNacimiento;
            txbsueldo.Text = empleado.Sueldo.ToString();
            pos = index;
        }
    }
}
