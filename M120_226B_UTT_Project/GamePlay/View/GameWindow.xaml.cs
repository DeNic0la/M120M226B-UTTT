using M120_226B_UTT_Project.GamePlay.Model;
using M120_226B_UTT_Project.GamePlay.ViewModel;
using M120_226B_UTT_Project.GameSetup.ViewModel;
using System.Windows;

namespace M120_226B_UTT_Project.GamePlay.View
{
    /// <summary>
    /// Interaktionslogik für GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow(GameSetupViewModel setupData)
        {
            InitializeComponent();
            BasicFieldModel bfm = new BasicFieldModel(true);
            this.DataContext = new UltimateFieldViewModel(bfm, setupData);
        }
    }
}
