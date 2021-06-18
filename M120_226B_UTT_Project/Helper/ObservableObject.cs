using System.ComponentModel;

namespace M120_226B_UTT_Project.Helper {
    /// <summary>
    /// Implements INotifyPropertyChanged. Helps implement changed events
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged {
        #region INotifyPropertyChanged Members

        /// <summary>
        /// Raises the PropertyChange event for the property specified
        /// </summary>
        /// <param name="propertyName">Property name to update. (Case sensitive)</param>
        public virtual void RaisePropertyChanged(string propertyName) {
            OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises this object's PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property that has a new value.</param>
        protected virtual void OnPropertyChanged(string propertyName) {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        #endregion // INotifyPropertyChanged Members
    }
}
