using OpenTK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PracticaFinal.BLL
{
    class Utilidades
    {

        public static bool ValidarSoloNumeros(KeyEventArgs v)
        {

            if ( "D1" == v.Key.ToString() || "D2" == v.Key.ToString() || "D3" == v.Key.ToString() || 
                 "D4" == v.Key.ToString() || "D5" == v.Key.ToString() || "D6" == v.Key.ToString() || 
                 "D7" == v.Key.ToString() || "D8" == v.Key.ToString() || "D9" == v.Key.ToString() || 
                 "D0" == v.Key.ToString() || "NumPad0" == v.Key.ToString() || "NumPad1" == v.Key.ToString() 
                 || "NumPad2" == v.Key.ToString() || "NumPad3" == v.Key.ToString() || "NumPad4" == v.Key.ToString() 
                 || "NumPad5" == v.Key.ToString() || "NumPad6" == v.Key.ToString() || "NumPad7" == v.Key.ToString() 
                 || "NumPad8" == v.Key.ToString() || "NumPad9" == v.Key.ToString())
            {
                v.Handled = false;
            }
            else 
            {
                v.Handled = true;
                MessageBox.Show("Solo Puede Digitar Numero", "Informacion Importante", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return v.Handled;
        }
    }
}

