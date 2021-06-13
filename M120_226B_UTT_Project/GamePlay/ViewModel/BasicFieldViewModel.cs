using M120_226B_UTT_Project.GamePlay.Model;
using M120_226B_UTT_Project.Helper;
using System.Windows.Media;

namespace M120_226B_UTT_Project.GamePlay.ViewModel
{
    public class BasicFieldViewModel : ObservableObject, IObserver
    {
        public SingleFieldViewModel[] SubViewModels;
        public SingleFieldViewModel SubModel1
        {
            get
            {
                return SubViewModels[0];
            }
        }
        public SingleFieldViewModel SubModel2
        {
            get
            {
                return SubViewModels[1];
            }
        }
        public SingleFieldViewModel SubModel3
        {
            get
            {
                return SubViewModels[2];
            }
        }
        public SingleFieldViewModel SubModel4
        {
            get
            {
                return SubViewModels[3];
            }
        }
        public SingleFieldViewModel SubModel5
        {
            get
            {
                return SubViewModels[4];
            }
        }
        public SingleFieldViewModel SubModel6
        {
            get
            {
                return SubViewModels[5];
            }
        }
        public SingleFieldViewModel SubModel7
        {
            get
            {
                return SubViewModels[6];
            }
        }
        public SingleFieldViewModel SubModel8
        {
            get
            {
                return SubViewModels[7];
            }
        }
        public SingleFieldViewModel SubModel9
        {
            get
            {
                return SubViewModels[8];
            }
        }
        private BasicFieldModel fieldModel;
        private int ownFieldPosition;
        public BasicFieldViewModel(BasicFieldModel fieldModel, int fieldPostion)
        {
            _BackgroundColor = defaultColor;
            ownFieldPosition = fieldPostion;
            this.fieldModel = fieldModel;
            SubViewModels = new SingleFieldViewModel[9];
            for (int i = 0; i < fieldModel.Fields.Length; i++)
            {
                SubViewModels[i] = new SingleFieldViewModel((SingleFieldModel)fieldModel.Fields[i], i, fieldPostion);
            }
            fieldModel.PropertyChanged += FieldModel_PropertyChanged;
            GameManager.Subscribe(this);

        }
        private Color _BackgroundColor;
        public SolidColorBrush BackgroundColor
        {
            get
            {
                return new SolidColorBrush(_BackgroundColor);
            }
            set
            {
                _BackgroundColor = value.Color;
                RaisePropertyChanged("BackgroundColor");
            }
        }
        private Color defaultColor = Color.FromRgb(191, 191, 191);
        private Color markingColor = Color.FromRgb(27, 196, 58);

        private void FieldModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Disable Childs Button Click.
            if (fieldModel.FieldState != FieldState.Empty)
            {
                for (int i = 0; i < 9; i++)
                {
                    SubViewModels[i].FieldClickCommand = null;
                }
                GameManager.CompletedField = ownFieldPosition;
            }
        }

        public void ExecuteOnUpdate(string propertyName)
        {
            //TODO Change Background if this is a Playable field
            if (propertyName == "LastMovePosition")
            {
                _BackgroundColor = defaultColor;
                if (GameManager.LastMovePostion == 10 || GameManager.LastMovePostion == ownFieldPosition)
                {
                    _BackgroundColor = markingColor;
                }
                RaisePropertyChanged("BackgroundColor");
            }

        }
    }
}
