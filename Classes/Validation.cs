using System;
using System.Windows.Forms;

namespace MatrixOfCalculator.Classes
{
    public static class Validation
    {
        /// <summary>
        /// Проверка ввода данных
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CheckIntOrDefault(this string text)
        {
            return CheckLimitRangeValue(int.TryParse(text, out int result) ? result : 0);
        }

        /// <summary>
        /// Проверка превышения лимита значения
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int CheckLimitRangeValue(int number)
        {
            if (number > 30) 
                number = 30;

            if (number < -30)
                number = -30;

            return number;
        }

        /// <summary>
        /// Блокирует ввод букв и символов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar) && e.KeyChar != 8))
                e.Handled = true;
        }
    }
}
