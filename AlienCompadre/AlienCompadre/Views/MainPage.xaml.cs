using AlienCompadre.ViewModel;
using AlienCompadre.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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
            bool broma = (Boolean)e.Parameter;
            viewModel.Repeat = true;
            viewModel.ModoBroma = broma;
        }

        private async void CoreWindow_CharacterReceived(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.CharacterReceivedEventArgs args) {
            if (viewModel.Repeat) {
                if (args.KeyCode == 119){ //Arriba
                    viewModel.tryMoveCharacter('u');
                } else if (args.KeyCode == 115) { //Abajo
                    viewModel.tryMoveCharacter('d');
                } else if (args.KeyCode == 97) { //Izquierda
                    viewModel.tryMoveCharacter('l');
                } else if (args.KeyCode == 100) { //Derecha
                    viewModel.tryMoveCharacter('r');
                }
                for (int i =0; i< 100000000; i++) {

                }
            }
        }
    }
}
