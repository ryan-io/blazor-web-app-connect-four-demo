namespace ConnectFour.Client.Data {
    public class GameState {
        public Player[] Players { get; private set; }
        public byte CurrentTurn { get; set; }
        public string StatusText { get; set; }
        public bool GameOver { get; private set; }
        public Player? Winner { get; private set; } = default;

        public void StartGame (Player player1, Player player2) {
            Players = new[] { player1, player2 };
            StatusText = "No player has won";
            SetNextTurnRandom();
        }

        /// <summary>
        /// Sets the next turn to a random player.
        /// </summary>
        /// <remarks>
        /// This method uses a random number generator to select a player for the next turn.
        /// The random number generator is seeded with the current time in milliseconds.
        /// </remarks>

        public void SetNextTurnRandom () {
            var random = new Random(DateTime.Now.Millisecond);
            CurrentTurn = (byte)random.Next(0, 2);
        }

        /// <summary>
        /// Sets the next turn to the other player.
        /// </summary>
        /// <remarks>
        /// This method switches the current turn to the other player. If the current player is player 1, it will switch to player 2 and vice versa.
        /// </remarks>
        public void SetNextTurn () {
            CurrentTurn = CurrentTurn == Players[0].TurnId
                ? Players[1].TurnId
                : Players[0].TurnId;
        }

        public Player? Get (byte id) => Players.FirstOrDefault(p => p.TurnId == id);

        public Player GetCurrentPlayerTurn () => Players.First(p => p.TurnId == CurrentTurn);

        /// <summary>
        /// Checks if the specified player has won the game.
        /// </summary>
        /// <param name="map">The current state of the game board represented as a 2D array of MapCellData objects.</param>
        /// <param name="player">The player to check for a win condition.</param>
        /// <remarks>
        /// This method checks for a win condition by examining the game board for a sequence of four consecutive cells
        /// owned by the specified player, either horizontally or vertically. If such a sequence is found, the method sets the winner and ends the game.
        /// </remarks>
        public void CheckForWin (in MapCellData[,] map, in Player player) {
            for (int j = 0; j < map.GetLength(0); j++) {
                for (int k = 0; k < map.GetLength(1) - 3; k++) {
                    if (map[j, k].Owner == player.TurnId &&
                        map[j, k + 1].Owner == player.TurnId &&
                        map[j, k + 2].Owner == player.TurnId &&
                        map[j, k + 3].Owner == player.TurnId) {
                        SetWinner(in player);
                        return;
                    }
                }
            }

            for (int j = 0; j < map.GetLength(1) - 3; j++) {
                for (int k = 0; k < map.GetLength(0); k++) {
                    if (map[j, k].Owner == player.TurnId &&
                        map[j + 1, k].Owner == player.TurnId &&
                        map[j + 2, k].Owner == player.TurnId &&
                        map[j + 3, k].Owner == player.TurnId) {
                        SetWinner(in player);
                        return;
                    }
                }
            }
        }

        private void SetWinner (in Player player) {
            StatusText = $"{player.Name} has won!";
            GameOver = true;
            Winner = player;
        }

        public GameState () {
            StatusText = string.Empty;
            Players = new Player[] { };
        }
    }

}
