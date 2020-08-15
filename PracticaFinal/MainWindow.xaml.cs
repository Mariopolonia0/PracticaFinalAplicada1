using PracticaFinal.UI;
using PracticaFinal.UI.Consultas;
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

namespace PracticaFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void rAmigosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rAmigos amigos = new rAmigos();
            amigos.Show();
        }

        private void rEntradaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rEntradas entrada = new rEntradas();
            entrada.Show();
        }

        private void rJuegosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rJuegos juegos = new rJuegos();
            juegos.Show();
        }

        private void rPrestamoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rPrestamos prestamos = new rPrestamos();
            prestamos.Show();
        }

        private void cAmigosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cAmigos camigo = new cAmigos();
            camigo.Show();
        }
    }
}
