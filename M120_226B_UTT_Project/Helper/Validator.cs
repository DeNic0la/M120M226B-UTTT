namespace M120_226B_UTT_Project.Helper
{
    public static class Validator
    {
        public static FieldState ValidateFieldState(IField[] fields)
        { // This Checks if the Field is Captured by eighter sides, this will not check for Tie (No Need)


            FieldState[] board = new FieldState[9];// Extracting the FieldStates into an Array, this will Perform better
            for (int i = 0; i < 9; i++)
            {
                board[i] = fields[i].FieldState;
            }

            if (IsFieldWin(board, FieldState.X))
            {
                return FieldState.X;
            }

            if (IsFieldWin(board, FieldState.O))
            {
                return FieldState.O;
            }

            return FieldState.Empty;
        }
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




        private static bool IsFieldWin(FieldState[] board, FieldState toCheck)
        { // for ValidateFieldState

            for (int i = 0; i < win.Length; i++)
            {
                if (board[win[i][0]] == toCheck &&
                    board[win[i][1]] == toCheck &&
                    board[win[i][2]] == toCheck)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
