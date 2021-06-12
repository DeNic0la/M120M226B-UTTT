using M120_226B_UTT_Project.GamePlay.Model;
using M120_226B_UTT_Project.GamePlay.ViewModel;
using M120_226B_UTT_Project.GameSetup.ViewModel;
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

namespace M120_226B_UTT_Project.GamePlay.View
{
    /// <summary>
    /// Interaktionslogik für GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window {
        public GameWindow(GameSetupViewModel setupData) {
            InitializeComponent();
            BasicFieldModel bfm = new BasicFieldModel(true);
            this.DataContext = new UltimateFieldViewModel(bfm, setupData);
        }
    }
}
