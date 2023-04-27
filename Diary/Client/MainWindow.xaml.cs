using Client.Network;
using Client.ViewModels;
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

        /// <summary>
        /// Représente l'étudiant qui est connecté
        /// </summary>
        private User userConnected;

        /// <summary>
        /// Permet d'accéder à l'api
        /// </summary>
        private INetworkClient networkClient;

        /// <summary>
        /// Constructeur de la mainwindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.networkClient = new NetworkClient();
        }


        /// <summary>
        /// Permet de se connecter au diary de l'étudiant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Connexion(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = await networkClient.GetStudent(this.login.Text,this.password.Password);
                this.userConnected = student;
                DiaryWindow win = new DiaryWindow(userConnected, networkClient);
                win.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
