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
        //Creo un empleado para llenarlo con los datos de entrada
        Personal empleado;
        public VentanaPersonal(BindingList<Personal> personal)
        {
            InitializeComponent();
            //Tomo como fuente del listbox la lista que entra
            listBox.ItemsSource = personal;
        }
        //Armo un getter de personal
        public Personal GetPersonal()
        {
            return empleado;
        }
        //Creo el evento para agregar los datos al empleado
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Controlo vagamente que los campos no sean nulos o espacios en blanco
            if (!string.IsNullOrWhiteSpace(textBox.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(date.Text))
            {
                //Armo el alumno con el constructor de la clase
                empleado = new Personal(textBox.Text, textBox1.Text, .DisplayDate, textBox2.Text,, Convert.ToSingle(textBox3.Text));
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
}
