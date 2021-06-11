﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_226B_UTT_Project {
    public class BasicFieldViewModel : ObservableObject {
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
        private BasicFieldModel fieldModel;
        public BasicFieldViewModel(BasicFieldModel fieldModel) {
            this.fieldModel = fieldModel;
            SubViewModels = new SingleFieldViewModel[9];
            for (int i = 0; i < fieldModel.Fields.Length; i++) {
                SubViewModels[i] = new SingleFieldViewModel((SingleFieldModel)fieldModel.Fields[i]);
            }
            fieldModel.PropertyChanged += FieldModel_PropertyChanged;
        }

        private void FieldModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //Disable Childs Button Click.
            if (fieldModel.FieldState != FieldState.Empty)
            {
                for(int i = 0; i < 9; i++)
                {
                    SubViewModels[i].FieldClickCommand = null;
                }
            }
        }
    }
}
