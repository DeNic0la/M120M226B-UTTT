namespace M120_226B_UTT_Project.Helper {
    /// <summary>
    /// The State of a Field
    /// </summary>
    public enum FieldState {
        /// <summary>
        /// Captured by PlayerX
        /// </summary>
        X,
        /// <summary>
        /// Captured by PlayerO
        /// </summary>
        O,
        /// <summary>
        /// Field has not been Captured, but contains EmptySubFields or is Empty
        /// </summary>
        Empty,
        /// <summary>
        /// Field has not been Captured and contains no EmptySubFields
        /// </summary>
        Tie,
    }
}
