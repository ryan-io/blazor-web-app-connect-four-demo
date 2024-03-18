using System.Drawing;

namespace ConnectFour.Client.Data {
    public record Player (byte TurnId, string Name, Color Color) {
        /// <summary>
        /// Gets the CSS class for the player. The CSS class is determined based on the player's turn id.
        /// </summary>
        /// <value>
        /// The CSS class as a string. It will be "player-1-bg" for the first player and "player-2-bg" for the second player.
        /// </value>
        public string CssClass { get; } = TurnId == 0 ? "player-1-bg" : "player-2-bg";
    }
}
