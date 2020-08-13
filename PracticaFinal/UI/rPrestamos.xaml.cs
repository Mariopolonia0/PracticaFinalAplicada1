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
    /// Interaction logic for rPrestamos.xaml
    /// </summary>
    public partial class rPrestamos : Window
    {

        private Prestamos prestamo = new Prestamos();
        public rPrestamos()
        {
            InitializeComponent();
            this.DataContext = prestamo;
            this.prestamo.PrestamoId = 1;
            prestamo.Fecha = DateTime.Now;

            JuegoIdComboBox.ItemsSource = JuegosBLL.GetJuegos();
            JuegoIdComboBox.SelectedValuePath = "JuegoId";
            JuegoIdComboBox.DisplayMemberPath = "JuegoId";

            AmigoIdComboBox.ItemsSource = AmigosBLL.GetAmigos();
            AmigoIdComboBox.SelectedValuePath = "AmigoId";
            AmigoIdComboBox.DisplayMemberPath = "AmigoId";
        }

        private void Limpiar()
        {
            Prestamos prestamo = new Prestamos();
            this.DataContext = prestamo;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = prestamo;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (PrestamoIdTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Prestamo Id está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                PrestamoIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (AmigoIdComboBox.SelectedItem == null)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Amigo Id está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                AmigoIdComboBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ObservacionTextbox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Observacion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ObservacionTextbox.Focus();
                GuardarButton.IsEnabled = true;
            }


            return esValido;
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            if (!Validar())
                return;

            Juegos juegos = JuegosBLL.Buscar(Convert.ToInt32(JuegoIdComboBox.SelectedIndex)); ;
            juegos.Existencia -= prestamo.AmigoId;
            JuegosBLL.Modificar(juegos);

            var paso = PrestamosBLL.Guardar(prestamo);

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
            if (PrestamosBLL.Eliminar(Convert.ToInt32(PrestamoIdTextBox.Text)))
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
            var prestamo = PrestamosBLL.Buscar(int.Parse(PrestamoIdTextBox.Text));

            if (prestamo != null)
            {
                this.prestamo = prestamo;
            }
            else
            {
                this.prestamo = new Entidades.Prestamos();
                MessageBox.Show("El Producto no existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            this.DataContext = this.prestamo;
        }

        private void JuegoIdComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Juegos juego = JuegosBLL.Buscar(Convert.ToInt32(JuegoIdComboBox.SelectedValue));
            if (juego == null)
                return;
            DescripcionJuegoLabel.Content = juego.Descripcion;
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            Juegos juego = JuegosBLL.Buscar(Convert.ToInt32(JuegoIdComboBox.SelectedValue));
            
            if (juego == null)
            {
                MessageBox.Show("no se encotro bueno!");
                return;
            }

            prestamo.PrestamoDetalle.Add(new PrestamosDetalle( Convert.ToInt32(PrestamoIdTextBox.Text), Convert.ToInt32(JuegoIdComboBox.SelectedValue), Convert.ToInt32(CantidadTextBox.Text),juego.Descripcion));
            Cargar();

        }

        private void AmigoIdComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Amigos amigo = AmigosBLL.Buscar(Convert.ToInt32(AmigoIdComboBox.SelectedValue));
            if (amigo == null)
                return;

            AmigoNombreLabel.Content = amigo.Nombre;
        }
    }
}
