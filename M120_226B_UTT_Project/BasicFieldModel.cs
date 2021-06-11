using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_226B_UTT_Project {
    public class BasicFieldModel : ObservableObject, IField {

        private IField[] _Fields;
        private FieldState _FieldState;
        private int _EmptySubFields;

        public BasicFieldModel(bool isUltimate = false) {
            _EmptySubFields = 9;

            if (isUltimate) {
                _Fields = new BasicFieldModel[9];
                for (int i = 0; i < 9; i++) {
                    BasicFieldModel subFieldModel = new BasicFieldModel();
                    subFieldModel.PropertyChanged += SingleFieldModel_PropertyChanged;
                    _Fields[i] = subFieldModel;
                }
            }
            else {
                _Fields = new SingleFieldModel[9];
                for (int i = 0; i < 9; i++) {
                    SingleFieldModel subFieldModel = new SingleFieldModel();
                    subFieldModel.PropertyChanged += SingleFieldModel_PropertyChanged;
                    _Fields[i] = subFieldModel;
                }
            }

            _FieldState = FieldState.Empty;

        }


        public FieldState FieldState {
            get {
                return _FieldState;
            }
            set {
                _FieldState = value;
                RaisePropertyChanged("FieldState");
            }
        }

        private void SingleFieldModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == "FieldState") {
                _EmptySubFields--;
            }
            if (_EmptySubFields <= 6 && _FieldState == FieldState.Empty) {
                FieldState before = _FieldState;
                _FieldState = Helper.ValidateFieldState(_Fields);
                if (_EmptySubFields == 0 && _FieldState == FieldState.Empty) {
                    _FieldState = FieldState.Tie;
                }
                if (before != _FieldState) {
                    RaisePropertyChanged("FieldState");
                }
            }
        }
        public IField[] Fields {
            get {
                return _Fields;
            }
        }
    }
}
