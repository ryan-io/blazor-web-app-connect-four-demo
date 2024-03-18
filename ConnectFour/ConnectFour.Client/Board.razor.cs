using ConnectFour.Client.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Drawing;

namespace ConnectFour.Client;

public partial class Board {
    [Parameter, EditorRequired] public int Rows { get; set; }

    [Parameter, EditorRequired] public int Cols { get; set; }

    [Parameter] public Color Player1Color { get; set; } = Color.Chartreuse;
    [Parameter] public Color Player2Color { get; set; } = Color.Red;
    private BoardState BoardState { get; set; } = new();

    protected override async Task OnAfterRenderAsync (bool firstRender) {
        if (firstRender) {
            try {
                var p1Color = Player1Color.ToHex();
                var p2Color = Player2Color.ToHex();

                await Js.InvokeVoidAsync("applyStyleForElement", new {
                    className = "player-1-bg",
                    value = p1Color
                });

                await Js.InvokeVoidAsync("applyStyleForElement", new {
                    className = "player-2-bg",
                    value = p2Color
                });
            }
            catch (Exception e) {
                // log
                var t = e;
                throw;
            }
        }
    }

    protected override void OnParametersSet () {
        BoardState = new BoardState(Rows, Cols);
    }

    protected override void OnInitialized () {
        GameState.StartGame(
            new Player(0, "P1", Player1Color),
            new Player(1, "P2", Player2Color));
    }

    private string GetClass (int row, int col) {
        return BoardState.GetCell(row, col).Class;
    }

    private void SetNextTurn (int indexI, int indexJ) {
        if (GameState.GameOver)
            return;

        var currentPlayer = GameState.GetCurrentPlayerTurn();
        BoardState.CurrentCol = indexJ;
        BoardState.CurrentRow = indexI;

        BoardState.SetCell(
            new MapCellData(currentPlayer, indexI, indexJ),
            indexI, indexJ);

        GameState.SetNextTurn();

        var map = BoardState.Map;
        GameState.CheckForWin(in map, in currentPlayer);
    }
}