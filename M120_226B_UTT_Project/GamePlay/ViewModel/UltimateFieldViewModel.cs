using M120_226B_UTT_Project.GamePlay.Model;
using M120_226B_UTT_Project.GameSetup.ViewModel;
using M120_226B_UTT_Project.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace M120_226B_UTT_Project.GamePlay.ViewModel
{
    public class UltimateFieldViewModel : ObservableObject
    {
        private BasicFieldViewModel[] SubViewModels;
        public BasicFieldViewModel SubModel1
        {
            get
            {
                return SubViewModels[0];
            }
        }
        public BasicFieldViewModel SubModel2
        {
            get
            {
                return SubViewModels[1];
            }
        }
        public BasicFieldViewModel SubModel3
        {
            get
            {
                return SubViewModels[2];
            }
        }
        public BasicFieldViewModel SubModel4
        {
            get
            {
                return SubViewModels[3];
            }
        }
        public BasicFieldViewModel SubModel5
        {
            get
            {
                return SubViewModels[4];
            }
        }
        public BasicFieldViewModel SubModel6
        {
            get
            {
                return SubViewModels[5];
            }
        }
        public BasicFieldViewModel SubModel7
        {
            get
            {
                return SubViewModels[6];
            }
        }
        public BasicFieldViewModel SubModel8
        {
            get
            {
                return SubViewModels[7];
            }
        }
        public BasicFieldViewModel SubModel9
        {
            get
            {
                return SubViewModels[8];
            }
        }

        private BasicFieldModel fieldModel;
        public UltimateFieldViewModel(BasicFieldModel fieldModel, GameSetupViewModel setupData)
        {
            SubViewModels = new BasicFieldViewModel[9];
            for (int i = 0; i < fieldModel.Fields.Length; i++)
            {
                SubViewModels[i] = new BasicFieldViewModel((BasicFieldModel)fieldModel.Fields[i], i);
            }


            _PlayerX = setupData.PlayerXName;
            if (setupData.Enemy_Player)
            {
                _PlayerO = setupData.PlayerOName;
            }
            else if (setupData.Enemy_Bot)
            {
                _BotLevel = setupData.BotDifficulty;
            }

            _ScoreX = 0;
            _ScoreO = 0;

            GameManager.Turn = setupData.First_X ? Turn.X : Turn.O;
            GameManager.LastMovePostion = 10;

            fieldModel.PropertyChanged += FieldModel_PropertyChanged;
            this.fieldModel = fieldModel;


        }

        private void FieldModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FieldState")
            {
                //TODO Check For Win and Update Stats
                if (fieldModel.FieldState == FieldState.X)
                {
                    _ScoreX++;
                    MessageBox.Show("X Hat gewonnen");
                }
                else if (fieldModel.FieldState == FieldState.O)
                {
                    _ScoreO++;
                    MessageBox.Show("O Hat gewonnen");
                }
                else if (fieldModel.FieldState == FieldState.Tie)
                {
                    MessageBox.Show("Es steht unentschieden");
                }
            }
        }

        protected string _PlayerX;
        protected string _PlayerO;

        protected int _ScoreX;
        protected int _ScoreO;

        protected int _BotLevel;


        public string PlayerXDisplay
        {
            get
            {
                return "TEST";
            }
        }

    }
}
