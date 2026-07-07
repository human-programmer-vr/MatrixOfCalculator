using MatrixOfCalculator.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixOfCalculator.Forms
{
    public partial class MatrixCalculation : Form
    {
        public MatrixCalculation()
        {
            InitializeComponent();

            CreateMatrix.Click += (s, e) => 
            {
                if (CreateBothMatrix.BackColor == Color.FromArgb(192, 255, 192))
                    return;
                else
                    UtilityTools.SetColorForButton(CreateMatrix);   
            };
            CreateBothMatrix.Click += (s, e) => 
            {
                if (CreateMatrix.BackColor == Color.FromArgb(192, 255, 192))
                    return;
                else
                    UtilityTools.SetColorForButton(CreateBothMatrix);
            };
            pCloseWindow.Click += (s, e) => { Close(); };
            HideButton(bBack);
        }
        
        private void Next(object sender, EventArgs e)
        {
            ShowButton(bBack);

            CheckCurrentPage();


            if (IsChooseOneMatrixAndHandleInput())
            {
                if (sizeTwoOnTwo.Checked) 
                {
                    InputAndOutputDataToMatrix.HandleInput(Matrix._matrixOne = new float[2, 2],
                        tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                        tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                } else if (sizeThreeToThree.Checked) 
                {
                    InputAndOutputDataToMatrix.HandleInput(Matrix._matrixOne = new float[3, 3],
                        textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                        textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(),
                        textBox7.Text.CheckIntOrDefault(), textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
                } else if (sizeFourToFour.Checked)
                {
                    InputAndOutputDataToMatrix.HandleInput(Matrix._matrixOne = new float[4, 4],
                        textBox10.Text.CheckIntOrDefault(), textBox11.Text.CheckIntOrDefault(), textBox12.Text.CheckIntOrDefault(), textBox13.Text.CheckIntOrDefault(),
                        textBox14.Text.CheckIntOrDefault(), textBox15.Text.CheckIntOrDefault(), textBox16.Text.CheckIntOrDefault(), textBox17.Text.CheckIntOrDefault(),
                        textBox18.Text.CheckIntOrDefault(), textBox19.Text.CheckIntOrDefault(), textBox20.Text.CheckIntOrDefault(), textBox21.Text.CheckIntOrDefault(),
                        textBox22.Text.CheckIntOrDefault(), textBox23.Text.CheckIntOrDefault(), textBox24.Text.CheckIntOrDefault(), textBox25.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16,
                        textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25);
                }
            }

            if (IsChooseBothMatrixAndHandleInput())
            {
                if (sizeTwoOnTwo.Checked)
                {
                    if (Matrix._matrixOne == null)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix._matrixOne = new float[2, 2],
                            tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                            tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                        Navigation.MovePage(currentPage: gHomeWindow, newPage: gInputDataToMatrixTwoOnTwo);

                        return;
                    }
                    if (UtilityTools.CheckExistData(Matrix._matrixOne) != Matrix._matrixOne.Length)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix._matrixTwo = new float[2, 2],
                            tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                            tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                    }
                    
                    Navigation.MovePage(gInputDataToMatrixTwoOnTwo, gOperationMatrix);
                } else if (sizeThreeToThree.Checked)
                {
                    if (Matrix._matrixOne == null)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix._matrixOne = new float[3, 3],
                            textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                            textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(),
                            textBox7.Text.CheckIntOrDefault(), textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
                        Navigation.MovePage(currentPage: gHomeWindow, newPage: gInputDataToMatrixThreeOnThree);

                        return;
                    }
                    if (UtilityTools.CheckExistData(Matrix._matrixOne) != Matrix._matrixOne.Length)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix._matrixTwo = new float[3, 3],
                            textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                            textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(),
                            textBox7.Text.CheckIntOrDefault(), textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
                    }
                    
                    Navigation.MovePage(gInputDataToMatrixThreeOnThree, gOperationMatrix);
                } else if (sizeFourToFour.Checked)
                {
                    if (Matrix._matrixOne == null)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix._matrixOne = new float[4, 4],
                            textBox10.Text.CheckIntOrDefault(), textBox11.Text.CheckIntOrDefault(), textBox12.Text.CheckIntOrDefault(), textBox13.Text.CheckIntOrDefault(),
                            textBox14.Text.CheckIntOrDefault(), textBox15.Text.CheckIntOrDefault(), textBox16.Text.CheckIntOrDefault(), textBox17.Text.CheckIntOrDefault(),
                            textBox18.Text.CheckIntOrDefault(), textBox19.Text.CheckIntOrDefault(), textBox20.Text.CheckIntOrDefault(), textBox21.Text.CheckIntOrDefault(),
                            textBox22.Text.CheckIntOrDefault(), textBox23.Text.CheckIntOrDefault(), textBox24.Text.CheckIntOrDefault(), textBox25.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16,
                            textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25);

                        Navigation.MovePage(currentPage: gHomeWindow, newPage: gInputDataToMatrixFourOnFour);

                        return;
                    }
                    if (UtilityTools.CheckExistData(Matrix._matrixOne) != Matrix._matrixOne.Length)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix._matrixTwo = new float[4, 4],
                            textBox10.Text.CheckIntOrDefault(), textBox11.Text.CheckIntOrDefault(), textBox12.Text.CheckIntOrDefault(), textBox13.Text.CheckIntOrDefault(),
                            textBox14.Text.CheckIntOrDefault(), textBox15.Text.CheckIntOrDefault(), textBox16.Text.CheckIntOrDefault(), textBox17.Text.CheckIntOrDefault(),
                            textBox18.Text.CheckIntOrDefault(), textBox19.Text.CheckIntOrDefault(), textBox20.Text.CheckIntOrDefault(), textBox21.Text.CheckIntOrDefault(),
                            textBox22.Text.CheckIntOrDefault(), textBox23.Text.CheckIntOrDefault(), textBox24.Text.CheckIntOrDefault(), textBox25.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                    }
                    
                    Navigation.MovePage(gInputDataToMatrixFourOnFour, gOperationMatrix);
                }
            }
        }






        // кнопки [Назад]
        private void bBack_Click(object sender, EventArgs e)
        {
            if (inHandle.Checked)
            {
                if (sizeTwoOnTwo.Checked)
                    Navigation.MovePage(currentPage: gOperationMatrix, newPage: gInputDataToMatrixTwoOnTwo);

                if (sizeThreeToThree.Checked)
                    Navigation.MovePage(currentPage: gOperationMatrix, newPage: gInputDataToMatrixThreeOnThree);

                if (sizeFourToFour.Checked)
                    Navigation.MovePage(currentPage: gOperationMatrix, newPage: gInputDataToMatrixFourOnFour);
            }
            else
                Navigation.MovePage(currentPage: gOperationMatrix, newPage: gHomeWindow);
        }
        private void bBаck_Click(object sender, EventArgs e)
        {
            Navigation.MovePage(currentPage: gResultCalculation, newPage: gOperationMatrix);
        }
        private void bReturn_Click(object sender, EventArgs e)
        {
            Navigation.MovePage(currentPage: gResultCalculation, newPage: gHomeWindow);
            Navigation.SetFormAndCloseExist(gHomeWindow, gInputDataToMatrixTwoOnTwo, gInputDataToMatrixThreeOnThree, gInputDataToMatrixFourOnFour);
        }
        private void bPrevious_Click(object sender, EventArgs e)
        {
            Navigation.MovePage(currentPage: gInputDataToMatrixFourOnFour, newPage: gHomeWindow);
        }
        private void bBehind_Click(object sender, EventArgs e)
        {
            Navigation.SetFormAndCloseExist(gHomeWindow, gInputDataToMatrixTwoOnTwo, gInputDataToMatrixThreeOnThree, gInputDataToMatrixFourOnFour);
        }








        private void bMultiplicationMatrixOnNumber_Click(object sender, EventArgs e)
        {
            tInputField.Clear();

            if (tInputField.Visible != false)
                tInputField.Visible = false;
            else
                tInputField.Visible = true;
        }

        // Повторяющийся код
        private void bTransposeMatrix_Click(object sender, EventArgs e)
        {
            Matrix._temp = Matrix.TransposeMatrix(Matrix._matrixOne);


            Navigation.MovePage(currentPage: gOperationMatrix, newPage: gResultCalculation);
            UtilityTools.Notification();
            InputAndOutputDataToMatrix.OutputData(Matrix._temp, tOutputData);
        }
        private void bAdditionMatrix_Click(object sender, EventArgs e)
        {
            Matrix._temp = Matrix.AdditionMatrix(Matrix._matrixOne, Matrix._matrixTwo);

            Navigation.MovePage(currentPage: gOperationMatrix, newPage: gResultCalculation);
            UtilityTools.Notification();
            InputAndOutputDataToMatrix.OutputData(Matrix._temp, tOutputData);
        }
        private void bSubtractionMatrix_Click(object sender, EventArgs e)
        {
            Matrix._temp = Matrix.SubstractionMatrix(Matrix._matrixOne, Matrix._matrixTwo);


            Navigation.MovePage(currentPage: gOperationMatrix, newPage: gResultCalculation);
            UtilityTools.Notification();
            InputAndOutputDataToMatrix.OutputData(Matrix._temp, tOutputData);
        }
        private void bMultiplicateMatrix_Click(object sender, EventArgs e)
        {
            Matrix._temp = Matrix.MultiplicateBothMatrix(Matrix._matrixOne, Matrix._matrixTwo);


            Navigation.MovePage(currentPage: gOperationMatrix, newPage: gResultCalculation);
            UtilityTools.Notification();
            InputAndOutputDataToMatrix.OutputData(Matrix._temp, tOutputData);
        }
        private void bFindReverseMatrix_Click(object sender, EventArgs e)
        {
            Matrix._temp = Matrix.ReverseMatrix(Matrix._matrixOne);


            Navigation.MovePage(currentPage: gOperationMatrix, newPage: gResultCalculation);
            UtilityTools.Notification();
            InputAndOutputDataToMatrix.OutputData(Matrix._temp, tOutputData);
        }

        private void tInput1_KeyPress(object sender, KeyPressEventArgs e) => Validation.OnlyNumbers(sender, e);

        private void HideButton(Button button) => button.Visible = false;
        private void ShowButton(Button button) => button.Visible = true;


        public void Calculation()
        {
            // цепочка методов вычисления данных для каждого случая
        }


        // проверка нахождения на странице
        public void CheckCurrentPage()
        {
            if (gHomeWindow.Visible)
                MovePageInputDataToMatrix();
            else if (gInputDataToMatrixTwoOnTwo.Visible)            
                MovePageOperationMatrix();
            else if (gInputDataToMatrixThreeOnThree.Visible)
                MovePageOperationMatrix();
            else if (gInputDataToMatrixFourOnFour.Visible)
                MovePageOperationMatrix();
            else if (gOperationMatrix.Visible)
                MovePageResultCalculation();
            else if (gResultCalculation.Visible)
                MoveHomePage();
        }

        private void MovePageResultCalculation()
        {
            Navigation.MovePage(currentPage: gOperationMatrix, newPage: gResultCalculation);
        }

        private void MovePageOperationMatrix()
        {

            if (CreateMatrix.BackColor.Name.StartsWith("ffc0ffc0"))
            {
                if (gInputDataToMatrixTwoOnTwo.Visible)
                    Navigation.MovePage(currentPage: gInputDataToMatrixTwoOnTwo, newPage: gOperationMatrix);
                else if (gInputDataToMatrixThreeOnThree.Visible)
                    Navigation.MovePage(currentPage: gInputDataToMatrixThreeOnThree, newPage: gOperationMatrix);
                else if (gInputDataToMatrixFourOnFour.Visible)
                    Navigation.MovePage(currentPage: gInputDataToMatrixFourOnFour, newPage: gOperationMatrix);

                Navigation.ViewElements(hideElement: pOperationsWithTwoMatrix, showElement: pOperationsWithOneMatrix);
            }
            if (CreateBothMatrix.BackColor.Name.StartsWith("ffc0ffc0"))
            {
                if (gInputDataToMatrixTwoOnTwo.Visible)
                    Navigation.MovePage(currentPage: gInputDataToMatrixTwoOnTwo, newPage: gOperationMatrix);
                else if (gInputDataToMatrixThreeOnThree.Visible)
                    Navigation.MovePage(currentPage: gInputDataToMatrixThreeOnThree, newPage: gOperationMatrix);
                else if (gInputDataToMatrixFourOnFour.Visible)
                    Navigation.MovePage(currentPage: gInputDataToMatrixFourOnFour, newPage: gOperationMatrix);

                Navigation.ViewElements(hideElement: pOperationsWithOneMatrix, showElement: pOperationsWithTwoMatrix);
            }











                // Умножение на число
            //Matrix._temp = Matrix.MultiplicateNumberOnMatrix(Matrix._matrixOne, (byte)tInputField.Text.CheckIntOrDefault());
            //Navigation.MovePage(currentPage: gOperationMatrix, newPage: gResultCalculation);
            //UtilityTools.Notification();
            //InputAndOutputDataToMatrix.OutputData(Matrix._temp, tOutputData);
        }

        private void MoveHomePage()
        {
            Navigation.MovePage(currentPage: gResultCalculation, newPage: gHomeWindow);
        }
        
        
        private void MovePageInputDataToMatrix()
        {
            if (IsChooseOneMatrixAndHandleInput() || IsChooseBothMatrixAndHandleInput())
            {
                if (sizeTwoOnTwo.Checked)
                    Navigation.MovePage(currentPage: gHomeWindow, newPage: gInputDataToMatrixTwoOnTwo);
                else if (sizeThreeToThree.Checked)
                    Navigation.MovePage(currentPage: gHomeWindow, newPage: gInputDataToMatrixThreeOnThree);
                else if (sizeFourToFour.Checked)
                    Navigation.MovePage(currentPage: gHomeWindow, newPage: gInputDataToMatrixFourOnFour);
            }

            if (IsChooseOneMatrixAndAutomateInput())
            {
                if (sizeTwoOnTwo.Checked)
                    InputAndOutputDataToMatrix.AutoInput(Matrix._matrixOne = new float[2, 2]);
                else if (sizeThreeToThree.Checked)
                    InputAndOutputDataToMatrix.AutoInput(Matrix._matrixOne = new float[3, 3]);
                else if (sizeFourToFour.Checked)
                    InputAndOutputDataToMatrix.AutoInput(Matrix._matrixOne = new float[4, 4]);
            } 
            if (IsChooseBothMatrixAndAutomateInput())
            {
                if (sizeTwoOnTwo.Checked)
                    InputAndOutputDataToMatrix.AutoInputBothMatrix(Matrix._matrixOne = new float[2, 2], Matrix._matrixTwo = new float[2, 2]);
                else if (sizeThreeToThree.Checked)
                    InputAndOutputDataToMatrix.AutoInputBothMatrix(Matrix._matrixOne = new float[3, 3], Matrix._matrixTwo = new float[3, 3]);
                else if (sizeFourToFour.Checked)
                    InputAndOutputDataToMatrix.AutoInputBothMatrix(Matrix._matrixOne = new float[4, 4], Matrix._matrixTwo = new float[4, 4]);
            }
        }
        private bool IsChooseOneMatrixAndHandleInput()
        {
            return CreateMatrix.BackColor.Name.StartsWith("ffc0ffc0") && inHandle.Checked;
        }
        private bool IsChooseBothMatrixAndHandleInput()
        {
            return CreateBothMatrix.BackColor.Name.StartsWith("ffc0ffc0") && inHandle.Checked;
        }
        private bool IsChooseOneMatrixAndAutomateInput()
        {
            return CreateMatrix.BackColor.Name.StartsWith("ffc0ffc0") && inAutomatic.Checked;
        }
        private bool IsChooseBothMatrixAndAutomateInput()
        {
            return CreateBothMatrix.BackColor.Name.StartsWith("ffc0ffc0") && inAutomatic.Checked;
        }
    }
}