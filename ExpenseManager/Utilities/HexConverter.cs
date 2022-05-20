namespace ExpenseManager.Utilities;

public static class HexConverter
{
    private const string HexChars = "0123456789ABCDEF";
    private static readonly HashSet<char> HexCharSet = new HashSet<char>(HexChars.ToCharArray());

    public static bool IsValidHexString(string str) {
        if (string.IsNullOrWhiteSpace(str))
            return false;
        int startIndex = str[0] == '#' ? 1 : 0;
        for (int i = startIndex; i < str.Length; i++) {
            if (!HexCharSet.Contains(str[i]))
                return false;
        }
        return true;
    }

    public static string RGBToHex(Color color) {
        char a = IntToHex((int)Math.Floor(color.R / 16f));
        char b = IntToHex((int)Math.Round(color.R % 16f));
        char c = IntToHex((int)Math.Floor(color.G / 16f));
        char d = IntToHex((int)Math.Round(color.G % 16f));
        char e = IntToHex((int)Math.Floor(color.B / 16f));
        char f = IntToHex((int)Math.Round(color.B % 16f));

        return string.Concat(new char[] { a, b, c, d, e, f });
    }

    public static Color HexToRGB(string hex) {
        if (hex.StartsWith("#"))
            hex = hex.Remove(0, 1);

        if (!IsValidHexString(hex))
            throw new ArgumentException("String contains non-hex characters");
        if (hex.Length != 6)
            throw new ArgumentException("Invalid string length");
        byte r = (byte)(HexToByte(hex[1]) + HexToByte(hex[0]) * 16);
        byte g = (byte)(HexToByte(hex[3]) + HexToByte(hex[2]) * 16);
        byte b = (byte)(HexToByte(hex[5]) + HexToByte(hex[4]) * 16);
        return Color.FromArgb(255, r, g, b);
    }

    public static string ByteArrayToHex(byte[] array) {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < array.Length; i++) {
            builder.Append(IntToHex(array[i]));
        }

        return builder.ToString();
    }

    private static char IntToHex(int number) {
        return HexChars[number];
    }

    private static char IntToHex(byte number) {
        return HexChars[number];
    }

    private static int HexToInt(char hexChar) {
        //return ch - '0' * ((ch >= '0' && ch <= '9')? 1 : 0) - ('a' + 10) * ((ch >= 'a' && ch <= 'f')? 1 : 0) - ('A' + 10) * ((ch >= 'A' && ch <= 'F')? 1 : 0);

        return hexChar switch {
            char ch when ch >= '0' && ch <= '9' => ch - '0',
            char ch when ch >= 'a' && ch <= 'f' => ch - 'a' + 10,
            char ch when ch >= 'A' && ch <= 'F' => ch - 'A' + 10,
            _ => 0,
        };
    }

    private static byte HexToByte(char hexChar) {
        return (byte)HexToInt(hexChar);
    }
}