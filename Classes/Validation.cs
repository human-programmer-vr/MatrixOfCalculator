using System;
using System.Windows.Forms;

namespace MatrixOfCalculator.Classes
{
    public static class Validation
    {
        public static int CheckIntOrDefault(this string text)
        {
            return CheckLimitRangeValue(int.TryParse(text, out int result) ? result : 0);
        }

        private static int CheckLimitRangeValue(int number)
        {
            if (number > 30)
                number = 30;
            else if (number < -30)
                number = -30;

            return number;
        }

        public static void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 45))
                e.Handled = true;
        }
    }
}
