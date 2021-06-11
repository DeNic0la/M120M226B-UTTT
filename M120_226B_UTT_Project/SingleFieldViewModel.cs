using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_226B_UTT_Project {
    public class SingleFieldViewModel : ObservableObject {
        private FieldState _fieldState;
        private SingleFieldModel _Model;
        public bool FieldIsX {
            get {
                return _fieldState == FieldState.X;
            }
            set {
                if (value == true && _fieldState != FieldState.X) {
                    _fieldState = FieldState.X;
                    _Model.FieldState = _fieldState;
                    RaisePropertyChanged("FieldIsX");
                }
            }
        }
        public bool FieldIsO {
            get {
                return _fieldState == FieldState.O;
            }
            set {
                if (value == true && _fieldState != FieldState.O) {
                    _fieldState = FieldState.O;
                    _Model.FieldState = _fieldState;
                    RaisePropertyChanged("FieldIsO");
                }
            }
        }
        public bool FieldIsEmpty {
            get {
                return _fieldState == FieldState.Empty;
            }
            set {
                if (value == true && _fieldState != FieldState.Empty) {
                    _fieldState = FieldState.Empty;
                    _Model.FieldState = _fieldState;
                    RaisePropertyChanged("FieldIsEmpty");
                }
            }
        }
        public SingleFieldViewModel(SingleFieldModel model) {

            _fieldState = model.FieldState;

            model.PropertyChanged += Model_PropertyChanged;

            _Model = model;


        }

        public string Test {
            get { return "X"; }
        }

        private void Model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (_Model.FieldState != _fieldState) {
                _fieldState = _Model.FieldState;
                RaisePropertyChanged("FieldIsEmpty");
                RaisePropertyChanged("FieldIsO");
                RaisePropertyChanged("FieldIsX");
            }

        }
    }
}
