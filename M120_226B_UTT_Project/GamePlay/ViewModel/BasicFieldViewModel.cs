using M120_226B_UTT_Project.GamePlay.Model;
using M120_226B_UTT_Project.Helper;
using System.Windows.Media;

namespace M120_226B_UTT_Project.GamePlay.ViewModel {
    public class BasicFieldViewModel : ObservableObject, IObserver {

        #region SubViewModels
        public SingleFieldViewModel[] SubViewModels;
        public SingleFieldViewModel SubModel1 {
            get {
                return SubViewModels[0];
            }
        }
        public SingleFieldViewModel SubModel2 {
            get {
                return SubViewModels[1];
            }
        }
        public SingleFieldViewModel SubModel3 {
            get {
                return SubViewModels[2];
            }
        }
        public SingleFieldViewModel SubModel4 {
            get {
                return SubViewModels[3];
            }
        }
        public SingleFieldViewModel SubModel5 {
            get {
                return SubViewModels[4];
            }
        }
        public SingleFieldViewModel SubModel6 {
            get {
                return SubViewModels[5];
            }
        }
        public SingleFieldViewModel SubModel7 {
            get {
                return SubViewModels[6];
            }
        }
        public SingleFieldViewModel SubModel8 {
            get {
                return SubViewModels[7];
            }
        }
        public SingleFieldViewModel SubModel9 {
            get {
                return SubViewModels[8];
            }
        }
        #endregion

        /// <summary>
        /// BackgroundColor for View
        /// </summary>
        public SolidColorBrush BackgroundColor {
            get {
                return new SolidColorBrush(_BackgroundColor);
            }
            set {
                _BackgroundColor = value.Color;
                RaisePropertyChanged("BackgroundColor");
            }
        }
        private Color _BackgroundColor;

        private BasicFieldModel _fieldModel;
        private int _ownFieldPosition;

        // Defining Colors
        private static readonly Color defaultColor = Color.FromRgb(191, 191, 191);
        private static readonly Color markingColor = Color.FromRgb(27, 196, 58);

        /// <summary>
        /// The ViewModel for a Basic 3 * 3 Field
        /// </summary>
        /// <param name="fieldModel">The Model for the Field</param>
        /// <param name="fieldPostion">Position/Index in field of Parent</param>
        public BasicFieldViewModel(BasicFieldModel fieldModel, int fieldPostion) {
            _BackgroundColor = defaultColor;
            _ownFieldPosition = fieldPostion;
            this._fieldModel = fieldModel;
            SubViewModels = new SingleFieldViewModel[9];
            for (int i = 0; i < fieldModel.Fields.Length; i++) {
                SubViewModels[i] = new SingleFieldViewModel((SingleFieldModel)fieldModel.Fields[i], i, fieldPostion);
            }
            fieldModel.PropertyChanged += FieldModel_PropertyChanged;
            GameManager.Subscribe(this);

        }



        #region EventHandler
        private void FieldModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (_fieldModel.FieldState != FieldState.Empty) {
                GameManager.CompletedField = _ownFieldPosition;
            }
        }

        public void ExecuteOnUpdate(string propertyName) {
            if (propertyName == "LastMovePosition") {
                _BackgroundColor = defaultColor;
                if (GameManager.LastMovePostion == 10 || GameManager.LastMovePostion == _ownFieldPosition) {
                    _BackgroundColor = markingColor;
                }
                RaisePropertyChanged("BackgroundColor");
            }

        }
        #endregion

    }
}
