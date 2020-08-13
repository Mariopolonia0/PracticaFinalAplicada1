using PracticaFinal.BLL;
using PracticaFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticaFinal.UI
{
    /// <summary>
    /// Interaction logic for rEntradas.xaml
    /// </summary>
    public partial class rEntradas : Window
    {

        private Entradas entrada = new Entradas();
        public rEntradas()
        {
            InitializeComponent();
            this.DataContext = entrada;
            EntradaIdTextBox.Text = "0";
            this.entrada.EntradaId = 1;
            entrada.Fecha = DateTime.Now;
        }

        private void Limpiar()
        {
            Entradas entrada = new Entradas();
            this.DataContext = entrada;
            EntradaIdTextBox.Text = "0";
            entrada.Fecha = DateTime.Now;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (EntradaIdTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Producto Id está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                EntradaIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (JuegoIdTextBox.Text.Length == 0 | Convert.ToInt32(JuegoIdTextBox.Text) == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Descripcion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                JuegoIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            /*
            if (DireccionTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Precio está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DireccionTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (CelularTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("UsuarioId está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CelularTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (EmailTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("ITBIS está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (FechaDatePicker.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Fecha está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                FechaDatePicker.Focus();
                GuardarButton.IsEnabled = true;
            }
            */
            return esValido;
        }


        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EntradasBLL.Eliminar(Convert.ToInt32(EntradaIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Producto eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el producto", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var entrada = EntradasBLL.Buscar(int.Parse(EntradaIdTextBox.Text));

            if (entrada != null)
            {
                this.entrada = entrada;
            }
            else
            {
                this.entrada = new Entidades.Entradas();
                MessageBox.Show("El Producto no existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            this.DataContext = this.entrada;
        }

        private void NuevoButton_Click_1(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            Juegos juegos = JuegosBLL.Buscar(Convert.ToInt32(JuegoIdTextBox.Text)); ;
            juegos.Existencia += entrada.Cantidad;
            JuegosBLL.Modificar(juegos);

            var paso = EntradasBLL.Guardar(entrada);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transacción exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transacción Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
