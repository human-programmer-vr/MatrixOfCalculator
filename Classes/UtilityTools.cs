using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MatrixOfCalculator.Classes
{
    public class UtilityTools
    {
        private static StringBuilder _stringBuilder = new StringBuilder();

        /// <summary>
        /// Отображает активной выбранную кнопку
        /// </summary>
        /// <param name="button"></param>
        public static void Change(Button button)
        {
            if (button.BackColor.Name.StartsWith("White"))
                button.BackColor = Color.FromArgb(192, 255, 192);
            else
                button.BackColor = Color.White;
        }

        /// <summary>
        /// Очищает опля ввода
        /// </summary>
        /// <param name="inputField"></param>
        public static void ClearInput(params TextBox[] inputField)
        {
            foreach (var item in inputField)
                item.Clear();
        }


        /// <summary>
        /// Проверяет наличие данных в матрице
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="indicator"></param>
        /// <returns></returns>
        public static int CheckExistData(double[,] matrix, int indicator = 0)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    if (matrix[x, y] == 0)
                        indicator++;

            return indicator;
        }

        /// <summary>
        /// Выводит данные на экран
        /// </summary>
        public static void OutputData(double [,] matrix, TextBox output) 
        {
            output.Clear();
            _stringBuilder.Clear();

            for (short x = 0; x < matrix.GetLength(0); x++)
            {
                for (short y = 0; y < matrix.GetLength(1); y++)
                {
                    _stringBuilder.Append(matrix[x, y].ToString("F2") + "\t");
                }
                _stringBuilder.AppendLine();
            }

            output.Text = _stringBuilder.ToString();
        }

        /// <summary>
        /// Уведомление пользователю
        /// </summary>
        public static void Notification()
        {
            MessageBox.Show("Производятся вычисления!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}
