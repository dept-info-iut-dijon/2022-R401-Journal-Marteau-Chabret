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
        public DiaryWindow(User user, INetworkClient network)
        {
            InitializeComponent();
            this.Init(user, network);
           
        }

        private async void Init(User student, INetworkClient net)
        {
            Diary model = await net.GetDiary(student);
            DiaryViewModel d = new DiaryViewModel(model);
            this.DataContext = d;
        }
    }
}
