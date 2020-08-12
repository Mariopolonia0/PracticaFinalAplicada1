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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class rAmigos : Window
    {
        private Amigos amigo = new Amigos();
        public rAmigos()
        {
            InitializeComponent();
            this.DataContext = amigo;
            AmigoIdTextBox.Text = "0";
            this.amigo.AmigoId = 1;
            amigo.FechaNacimiento = DateTime.Now;
            /*SexoComboBox.ItemsSource = ClientesBLL.GetClientes();
            SexoComboBox.SelectedValuePath = "Clientes";
            SexoComboBox.DisplayMemberPath = "Sexo";*/
        }

        private void Limpiar()
        {
            AmigoIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            CelularTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            //FechaDatePicker.SelectedDate = DateTime.Now;

        }

        private bool Validar()
        {
            bool esValido = true;

            if (AmigoIdTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Producto Id está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                AmigoIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Descripcion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

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
            
            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
        
            if (!Validar())
                return;

            var paso = AmigosBLL.Guardar(amigo);

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

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AmigosBLL.Eliminar(Convert.ToInt32(AmigoIdTextBox.Text)))
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
            var amigo = AmigosBLL.Buscar(int.Parse(AmigoIdTextBox.Text));

            if (amigo != null)
            {
                this.amigo = amigo;
            }
            else
            {
                this.amigo = new Entidades.Amigos();
                MessageBox.Show("El Producto no existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            this.DataContext = this.amigo;
        }
    }
}
