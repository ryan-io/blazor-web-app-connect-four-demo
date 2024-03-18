namespace ConnectFour.Client.Data;

public readonly struct MapCellData {
    public MapCellData (Player player, int row, int col) {
        Owner = player.TurnId;
        Class = player.CssClass;
        Row = row;
        Col = col;
    }

    public MapCellData (byte owner, string @class, int row, int col) {
        Owner = owner;
        Class = @class;
        Row = row;
        Col = col;
    }

    public byte Owner { get; }
    public string Class { get; }
    public int Row { get; }
    public int Col { get; }
}