using System.Drawing;

namespace ConnectFour.Client.Data {
    public static class Help {
        public static string GetClass (ref string[,] map, int indexI, int indexJ) {
            return map[indexI, indexJ];
        }

        public static string ToHex (this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";
    }
}
