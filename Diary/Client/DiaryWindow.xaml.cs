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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Logique d'interaction pour DiaryWindow.xaml
    /// </summary>
    public partial class DiaryWindow : Window
    {
        /// <summary>
        /// Représente le VM du diary
        /// </summary>
        private DiaryViewModel diaryViewModel;

        /// <summary>
        /// Constructeur du constructeur de la fenêtre
        /// </summary>
        /// <param name="user"></param>
        /// <param name="network"></param>
        public DiaryWindow(User user, INetworkClient network)
        {
            InitializeComponent();
            this.Init(user, network);
           
        }

        /// <summary>
        /// Initialise la liste d'entries
        /// </summary>
        /// <param name="student"></param>
        /// <param name="net"></param>
        private async void Init(User student, INetworkClient net)
        {
            Diary model = await net.GetDiary(student);
            Categories cat = await net.ReadCategories();
            diaryViewModel = new DiaryViewModel(model, cat,net);
            this.DataContext = diaryViewModel;

        }

        /// <summary>
        /// Permet de valider les changements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validate(object sender, RoutedEventArgs e)
        {
            diaryViewModel.SaveEntry();
        }

        /// <summary>
        /// Permet de créer une nouvelle entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateEntry(object sender, RoutedEventArgs e)
        {
            diaryViewModel.AddEntry();
        }
    }
}
