namespace M120_226B_UTT_Project.Helper {
    /// <summary>
    /// Static Helper for Validating Winning
    /// </summary>
    public static class Validator {
        /// <summary>
        /// This Checks if the Field has been Captured by eighter Side.
        /// </summary>
        /// <param name="fields">SubFields of the Field to Check</param>
        /// <returns>The State of the Field</returns>
        public static FieldState ValidateFieldState(IField[] fields) { //  this will not check for Tie (No Need)


            FieldState[] board = new FieldState[9];// Extracting the FieldStates into an Array, this will Perform better
            for (int i = 0; i < 9; i++) {
                board[i] = fields[i].FieldState;
            }

            if (IsFieldWin(board, FieldState.X)) {
                return FieldState.X;
            }

            if (IsFieldWin(board, FieldState.O)) {
                return FieldState.O;
            }

            return FieldState.Empty;
        }
        /// <summary>
        /// Wining Conditions, if one matches a field is Captured.
        /// </summary>
        private static int[][] win = new int[][]//If One of those is complete, the field ist "Won". This is for ValidateFieldState
        {
            new int[] {0, 1, 2},
            new int[] {3, 4, 5},
            new int[] {6, 7, 8},
            new int[] {0, 3, 6},
            new int[] {1, 4, 7},
            new int[] {2, 5, 8},
            new int[] {0, 4, 8},
            new int[] {2, 4, 6}
        };


        /// <summary>
        /// Checks if the Field is Captured by the Specific Player
        /// </summary>
        /// <param name="board">The Board of the Field to Check</param>
        /// <param name="toCheck">The Player to check for</param>
        /// <returns>True if the Field belongs to the Checked Player</returns>
        private static bool IsFieldWin(FieldState[] board, FieldState toCheck) { // for ValidateFieldState

            for (int i = 0; i < win.Length; i++) {
                if (board[win[i][0]] == toCheck &&
                    board[win[i][1]] == toCheck &&
                    board[win[i][2]] == toCheck) {
                    return true;
                }
            }
            return false;
        }
    }
}
