namespace ConnectFour.Client.Data {
    // The BoardState class represents the state of the game board in the Connect Four game.
    public class BoardState {
        // Rows property represents the number of rows in the game board.
        public int Rows { get; }
        // Cols property represents the number of columns in the game board.
        public int Cols { get; }
        // Map property represents the game board. It is a 2D array of MapCellData objects.
        public MapCellData[,] Map { get; private set; }
        // CurrentRow property represents the row of the current cell in focus.
        public int CurrentRow { get; set; }
        // CurrentCol property represents the column of the current cell in focus.s
        public int CurrentCol { get; set; }
        // GetCell method returns a reference to the MapCellData object at the specified row and column.
        public ref MapCellData GetCell (int row, int col) => ref Map[row, col];
        // SetCell method sets the MapCellData object at the specified row and column to the provided data.
        public void SetCell (MapCellData data, int row, int col) => Map[row, col] = data;
        // NewBoard method initializes the game board with default MapCellData objects.
        public void NewBoard () {
            Map = new MapCellData[Rows, Cols];
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Cols; j++) {
                    Map[i, j] = new MapCellData(byte.MaxValue, DefaultBg, i, j);
                }
            }
        }
        // Default constructor initializes the Map property with an empty 2D array.
        public BoardState () {
            Map = new MapCellData[,] { };
        }
        // Overloaded constructor initializes the Map property with an empty 2D array and sets the Rows and Cols properties.
        public BoardState (int rows, int cols) {
            Map = new MapCellData[,] { };
            Rows = rows;
            Cols = cols;
            NewBoard();
        }
        // DefaultBg is a constant string representing the default background.
        const string DefaultBg = "default-bg";
    }
}
