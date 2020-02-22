using AlienCompadre.ViewModel;
using AlienCompadre_Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace AlienCompadre.Views{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PantallaFinal : Page{
        ClsPantallaFinalVM vm { get; set; }
        private bool canSave; //Asi controlamos que no pueda subir sus datos mas de una vez por partida. Hecho asi porque isTapped = false no funcionaba.
        public PantallaFinal(){
            this.InitializeComponent();
            vm = (ClsPantallaFinalVM)this.DataContext;
            canSave = true;
        }

        /// <summary>
        /// Evento asociado al click de la imagen. Vuelve atras en la navegacion si es posible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BitmapIcon_Tapped(object sender, TappedRoutedEventArgs e){
            if (this.Frame.CanGoBack) {
                //this.Frame.GoBack();
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            int puntuacion = (int)e.Parameter;
            vm.Estadisticas.Score = puntuacion;
        }

        /// <summary>
        /// Evento asociado al click de la imagen, sube los datos de la partida al servidor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Tapped(object sender, TappedRoutedEventArgs e) {
            if (canSave) {
                if(vm.subirDatosPartida() == 1) //Asi en caso de haber error, podemos subir los datos luego porque no se bloquea.
                    canSave = false;
            }
        }

        /// <summary>
        /// Evento asociado al click, navega hacia la pagina de menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BitmapIcon_Tapped_1(object sender, TappedRoutedEventArgs e) {
            this.Frame.Navigate(typeof(MenuPrincipal));
        }
    }
}
