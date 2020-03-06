using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

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
        }

        /// <summary>
        /// Evento asociado al click sobre Jugar. Navega hacia la pagina principal de juego.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Jugar_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), terror);
        }

        /*private void navigateTo(object sender, TappedRoutedEventArgs e) {
            string name = ((TextBlock)sender).Name;
            switch (name) {
                case "jugar":
                    this.Frame.Navigate(typeof(MainPage), terror);
                    break;
                case "inf":
                    this.Frame.Navigate(typeof(Informacion));
                    break;
                case "stats":
                    this.Frame.Navigate(typeof(Estadisticas));
                    break;
            }
        }*/

        //Podriamos unir estos 3 metodos en 1 solo (Vease el metodo comentado de arriba) Pero es mas costoso en terminos de rendimiento.

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
            if(mod.Text == "MODO TERROR")
            {
                mod.Text = "MODO BROMA";
                terror = false;
            }
            else
            {
                mod.Text = "MODO TERROR";
                terror = true;
            }
        }

        //Estos 2 metodos nos sirven para resaltar y apagar los stackpanel sobre los que se pase el cursor.
        private void StackPanel_PointerEntered(object sender, PointerRoutedEventArgs e) {
            (sender as StackPanel).Background = new SolidColorBrush(Colors.Gray);
        }

        private void StackPanel_PointerExited(object sender, PointerRoutedEventArgs e) {
            (sender as StackPanel).Background = new SolidColorBrush(Colors.Transparent);
        }
    }
}
