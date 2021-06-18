namespace M120_226B_UTT_Project.Helper {
    /// <summary>
    /// Interface for Models to be declared a Field
    /// </summary>
    public interface IField {
        /// <summary>
        /// State of the Field
        /// </summary>
        FieldState FieldState { get; }
        /// <summary>
        /// reset Data of Field
        /// </summary>
        void reset();
    }
}
