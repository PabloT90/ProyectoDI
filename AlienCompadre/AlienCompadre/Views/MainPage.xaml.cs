﻿using AlienCompadre.ViewModel;
using AlienCompadre.Views;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace AlienCompadre
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page{
        ClsMainPageVM viewModel { get; set; }
        public MainPage(){
            this.InitializeComponent();
            viewModel = (ClsMainPageVM)this.DataContext;
            NavigationCacheMode = NavigationCacheMode.Enabled; //Para que no instancie varios ViewModels.
            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            if (e.Parameter != null) { //Necesario porque si estamos en la pantalla final y queremos volver aqui nos pondria el modo broma aunque no queramos.
                bool broma = (Boolean)e.Parameter;
                viewModel.ModoBroma = broma;
            }
            viewModel.Repeat = true;
        }

        /// <summary>
        /// Evento asociado a la entrada de teclado. Se activa cuando se pulsa sobre alguna tecla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CoreWindow_CharacterReceived(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.CharacterReceivedEventArgs args) {
            if (viewModel.Repeat) {
                if (args.KeyCode == 119){ //Arriba
                    viewModel.tryMoveCharacter('u');
                } else if (args.KeyCode == 115) { //Abajo
                    viewModel.tryMoveCharacter('d');
                } else if (args.KeyCode == 97) { //Izquierda
                    viewModel.tryMoveCharacter('l');
                } else if (args.KeyCode == 100) { //Derecha
                    viewModel.tryMoveCharacter('r');
                } else if (args.KeyCode == 27) { //Si pulsa escape
                    viewModel.ReiniciarJuego();
                    this.Frame.Navigate(typeof(MenuPrincipal));
                }
            }
        }
    }
}
