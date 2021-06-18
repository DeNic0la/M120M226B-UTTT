using M120_226B_UTT_Project.GameSetup.ViewModel;
using System.Windows;


namespace M120_226B_UTT_Project.GameSetup.View {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class GameSetupWindow : Window {
        public GameSetupWindow() {
            InitializeComponent();

            GameSetupViewModel vm = new GameSetupViewModel(this);
            this.DataContext = vm;
        }
    }
}
