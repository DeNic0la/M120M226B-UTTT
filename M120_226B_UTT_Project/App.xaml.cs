using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace M120_226B_UTT_Project {
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            GameSetupWindow setupWindow = new GameSetupWindow();
            setupWindow.Show();           


            

        }

        private void startGame(GameSetupWindow setupWindow)
        {
            setupWindow.Close();
            GameWindow game = new GameWindow();
            game.Show();
        }
    }

}
