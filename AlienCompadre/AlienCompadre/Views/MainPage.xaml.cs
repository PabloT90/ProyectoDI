using AlienCompadre.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
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
    public sealed partial class MainPage : Page
    {
        ClsMainPageVM viewModel { get; set; }
    public MainPage()
        {
            this.InitializeComponent();
            viewModel = (ClsMainPageVM)this.DataContext;
        }

        /// <summary>
        /// Evento que se da al pulsar una tecla, en este caso, W y S para mover la barra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case VirtualKey.Up:
                    viewModel.tryMoveCharacter('u');//Intentamos mover al personaje hacía arriba
                    break;
                case VirtualKey.Down:
                    viewModel.tryMoveCharacter('d');//Intentamos mover al personaje hacía abajo
                    break;
                case VirtualKey.Right:
                    viewModel.tryMoveCharacter('r');//Intentamos mover al personaje hacía la derecha
                    break;
                case VirtualKey.Left:
                    viewModel.tryMoveCharacter('l');//Intentamos mover al personaje hacía la izquierda
                    break;
            }
        }
    }
}
