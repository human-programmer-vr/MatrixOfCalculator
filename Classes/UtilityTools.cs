using System.Drawing;
using System.Windows.Forms;

namespace MatrixOfCalculator.Classes
{
    public class UtilityTools
    {
        public static void SetColorForButton(Button button)
        {
            button.BackColor = button.BackColor.Name.StartsWith("White") ? Color.FromArgb(192, 255, 192) : Color.White;
        }

        public static void SetMaxLengthFieldInput(int length, params TextBox[] inputs)
        {
            foreach (var input in inputs)
                input.MaxLength = length;
        }

        public static void SetDefaultToggles(params RadioButton[] switches)
        {
            foreach (var toggle in switches)
                toggle.Checked = false;
        }

        public static void ResetColorForButton(Button button)
        {
            button.BackColor = Color.White;
        }

        public static bool CheckPressFromOtherButton(Button button)
        {
            return button.BackColor == Color.FromArgb(192, 255, 192) ? false : true;
        }

        public static void ClearInput(params TextBox[] inputField)
        {
            foreach (var item in inputField)
                item.Clear();
        }
    }
}
