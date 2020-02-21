using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace AlienCompadre.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MenuPrincipal : Page
    {
        private bool terror;
        public MenuPrincipal()
        {
            this.InitializeComponent();
            terror = true;
            //this.Frame.BackStack.Clear();
        }

        //TODO: unir estos metodos en uno solo.

        /// <summary>
        /// Evento asociado al click sobre Jugar. Navega hacia la pagina principal de juego.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Jugar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), terror);
        }

        /// <summary>
        /// Evento asociado al click sobre estadisticas. Navega hacia la pagina de estadisticas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Estadisticas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Estadisticas));
        }

        /// <summary>
        /// Evento asociado al click sobre Informacion. Navega a la pagina de informacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Informacion));
        }

        /// <summary>
        /// Evento asociado al hacer click sobre el modo broma. Cambia de modo entre broma y original.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modos_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if(modos.Text == "MODO TERROR")
            {
                modos.Text = "MODO BROMA";
                terror = false;
            }
            else
            {
                modos.Text = "MODO TERROR";
                terror = true;
            }
        }
    }
}
