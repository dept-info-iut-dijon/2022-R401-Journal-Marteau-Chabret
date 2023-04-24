using Client.Network;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User userConnected;
        public MainWindow()
        {
            InitializeComponent();

            // User
            userConnected = new User();
            userConnected.Id = 50;
            userConnected.Login = "fm427410";
            userConnected.Password = "fm427410";
            userConnected.Name = "Marteau Florian";
        }

        private void Boutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenDiaryWindow(object sender, RoutedEventArgs e)
        {
            DiaryWindow win = new DiaryWindow(userConnected, new NetworkClient());
            win.Show();
        }
    }
}
