using System.Windows.Forms;

namespace MatrixOfCalculator.Forms
{
    public class WorkWithForms
    {
        /// <summary>
        /// Показывает переданый элемент и скрывает текущий
        /// </summary>
        /// <param name="currentElement"></param>
        /// <param name="nextElement"></param>
        public static void ViewElement(Panel currentElement, Panel nextElement) 
        {
            currentElement.Visible = false;
            nextElement.Visible = true;
        }

        /// <summary>
        /// Переключает интерфейс текущей формы на выбранный
        /// </summary>
        /// <param name="currentDesign"></param>
        /// <param name="chooseDesign"></param>
        public static void SetForm(GroupBox currentDesign, GroupBox chooseDesign)
        {
            currentDesign.Visible = false;

            chooseDesign.Parent = currentDesign.Parent;
            chooseDesign.Visible = true;
        }

        /// <summary>
        /// Переключает интерфейс текущей формы на выбранный и очищает все существующие
        /// </summary>
        /// <param name="chooseDesign"></param>
        /// <param name="currentDesign"></param>
        public static void SetFormAndCloseExist(GroupBox chooseDesign, params GroupBox[] currentDesign)
        {
            foreach (var window in currentDesign)
                window.Visible = false;

            if (currentDesign.Length > 0)
                chooseDesign.Parent = currentDesign[0].Parent;

            chooseDesign.Visible = true;
            chooseDesign.BringToFront();
        }
    }
}