using MatrixOfCalculator.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixOfCalculator.Forms
{
    public partial class MatrixCalculation : Form
    {
        /* 1. Подумать о переходе к интерфесу вывода данных по соответствующей кнопке
         */

        public MatrixCalculation()
        {
            InitializeComponent();

            CreateMatrix.Click += (s, e) => 
            {
                if (UtilityTools.CheckPressFromOtherButton(CreateBothMatrix))
                    UtilityTools.SetColorForButton(CreateMatrix);
            };
            CreateBothMatrix.Click += (s, e) => 
            {
                if (UtilityTools.CheckPressFromOtherButton(CreateMatrix))
                    UtilityTools.SetColorForButton(CreateBothMatrix);
            };
            
            TransposeMatrix.Click += (s, e) =>
            {
                Matrix.destinationMatrix = Matrix.TransposeMatrix(Matrix.matrixOne);
                MovePageResultCalculation();    
            };
            AdditionMatrix.Click += (s, e) =>
            {
                Matrix.destinationMatrix = Matrix.AdditionMatrix(Matrix.matrixOne, Matrix.matrixTwo);
                MovePageResultCalculation();
            };
            SubtractionMatrix.Click += (s, e) =>
            {
                Matrix.destinationMatrix = Matrix.SubstractionMatrix(Matrix.matrixOne, Matrix.matrixTwo);
                MovePageResultCalculation();
            };
            MultiplicateMatrix.Click += (s, e) => 
            {
                Matrix.destinationMatrix = Matrix.MultiplicateBothMatrix(Matrix.matrixOne, Matrix.matrixTwo);
                MovePageResultCalculation();
            };
            FindReverseMatrix.Click += (s, e) =>
            {
                Matrix.destinationMatrix = Matrix.ReverseMatrix(Matrix.matrixOne);
                MovePageResultCalculation();
            };

            MultiplicationMatrixOnNumber.Click += (s, e) => InputField.Visible = InputField.Visible != false ? false : true;

            Next.Click += (s, e) => { UserInterface.ShowButton(Return); MoveToNextPage(); }; 
            CloseWindow.Click += (s, e) => Close();
            Return.Click += (s, e) => MoveToPreviousPage();

            UserInterface.HideButton(Return);
            UtilityTools.SetMaxLengthFieldInput(3, textBox1, textBox2, textBox3, textBox4,
                textBox5, textBox6, textBox7, textBox8, textBox9, textBox10, textBox11, textBox12,
                textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20,
                textBox21, textBox22, textBox23, textBox24, textBox25, tInput1, tInput2, tInput3, tInput4);
        }

        private void InputKeyPress(object sender, KeyPressEventArgs e) => Validation.OnlyNumbers(sender, e);

        public void MoveToNextPage()
        {
            if (HomeWindow.Visible)
                CheckHandleOrAutomateInput();
            else if (InputDataToMatrixTwoOnTwo.Visible ||
                InputDataToMatrixThreeOnThree.Visible ||
                InputDataToMatrixFourOnFour.Visible)
                MovePageOperationMatrix();
            else if (OperationMatrix.Visible)
                MovePageResultCalculation();
            else if (ResultCalculation.Visible)
                MoveHomePage();
        }

        private void CheckHandleOrAutomateInput()
        {
            if (IsChooseOneMatrixAndHandleInput() || IsChooseBothMatrixAndHandleInput())
                MovePageInputDataToMatrix();
            else if (IsChooseOneMatrixAndAutomateInput())
            {
                if (sizeTwoOnTwo.Checked)
                    InputAndOutputDataToMatrix.AutoInput(Matrix.matrixOne = new float[2, 2]);
                else if (sizeThreeToThree.Checked)
                    InputAndOutputDataToMatrix.AutoInput(Matrix.matrixOne = new float[3, 3]);
                else if (sizeFourToFour.Checked)
                    InputAndOutputDataToMatrix.AutoInput(Matrix.matrixOne = new float[4, 4]);

                MovePageOperationMatrix();
            } else if (IsChooseBothMatrixAndAutomateInput())
            {
                if (sizeTwoOnTwo.Checked)
                    InputAndOutputDataToMatrix.AutoInputBothMatrix(Matrix.matrixOne = new float[2, 2], Matrix.matrixTwo = new float[2, 2]);
                else if (sizeThreeToThree.Checked)
                    InputAndOutputDataToMatrix.AutoInputBothMatrix(Matrix.matrixOne = new float[3, 3], Matrix.matrixTwo = new float[3, 3]);
                else if (sizeFourToFour.Checked)
                    InputAndOutputDataToMatrix.AutoInputBothMatrix(Matrix.matrixOne = new float[4, 4], Matrix.matrixTwo = new float[4, 4]);

                MovePageOperationMatrix();
            }
        }

        private void MovePageInputDataToMatrix()
        {
            if (sizeTwoOnTwo.Checked)
                Navigation.MoveToPage(currentPage: HomeWindow, nextPage: InputDataToMatrixTwoOnTwo);
            else if (sizeThreeToThree.Checked)
                Navigation.MoveToPage(currentPage: HomeWindow, nextPage: InputDataToMatrixThreeOnThree);
            else if (sizeFourToFour.Checked)
                Navigation.MoveToPage(currentPage: HomeWindow, nextPage: InputDataToMatrixFourOnFour);
        }
        private void MovePageOperationMatrix()
        {
            InputData();

            if (Matrix.matrixTwo == null) { MovePageInputDataToMatrix(); return; }

            if (CreateMatrix.BackColor.Name.StartsWith("ffc0ffc0"))
                Navigation.ViewElements(hideElement: OperationsWithTwoMatrix, showElement: OperationsWithOneMatrix);
            else if (CreateBothMatrix.BackColor.Name.StartsWith("ffc0ffc0"))
                Navigation.ViewElements(hideElement: OperationsWithOneMatrix, showElement: OperationsWithTwoMatrix);

            if (InputDataToMatrixTwoOnTwo.Visible)
                Navigation.MoveToPage(currentPage: InputDataToMatrixTwoOnTwo, nextPage: OperationMatrix);
            else if (InputDataToMatrixThreeOnThree.Visible)
                Navigation.MoveToPage(currentPage: InputDataToMatrixThreeOnThree, nextPage: OperationMatrix);
            else if (InputDataToMatrixFourOnFour.Visible)
                Navigation.MoveToPage(currentPage: InputDataToMatrixFourOnFour, nextPage: OperationMatrix);
            else if (HomeWindow.Visible)
                Navigation.MoveToPage(currentPage: HomeWindow, nextPage: OperationMatrix);
        }

        private void InputData()
        {
            if (IsChooseOneMatrixAndHandleInput())
            {
                if (sizeTwoOnTwo.Checked)
                {
                    InputAndOutputDataToMatrix.HandleInput(Matrix.matrixOne = new float[2, 2],
                        tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                        tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                }
                else if (sizeThreeToThree.Checked)
                {
                    InputAndOutputDataToMatrix.HandleInput(Matrix.matrixOne = new float[3, 3],
                        textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                        textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(),
                        textBox7.Text.CheckIntOrDefault(), textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
                }
                else if (sizeFourToFour.Checked)
                {
                    InputAndOutputDataToMatrix.HandleInput(Matrix.matrixOne = new float[4, 4],
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
                    if (Matrix.matrixOne == null)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix.matrixOne = new float[2, 2],
                            tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                            tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                    }
                    else
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix.matrixTwo = new float[2, 2],
                            tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                            tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                    }
                }
                else if (sizeThreeToThree.Checked)
                {
                    if (Matrix.matrixOne == null)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix.matrixOne = new float[3, 3],
                            textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                            textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(),
                            textBox7.Text.CheckIntOrDefault(), textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
                    }
                    else
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix.matrixTwo = new float[3, 3],
                            textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                            textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(),
                            textBox7.Text.CheckIntOrDefault(), textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
                    }
                }
                else if (sizeFourToFour.Checked)
                {
                    if (Matrix.matrixOne == null)
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix.matrixOne = new float[4, 4],
                            textBox10.Text.CheckIntOrDefault(), textBox11.Text.CheckIntOrDefault(), textBox12.Text.CheckIntOrDefault(), textBox13.Text.CheckIntOrDefault(),
                            textBox14.Text.CheckIntOrDefault(), textBox15.Text.CheckIntOrDefault(), textBox16.Text.CheckIntOrDefault(), textBox17.Text.CheckIntOrDefault(),
                            textBox18.Text.CheckIntOrDefault(), textBox19.Text.CheckIntOrDefault(), textBox20.Text.CheckIntOrDefault(), textBox21.Text.CheckIntOrDefault(),
                            textBox22.Text.CheckIntOrDefault(), textBox23.Text.CheckIntOrDefault(), textBox24.Text.CheckIntOrDefault(), textBox25.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16,
                            textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25);
                    }
                    else
                    {
                        InputAndOutputDataToMatrix.HandleInput(Matrix.matrixTwo = new float[4, 4],
                            textBox10.Text.CheckIntOrDefault(), textBox11.Text.CheckIntOrDefault(), textBox12.Text.CheckIntOrDefault(), textBox13.Text.CheckIntOrDefault(),
                            textBox14.Text.CheckIntOrDefault(), textBox15.Text.CheckIntOrDefault(), textBox16.Text.CheckIntOrDefault(), textBox17.Text.CheckIntOrDefault(),
                            textBox18.Text.CheckIntOrDefault(), textBox19.Text.CheckIntOrDefault(), textBox20.Text.CheckIntOrDefault(), textBox21.Text.CheckIntOrDefault(),
                            textBox22.Text.CheckIntOrDefault(), textBox23.Text.CheckIntOrDefault(), textBox24.Text.CheckIntOrDefault(), textBox25.Text.CheckIntOrDefault());

                        UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                    }
                }
            }
        }

        private void MovePageResultCalculation()
        {
            if (InputField.Text != "")
            {
                Matrix.destinationMatrix = Matrix.MultiplicateNumberOnMatrix(Matrix.matrixOne, InputField.Text.CheckIntOrDefault());
                InputAndOutputDataToMatrix.OutputData(Matrix.destinationMatrix, OutputData);
            }

            Next.Text = "Главная";
            Navigation.MoveToPage(currentPage: OperationMatrix, nextPage: ResultCalculation);
            InputAndOutputDataToMatrix.OutputData(Matrix.destinationMatrix, OutputData);
        }
        private void MoveHomePage()
        {
            Next.Text = "Далее →";
            UserInterface.HideButton(Return);

            Navigation.MoveToPage(currentPage: ResultCalculation, nextPage: HomeWindow);
            UtilityTools.SetDefaultToggles(sizeTwoOnTwo, sizeThreeToThree, sizeFourToFour, inHandle, inAutomatic);
            UtilityTools.ResetColorForButton(CreateMatrix);
            UtilityTools.ResetColorForButton(CreateBothMatrix);
        }

        private void MoveToPreviousPage() 
        {
            if (InputDataToMatrixTwoOnTwo.Visible)
            {
                Navigation.MoveToPage(currentPage: InputDataToMatrixTwoOnTwo, nextPage: HomeWindow);
                UserInterface.HideButton(Return);
            }
            else if (InputDataToMatrixThreeOnThree.Visible)
                Navigation.MoveToPage(currentPage: InputDataToMatrixThreeOnThree, nextPage: HomeWindow);
            else if (InputDataToMatrixFourOnFour.Visible)
                Navigation.MoveToPage(currentPage: InputDataToMatrixFourOnFour, nextPage: HomeWindow);
            else if (OperationMatrix.Visible)
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
                    Navigation.MoveToPage(currentPage: OperationMatrix, nextPage: HomeWindow);
            } else if (ResultCalculation.Visible)
            {
                Next.Text = "Далее →";
                Navigation.MoveToPage(currentPage: ResultCalculation, nextPage: OperationMatrix);
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