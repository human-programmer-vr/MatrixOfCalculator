using System.Windows.Forms;

namespace MatrixOfCalculator.Classes
{
    public class UserInterface
    {
        public static void HideButton(Button button) => button.Visible = false;
        public static void ShowButton(Button button) => button.Visible = true;

        public static void ChangeButtonNext(Button button, string message) => button.Text = message;
    }
}
