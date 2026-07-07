using System.Windows.Forms;

namespace MatrixOfCalculator.Forms
{
    public class Navigation
    {
        public static void MovePage(GroupBox currentPage, GroupBox newPage)
        {
            currentPage.Visible = false;

            newPage.Parent = currentPage.Parent;
            newPage.Visible = true;
        }

        public static void ViewElements(Panel hideElement, Panel showElement) 
        {
            hideElement.Visible = false;
            showElement.Visible = true;
        }

        public static void SetFormAndCloseExist(GroupBox chooseDesign, params GroupBox[] currentDesign)
        {
            foreach (var window in currentDesign)
                window.Visible = false;

            if (currentDesign.Length > 0)
                chooseDesign.Parent = currentDesign[0].Parent;

            chooseDesign.Visible = true;
            chooseDesign.BringToFront();
        }

        public void CheckCurrentPage()
        {

        }
    }
}