namespace M120_226B_UTT_Project.Helper {
    /// <summary>
    /// Observer with a EventHandler
    /// </summary>
    public interface IObserver {
        /// <summary>
        /// Event Handler for Update of a Property
        /// </summary>
        /// <param name="propertyName"></param>
        void ExecuteOnUpdate(string propertyName);
    }
}
