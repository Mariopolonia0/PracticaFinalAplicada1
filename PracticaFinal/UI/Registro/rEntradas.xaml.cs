﻿using PracticaFinal.BLL;
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
            JuegoIdComboBox.ItemsSource = JuegosBLL.GetJuegos();
            JuegoIdComboBox.SelectedValuePath = "JuegoId";
            JuegoIdComboBox.DisplayMemberPath = "JuegoId";
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

            if (JuegoIdComboBox.SelectedItem == null )
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Descripcion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                JuegoIdComboBox.Focus();
                GuardarButton.IsEnabled = true;
            }
           
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

        private void JuegoIdComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Juegos juego = JuegosBLL.Buscar(Convert.ToInt32(JuegoIdComboBox.SelectedValue));
            if (juego == null)
                return;

            DescripcionLabel.Content = juego.Descripcion;
        }

        private void EntradaIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilidades.ValidarSoloNumeros(e);
            //JuegoIdTextBox.Text = e.Key.ToString();
        }
    }
}
