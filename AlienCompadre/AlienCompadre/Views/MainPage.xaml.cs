﻿using AlienCompadre.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class MainPage : Page
    {
        ClsMainPageVM viewModel { get; set; }
        public MainPage(){
            this.InitializeComponent();
            //this.DataContext = new ClsMainPageVM();
            viewModel = (ClsMainPageVM)this.DataContext;
            /*
            if (viewModel.Repeat)
            {
                this.DataContext = new ClsMainPageVM();
                viewModel = (ClsMainPageVM)this.DataContext;
                viewModel.Repeat = false;
            }
            */
            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            bool broma = (Boolean)e.Parameter;
            /*
            Frame frame = (Frame)Window.Current.Content;
            frame.DataContext = new ClsMainPageVM();
            frame.Navigate(typeof(MainPage));
            frame.BackStack.Clear();
            */
            //this.Content = null;
            /*
            if(viewModel.Repeat)
            {
                this.DataContext = new ClsMainPageVM();
                viewModel = (ClsMainPageVM)this.DataContext;
                viewModel.Repeat = false;
            }*/
            viewModel.ModoBroma = broma;
        }

        private void CoreWindow_CharacterReceived(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.CharacterReceivedEventArgs args) {
            if (viewModel.Repeat)
            {
                this.DataContext = new ClsMainPageVM();
                viewModel = (ClsMainPageVM)this.DataContext;
                viewModel.Repeat = false;
            }

            if (args.KeyCode == 119) //Arriba
            {
                viewModel.tryMoveCharacter('u');
            }
            if (args.KeyCode == 115) //Abajo
            {
                viewModel.tryMoveCharacter('d');
            }
            if (args.KeyCode == 97) { //Izquierda
                viewModel.tryMoveCharacter('l');
            }

            if (args.KeyCode == 100) { //Derecha
                viewModel.tryMoveCharacter('r');
            }
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    // Set the input focus to ensure that keyboard events are raised.
        //    this.Loaded += delegate { this.Focus(FocusState.Programmatic); };
        //}


        //private void allowfocus_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Window.Current.Content.KeyDown += Grid_KeyDown;
        //}

        //private static bool IsCtrlKeyPressed()
        //{
        //    var ctrlState = CoreWindow.GetForCurrentThread().GetKeyState(VirtualKey.Control);
        //    return (ctrlState & CoreVirtualKeyStates.Down) == CoreVirtualKeyStates.Down;
        //}

        ///// <summary>
        ///// Evento que se da al pulsar una tecla, en este caso, W y S para mover la barra
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        //{
        //    if (IsCtrlKeyPressed())
        //    {
        //        switch (e.Key)
        //        {
        //            case VirtualKey.Up:
        //                viewModel.tryMoveCharacter('u');//Intentamos mover al personaje hacía arriba
        //                break;
        //            case VirtualKey.Down:
        //                viewModel.tryMoveCharacter('d');//Intentamos mover al personaje hacía abajo
        //                break;
        //            case VirtualKey.Right:
        //                viewModel.tryMoveCharacter('r');//Intentamos mover al personaje hacía la derecha
        //                break;
        //            case VirtualKey.Left:
        //                viewModel.tryMoveCharacter('l');//Intentamos mover al personaje hacía la izquierda
        //                break;
        //        }
        //    }
            
        //}
    }
}
