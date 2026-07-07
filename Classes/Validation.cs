using System;
using System.Windows.Forms;

namespace MatrixOfCalculator.Classes
{
    public static class Validation
    {
        public static float CheckIntOrDefault(this string text)
        {
            return CheckLimitRangeValue(int.TryParse(text, out int result) ? result : 0);
        }

        private static float CheckLimitRangeValue(int number)
        {
            if (number > 30)
                number = 30;
            else if (number < -30)
                number = -30;

            return number;
        }

        public static void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar) && e.KeyChar != 8))
                e.Handled = true;
        }
    }
}
