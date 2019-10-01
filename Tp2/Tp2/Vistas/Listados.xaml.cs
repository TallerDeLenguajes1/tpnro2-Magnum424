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
    /// Interaction logic for Listados.xaml
    /// </summary>
    public partial class Listados : Window
    {
        //Creo el alumno en el cual voy a guardar los datos de entrada
        Alumno alumnito;
        public Listados(BindingList<Alumno> lista)
        {
            InitializeComponent();

        }
    }
}
