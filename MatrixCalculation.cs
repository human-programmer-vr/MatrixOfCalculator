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
            MultiplicateMatrix.Click += (s, e) => 
            {
                InputField.Visible = InputField.Visible != false ? false : true;
            };
            TransposeMatrix.Click += (s, e) =>
            {
                Matrix._temp = Matrix.TransposeMatrix(Matrix._matrixOne);
                InputAndOutputDataToMatrix.OutputData(Matrix._temp, OutputData);

                MovePageResultCalculation();
            };
            AdditionMatrix.Click += (s, e) =>
            {
                Matrix._temp = Matrix.AdditionMatrix(Matrix._matrixOne, Matrix._matrixTwo);
                InputAndOutputDataToMatrix.OutputData(Matrix._temp, OutputData);

                MovePageResultCalculation();
            };
            SubtractionMatrix.Click += (s, e) =>
            {
                Matrix._temp = Matrix.SubstractionMatrix(Matrix._matrixOne, Matrix._matrixTwo);
                InputAndOutputDataToMatrix.OutputData(Matrix._temp, OutputData);

                MovePageResultCalculation();
            };
            MultiplicateMatrix.Click += (s, e) => 
            {
                Matrix._temp = Matrix.MultiplicateBothMatrix(Matrix._matrixOne, Matrix._matrixTwo);
                InputAndOutputDataToMatrix.OutputData(Matrix._temp, OutputData);

                MovePageResultCalculation();
            };
            FindReverseMatrix.Click += (s, e) =>
            {
                Matrix._temp = Matrix.ReverseMatrix(Matrix._matrixOne);
                InputAndOutputDataToMatrix.OutputData(Matrix._temp, OutputData);

                MovePageResultCalculation();
            };
            CloseWindow.Click += (s, e) => { Close(); };
            
            HideButton(bBack);
            UtilityTools.SetMaxLengthFieldInput(3, textBox1, textBox2, textBox3, textBox4,
                textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12,
                textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20,
                textBox21, textBox22, textBox23, textBox24, textBox25, tInput1, tInput2, tInput3, tInput4);
        }
        
        private void Next(object sender, EventArgs e) => MoveToNextPage();

        private void HideButton(Button button) => button.Visible = false;
        private void ShowButton(Button button) => button.Visible = true;

        public void MoveToNextPage()
        {
            if (gHomeWindow.Visible)
                MovePageInputDataToMatrix();
            else if (InputDataToMatrixTwoOnTwo.Visible ||
                InputDataToMatrixThreeOnThree.Visible ||
                InputDataToMatrixFourOnFour.Visible)
                MovePageOperationMatrix();
            else if (OperationMatrix.Visible)
                MovePageResultCalculation();
            else if (ResultCalculation.Visible)
                MoveHomePage();
        }

        private void MovePageInputDataToMatrix()
        {
            ShowButton(bBack);

            if (IsChooseOneMatrixAndHandleInput() || IsChooseBothMatrixAndHandleInput())
            {
                if (sizeTwoOnTwo.Checked)
                    Navigation.MoveToPage(currentPage: gHomeWindow, nextPage: InputDataToMatrixTwoOnTwo);
                else if (sizeThreeToThree.Checked)
                    Navigation.MoveToPage(currentPage: gHomeWindow, nextPage: InputDataToMatrixThreeOnThree);
                else if (sizeFourToFour.Checked)
                    Navigation.MoveToPage(currentPage: gHomeWindow, nextPage: InputDataToMatrixFourOnFour);
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

        private void MovePageOperationMatrix()
        {
            if (CreateMatrix.BackColor.Name.StartsWith("ffc0ffc0"))
            {
                if (InputDataToMatrixTwoOnTwo.Visible)
                    Navigation.MoveToPage(currentPage: InputDataToMatrixTwoOnTwo, nextPage: OperationMatrix);
                else if (InputDataToMatrixThreeOnThree.Visible)
                    Navigation.MoveToPage(currentPage: InputDataToMatrixThreeOnThree, nextPage: OperationMatrix);
                else if (InputDataToMatrixFourOnFour.Visible)
                    Navigation.MoveToPage(currentPage: InputDataToMatrixFourOnFour, nextPage: OperationMatrix);

                Navigation.ViewElements(hideElement: OperationsWithTwoMatrix, showElement: OperationsWithOneMatrix);
            }
            if (CreateBothMatrix.BackColor.Name.StartsWith("ffc0ffc0"))
            {
                if (InputDataToMatrixTwoOnTwo.Visible)
                    Navigation.MoveToPage(currentPage: InputDataToMatrixTwoOnTwo, nextPage: OperationMatrix);
                else if (InputDataToMatrixThreeOnThree.Visible)
                    Navigation.MoveToPage(currentPage: InputDataToMatrixThreeOnThree, nextPage: OperationMatrix);
                else if (InputDataToMatrixFourOnFour.Visible)
                    Navigation.MoveToPage(currentPage: InputDataToMatrixFourOnFour, nextPage: OperationMatrix);

                Navigation.ViewElements(hideElement: OperationsWithOneMatrix, showElement: OperationsWithTwoMatrix);
            }

            if (IsChooseOneMatrixAndHandleInput())
            {
                if (sizeTwoOnTwo.Checked)
                {
                    InputAndOutputDataToMatrix.HandleInput(Matrix._matrixOne = new float[2, 2],
                        tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                        tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                }
                else if (sizeThreeToThree.Checked)
                {
                    InputAndOutputDataToMatrix.HandleInput(Matrix._matrixOne = new float[3, 3],
                        textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                        textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(),
                        textBox7.Text.CheckIntOrDefault(), textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
                }
                else if (sizeFourToFour.Checked)
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
                        Navigation.MoveToPage(currentPage: gHomeWindow, nextPage: InputDataToMatrixTwoOnTwo);

                        return;
                    }
                    if (UtilityTools.CheckExistData(Matrix._matrixOne) != Matrix._matrixOne.Length)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix._matrixTwo = new float[2, 2],
                            tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                            tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                    }

                    Navigation.MoveToPage(InputDataToMatrixTwoOnTwo, OperationMatrix);
                }
                else if (sizeThreeToThree.Checked)
                {
                    if (Matrix._matrixOne == null)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix._matrixOne = new float[3, 3],
                            textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                            textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(),
                            textBox7.Text.CheckIntOrDefault(), textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
                        Navigation.MoveToPage(currentPage: gHomeWindow, nextPage: InputDataToMatrixThreeOnThree);

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

                    Navigation.MoveToPage(InputDataToMatrixThreeOnThree, OperationMatrix);
                }
                else if (sizeFourToFour.Checked)
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

                        Navigation.MoveToPage(currentPage: gHomeWindow, nextPage: InputDataToMatrixFourOnFour);

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

                    Navigation.MoveToPage(InputDataToMatrixFourOnFour, OperationMatrix);
                }
            }









            // Умножение на число
            //Matrix._temp = Matrix.MultiplicateNumberOnMatrix(Matrix._matrixOne, (byte)tInputField.Text.CheckIntOrDefault());
            //Navigation.MovePage(currentPage: gOperationMatrix, newPage: gResultCalculation);
            //UtilityTools.Notification();
            //InputAndOutputDataToMatrix.OutputData(Matrix._temp, tOutputData);
        }

        private void MovePageResultCalculation()
        {
            bNext.Text = "Главная";
            Navigation.MoveToPage(currentPage: OperationMatrix, nextPage: ResultCalculation);
        }

        private void MoveHomePage()
        {
            bNext.Text = "Далее →";
            HideButton(bBack);

            Navigation.MoveToPage(currentPage: ResultCalculation, nextPage: gHomeWindow);
            UtilityTools.SetDefaultToggles(sizeTwoOnTwo, sizeThreeToThree, sizeFourToFour, inHandle, inAutomatic);
            UtilityTools.ResetColorForButton(CreateMatrix);
            UtilityTools.ResetColorForButton(CreateBothMatrix);
        }

        private void Return(object sender, EventArgs e) => MoveToPreviousPage();

        private void MoveToPreviousPage()
        {
            if (InputDataToMatrixTwoOnTwo.Visible)
            {
                Navigation.MoveToPage(currentPage: InputDataToMatrixTwoOnTwo, nextPage: gHomeWindow);
                HideButton(bBack);
            } else if (InputDataToMatrixThreeOnThree.Visible)
            {
                Navigation.MoveToPage(currentPage: InputDataToMatrixThreeOnThree, nextPage: gHomeWindow);
                HideButton(bBack);
            } else if (InputDataToMatrixFourOnFour.Visible)
            {
                Navigation.MoveToPage(currentPage: InputDataToMatrixFourOnFour, nextPage: gHomeWindow);
                HideButton(bBack);
            } else if (OperationMatrix.Visible)
            {
                if (inHandle.Checked)
                {
                    if (sizeTwoOnTwo.Checked)
                        Navigation.MoveToPage(currentPage: OperationMatrix, nextPage: InputDataToMatrixTwoOnTwo);

                    if (sizeThreeToThree.Checked)
                        Navigation.MoveToPage(currentPage: OperationMatrix, nextPage: InputDataToMatrixThreeOnThree);

                    if (sizeFourToFour.Checked)
                        Navigation.MoveToPage(currentPage: OperationMatrix, nextPage: InputDataToMatrixFourOnFour);
                }
                else
                    Navigation.MoveToPage(currentPage: OperationMatrix, nextPage: gHomeWindow);

            } else if (ResultCalculation.Visible)
            {
                bNext.Text = "Далее →";
                Navigation.MoveToPage(currentPage: ResultCalculation, nextPage: OperationMatrix);
            }
        }

        private void InputKeyPress(object sender, KeyPressEventArgs e) => Validation.OnlyNumbers(sender, e);

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