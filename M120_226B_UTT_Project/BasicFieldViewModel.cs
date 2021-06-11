using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120_226B_UTT_Project {
    public class BasicFieldViewModel : ObservableObject {
        public SingleFieldViewModel[] SubViewModels;
        public BasicFieldViewModel(BasicFieldModel fieldModel) {
            SubViewModels = new SingleFieldViewModel[9];
            for (int i = 0; i < fieldModel.Fields.Length; i++) {
                SubViewModels[i] = new SingleFieldViewModel((SingleFieldModel)fieldModel.Fields[i]);
            }
        }

        public string Test {
            get { return "X"; }
        }

    }
}
