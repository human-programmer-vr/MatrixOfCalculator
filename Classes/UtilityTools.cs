using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MatrixOfCalculator.Classes
{
    public class UtilityTools
    {
        public static void SetColorForButton(Button button)
        {
            button.BackColor = button.BackColor.Name.StartsWith("White") ? Color.FromArgb(192, 255, 192) : Color.White;
        }

        public static void ClearInput(params TextBox[] inputField)
        {
            foreach (var item in inputField)
                item.Clear();
        }

        public static int CheckExistData(float[,] matrix, int indicator = 0)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    if (matrix[x, y] == 0)
                        indicator++;

            return indicator;
        }


        public static void Notification()
        {
            MessageBox.Show("Производятся вычисления!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
